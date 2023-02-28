using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Piece
    {
        // Atributs
        public (char colomun, int line) Position { get; set; }
        public string Color { get; set; }
        public string PieceType { get; set; }

        // Constructor 
        public Piece((char colomun, int line) position, string color)
        {
            Position = position;
            Color = color;
            PieceType = "piece";
        }

        // Methods

        public char PieceChar()
        {    
            if (Color == "white")
            {
                switch (PieceType)
                {
                    case "King":
                        return '\u2654';
                    case "Queen":
                        return '\u2655';
                    case "Bishop":
                        return '\u2657';
                    case "Knight":
                        return '\u2658';
                    case "Rook":
                        return '\u2656';
                    case "Pawn":
                        return '\u2659';
                    default:
                        throw new ArgumentOutOfRangeException("Your PieceType isn't recognize.");
                }
            }
            else
            {
                switch (PieceType)
                {
                    case "King":
                        return '\u265A';
                    case "Queen":
                        return '\u265B';
                    case "Bishop":
                        return '\u265D';
                    case "Knight":
                        return '\u265E';
                    case "Rook":
                        return '\u265C';
                    case "Pawn":
                        return '\u265F';
                    default:
                        throw new ArgumentOutOfRangeException("Your PieceType isn't recognize.");
                }
            }
        }

        public char NewColumn(char currentColumn, int amplitude)
        // Give letter that correspond to new columun after a mouvement of amplitude lines and from initial line currentColumn.
        {
            char newChar = (char)(((int)currentColumn) + amplitude);
            //Check if new column if out of board
            string boardColumn = "abcdefgh";
            if (boardColumn.Contains(newChar))
            {
                return newChar;
            }
            else
            {
                throw new ArgumentOutOfRangeException("New column out of board");
            }

        }

        public int NewLine(int currentLine, int amplitude)
        {
            int newLine = currentLine + amplitude;
            if (newLine > 0)
            {
                return newLine;
            }
            else
            {
                throw new ArgumentOutOfRangeException("New line out of board");
            }
        }
    }

    public class King : Piece
    {
        //Constructor
        public King((char colomun, int line) position, string color) : base(position, color)
        {
            PieceType = "King";
        }

        //Methods

        // public List<(char, int)> PossiblesMoves()
        // {
        //     List<(char, int)> possiblesMoves = new List<(char, int)>();
        //     char column = Position.colomun;
        //     int line = Position.line;

        //     int[] linesAmplitudes = { -1, 1 };
        //     int[] columnsAmplitudes = { -1, 1 };
        //     foreach (int amplitudeL in linesAmplitudes)
        //     {
        //         foreach (int amplitudeC in columnsAmplitudes)
        //         {
        //             try
        //             {
        //                 possiblesMoves.Add((NewColumn(column, amplitudeC), NewLine(line, amplitudeL)));
        //             }
        //             catch
        //             { }
        //         }
        //     }
        //     return possiblesMoves;
        // }
    }
    // Class 
    public class Queen : Piece
    {
        //Constructor
        public Queen((char colomun, int line) position, string color) : base(position, color)
        {
            PieceType = "Queen";
        }

        //Methods


    }

    public class Bishop : Piece
    {
        //Constructor
        public Bishop((char colomun, int line) position, string color) : base(position, color)
        {
            PieceType = "Bishop";
        }

        //Methods


    }


    public class Knight : Piece
    {
        //Constructors
        public Knight((char colomun, int line) position, string color) : base(position, color)
        {
            PieceType = "Knight";
        }

        //Methods
        public List<(char, int)> PossiblesMoves()
        {
            List<(char, int)> possiblesMoves = new List<(char, int)>();
            char column = Position.colomun;
            int line = Position.line;

            int[] linesAmplitudes = { -2, 2 };
            int[] columnsAmplitudes = { -1, 1 };
            foreach (int amplitudeL in linesAmplitudes)
            {
                foreach (int amplitudeC in columnsAmplitudes)
                {
                    try
                    {
                        possiblesMoves.Add((NewColumn(column, amplitudeC), NewLine(line, amplitudeL)));
                    }
                    catch
                    { }
                }
            }

            linesAmplitudes = new int[] { -1, 1 };
            columnsAmplitudes = new int[] { -2, 2 };
            foreach (int amplitudeL in linesAmplitudes)
            {
                foreach (int amplitudeC in columnsAmplitudes)
                {
                    try
                    {
                        possiblesMoves.Add((NewColumn(column, amplitudeC), NewLine(line, amplitudeL)));
                    }
                    catch
                    { }
                }
            }
            return possiblesMoves;
        }
    }


    public class Rook : Piece
    {
        //Constructor
        public Rook((char colomun, int line) position, string color) : base(position, color)
        {
            PieceType = "Rook";
        }

        //Methods



    }

    public class Pawn : Piece
    {

        //Constructors
        public Pawn((char colomun, int line) position, string color) : base(position, color)
        {
            PieceType = "Pawn";
        }

        //Methods

        public List<(char, int)> PossiblesMoves()
        {
            List<(char, int)> possiblesMoves = new List<(char, int)>();
            char column = Position.colomun;
            int line = Position.line;

            if (Color == "white")
            {
                int[] amplitudes = new int[] { -1, 1 };
                foreach (int moveAmplitude in amplitudes)
                    try
                    {
                        possiblesMoves.Add((NewColumn(column, moveAmplitude), NewLine(line, 1)));
                    }
                    catch (ArgumentOutOfRangeException)
                    { }
            }
            else
            {
                int[] amplitudes = new int[] { -1, 1 };
                foreach (int moveAmplitude in amplitudes)
                    try
                    {
                        possiblesMoves.Add((NewColumn(column, moveAmplitude), NewLine(line, -1)));
                    }
                    catch (ArgumentOutOfRangeException)
                    { }
            }
            return possiblesMoves;
        }
    }
}



