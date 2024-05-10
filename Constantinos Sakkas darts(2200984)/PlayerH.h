#ifndef PLAYERH_H
#define PLAYERH_H

class Player {
private:
    int score;//player's score
    int accuracy; //bull accuracy percentage
    int aiming;// aiming to the target
    bool won;//who wins dipending on the outcome
    int throw_count; //number of throws made
    int wins;// number of wins
    int rounds;// number of rounds played

public:
    Player(); // constructor
    void reset();// reset player's stats
    void play_round();//plays a round
    void Aim();// set aiming target
    void Play(); // play the game
    void AimmingAssist();// assist in aiming
    bool Hit(int bullshits);// check if hits target and update score
    bool throw_double(int d);// check if player hits double d

    // Getter methods
    int getScore() const { return score; }//value score is returned
    int getRounds() const { return rounds; }//value rounds is returned
    bool hasWon() const { return won; }//value won is returned

    // Setter method
    void Accuracy(int accuracy) { accuracy = accuracy; }//associated with joe and Sid accuracy 
};

#endif //end 
