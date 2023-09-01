/*
Name: Daniël De Jager
Date: 24/08/2023
Program: Name and mark sorting/adding
Description: Take names and marks, sorts, and permits one addition
*/

#include <iostream>
#include <time.h>
#include <iomanip>

using namespace std;

void displayList(string arrNames[], int arrMarks[], int counter) // Displays names and marks in a neat list
{
    cout << "\nList of students and their marks:" << endl;
    cout << "    " << setw(16) << left << "Names" << "Marks" << endl;

    for (int k = 0; k < counter; k++)
    {
        cout << setw(4) << left << (k + 1) << setw(16) << left << arrNames[k] << arrMarks[k] << endl;
    }
}

int main()
{
    string arrNames[15] = {"Peter Johnson", "Diane Drake", "John Mokoena", "Jacky Muller", "Greg Xaba", "Jane Peterson", "Wendy Westley", "Frank Mokaba", "Ann Shabalala", "Dean Smit"};
    int arrMarks[15];
    int counter = 0;
    string name; // New name to be added
    int mark; // New mark to be added
    int position; // Position of new name and mark
    int tempMark;
    string tempName;


    srand(time(0));

    for (int i = 0; i < 10; i++) // Generate and add 10 random marks 0 to 100
    {
        arrMarks[i] = (rand()%101);
        counter++;
    }

    displayList(arrNames, arrMarks, counter); // Display unsorted

    for (int i = 0; i < counter; i++) // Bubble sort
    {
        for (int j = 0; j < (counter-1-i); j++)
        {
            if (arrMarks[j] > arrMarks[j+1])
            {
                tempMark = arrMarks[j]; // Sort marks
                arrMarks[j] = arrMarks[j+1];
                arrMarks[j+1] = tempMark;
                tempName = arrNames[j]; // Sort names too
                arrNames[j] = arrNames[j+1];
                arrNames[j+1] = tempName;
            }
        }
    }

    displayList(arrNames, arrMarks, counter); // Display sorted


    cout << "\nEnter the new name: "; // Receive input for new name and mark and its position
    cin.ignore();
    getline(cin, name);
    cout << "Enter the mark for " << name << ": ";
    cin >> mark;
    cout << "Enter the position of the name and mark in the list: ";
    cin >> position;

    if (position >= 1 && position <= counter + 1) // Enters the new name and marks at the indicated position and moves the rest up
    {
        for (int i = counter; i >= position; i--) // First move all elements from position up
        {
            arrNames[i] = arrNames[i - 1];
            arrMarks[i] = arrMarks[i - 1];
        }

        arrNames[position - 1] = name; // Then add new name and mark to position
        arrMarks[position - 1] = mark;

        counter++;
    }
    else
    {
        cout << "Invalid position entered." << endl;
    }

    displayList(arrNames, arrMarks, counter); // Final display with added name and mark

    return 0;
}
