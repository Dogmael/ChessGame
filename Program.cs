using System;
using System.Text.RegularExpressions;
using System.Text;


namespace ChessGame;



class Program //Il faut hériter de board si on veut pouvoir utiliser les méthodes static qui sont dedans ! 
{
    static void Main(string[] args)
    {
        Console.WriteLine("Entré une case");
        AskCoords();
        // Console.WriteLine("Bonjour, bienvenue dans le jeu d'échec !");
        // Console.OutputEncoding = Encoding.UTF8;
        // Board board = new Board();
        // board.PrintBoard();

        // bool win = false;

        // do
        // {
        //     Console.WriteLine("Quelle pièce voulez-vous jouer ? Entrez sont emplacement actuel.");
        //     Coords? currentPosition = AskCoords();
        //     // currentPositionValidation
        //     Console.WriteLine("Ou voulez vous mettre cette pièce ? Entrez l'emplacement voulue.");
        //     Coords? newPosition = AskCoords();
        //     // newPositionValidation
        //     win = board.MovePiece(currentPosition, newPosition);
        //     board.PrintBoard();
        // } while (!win);
    }


    public static Coords AskCoords() //On veut être sur de retourner des coordonnées.
    {
        //On verifie que l'utilisateur entre qlq chose
        string? stringCoords = null;
        stringCoords = Console.ReadLine();
        Coords result; //Pourquoi ??
        while (string.IsNullOrEmpty(stringCoords) || !Coords.TryParse(stringCoords, out result))
        {
            Console.WriteLine("Ce que vous avez saisis ne correspond pas à des coordonnées (ex: A5).Veuillez entrer des coordonnées valides.");
            stringCoords = Console.ReadLine();
        }
            result = new Coords();
            Coords.TryParse(stringCoords, out result);
            return (Coords)result;
    }
}
