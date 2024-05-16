// Matrix Multiplication using different Memory Management Model


#include <CL/sycl.hpp>
#include <iostream>
#include <algorithm>
#include <chrono>

using namespace sycl;
constexpr size_t M = 2000;
constexpr size_t N = 1000;
constexpr size_t P = 1500;
constexpr size_t TILE_SIZE = 20; // Set an appropriate tile size

// Kernel function for tiled matrix multiplication
void tiled_matrix_multiplication(const float* A, const float* B, float* C, queue& q) {
    // Create buffers for matrices A, B, and C
    buffer<float, 2> bufA((float*)A, range<2>(N, N)); // buffer for matrix A
    buffer<float, 2> bufB((float*)B, range<2>(N, N)); // buffer for matrix B
    buffer<float, 2> bufC((float*)C, range<2>(N, N)); // buffer for matrix C

    // Submit a SYCL command group for execution
    q.submit([&](handler& h) {
        // Obtain accessors for matrices A, B, and C
        auto accA = bufA.get_access<access::mode::read>(h); // accessor for reading from buffer A
        auto accB = bufB.get_access<access::mode::read>(h); // accessor for reading from buffer B
        auto accC = bufC.get_access<access::mode::write>(h); // accessor for writing to buffer C

        // Define local memory accessors for tiles of matrices A and B
        accessor<float, 2, access::mode::read_write, access::target::local> tileA(range<2>(TILE_SIZE, TILE_SIZE), h); // local memory accessor for tile of matrix A
        accessor<float, 2, access::mode::read_write, access::target::local> tileB(range<2>(TILE_SIZE, TILE_SIZE), h); // local memory accessor for tile of matrix B

        // Define the parallel computation kernel
        h.parallel_for<class TiledMatrixMulKernel>(
            nd_range<2>(range<2>(N, N), range<2>(TILE_SIZE, TILE_SIZE)),
            [=](nd_item<2> item) {
                // Get global and local IDs
                const int globalRow = item.get_global_id(0); // global row ID
                const int globalCol = item.get_global_id(1); // global column ID
                const int localRow = item.get_local_id(0); // local row ID
                const int localCol = item.get_local_id(1); // local column ID

                // temporary variable to store the result 
                float temp = 0.0f;

                // Loop over tiles of matrices A and B
                for (int t = 0; t < N; t += TILE_SIZE) {
                    // Load tiles into local memory
                    tileA[localRow][localCol] = accA[globalRow][t + localCol];
                    tileB[localRow][localCol] = accB[t + localRow][globalCol];
                    item.barrier(access::fence_space::local_space); // Synchronize to ensure all work-items have finished loading tiles

                    // Perform tile multiplication
                    for (int k = 0; k < TILE_SIZE; ++k) {
                        temp += tileA[localRow][k] * tileB[k][localCol];
                    }

                    // Synchronize again before moving to the next tile
                    item.barrier(access::fence_space::local_space);
                }

                // Write the result back to global memory
                accC[globalRow][globalCol] = temp;
            });
        });
}

// Kernel function for matrix multiplication
void matrix_multiplication(const float* A, const float* B, float* C, size_t M, size_t N, size_t P, queue& q) {
    buffer<float, 2> bufA((float*)A, range<2>(M, N)); // buffer for matrix A
    buffer<float, 2> bufB((float*)B, range<2>(N, P)); // buffer for matrix B
    buffer<float, 2> bufC((float*)C, range<2>(M, P)); // buffer for matrix C

    q.submit([&](handler& h) {
        // obtain accessors for reading from buffers
        auto accA = bufA.get_access<access::mode::read>(h);
        auto accB = bufB.get_access<access::mode::read>(h);
        auto accC = bufC.get_access<access::mode::write>(h);

        // define the parallel computation kernel
        h.parallel_for<class MatrixMulKernel>(range<2>(M, P), [=](id<2> idx) {
            const int i = idx[0]; // row index
            const int j = idx[1]; // column index
            float temp = 0.0f;
            // perform matrix multiplication
            for (int k = 0; k < N; ++k) {
                temp += accA[i][k] * accB[k][j];
            }
            accC[i][j] = temp; // store the result in C
            });
        });
}

// kernel function for matrix multiplication using explicit USM
void e_usm_matrix_multiplication(const float* A, const float* B, float* C, size_t M, size_t N, size_t P, queue& q) {
    // allocate memory on the device
    float* A_dev = malloc_device<float>(M * N, q);
    float* B_dev = malloc_device<float>(N * P, q);
    float* C_dev = malloc_device<float>(M * P, q);

    // copy data from host to device
    q.memcpy(A_dev, A, sizeof(float) * M * N);
    q.memcpy(B_dev, B, sizeof(float) * N * P);

    // perform the matrix multiplication on the device
    q.submit([&](handler& h) {
        h.parallel_for<class MatrixMulKernelUSMe>(range<2>(M, P), [=](id<2> idx) {
            const int i = idx[0];
            const int j = idx[1];
            float temp = 0.0f;
            // Perform matrix multiplication
            for (int k = 0; k < N; ++k) {
                temp += A_dev[i * N + k] * B_dev[k * P + j];
            }
            C_dev[i * P + j] = temp;
            });
        });

    // copy the result back to host memory
    q.memcpy(C, C_dev, sizeof(float) * M * P).wait();

    // Free device memory
    free(A_dev, q);
    free(B_dev, q);
    free(C_dev, q);
}

// kernel function for matrix multiplication using subgroup
void subgroup_matrix_multiplication(const float* A, const float* B, float* C, size_t M, size_t N, size_t P, queue& q) {
    // create buffers for matrices A, B,C
    buffer<float, 2> bufA((float*)A, range<2>(M, N)); // buffer for matrix A
    buffer<float, 2> bufB((float*)B, range<2>(N, P)); // buffer for matrix B
    buffer<float, 2> bufC((float*)C, range<2>(M, P)); // buffer for matrix C

    // submit a SYCL command group for execution
    q.submit([&](handler& h) {
        // Obtain accessors for matrices A, B, and C
        auto accA = bufA.get_access<access::mode::read>(h); // accessor for reading from buffer A
        auto accB = bufB.get_access<access::mode::read>(h); // accessor for reading from buffer B
        auto accC = bufC.get_access<access::mode::write>(h); //accessor for writing to buffer C

        // define the parallel computation kernel
        h.parallel_for<class SubgroupMatrixMulKernel>(range<2>(M, P), [=](id<2> idx) {
            const int i = idx[0]; // row index
            const int j = idx[1]; // column index
            float temp = 0.0f;
            // aterate over rows of A and columns of B
            for (int k = 0; k < N; ++k) {
                temp += accA[i][k] * accB[k][j];
            }
            accC[i][j] = temp; // store the result in C
            });
        });
}

int main() {
    // allocate memory for matrices A, B, and C
    float* A = new float[M * N];
    float* B = new float[N * P];
    float* C_buffer = new float[M * P];
    float* C_usm_explicit = new float[M * P];
    float* C_subgroup = new float[M * P];

    // initialize matrices A and B
    for (int i = 0; i < M * N; ++i) {
        A[i] = i % 10;
    }
    for (int i = 0; i < N * P; ++i) {
        B[i] = (i % 10) + 1;
    }

    queue q(gpu_selector{}); // select GPU device or CPU for computetion

    // measure performance for matrix multiplication using buffers/accessors
    auto start_buffer = std::chrono::high_resolution_clock::now();
    matrix_multiplication(A, B, C_buffer, M, N, P, q);
    q.wait();
    auto stop_buffer = std::chrono::high_resolution_clock::now();
    auto duration_buffer = std::chrono::duration_cast<std::chrono::milliseconds>(stop_buffer - start_buffer);
    std::cout << "Buffer/Accessor: " << duration_buffer.count() << " milliseconds\n";

    // measure performance for matrix multiplication using explicit USM
    auto start_usm_explicit = std::chrono::high_resolution_clock::now();
    e_usm_matrix_multiplication(A, B, C_usm_explicit, M, N, P, q);
    q.wait();
    auto stop_usm_explicit = std::chrono::high_resolution_clock::now();
    auto duration_usm_explicit = std::chrono::duration_cast<std::chrono::milliseconds>(stop_usm_explicit - start_usm_explicit);
    std::cout << "Explicit USM: " << duration_usm_explicit.count() << " milliseconds\n";

    // measure performance for matrix multiplication using subgroup
    auto start_subgroup = std::chrono::high_resolution_clock::now();
    subgroup_matrix_multiplication(A, B, C_subgroup, M, N, P, q);
    q.wait();
    auto stop_subgroup = std::chrono::high_resolution_clock::now();
    auto duration_subgroup = std::chrono::duration_cast<std::chrono::milliseconds>(stop_subgroup - start_subgroup);
    std::cout << "Subgroup: " << duration_subgroup.count() << " milliseconds\n";

    // free allocated memory for smoother data proccesing 
    delete[] A;
    delete[] B;
    delete[] C_buffer;
    delete[] C_usm_explicit;
    delete[] C_subgroup;

    return 0;
}
