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
    string taken; // Empty if not taken, filled by name of piece if taken
};

struct Pieces {
    char xLoc;
    int yLoc;
    string colour;
    string name;
    string code;
};

void populateChessboard(Coordinates (*pBoard)[8]); // Populates and displays chessboard

void addPieces(Pieces *pPieces); // Add pieces to starting position

void movePiece(Pieces *pPieces, Coordinates (*pBoard)[8], char *turn);

void displayBoard(Coordinates (*pBoard)[8]);

int main()
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
    addPieces(arrPieces);

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
}

void movePiece(Pieces *pPieces, Coordinates (*pBoard)[8], char *turn)
{
    string origin;
    string destin;

    cout << "\nEnter the coordinates of the piece to move: ";
    cin >> origin;
    cout << "Enter the coordinates to move to: ";
    cin >> destin;


}

void displayBoard(Coordinates (*pBoard)[8])
{
    cout << "\nCurrent chessboard: " << endl;
    string tempCoord;
    for(int i = 0; i < 8; i++) {
        for(int j = 0; j < 8; j++) {
            tempCoord = pBoard[i][j].character + to_string(pBoard[i][j].number);
            cout << setw(4) << left << tempCoord;
        }
        cout << endl;
    }
}

void populateChessboard(Coordinates (*pBoard)[8]) // Populates and displays chessboard
{
    for(int i = 0; i < 8; i++) {
        for(int j = 0; j < 8; j++) {
            pBoard[i][j].character = 'a' + j;
            pBoard[i][j].number = 8 - i;
            cout << pBoard[i][j].character << pBoard[i][j].number << " ";
        }
        cout << endl;
    }
}

void addPieces(Pieces *pPieces)
{
    for(int i = 0; i < 8; i++) // Runs 8x for pawns
    {
        string colour = "white"; // White pieces
        pPieces[i].xLoc = 'a' + i;
        pPieces[i].yLoc = 2;
        pPieces[i].colour = "white";
        pPieces[i].name = colour + " pawn " + to_string(i+1);
        cout << "The " << pPieces[i].name << " is located at " << pPieces[i].xLoc << pPieces[i].yLoc << endl;
        colour = "black"; // Black pieces
        pPieces[i+8].xLoc = 'a' + i;
        pPieces[i+8].yLoc = 7;
        pPieces[i+8].colour = "black";
        pPieces[i+8].name = colour + " pawn " + to_string(i+1);
        cout << "The " << pPieces[i+8].name << " is located at " << pPieces[i+8].xLoc << pPieces[i+8].yLoc << endl;
    }

    string colour = "white";
    int black = 0;

    for(int i = 0; i < 8; i++) // White unique pieces
    {
        colour = "white";
        pPieces[i+16].xLoc = 'a' + i;
        pPieces[i+16].yLoc = 1;
        pPieces[i+16].colour = colour;
    }
    for(int i = 0; i < 8; i++) // Black unique pieces
    {
        colour = "black";
        pPieces[i+24].xLoc = 'a' + i;
        pPieces[i+24].yLoc = 8;
        pPieces[i+24].colour = colour;
    }
    colour = "white";
    for(int i = 0; i < 2; i++)
    {
        pPieces[i+16+black].name = colour + " castle 1";
        cout << "The " << pPieces[i+16+black].name << " is located at " << pPieces[i+16+black].xLoc << pPieces[i+16+black].yLoc << endl;
        pPieces[i+17+black].name = colour + " knight 1";
        cout << "The " << pPieces[i+17+black].name << " is located at " << pPieces[i+17+black].xLoc << pPieces[i+17+black].yLoc << endl;
        pPieces[i+18+black].name = colour + " rook 1";
        cout << "The " << pPieces[i+18+black].name << " is located at " << pPieces[i+18+black].xLoc << pPieces[i+18+black].yLoc << endl;
        pPieces[i+19+black].name = colour + " queen";
        cout << "The " << pPieces[i+19+black].name << " is located at " << pPieces[i+19+black].xLoc << pPieces[i+19+black].yLoc << endl;
        pPieces[i+20+black].name = colour + " king";
        cout << "The " << pPieces[i+20+black].name << " is located at " << pPieces[i+20+black].xLoc << pPieces[i+20+black].yLoc << endl;
        pPieces[i+21+black].name = colour + " rook 2";
        cout << "The " << pPieces[i+21+black].name << " is located at " << pPieces[i+21+black].xLoc << pPieces[i+21+black].yLoc << endl;
        pPieces[i+22+black].name = colour + " knight 2";
        cout << "The " << pPieces[i+22+black].name << " is located at " << pPieces[i+22+black].xLoc << pPieces[i+22+black].yLoc << endl;
        pPieces[i+23+black].name = colour + " castle 2";
        cout << "The " << pPieces[i+23+black].name << " is located at " << pPieces[i+23+black].xLoc << pPieces[i+23+black].yLoc << endl;

        colour = "black";
        black = 7; // 8 less 1 to compensate for i incrementing
    }
}

//void movePiece(int arrBoard[][], int location)
//{
//
//}
