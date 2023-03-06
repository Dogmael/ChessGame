using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace ChessGame
{
    public class Board
    {
        // Attributs
        public Object[,] board = new Object[8, 8]; //Les valeurs sont : null

        // Constructor  
        public Board()
        {

            for (int i = 2; i < 6; i++) // Lines 
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = 0; // On un objet vers System.Int32
                }
            }

            // Set pieces on the board

            // Black pieces
            board[0, 0] = new Rook(new Coords('a', 8), "black");
            board[0, 1] = new Knight(new Coords('b', 8), "black");
            board[0, 2] = new Bishop(new Coords('c', 8), "black");
            board[0, 3] = new Queen(new Coords('d', 8), "black");
            board[0, 4] = new King(new Coords('e', 8), "black");
            board[0, 5] = new Bishop(new Coords('f', 8), "black");
            board[0, 6] = new Knight(new Coords('g', 8), "black");
            board[0, 7] = new Rook(new Coords('h', 8), "black");
            board[1, 0] = new Pawn(new Coords('a', 7), "black");
            board[1, 1] = new Pawn(new Coords('b', 7), "black");
            board[1, 2] = new Pawn(new Coords('c', 7), "black");
            board[1, 3] = new Pawn(new Coords('d', 7), "black");
            board[1, 4] = new Pawn(new Coords('e', 7), "black");
            board[1, 5] = new Pawn(new Coords('f', 7), "black");
            board[1, 6] = new Pawn(new Coords('g', 7), "black");
            board[1, 7] = new Pawn(new Coords('h', 7), "black");

            // White pieces
            board[6, 0] = new Pawn(new Coords('a', 2), "white");
            board[6, 1] = new Pawn(new Coords('b', 2), "white");
            board[6, 2] = new Pawn(new Coords('c', 2), "white");
            board[6, 3] = new Pawn(new Coords('d', 2), "white");
            board[6, 4] = new Pawn(new Coords('e', 2), "white");
            board[6, 5] = new Pawn(new Coords('f', 2), "white");
            board[6, 6] = new Pawn(new Coords('g', 2), "white");
            board[6, 7] = new Pawn(new Coords('h', 2), "white");
            board[7, 0] = new Rook(new Coords('a', 1), "white");
            board[7, 1] = new Knight(new Coords('b', 1), "white");
            board[7, 2] = new Bishop(new Coords('c', 1), "white");
            board[7, 3] = new Queen(new Coords('d', 1), "white");
            board[7, 4] = new King(new Coords('e', 1), "white");
            board[7, 5] = new Bishop(new Coords('f', 1), "white");
            board[7, 6] = new Knight(new Coords('g', 1), "white");
            board[7, 7] = new Rook(new Coords('h', 1), "white");
        }

        // Methods

        public void PrintBoard()
        {
            Console.WriteLine("  a b c d e f g h");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] is ChessGame.Piece)
                    {
                        Piece downCastPiece = (Piece)board[i, j]; // Downcasting
                        Console.Write(Char.ToString(downCastPiece.PieceChar()) + " ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.Write("\n");
            }
        }

public bool GetPiece(Coords position, out Piece pieceGet)
{
    // Return Piece at "position" location.
    // Throw an error if the case is empty.
    int lineInt = 8 - position.Line; //On veut des indices dans board (Attention: différents Coords)
    char columChar = position.Column;
    int columInt = ColumnToInt(columChar);


    try
    //Si la case est vide, le downcasting va renvoyer une erreur  
    {
        Object pieceObj = board[lineInt, columInt];
        pieceGet = (Piece)pieceObj;
        return true;
    }
    //Si la case est vide, on renvoie false et pieceGet prend une valeur sans signification
    catch (Exception)
    {
        pieceGet = new Pawn(new Coords('a', 1), "white");// Ca plante ici //Null equivalency
        return false;
    }
}

static public int ColumnToInt(char currentValue)
{
    //Convert 'a' -> 0, 'b' -> 1...
    int asciiValue = (int)currentValue;
    int result = asciiValue - 97; //La valeur ASCII de 'a' est 97
    return result;
}

    }
}