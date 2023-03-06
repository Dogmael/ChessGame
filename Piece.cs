using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame
{
    abstract public class Piece
    //Gérer proprement les valeurs possibles pour Position (type Coords), color (que deux possibilié) et PieceType()
    {
        // Atributs
        public Coords Position { get; set; }
        public string Color { get; set; }

        // Constructor 
        public Piece(Coords position, string color)
        {
            Position = position;
            Color = color;
        }

        // Methods

        abstract public List<Coords> PossiblesMoves();

        public char PieceChar()
        {
            if (Color == "white")
            {
                switch (this.GetType())
                {
                    case var value when value == typeof(King):
                        return '\u2654';
                    case var value when value == typeof(Queen):
                        return '\u2655';
                    case var value when value == typeof(Bishop):
                        return '\u2657';
                    case var value when value == typeof(Knight):
                        return '\u2658';
                    case var value when value == typeof(Rook):
                        return '\u2656';
                    case var value when value == typeof(Pawn):
                        return '\u2659';
                    default:
                        throw new ArgumentOutOfRangeException("Your PieceType isn't recognize.");
                }
            }
            else
            {
                switch (this.GetType())
                {
                    case var value when value == typeof(King) :
                        return '\u265A';
                    case var value when value == typeof(Queen):
                        return '\u265B';
                    case var value when value == typeof(Bishop):
                        return '\u265D';
                    case var value when value == typeof(Knight):
                        return '\u265E';
                    case var value when value == typeof(Rook):
                        return '\u265C';
                    case var value when value == typeof(Pawn):
                        return '\u265F';
                    default:
                        throw new ArgumentOutOfRangeException("Your PieceType isn't recognize.");
                }
            }
        }

        public char NewColumn(char currentColumn, int amplitude)
        {
            // Give letter that correspond to new columun after a mouvement of amplitude lines and from initial line currentColumn.
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
        //Clarifier si on travail avec les lignes de l'échéquier ou de la matrice board
        {
            int newLine = currentLine + amplitude;
            if (newLine > 0 && newLine < 9)
            {
                return newLine;
            }
            else
            {
                throw new ArgumentOutOfRangeException("New line out of board");
            }
        }
    }

    // Inherited classes 
    public class King : Piece
    {
        //Constructor
        public King(Coords position, string color) : base(position, color)
        {
        }

        //Methods

        public override List<Coords> PossiblesMoves()
        {
            List<Coords> possiblesMoves = new List<Coords>();
            char column = Position.Column;
            int line = Position.Line;

            int[] linesAmplitudes = { -1, 1 };
            int[] columnsAmplitudes = { -1, 1 };
            foreach (int amplitudeL in linesAmplitudes)
            {
                foreach (int amplitudeC in columnsAmplitudes)
                {
                    try
                    {
                        Coords newCoord = new Coords(NewColumn(column, amplitudeC), NewLine(line, amplitudeL));
                        possiblesMoves.Add(newCoord);
                    }
                    catch
                    { }
                }
            }
            return possiblesMoves;
        }
    }

    public class Queen : Piece
    {
        //Constructor
        public Queen(Coords position, string color) : base(position, color)
        {
        }

        //Methods
        override public List<Coords> PossiblesMoves()
        {
            List<Coords> possiblesMoves = new List<Coords>();
            char currentColumn = Position.Column;
            int currentLine = Position.Line;

            int[] amplitudes = new int[] { -8, -7, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, 7, 8 }; // On ne met pas 0 pour ne pas avoir la position initiale dans les positions possibles


            foreach (int amplitude in amplitudes) //Gauche, droite
            {
                try
                {
                    Coords newCoord = new Coords(NewColumn(currentColumn, amplitude), currentLine);
                    possiblesMoves.Add(newCoord);
                }
                catch (ArgumentOutOfRangeException)
                { }
            }

            foreach (int amplitude in amplitudes) // Haut/bas
            {
                try
                {
                    Coords newCoord = new Coords(currentColumn, NewLine(currentLine, amplitude));
                    possiblesMoves.Add(newCoord);
                }
                catch (ArgumentOutOfRangeException)
                { }
            }

            foreach (int amplitude in amplitudes) // Diagonale
            {
                try
                {
                    Coords newCoord = new Coords(NewColumn(currentColumn, amplitude), NewLine(currentLine, -amplitude));
                    possiblesMoves.Add(newCoord);
                }
                catch (ArgumentOutOfRangeException)
                { }
            }

            foreach (int amplitude in amplitudes) // Antidiagonale 
            {
                try
                {
                    Coords newCoord = new Coords(NewColumn(currentColumn, amplitude), NewLine(currentLine, amplitude));
                    possiblesMoves.Add(newCoord);
                }
                catch (ArgumentOutOfRangeException)
                { }
            }

            return possiblesMoves;
        }
    }

    public class Bishop : Piece
    {
        //Constructor
        public Bishop(Coords position, string color) : base(position, color)
        {

        }

        //Methods
        override public List<Coords> PossiblesMoves()
        {
            List<Coords> possiblesMoves = new List<Coords>();
            char currentColumn = Position.Column;
            int currentLine = Position.Line;

            int[] amplitudes = new int[] { -8, -7, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, 7, 8 }; // On ne met pas 0 pour ne pas avoir la position initiale dans les positions possibles

            foreach (int amplitude in amplitudes) // Diagonale
            {
                try
                {
                    Coords newCoord = new Coords(NewColumn(currentColumn, amplitude), NewLine(currentLine, -amplitude));
                    possiblesMoves.Add(newCoord);
                }
                catch (ArgumentOutOfRangeException)
                { }
            }

            foreach (int amplitude in amplitudes) // Antidiagonale 
            {
                try
                {
                    Coords newCoord = new Coords(NewColumn(currentColumn, amplitude), NewLine(currentLine, amplitude));
                    possiblesMoves.Add(newCoord);
                }
                catch (ArgumentOutOfRangeException)
                { }
            }

            return possiblesMoves;
        }

    }

    public class Knight : Piece
    {
        //Constructors
        public Knight(Coords position, string color) : base(position, color)
        {

        }

        //Methods
        override public List<Coords> PossiblesMoves()
        {
            List<Coords> possiblesMoves = new List<Coords>();
            char column = Position.Column;
            int line = Position.Line;

            int[] linesAmplitudes = { -2, 2 };
            int[] columnsAmplitudes = { -1, 1 };
            foreach (int amplitudeL in linesAmplitudes)
            {
                foreach (int amplitudeC in columnsAmplitudes)
                {
                    try
                    {
                        Coords newCoord = new Coords(NewColumn(column, amplitudeC), NewLine(line, amplitudeL));
                        possiblesMoves.Add(newCoord);
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
                        Coords newCoord = new Coords(NewColumn(column, amplitudeC), NewLine(line, amplitudeL));
                        possiblesMoves.Add(newCoord);
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
        public Rook(Coords position, string color) : base(position, color)
        {
        }

        //Methods
        override public List<Coords> PossiblesMoves()
        //Gérer la différence de mouvements possibles entre si c'est pour manger une pièce ou non
        {
            List<Coords> possiblesMoves = new List<Coords>();
            char currentColumn = Position.Column;
            int currentLine = Position.Line;

            int[] amplitudes = new int[] { -8, -7, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, 7, 8 }; // On ne met pas 0 pour ne pas avoir la position initiale dans les positions possibles

            foreach (int amplitude in amplitudes) //Gauche, droite
            {
                try
                {
                    Coords newCoord = new Coords(NewColumn(currentColumn, amplitude), currentLine);
                    possiblesMoves.Add(newCoord);
                }
                catch (ArgumentOutOfRangeException)
                { }
            }

            foreach (int amplitude in amplitudes) // Haut/bas
            {
                try
                {
                    Coords newCoord = new Coords(currentColumn, NewLine(currentLine, amplitude));
                    possiblesMoves.Add(newCoord);
                }
                catch (ArgumentOutOfRangeException)
                { }
            }
            return possiblesMoves;
        }
    }

    public class Pawn : Piece
    {

        //Constructors
        public Pawn(Coords position, string color) : base(position, color)
        {
        }

        //Methods
        override public List<Coords> PossiblesMoves()
        //Gérer la différence de mouvements possibles entre si c'est pour manger une pièce ou non
        {
            List<Coords> possiblesMoves = new List<Coords>();
            char column = Position.Column;
            int line = Position.Line;

            if (Color == "white")
            {
                int[] amplitudes = new int[] { -1, 0, 1 };
                foreach (int moveAmplitude in amplitudes)
                    try
                    {
                        char newColumn = NewColumn(column, moveAmplitude);
                        int newLine = NewLine(line, 1);
                        Coords newCoord = new Coords(newColumn, newLine);
                        possiblesMoves.Add(newCoord);
                    }
                    catch (ArgumentOutOfRangeException)
                    { }
            }
            else
            {
                int[] amplitudes = new int[] { -1, 0, 1 };
                foreach (int moveAmplitude in amplitudes)
                    try
                    {
                        char newColumn = NewColumn(column, moveAmplitude);
                        int newLine = NewLine(line, -1);
                        Coords newCoord = new Coords(newColumn, newLine);
                    }
                    catch (ArgumentOutOfRangeException)
                    { }
            }
            return possiblesMoves;
        }
    }
}



