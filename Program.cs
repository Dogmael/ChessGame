using System;
using System.Text.RegularExpressions;
using System.Text;


namespace ChessGame;



class Program : Board //Il faut hériter de board si on veut pouvoir utiliser les méthodes static qui sont dedans ! 
{
    static void Main(string[] args)
    {
        
        // Board board = new Board();
        // Object[,] boardObj = (Object[,]) board; 

        // Piece piece = (Piece) board[6, 2]; // Pas d'indexeur dans les arrays ! 

        Console.WriteLine("Bonjour, bienvenue dans le jeu d'échec !");
        Console.OutputEncoding = Encoding.UTF8;
        Board board = new Board();
        board.PrintBoard();

        bool win = false;

        do
        {
            Console.WriteLine("Quelle pièce voulez-vous jouer ? Entrez sont emplacement actuel.");
            Coords currentPosition = AskCoords();
            Console.WriteLine("Ou voulez vous mettre cette pièce ? Entrez l'emplacement voulue.");
            Coords newPosition = AskCoords();
            win = board.MovePiece(currentPosition, newPosition);
            board.PrintBoard();
        } while (!win);
    }


    public static Coords AskCoords()
    {
        while (true)
        {
            
            string? stringCoords = Console.ReadLine();
            if (string.IsNullOrEmpty(stringCoords))
            {
                Console.WriteLine("Vous n'avez rien entré");
            }
            else
            {
                try
                {
                    Coords currCoords = StringToCoords(stringCoords);
                    return currCoords;
                }
                catch
                {
                    Console.WriteLine("Enter a valid square please (e.g. A5).");
                    continue;
                }
            }
        }
    }

    public static Coords StringToCoords(string userInput)
    {
        //Check if string match with a chess square
        string regex = @"([a-hA-H]{1}[1-8])";
        var match = Regex.Match(userInput, regex, RegexOptions.IgnoreCase);

        if (userInput.Length != 2 || !match.Success)
        {
            throw new ArgumentException("Your input is not a valid chess square");
        }

        Coords result = new Coords();
        result.Column = userInput[0];
        int intLine = userInput[1] - '0'; // Attention unserInupt[1] renvoit un char qui doit être converti en int.
        result.Line = intLine;
        return result;
    }
}
