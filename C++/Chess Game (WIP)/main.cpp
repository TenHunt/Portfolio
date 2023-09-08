/*
To-do:
- (Should be easy) Allowing selecting piece code instead of the coords its on to move it
- Store legal moves in each piece. Check for legal moves algorithm.
- Implement castling.
- Check for stalemate.
- Possibly add validation to prevent one piece from being in two locations at once? Not really needed if code is 100%.
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

struct Pieces { // Struct for each piece
    char xLoc; // The x coordinate
    int yLoc; // The y coordinate
    string xyLoc; // Both together
    string colour; // white or black
    string name; // Pawn 1, Castle 2, Queen, etc.
    string code; // bP1, wC2, bQ, etc.
};

void populateChessboard(Coordinates (*pBoard)[8]); // Populates and displays chessboard

void addPieces(Pieces *pPieces, Coordinates (*pBoard)[8]); // Creates pieces and places them. Uses pPieces[] instead of *(pPieces + i) for indexing for clarity, but both can work.

void movePiece(Pieces *pPieces, Coordinates (*pBoard)[8], char *turn); // Big function that validates input, manages moving and taking

void displayBoard(Coordinates (*pBoard)[8], Pieces *pPieces); // Displays board and taken pieces

void checkMate(Pieces *pPieces, Coordinates (*pBoard)[8], bool *checkmate, bool *stalemate); // Determines if checkmate happened (stalemate WIP)

int main() // Begin main ---------------------------------------------------------------------------------------
{
    Coordinates arrBoard[8][8]; // The chessboard
    Coordinates (*pBoard)[8] = arrBoard; // Two-dimensional pointer to the board Coordinates struct array
    Pieces arrPieces[32]; // {8 white pawns, 8 black pawns, 8 unique white pieces, 8 unique black pieces}
    Pieces *pPieces = arrPieces;
    char turn = 'w';
    bool checkmate = false;
    bool stalemate = false;

    populateChessboard(arrBoard); // Initialize the chessboard
    addPieces(arrPieces, arrBoard); // Create pieces and add them to the board

    while(checkmate != true && stalemate != true) // Main loop, runs until end of game
    {
        if(turn == 'w') // White's turn
        {
            movePiece(arrPieces, arrBoard, &turn); // Moving
            displayBoard(arrBoard, arrPieces); // Display after moving
            checkMate(arrPieces, arrBoard, &checkmate, &stalemate); // Check if over
            turn = 'b'; // Change turn
        }
        else // Black's turn
        {
            movePiece(arrPieces, arrBoard, &turn); // Moving
            displayBoard(arrBoard, arrPieces); // Display after moving
            checkMate(arrPieces, arrBoard, &checkmate, &stalemate); // Check if over
            turn = 'w'; // Change turn
        }
    }
    if(turn == 'w'){ // Trying this
        cout << "\nBlack wins!" << endl;
    }
    else{
        cout << "\nWhite wins!" << endl;
    }

    return 0;
} // End main --------------------------------------------------------------------------------------------------

void movePiece(Pieces *pPieces, Coordinates (*pBoard)[8], char *turn) // Big function that validates input, manages moving and taking
{
    bool validMove = false; // Assume move is false until proven otherwise
    do{ // Runs first time always, then checks if move was valid, if not then reruns
        string origin = "";
        string destin = "";
        bool validInput = false;
        bool allowedMove = false;
        validMove = false;
        bool foundO = false;
        bool foundD = false;
        int movingPiece = 0;
        int takenPiece = 0;
        do {
            do{
                if(*turn == 'w'){
                    cout << "\nWhite, enter the coordinates of the piece to move: ";
                    cin >> origin;
                    cout << "Enter the coordinates to move to: ";
                    cin >> destin;
                }
                else {
                    cout << "\nBlack, enter the coordinates of the piece to move: ";
                    cin >> origin;
                    cout << "Enter the coordinates to move to: ";
                    cin >> destin;
                }
                if(origin[0] >= 'a' && origin[0] <= 'h' && origin[1] >= '1' && origin[1] <= '8' && destin[0] >= 'a' && destin[0] <= 'h' && destin[1] >= '1' && destin[1] <= '8'){ // Input validation between a and h and 1 and 8
                    validInput = true;
                }
                else{
                    cout << "Incorrect coordinates entered!" << endl;
                }
            }while(validInput == false);

            for(int k = 0; k < 32; k++){ // Run through all pieces (adjust to run through only specific colour maybe?)
                if(origin == pPieces[k].xyLoc){ // Find if piece is on origin (before going through board)
                    if(pPieces[k].code[0] == *turn){
                        cout << "found origin" << endl;
                        foundO = true; // Will need to add to WHILE LOOP to control?
                        movingPiece = k;
                        allowedMove = true;
                    }
                    else{
                        cout << "The piece you're trying to move is not yours!" << endl;
                    }
                }
            }
        }while (allowedMove == false);

        for(int i = 0; i < 8; i++) {
            for(int j = 0; j < 8; j++) { // Run through all x and y
                if(pBoard[i][j].taken == pPieces[movingPiece].code){ // Finds where piece is/was
                    pBoard[i][j].taken = ""; // Reset origin to coords
                    cout << "origin reset" << endl;
                }
                if(destin == pBoard[i][j].xyLoc){ // Find destination
                    foundD = true;
                    cout << "found destin" << endl;
                    if(pBoard[i][j].taken != "")
                    {
                        cout << "piece on destin" << endl;
                        for(int k = 0; k < 32; k++){ // Run through all pieces
                                if(pPieces[k].xyLoc == destin){ // Finds piece on spot and removes it
                                    pPieces[k].xyLoc = "";
                                    pBoard[i][j].taken = pPieces[movingPiece].code; // Move piece to destination on board
                                    pPieces[movingPiece].xyLoc = destin; // Record new location in pieces
                                    validMove = true; // Confirm move was valid
                                    cout << "1destin set" << endl;
                                    break;
                                }
                        }
                    }
                    else{
                        cout << "no piece on destin" << endl;
                        pBoard[i][j].taken = pPieces[movingPiece].code; // Move piece to destination on board
                        pPieces[movingPiece].xyLoc = destin; // Record new location in pieces
                        validMove = true; // Confirm move was valid
                        cout << "2destin set" << endl;
                    }
                }
            }
        }
        if(foundO == false){
            cout << "No valid piece found at origin position." << endl;
            foundD = true; // Prevent duplicate messages
        }
        if(foundD == false){
            cout << "Invalid destination position." << endl;
        }
        if (!validMove){
                cout << "Invalid move!" << endl;
        }
    }while(!validMove);
}

void checkMate(Pieces *pPieces, Coordinates (*pBoard)[8], bool *checkmate, bool *stalemate) // Determines if checkmate happened (stalemate WIP)
{
    if(pPieces[20].xyLoc == "" || pPieces[28].xyLoc == ""){ // If a king is not on the board, checkmate (index white king 20, black king 28)
        *checkmate = true;
    }
    // stalemate code, much tougher here
}

void displayBoard(Coordinates (*pBoard)[8], Pieces *pPieces) // Displays chessboard and taken pieces
{
    cout << "\nCurrent chessboard: " << endl;
    for(int i = 0; i < 8; i++) {
        for(int j = 0; j < 8; j++) {
            if(pBoard[i][j].taken == ""){ // If not taken, cout coordinates, otherwise cout the piece on it's code
                cout << setw(4) << left << pBoard[i][j].xyLoc;
            }
            else{
                cout << setw(4) << left << pBoard[i][j].taken;
            }
        }
        cout << endl;
    }
    cout << "\nPieces taken: " << endl;
    cout << "White: ";
    for(int k = 0; k < 8; k++){ // Lists all white pieces taken
        if(pPieces[k].xyLoc == ""){ // White pawns
            cout << pPieces[k].code << " ";
        }
        if(pPieces[k+16].xyLoc == ""){ // White uniques
            cout << pPieces[k+16].code << " ";
        }
    }
    cout << endl;
    cout << "Black: ";
    for(int k = 0; k < 8; k++){ // Lists all black pieces taken
        if(pPieces[k+8].xyLoc == ""){ // Black pawns
            cout << pPieces[k+8].code << " ";
        }
        if(pPieces[k+24].xyLoc == ""){ // Black uniques
            cout << pPieces[k+24].code << " ";
        }
    }
    cout << endl;
}

void populateChessboard(Coordinates (*pBoard)[8]) // Populates and displays chessboard
{
    for(int i = 0; i < 8; i++) {
        for(int j = 0; j < 8; j++) {
            pBoard[i][j].character = 'a' + j;
            pBoard[i][j].number = 8 - i;
            pBoard[i][j].xyLoc += pBoard[i][j].character + to_string(pBoard[i][j].number);
            pBoard[i][j].taken = "";
            //cout << pBoard[i][j].xyLoc << " "; // Old method (which works but doesn't handle piece codes well)
            cout << setw(4) << left << pBoard[i][j].xyLoc; // New method
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
    for(int i = 0; i < 2; i++) // Gives colour, name, code
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
    for(int i = 0; i < 16; i++){ // Assigns location for pieces
        for(int m = 0; m < 8; m++) {
            for(int n = 0; n < 8; n++) {
                if (pBoard[m][n].xyLoc == pPieces[i+16].xyLoc)
                {
                    pBoard[m][n].taken = pPieces[i+16].code;
                }
            }
        }
    }
}
