/*
Daniël De Jager 41669436
Practical 4.2
Process and display online orders during past month for grocery store
*/

#include <iostream>
#include <iomanip>
#include <time.h>

using namespace std;

void displayOrders(int arrOrders[4][7]) // Function nicely displays orders for the month
{
    cout << setw(25) << right << "Orders for one month" << endl;
    cout << "Days:   ";
    for (int i = 0; i < 7; i++) // Loop through days
    {
        cout << setw(3) << right << (i+1);
    }
    cout << endl;

    for (int i = 0; i < 4; i++) // Loop through weeks, then all days for week
    {
        cout << "Week " << (i+1) << ": ";
        for (int j = 0; j < 7; j++)
        {
            cout << setw(3) << right << arrOrders[i][j];
        }
        cout << endl;
    }
}

int calcWeekOrders(int arrOrders[4][7], int week) // Function to display a week's daily order and return the total
{
    int totalOrders = 0;

    cout << "Orders for week " << week << endl;
    for (int i = 0; i < 7; i++) // Loop through days
    {
        cout << "Day " << (i+1) << ": " << setw(3) << right << arrOrders[(week-1)][i] << endl;
        totalOrders += arrOrders[(week-1)][i];
    }

    return totalOrders;
}

int main()
{
    int arrOrders[4][7]; // Initialize array with 4 weeks and 7 days
    int week;
    int totalOrders;

    srand(time(0));

    for (int i = 0; i < 4; i++) // Assign random number between 0 and 99 to each
    {
        for (int j = 0; j < 7; j++)
        {
            arrOrders[i][j] = (rand() % 100);
        }
    }

    displayOrders(arrOrders); // Call display orders function

    cout << "\nEnter the number of the week (1/2/3/4): "; // Asks for week number and runs that into the calc function below
    cin >> week;

    totalOrders = calcWeekOrders(arrOrders, week);

    cout << "\nTotal number of orders for week " << week << ": " << totalOrders << endl; // Total of the week chosen

    return 0;
}
