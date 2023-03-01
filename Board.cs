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
            board[0, 0] = new Rook(('a', 8), "black");
            board[0, 1] = new Knight(('b', 8), "black");
            board[0, 2] = new Bishop(('c', 8), "black");
            board[0, 3] = new Queen(('d', 8), "black");
            board[0, 4] = new King(('e', 8), "black");
            board[0, 5] = new Bishop(('f', 8), "black");
            board[0, 6] = new Knight(('g', 8), "black");
            board[0, 7] = new Rook(('h', 8), "black");
            board[1, 0] = new Pawn(('a', 7), "black");
            board[1, 1] = new Pawn(('b', 7), "black");
            board[1, 2] = new Pawn(('c', 7), "black");
            board[1, 3] = new Pawn(('d', 7), "black");
            board[1, 4] = new Pawn(('e', 7), "black");
            board[1, 5] = new Pawn(('f', 7), "black");
            board[1, 6] = new Pawn(('g', 7), "black");
            board[1, 7] = new Pawn(('h', 7), "black");

            // White pieces
            board[6, 0] = new Pawn(('a', 2), "white");
            board[6, 1] = new Pawn(('b', 2), "white");
            board[6, 2] = new Pawn(('c', 2), "white");
            board[6, 3] = new Pawn(('d', 2), "white");
            board[6, 4] = new Pawn(('e', 2), "white");
            board[6, 5] = new Pawn(('f', 2), "white");
            board[6, 6] = new Pawn(('g', 2), "white");
            board[6, 7] = new Pawn(('h', 2), "white");
            board[7, 0] = new Rook(('a', 1), "white");
            board[7, 1] = new Knight(('b', 1), "white");
            board[7, 2] = new Bishop(('c', 1), "white");
            board[7, 3] = new Queen(('d', 1), "white");
            board[7, 4] = new King(('e', 1), "white");
            board[7, 5] = new Bishop(('f', 1), "white");
            board[7, 6] = new Knight(('g', 1), "white");
            board[7, 7] = new Rook(('h', 1), "white");
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

        public bool MovePiece(Coords currentPosition, Coords newPosition)
        {
            //  return true si victoire, false sinon
            // On récupère la pièce aux coords "currentPosition"
            Piece currentPiece;
            bool result = false;
            try
            {
                currentPiece = GetPiece(currentPosition); // {ChessGame.Pawn}

                var possiblesPositions = currentPiece.PossiblesMoves();

                // bool authorizedMove = false;

                foreach ((char, int) positions in possiblesPositions)
                {
                    if (newPosition.Equals(positions))
                    {
                        // authorizedMove = true;
                    }
                }


                // On regarde si le mouvement est autorisé
                Console.WriteLine(currentPiece.PossiblesMoves());
                //On regarde si il y a une pièce à "newPosition"
                try
                {
                    Piece eatenPiece = GetPiece(newPosition);
                    if (eatenPiece.PieceType == "King")
                    {
                        Console.WriteLine("Vous avec gagné. Félicitations. ");
                        result = true;
                    }
                    else
                    {
                        Console.WriteLine("Vous avez mangez une piece.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Vous n'avez mangez aucune piece.");
                }
                // On déplace la pièce
                board[8 - currentPosition.Line, ColumnToInt(currentPosition.Column)] = new Object();
                board[8 - newPosition.Line, ColumnToInt(newPosition.Column)] = currentPiece;
            }
            // Si la case est vide, on écris une erreur
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public Piece GetPiece(Coords position)
        {
            // Return Piece at "position" location.
            // Throw an error if the case is empty.
            int lineInt = 8 - position.Line; //On veut des indices dans board
            char columChar = position.Column;
            int columInt = ColumnToInt(columChar);

            try
            //Si la case est vide, le downcasting va renvoyer une erreur  
            {
                Object test = board[lineInt, columInt]; // /Problème : test.Position = (98 'b', 7), on voudrait ('b',2)
                Piece piece = (Piece)test; //Problème : piece.Position = (98 'b', 7), on voudrait ('b',2)
                return piece;
            }
            //Si la case est vide, on renvoie null
            catch (Exception)
            {
                throw new ArgumentException("La case est vide.");
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