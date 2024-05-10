#include "PlayerH.h"  // Include the Player header file
#include <iostream>



int main() {
    
    Player Joe, Sid;  // Create Player for Joe and Sid

   //enter user inputs their desired numbers 
    int simulations;
    std::cout << "Enter the number of simulations: ";
    std::cin >> simulations;

    int Joe_accuracy, Sid_accuracy;
    std::cout << "Enter Joes accuracy (0-100): ";
    std::cin >> Joe_accuracy;

    std::cout << "Enter Joes accuracy (0-100): ";
    std::cin >> Sid_accuracy;

    int starting_player;
    std::cout << "Enter the starting player (1 for Joe, 2 for Sid): ";
    std::cin >> starting_player;

    // Variables to track the total number of turns and wins for each player
    int Joetotalturns = 0;
    int Sidtotalturns = 0;
    int Joetotalwins = 0;
    int Sidtotalwins = 0;

    for (int i = 0; i < simulations; ++i) {
        Joe.reset();  // Reset Joe's score and other game statistics
        Sid.reset();  // Reset Sid's score and other game statistics

        // Set accuracy percentages for each player
        Joe.Accuracy(Joe_accuracy);
        Sid.Accuracy(Sid_accuracy);

        // Determine the starting player
        Player* current_player;
        Player* other_player;

        if (starting_player == 1) {
            current_player = &Joe;  // Joe starts the game
            other_player = &Sid;
        }
        else {
            current_player = &Sid;  // Sid starts the game
            other_player = &Joe;
        }

        // Game loop
        while (!current_player->hasWon() && !other_player->hasWon()) {
            current_player->play_round();  // Current player takes a turn
            std::swap(current_player, other_player);  // Swap the players for the next turn
        }

        // Update total turns and wins for each player
        Joetotalturns += Joe.getRounds();
        Sidtotalturns += Sid.getRounds();

        if (Joe.hasWon()) {
            ++Joetotalwins;  // Joe won the game
        }
        else {
            ++Sidtotalwins;  // Sid won the game
        }
    }


    // Calculate average turns and success rate
    double Joesuccessrate = (Joetotalwins) / simulations * 100.0;
    double Sidsuccessrate = (Sidtotalwins) / simulations * 100.0;

    // Print the results
    std::cout << "Joe success rate: " << Joesuccessrate << "%" << std::endl;
    std::cout << "Sid success rate: " << Sidsuccessrate << "%" << std::endl;

    return 0;
}
