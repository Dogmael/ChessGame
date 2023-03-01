using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
                if ((value > 0) && (value <= 8))
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
        public Coords(char column, int line)
        {
            this.Line = line;
            this.Column = column;
        }

        // Methods

        static public bool TryParse(string? userInput, out Coords? result) //On autorise result à return null
        /*
        Try parse string to Coord
        result : result of parsing (if sucess) 
        return : true if sucess, false else.
        */
        {
            //Check if string match with a chess square
            string regex = @"([a-hA-H]{1}[1-8])";
            
            if (string.IsNullOrEmpty(userInput))
            {
                result = null;
                return false;
            }
            else
            {
            var match = Regex.Match(userInput, regex, RegexOptions.IgnoreCase);

            if (userInput.Length != 2 || !match.Success)
            {
                result = null; //Quel choix de valeur ???
                return false;
            }
            else
            {
                Coords result2 = new Coords(); //Pas à repréciser la type Coord car déjà dans la déclaration de variable
                result2.Column = userInput[0];
                int intLine = userInput[1] - '0'; // Attention unserInupt[1] renvoit un char qui doit être converti en int.
                result2.Line = intLine;
                result = result2;
                return true;
            }

            }

        }
    }
}