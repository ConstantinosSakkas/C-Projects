// a sample mini-project
// Mini-Project: Stations, an extension based on Trains Mini-Project 
// using a group of condition variables


#include <iostream>
#include <vector>
#include <thread>
#include <mutex>
#include <condition_variable>
#include <memory>
#include <fstream>
#include <sstream>
#include <atomic>
#include <windows.h>
#include <chrono>

// Function to hide the console cursor for cleaner simulation display
void hideCursor() {
    HANDLE consoleHandle = GetStdHandle(STD_OUTPUT_HANDLE); // Get the console handle
    CONSOLE_CURSOR_INFO info; // Console cursor information structure
    info.dwSize = 100; // The size of the cursor, from 1 to 100. The size is irrelevant when hiding the cursor
    info.bVisible = FALSE; // Set the cursor visibility to FALSE to hide it
    SetConsoleCursorInfo(consoleHandle, &info); // Apply the settings to the console
}

// ANSI color codes for terminal text coloring
const char* ANSI_RESET = "\033[0m";
const char* ANSI_RED = "\033[41m";
const char* ANSI_GREEN = "\033[42m";
const char* ANSI_BLUE = "\033[44m";
const char* ANSI_YELLOW = "\033[43m";

// RailwaySystem class definition
class RailwaySystem {
public:
    RailwaySystem(); // Constructor
    ~RailwaySystem(); // Destructor
    void startSimulation(); // Function to start the railway simulation

private:
    struct Segment { // Segment structure representing a piece of track
        std::mutex mutex; // Mutex for synchronization
        std::condition_variable cond; // Condition variable for segment occupancy
        bool occupied = false; // Flag indicating if the segment is occupied
    };

    void trainA(); // Function to simulate train A's movement
    void trainB(); // Function to simulate train B's movement
    void trainC(); // Function to simulate train C's movement
    void trainD(); // Function to simulate train D's movement
    void trainE(); // Function to simulate train E's movement

    void displayTracks(); // Function to display the current state of the tracks
    void logEvent(const std::string& event); // Function to log events to a file

    std::mutex displayMutex; // Mutex for synchronizing display output
    std::vector<std::unique_ptr<Segment>> segments; // Vector of track segments
    const int totalLength = 60; // Total length of the track
    const int segmentLength = 10; // Length of a single track segment excluding the station
    const int shortStationLength = 3; // Expanded station length
    int positionA, positionB, positionC, positionD, positionE; // Positions of trains A, B, C, D, E
    std::ofstream logFile; // File stream for logging
    std::atomic<bool> simulationactive; // Atomic used  to control the simulation loop

    // Stations Control Centre 
    struct SCCentre {
        std::atomic<bool> emergencystop; // Atomic used for emergency stop signal

        // Constructor
        SCCentre() : emergencystop(false) {}

        // monitor system to send emergency stop signals
        void monitorSystem() {
            while (true) {
                std::this_thread::sleep_for(std::chrono::seconds(25));

                // Send emergency stop signal
                emergencystop.store(true);
                std::cout << "Emergency stop signal sent to all trains." << std::endl;
            }
        }

        // check if emergency stop signal is active
        bool emergencyStopSignaled() {
            return emergencystop.load();
        }

        // reset emergency stop signal
        void resetstop() {
            emergencystop = false;
        }
    } scc; // SCC instance
};

// Constructor initializes the simulation
RailwaySystem::RailwaySystem() : positionA(31), positionB(33), positionC(32), positionD(34), positionE(36), simulationactive(true) {
    logFile.open("RailwaySystemLog.txt", std::ofstream::out | std::ofstream::app); // Open log file
    int colors[] = { 31, 33, 32, 34, 36 }; // ANSI color codes for visualization

    // Create and add segments to the vector
    for (int i = 0; i < 5; ++i) {
        auto segment = std::make_unique<Segment>();
        segments.push_back(std::move(segment));
    }
}

// Destructor closes the log file if it's open
RailwaySystem::~RailwaySystem() {
    if (logFile.is_open()) {
        logFile.close();
    }
}

// startSimulation starts the simulation by creating threads for trains and display
void RailwaySystem::startSimulation() {
    // Thread for displaying the tracks
    std::thread displaythread([&]() {
        while (simulationactive) {
            displayTracks();
            std::this_thread::sleep_for(std::chrono::milliseconds(400));
        }
        });

    // Thread for SCC monitoring system which watches trains possition and sends a emergency stop signal
    std::thread sccthread(&SCCentre::monitorSystem, &scc);

    // Threads for trains A, B, C, D, E
    std::thread threadA(&RailwaySystem::trainA, this);
    std::thread threadB(&RailwaySystem::trainB, this);
    std::thread threadC(&RailwaySystem::trainC, this);
    std::thread threadD(&RailwaySystem::trainD, this);
    std::thread threadE(&RailwaySystem::trainE, this);

    // Wait for train threads to complete
    threadA.join();
    threadB.join();
    threadC.join();
    threadD.join();
    threadE.join();


    // Stop the simulation and wait for the display thread to complete
    simulationactive = false;
    displaythread.join();
    sccthread.join();
}


void RailwaySystem::trainA() {
    // Simulates the movement of train A around the track
    std::string trainName = "Train A";

    while (true) { // Infinite loop to simulate continuous movement
        // Check for emergency stop signal
        if (scc.emergencystop.load()) {
            std::cout << "Train A received emergency stop signal." << std::endl;
            // Handle emergency stop 
            break;
        }

        // Calculate the current segment index based on train A's position
        int segmentindex = positionA / (segmentLength + shortStationLength);

        // Each station has 3 spaces, one is reserved for train B, the second for A and the third for passengers boarding 
        bool isStation = (positionA % (segmentLength + shortStationLength)) == 0;

        // If the train is at the start of a station, wait for the segment to be free and then occupy it
        if (isStation) {
            std::unique_lock<std::mutex> lock(segments[segmentindex]->mutex); // Lock the current segment's mutex
            segments[segmentindex]->cond.wait(lock, [this, segmentindex] { return !segments[segmentindex]->occupied; }); // Wait until the segment is not occupied
            segments[segmentindex]->occupied = true; // Occupy the segment
        }

        // Move the train forward by one unit
        positionA = (positionA + 1) % totalLength;
        std::this_thread::sleep_for(std::chrono::seconds(1)); // Simulate time taken to move

        // Check if the train has reached the end of a segment
        bool segmentend = (positionA % (segmentLength + shortStationLength)) == 0;
        if (segmentend) {
            // Free the current segment and notify other trains
            std::lock_guard<std::mutex> lock(segments[segmentindex]->mutex); // Lock the current segment's mutex
            segments[segmentindex]->occupied = false; // Mark the current segment as not occupied
            segments[segmentindex]->cond.notify_one(); // Notify other trains waiting for this segment
        }

        // Log the completion of one iteration for train A
        logEvent("Train A has finished one iteration of its journey.");
    }
}


void RailwaySystem::trainB() {
    // Simulates the movement of train B around the track
    std::string trainName = "Train B";

    while (true) { // Infinite loop to simulate continuous movement
        // Check for emergency stop signal
        if (scc.emergencystop.load()) {
            std::cout << "Train B received emergency stop signal." << std::endl;
            // Handle emergency stop 
            break;
        }

        // Calculate the current segment index based on train B's position
        int segmentindex = positionB / (segmentLength + shortStationLength);

        // Each station has 3 spaces, one is reserved for train B, the second for A and the third for pasenegers boarding 
        bool isStation = (positionB % (segmentLength + shortStationLength)) == 0;

        // If the train is at a station, wait for the previous segment to be free and then occupy it
        if (isStation) {
            int previndex = segmentindex - 1; // Calculate the index of the previous segment
            std::unique_lock<std::mutex> lock(segments[previndex]->mutex); // Lock the previous segment's mutex
            segments[previndex]->cond.wait(lock, [this, previndex] { return !segments[previndex]->occupied; }); // Wait until the segment is not occupied
            segments[previndex]->occupied = true; // Occupy the segment
        }

        // Move the train backward by one unit, handling wrap-around at the start of the track
        positionB = (positionB - 1) % totalLength;
        if (positionB < 0) positionB = totalLength - 1;
        std::this_thread::sleep_for(std::chrono::seconds(1)); // Simulate time taken to move

        // Check if the train has reached the end of a segment
        bool segmentend = (positionB % (segmentLength + shortStationLength)) == 0;
        if (segmentend) {
            // Free the current segment and notify other trains
            std::lock_guard<std::mutex> lock(segments[segmentindex]->mutex); // Lock the current segment's mutex
            segments[segmentindex]->occupied = false; // Mark the current segment as not occupied
            segments[segmentindex]->cond.notify_one(); // Notify other trains waiting for this segment
        }

        // Log the completion of the journey 
        logEvent("Train B has finished its journey.");
    }
}

void RailwaySystem::trainC() {
    // Simulates the movement of train C around the track
    std::string trainName = "Train C";

    while (true) { // Infinite loop to simulate continuous movement
        // Check for emergency stop signal
        if (scc.emergencystop.load()) {
            std::cout << "Train C received emergency stop signal." << std::endl;
            // Handle emergency stop 
            break;
        }

        // Calculate the current segment index based on train C's position
        int segmentindex = positionC / (segmentLength + shortStationLength);

        // Each station has 3 spaces, one is reserved for train B, the second for A and the third for pasenegers boarding 
        bool isStation = (positionC % (segmentLength + shortStationLength)) == 0;

        // If the train is at a station, wait for the previous segment to be free and then occupy it
        if (isStation) {
            int previndex = segmentindex - 1; // Calculate the index of the previous segment
            std::unique_lock<std::mutex> lock(segments[previndex]->mutex); // Lock the previous segment's mutex
            segments[previndex]->occupied = true; // Occupy the segment
        }

        // Move the train backward by one unit, handling wrap-around at the start of the track
        positionC = (positionC - 1) % totalLength;
        if (positionC < 0) positionC = totalLength - 1;
        std::this_thread::sleep_for(std::chrono::seconds(1)); // Simulate time taken to move

        // Check if the train has reached the end of a segment
        bool segmentend = (positionC % (segmentLength + shortStationLength)) == 0;
        if (segmentend) {
            // Free the current segment and notify other trains
            std::lock_guard<std::mutex> lock(segments[segmentindex]->mutex); // Lock the current segment's mutex
            segments[segmentindex]->occupied = false; // Mark the current segment as not occupied
            segments[segmentindex]->cond.notify_one(); // Notify other trains waiting for this segment
        }

        // Log the completion of the journey
        logEvent("Train C has finished its journey.");
    }
}

void RailwaySystem::trainD() {
    // Simulates the movement of train D around the track
    std::string trainName = "Train D";

    while (true) { // Infinite loop which mimics non stop  movement
        // Check for emergency stop signal
        if (scc.emergencystop.load()) {
            std::cout << "Train D received emergency stop signal." << std::endl;
            // Handle emergency stop 
            break;
        }

        // Calculate the current segment index based on train D's position
        int segmentindex = positionD / (segmentLength + shortStationLength);

        // Each station has 3 spaces, one is reserved for train B, the second for A and the third for pasenegers boarding 
        bool isStation = (positionD % (segmentLength + shortStationLength)) == 0;

        // If the train is at a station, wait for the previous segment to be free and then occupy it
        if (isStation) {
            int previndex = segmentindex - 1; // Calculate the index of the previous segment
            std::unique_lock<std::mutex> lock(segments[previndex]->mutex); // Lock the previous segment's mutex
            segments[previndex]->occupied = true; // Occupy the segment
        }

        // Move the train backward by one unit, handling wrap-around at the start of the track
        positionD = (positionD - 1) % totalLength;
        if (positionD < 0) positionD = totalLength - 1;
        std::this_thread::sleep_for(std::chrono::seconds(1)); // Simulate time taken to move

        // Check if the train has reached the end of a segment
        bool segmentend = (positionD % (segmentLength + shortStationLength)) == 0;
        if (segmentend) {
            // Free the current segment and notify other trains
            std::lock_guard<std::mutex> lock(segments[segmentindex]->mutex); // Lock the current segment's mutex
            segments[segmentindex]->occupied = false; // Mark the current segment as not occupied
            segments[segmentindex]->cond.notify_one(); // Notify other trains waiting for this segment
        }

        // Log the completion of the journey 
        logEvent("Train D has finished its journey.");
    }
}

void RailwaySystem::trainE() {
    // Simulates the movement of train E around the track
    std::string trainName = "Train E";

    while (true) { // Infinite loop to simulate continuous movement
        // Check for emergency stop signal
        if (scc.emergencystop.load()) {
            std::cout << "Train E received emergency stop signal." << std::endl;
            // Handle emergency stop 
            break;
        }

        // Calculate the current segment index based on train E's position
        int segmentindex = positionE / (segmentLength + shortStationLength);

        // Each station has 3 spaces, one is reserved for train B, the second for A and the third for pasenegers boarding 
        bool isStation = (positionE % (segmentLength + shortStationLength)) == 0;

        // If the train is at a station, wait for the previous segment to be free and then occupy it
        if (isStation) {
            int previndex = segmentindex - 1; // Calculate the index of the previous segment
            std::unique_lock<std::mutex> lock(segments[previndex]->mutex); // Lock the previous segment's mutex
            segments[previndex]->cond.wait(lock, [this, previndex] { return !segments[previndex]->occupied; }); // Wait until the segment is not occupied
            segments[previndex]->occupied = true; // Occupy the segment
        }

        // Move the train backward by one unit, handling wrap-around at the start of the track
        positionE = (positionE - 1) % totalLength;
        if (positionE < 0) positionE = totalLength - 1;
        std::this_thread::sleep_for(std::chrono::seconds(1)); // Simulate time taken to move

        // Check if the train has reached the end of a segment
        bool segmentend = (positionE % (segmentLength + shortStationLength)) == 0;
        if (segmentend) {
            // Free the current segment and notify other trains
            std::lock_guard<std::mutex> lock(segments[segmentindex]->mutex); // Lock the current segment's mutex
            segments[segmentindex]->cond.notify_one(); // notify other trains waiting for this segment
        }

        // Log the completion of the journey 
        logEvent("Train E has finished its journey.");
    }
}

void RailwaySystem::displayTracks() {
    std::lock_guard<std::mutex> lock(displayMutex); // Lock the display mutex 

    // Clear the console before printing the updated track layout
    system("cls");

    // train positions for A,B,C,D,E
    std::stringstream ss;
    ss << "Railway Track:\n";
    for (int i = 0; i < totalLength; ++i) {
        if (i == positionA) {
            ss << ANSI_RED << "A"; // Train A 
        }
        else if (i == positionB) {
            ss << ANSI_GREEN << "B"; // Train B 
        }
        else if (i == positionC) {
            ss << ANSI_BLUE << "C"; // Train C 
        }
        else if (i == positionD) {
            ss << ANSI_YELLOW << "D"; // Train D 
        }
        else if (i == positionE) {
            ss << ANSI_YELLOW << "E"; // Train E 
        }
        else {
            ss << " "; // Empty track for movement
        }
    }
    ss << ANSI_RESET; // Reset color after
    std::cout << ss.str() << std::endl;

    // Print status for each segment whether they are free or occupied 
    std::cout << "Platform Status:\n";
    for (size_t i = 0; i < segments.size(); ++i) {
        std::lock_guard<std::mutex> segmentLock(segments[i]->mutex); // Lock each segment mutex
        std::cout << "Segment " << i + 1 << ": " << (segments[i]->occupied ? "Occupied" : "Free") << std::endl;
    }
  
}


// logEvent function whihc  logs events to a file
void RailwaySystem::logEvent(const std::string& event) {
    // Lock the file stream to ensure thread safety
    std::lock_guard<std::mutex> lock(displayMutex);
    // Write the event to the log file
    logFile << event << std::endl;
}



int main() {
    RailwaySystem railwaySystem; // Create a RailwaySystem object
    hideCursor(); // Hide the console cursor for cleaner output
    railwaySystem.startSimulation(); // Start the simulation
    return 0;
    exit;
}

