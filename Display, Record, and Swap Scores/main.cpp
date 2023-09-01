/*
Author: Daniël De Jager 41669436
Program name: Test2_DeJager_41669436
Description: Project displaying, scoring, and swapping
*/

#include <iostream>
#include <iomanip>

using namespace std;

void displayProjects(string arrProjects[], int arrScores[]) // Function that displays a numbered list of project names and scores
{
    cout << "\nList of projects and scores" << endl;
    for(int k = 0; k < 6; k++)
    {
        cout << setw(3) << left << (k + 1) << setw(20) << left << arrProjects[k] << setw(4) << right << arrScores[k] << endl;
    }
}

int getAndValidateScore(string arrProjects[], string arrQuestions[], int i) // Function that receives input for scores for 5 questions for each project
{
    int score = 0;
    cout << arrQuestions[i] << endl;
    cout << "Enter score (0/1/2): ";
    cin >> score;
    while (score < 0 || score > 2)
    {
        cout << "Invalid score, try again" << endl;
        cout << "Enter score (0/1/2): ";
        cin.ignore();
        cin >> score;
    }
    return score;
}

int main()
{
    string arrProjects[6] = {"Sales System", "Bookings System", "Time Table", "Student Enrolments", "Marketing System", "Career System"};
    int arrScores[6] = {0, 0, 0, 0, 0, 0};
    string arrQuestions[5] = {"Can the project be executed?", "Does it meet all the requirements?", "Is the project user-friendly?", "Has a prototype been uploaded?", "Was it well-presented?"};
    bool exit = false;
    int score = 0;
    int projectScore = 0;
    int totalScore = 0;
    double averageScore = 0.0;
    int choice, project1, project2, tempScore;
    string tempProject;
    string tempChoice;
    bool passCheck = false;

    while(!exit) // Main menu loop
    {
        cout << "\n   Options" << endl;
        cout << "1. Display projects" << endl;
        cout << "2. Score projects" << endl;
        cout << "3. Swap projects" << endl;
        cout << "4. Exit" << endl;
        cout << "Your choice (1/2/3/4): ";
        cin >> tempChoice;

        while(passCheck == false) // Input validation for main menu choice
        {
            if(tempChoice == "1" || tempChoice == "2" || tempChoice == "3" || tempChoice == "4") // If one of approved choices then pass check
            {
                choice = stoi(tempChoice);
                passCheck = true;
            }
            else
            {
                cout << "\nWrong input. Try again." << endl;
                cout << "\n   Options" << endl;
                cout << "1. Display projects" << endl;
                cout << "2. Score projects" << endl;
                cout << "3. Swap projects" << endl;
                cout << "4. Exit" << endl;
                cout << "Your choice (1/2/3/4): ";
                cin >> tempChoice;
            }
        }

        passCheck = false; // Reset input validation

        switch(choice) // Switch for main menu options
        {
        case 1: // Display projects
            displayProjects(arrProjects, arrScores);
            break;
        case 2: // Score projects
            cout << "\nScore projects" << endl;
            for(int k = 0; k < 6; k++) // Loop per project (6)
            {
                projectScore = 0;
                cout << "\nName of project: " << arrProjects[k] << endl;
                for(int i = 0; i < 5; i++) // Loop per question (5)
                {
                    score = getAndValidateScore(arrProjects, arrQuestions, i);
                    projectScore += score;
                }
                cout << "Total score: " << projectScore << endl;
                arrScores[k] = projectScore;
                totalScore += projectScore;
            }
            averageScore = totalScore / 6.0; // Calculate average score of all projects
            cout << "\nAverage score: " << fixed << setprecision(1) << averageScore << endl;
            break;
        case 3: // Swap projects
            displayProjects(arrProjects, arrScores); // Displays list to swap
            cout << "\nEnter the number of the project to swap: ";
            cin >> project1;
            cout << "Enter the number of the project to be swapped with: ";
            cin >> project2;

            tempProject = arrProjects[(project1 - 1)]; // Temp storage of first project selected
            tempScore = arrScores[(project1 - 1)];
            arrProjects[(project1 - 1)] = arrProjects[(project2 - 1)]; // Puts second project selected into array index of first project
            arrScores[(project1 - 1)] = arrScores[(project2 - 1)];
            arrProjects[(project2 - 1)] = tempProject; // Puts temp storage of first project into array index of second projects
            arrScores[(project2 - 1)] = tempScore;

            displayProjects(arrProjects, arrScores); // Displays swapped list
            break;
        case 4: // Exit
            cout << "\nExiting program!" << endl;
            exit = true;
            break;
        default:
            cout << "\nIncorrect input. Try again." << endl;
            break;
        }
    }

    return 0;
}
