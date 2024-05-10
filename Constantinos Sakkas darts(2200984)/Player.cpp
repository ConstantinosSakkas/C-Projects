#include "PlayerH.h"//header for the program to access amd write our own classes
#include <cstdlib>
#include <ctime>//randomizer
#include <iostream>

// Player class 
Player::Player() :
    score(301),//start with 301
   accuracy(80), //  accuracy to 80%
    aiming(25),  //  aiming set to 25
    won(false),  // won variable
    throw_count(0),    // Initialize the throw count to 0
    wins(0),  // Initialize the number of wins to 0
    rounds(0)  // Initialize the number of rounds played to 0
{}
void Player::play_round() {//a round a is played determening who has won
    Aim();//aim variable is utolized in order to help the player aim 

    while (score > 0 && !won) {//if score is greater than 0 either ruturn true or false until one of the players reaches 0
        Play();// play function will begin the game and mimic each players turn
    }

    rounds++;// will be count of how many rounds have been played

    if (won) {//dipending on the score it will output the winner 
        wins++;//count who reached 0 first
        std::cout << " You won the round" << std::endl;//winner 
    }
    else {
        std::cout << "Looser" << std::endl;//looser
    }

    reset();//rests stats
}

// Reset the player's attributes
void Player::reset() {
    score = 301;  // rset the score to 301
    won = false;  // reset the "won" flag to false
    throw_count = 0;  // reset the throw count to 0
    rounds = 0; // reset the number of rounds played to 0
}



// Set a random aiming target
void Player::Aim() {
    int target = (rand() % 3 + 1) * 20; // generate a random number between 1 and 3 and multiply it by 20
    aiming = target; // set the aiming target to the generated value
}

// Perform the player's turn
void Player::Play() {
    int bullshits;

    do {
        ++throw_count; // adds throw
        AimmingAssist();// assist in aiming before each throw
        bullshits = (rand() % 100) < accuracy ? 25 : (rand() % 20) + 1; // generate a random number to determine if the player hits the bullseye

    } while (!Hit(bullshits) && throw_count < aiming); // continue throwing until the player hits the target or reaches the maximum throw count

    if (score == 0) {
        won = true; // If the player's score reaches 0, set the "won" flag to true
    }
}

// Assist in aiming based on the player's current score
void Player::AimmingAssist() {//aimmingasssit returns outcome of player to class Player 
if (aiming != 60 && aiming != 40 && aiming != 20 && aiming != 0) {
if (aiming != score) {
 if (aiming != score / 2) {
 if (aiming != score / 3) {
 if (aiming > 60) {
 aiming = 20; // If the aiming target is not one of the predefined values and not related to the player's score, set it to 20
  }
 else if (aiming > 40) {
 aiming = 40; // If the aiming target is greater than 40, set it to 40
  }
  else {
 aiming = 60; // If the aiming target is less than 40, set it to 60
  }
  }
 else {
  aiming /= 3; // If the aiming target is divisible by 3, set it to one-third of its value
 }
  }
  else {
  aiming /= 2; // If the aiming target is divisible by 2, set it to half of its value
 }
 }
 else {
  aiming = 0; // If the aiming target is equal to the player's score, set it to 0     
 }
 }
    // If the aiming target is equal to the player's score, set it to 0
}


// Check if the player hits the target and update the score 
bool Player::Hit(int bullshits) {//if both the score and bulls hit equal to zero 
    if (score - bullshits == 0) {
        score = 0; // If the player's score minus the bullshits is 0, set the score to 0 (player hits the target)
        return true; // if true ta successful hit
    }
    else if (score - bullshits > 1) {
        score -= bullshits;  // subtract bullshits and the score is reduced by 0 or negative
    }
    return false;//return false which is miss 
}

