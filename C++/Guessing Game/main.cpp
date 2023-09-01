/*
Name: Daniël De Jager
Date: 24/08/2023
Program: Guess the Number
Description: Game for player to guess number between 0 and 10
*/

#include <iostream>
#include <time.h>

using namespace std;

struct Player
{
    string name;
    int score;
};

int generateRandomNumber() // Generates random number
{
    int number = (rand()%10 + 1);
    return number;
}

void playGame(Player player1) // Only receives the structure for input as the random number must be generated each loop. Receiving it as inputn from main wouldn't make sense and only complicate the code unnecessarily.
{
    int guess;
    int number;
    int attempts = 0;
    string attemptSiPl;
    char play = 'y';
    bool correct = false;

    do{ // Do loop simplifies code while player wants to play
        cout << "\nWelcome, " << player1.name << "! Let's play the Guess the Number game." << endl;
        cout << "I'm thinking of a number between 1 and 10. Guess the number!"<< endl;

        // Sets all numbers and values to correct position for game start
        number = generateRandomNumber();
        attempts = 0;
        player1.score = 100;
        guess = 11;
        correct = false;

        while (!correct) // Guess the number loop
        {
            cout << "\nEnter your guess: ";
            cin >> guess;

            if (guess < number)
            {
                cout << "Too low! Try again." << endl;
                attempts++;
                player1.score -= 10;
            }
            else if (guess > number)
            {
                cout << "Too high! Try again." << endl;
                attempts++;
                player1.score -= 10;
            }
            else if (guess = number)
            {
                correct = true;
            }
            else
            {
                cout << "Invalid input! Try again." << endl;
            }
        }

        if (attempts == 1) // Determines if singular attempt or plural attempts
        {
            attemptSiPl = " attempt.";
        }
        else
        {
            attemptSiPl = " attempts.";
        }

        cout << "Congratulations, " << player1.name << "! You guessed the number " << number << " in " << attempts << attemptSiPl << endl; // Results output
        cout << "\nThank you for playing, Peter! Your final score: " << player1.score << endl;

        cout << "\nDo you want to play again? (y/n): ";
        cin >> play;

    } while(tolower(play) == 'y');
}

int main()
{
    Player player1;
    srand(time(0));

    // Assign initial values
    cout << "Enter your name: ";
    getline(cin, player1.name);
    player1.score = 100;

    playGame(player1); // Play the game. See note next to the function for why random number isn't given/received here

    return 0;
}
