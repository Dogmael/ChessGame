using System;
using System.Text.RegularExpressions;
using System.Text;


namespace ChessGame;



class Program //Il faut hériter de board si on veut pouvoir utiliser les méthodes static qui sont dedans ! 
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bonjour, bienvenue dans le jeu d'échec !");
        Console.OutputEncoding = Encoding.UTF8;
        Board board = new Board();
        board.PrintBoard();

        bool win = false;

        do
        {
            Console.WriteLine("Quelle pièce voulez-vous jouer ? Entrez sont emplacement actuel.");
            Coords? currentPosition = AskCoords();
            // currentPositionValidation
            Console.WriteLine("Ou voulez vous mettre cette pièce ? Entrez l'emplacement voulue.");
            Coords? newPosition = AskCoords();
            // newPositionValidation
            win = board.MovePiece(currentPosition, newPosition);
            board.PrintBoard();
        } while (!win);
    }


    public static Coords? AskCoords()
    {
        //On verifie que l'utilisateur entre qlq chose
        string? stringCoords = null;
        stringCoords = Console.ReadLine();
        while (string.IsNullOrEmpty(stringCoords)) 
        {
            Console.WriteLine("Vous n'avez rien entré. Veuillez saisir des coordonnées.");
            stringCoords = Console.ReadLine();
        }

        //On vérifie que le texte entré correponde bien à des coordonnées.
        Coords? result; //Attention
        if (!Coords.TryParse(stringCoords, out result)) // Attention à ne pas oublier la négation
        {
            Console.WriteLine("Ce que vous avez saisis ne correspond pas à des coordonnées (ex: A5).Veuillez entrer des coordonnées valides.");
            AskCoords(); //Appel récurcif pour revérifier si la personne rentre bien quelquechose.
            return null;
        }
        else
        {
            return result;
        }
    }
}
