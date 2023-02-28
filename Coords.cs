using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame
{
    public struct Coords //Accepte A5 ou a5 (stoque en minuscule)
    {
        //Attributs
        
        private int line;

        public int Line
        {
            get => line;
            set
            {
                if ( (value > 0) && (value <= 8) )
                {
                    line = value;
                }
                else
                {
                    Console.WriteLine(value);
                    throw new ArgumentOutOfRangeException("Your int value do not correspond to a chess board line.");
                }
            }
        }


        private char column;

        public char Column
        {
            get => column;
            set
            {
                value = Char.ToLower(value);
                string boardColumns = "abcdefgh";
                if (boardColumns.Contains(value))
                {
                    column = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Your char value do not correspond to a chess board column.");
                }
            }
        }

       //Constructeur
        public Coords(char column,int line)
        {
            this.Line = line;
            this.Column = column;
        }



    }
}