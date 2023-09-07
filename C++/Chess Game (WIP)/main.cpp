/*
Add taken/not-taken value to each piece at start?
Keep track of taken?
Store legal moves in each piece?
Detect if other colour piece or same colour piece is on destination coords?
Store which piece is on a piece (if its taken or not) and then...
*/

#include <iostream>
#include <iomanip>

using namespace std;

struct Coordinates { // Two-dimensional structure for the array of 'a' through 'h' and 1 through 8 for chessboard coordinates
    char character; // The x coordinate
    int number; // The y coordinate
    string xyLoc; // Both together
    string taken; // Empty if not taken, filled by name of piece if taken
};

struct Pieces {
    char xLoc;
    int yLoc;
    string xyLoc;
    string colour;
    string name;
    string code;
};

void populateChessboard(Coordinates (*pBoard)[8]); // Populates and displays chessboard

void addPieces(Pieces *pPieces, Coordinates (*pBoard)[8]); // Add pieces to starting position

void movePiece(Pieces *pPieces, Coordinates (*pBoard)[8], char *turn);

void displayBoard(Coordinates (*pBoard)[8]);

int main() // Begin main ---------------------------------------------------------------------------------------
{
    Coordinates arrBoard[8][8];
    Coordinates (*pBoard)[8] = arrBoard; // Two-dimensional pointer to the board Coordinates struct array
    Pieces arrPieces[32]; // {8 white pawns, 8 black pawns, 8 unique white pieces, 8 unique black pieces}
    Pieces *pPieces = arrPieces;
    //Pieces arrPiecesW[16]; // {8 white pawns, 8 unique white pieces}
    //Pieces *pPiecesW = arrPiecesW;
    //Pieces arrPiecesW[16]; // {8 black pawns, 8 unique black pieces}
    //Pieces *pPiecesW = arrPiecesW;
    char turn = 'w';
    bool checkmate = false;
    bool stalemate = false;

    populateChessboard(pBoard);
    addPieces(arrPieces, arrBoard);

    if(checkmate != true && stalemate != true)
    {
        if(turn == 'w')
        {
            movePiece(pPieces, pBoard, &turn);
            displayBoard(pBoard);
        }
        else //(turn == 'b')
        {

        }
    }

    return 0;
} // End main ---------------------------------------------------------------------------------------------

void movePiece(Pieces *pPieces, Coordinates (*pBoard)[8], char *turn)
{
    string origin;
    string destin;

    cout << "\nEnter the coordinates of the piece to move: ";
    cin >> origin;
    cout << "Enter the coordinates to move to: ";
    cin >> destin;


}

void displayBoard(Coordinates (*pBoard)[8]) // Displays chessboard using new method (old method is in populateChessboard)
{
    cout << "\nCurrent chessboard: " << endl;
    for(int i = 0; i < 8; i++) {
        for(int j = 0; j < 8; j++) {
            if(pBoard[i][j].taken == "") // If not taken, cout coordinates, otherwise cout the piece on it
            {
                cout << setw(4) << left << pBoard[i][j].xyLoc;
            }
            else
            {
                cout << setw(4) << left << pBoard[i][j].taken;
            }
        }
        cout << endl;
    }
}

void populateChessboard(Coordinates (*pBoard)[8]) // Populates and displays chessboard using old method
{
    for(int i = 0; i < 8; i++) {
        for(int j = 0; j < 8; j++) {
            pBoard[i][j].character = 'a' + j;
            pBoard[i][j].number = 8 - i;
            pBoard[i][j].xyLoc += pBoard[i][j].character + to_string(pBoard[i][j].number);
            pBoard[i][j].taken = "";
            cout << pBoard[i][j].xyLoc << " ";
        }
        cout << endl;
    }
}

void addPieces(Pieces *pPieces, Coordinates (*pBoard)[8]) // Creates pieces and places them. Uses pPieces[] instead of *(pPieces + i) for indexing for clarity, but both can work.
{
    for(int i = 0; i < 8; i++) // Runs 8x for pawns
    {
        string colour = "white"; // White pieces
        pPieces[i].xLoc = 'a' + i;
        pPieces[i].yLoc = 2;
        pPieces[i].xyLoc += pPieces[i].xLoc + to_string(pPieces[i].yLoc);
        pPieces[i].colour = "white";
        pPieces[i].name = colour + " Pawn " + to_string(i+1);
        pPieces[i].code = "wP" + to_string(i+1); // wp1, wp2, etc.
        for(int m = 0; m < 8; m++) {
            for(int n = 0; n < 8; n++) {
                if (pBoard[m][n].xyLoc == pPieces[i].xyLoc)
                {
                    pBoard[m][n].taken = pPieces[i].code;
                }
            }
        }
        cout << "The " << pPieces[i].name << " is located at " << pPieces[i].xLoc << pPieces[i].yLoc << endl;
        colour = "black"; // Black pieces
        pPieces[i+8].xLoc = 'a' + i;
        pPieces[i+8].yLoc = 7;
        pPieces[i+8].xyLoc += pPieces[i+8].xLoc + to_string(pPieces[i+8].yLoc);
        pPieces[i+8].colour = "black";
        pPieces[i+8].name = colour + " Pawn " + to_string(i+1);
        pPieces[i+8].code = "bP" + to_string(i+1); // bp1, bp2, etc.
        cout << "The " << pPieces[i+8].name << " is located at " << pPieces[i+8].xLoc << pPieces[i+8].yLoc << endl;
        for(int m = 0; m < 8; m++) {
            for(int n = 0; n < 8; n++) {
                if (pBoard[m][n].xyLoc == pPieces[i+8].xyLoc)
                {
                    pBoard[m][n].taken = pPieces[i+8].code;
                }
            }
        }
    }

    string colour = "white";
    string colLet = "w";
    int black = 0;

    for(int i = 0; i < 8; i++) // White unique pieces
    {
        colour = "white";
        pPieces[i+16].xLoc = 'a' + i;
        pPieces[i+16].yLoc = 1;
        pPieces[i+16].xyLoc += pPieces[i+16].xLoc + to_string(pPieces[i+16].yLoc);
        pPieces[i+16].colour = colour;
    }
    for(int i = 0; i < 8; i++) // Black unique pieces
    {
        colour = "black";
        pPieces[i+24].xLoc = 'a' + i;
        pPieces[i+24].yLoc = 8;
        pPieces[i+24].xyLoc += pPieces[i+24].xLoc + to_string(pPieces[i+24].yLoc);
        pPieces[i+24].colour = colour;
    }
    colour = "white";
    colLet = "w";
    for(int i = 0; i < 2; i++)
    {
        pPieces[i+16+black].name = colour + " Castle 1";
        pPieces[i+16+black].code = colLet + "C1";
        cout << "The " << pPieces[i+16+black].name << " is located at " << pPieces[i+16+black].xLoc << pPieces[i+16+black].yLoc << endl;
        pPieces[i+17+black].name = colour + " kNight 1";
        pPieces[i+17+black].code = colLet + "N1";
        cout << "The " << pPieces[i+17+black].name << " is located at " << pPieces[i+17+black].xLoc << pPieces[i+17+black].yLoc << endl;
        pPieces[i+18+black].name = colour + " Bishop 1";
        pPieces[i+18+black].code = colLet + "B1";
        cout << "The " << pPieces[i+18+black].name << " is located at " << pPieces[i+18+black].xLoc << pPieces[i+18+black].yLoc << endl;
        pPieces[i+19+black].name = colour + " Queen";
        pPieces[i+19+black].code = colLet + "Q";
        cout << "The " << pPieces[i+19+black].name << " is located at " << pPieces[i+19+black].xLoc << pPieces[i+19+black].yLoc << endl;
        pPieces[i+20+black].name = colour + " King";
        pPieces[i+20+black].code = colLet + "K";
        cout << "The " << pPieces[i+20+black].name << " is located at " << pPieces[i+20+black].xLoc << pPieces[i+20+black].yLoc << endl;
        pPieces[i+21+black].name = colour + " Bishop 2";
        pPieces[i+21+black].code = colLet + "B2";
        cout << "The " << pPieces[i+21+black].name << " is located at " << pPieces[i+21+black].xLoc << pPieces[i+21+black].yLoc << endl;
        pPieces[i+22+black].name = colour + " kNight 2";
        pPieces[i+22+black].code = colLet + "N2";
        cout << "The " << pPieces[i+22+black].name << " is located at " << pPieces[i+22+black].xLoc << pPieces[i+22+black].yLoc << endl;
        pPieces[i+23+black].name = colour + " Castle 2";
        pPieces[i+23+black].code = colLet + "C2";
        cout << "The " << pPieces[i+23+black].name << " is located at " << pPieces[i+23+black].xLoc << pPieces[i+23+black].yLoc << endl;

        colour = "black";
        colLet = "b";
        black = 7; // 8 less 1 to compensate for i incrementing
    }
}

//void movePiece(int arrBoard[][], int location)
//{
//
//}
