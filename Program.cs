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
        string playerColor = "white";

        do
        {
            Console.WriteLine("Quelle pièce voulez-vous jouer ? Entrez sont emplacement actuel.");
            Coords currentCoords = AskCoords();
            Console.WriteLine(CurrentCoordsValidation(board, currentCoords, playerColor));
            // Console.WriteLine("Ou voulez vous mettre cette pièce ? Entrez l'emplacement voulue.");
            // Coords newCoords = AskCoords();
            // newPositionValidation
            // win = board.MovePiece(currentCoords, newCoords);
            board.PrintBoard();
            playerColor = MajPlayerColor(playerColor);
        } while (!win);


    }

    public static string MajPlayerColor(string currentPlayerColor) 
    {
        switch (currentPlayerColor)
        {
            case "white" :
            return "black";
            case "black" : 
            return "white";
            default:
            return "error";
        }       
    }

    public static Coords AskCoords()
    {
        string? stringCoords = null;
        stringCoords = Console.ReadLine();
        Coords result;
        while (string.IsNullOrEmpty(stringCoords) || !Coords.TryParse(stringCoords, out result))
        {
            Console.WriteLine("Ce que vous avez saisis ne correspond pas à des coordonnées (ex: A5).Veuillez entrer des coordonnées valides.");
            stringCoords = Console.ReadLine();
        }
        result = new Coords(); //Nécessaire ?? 
        Coords.TryParse(stringCoords, out result);
        return result;
    }

    public static bool CurrentCoordsValidation(Board board, Coords currentCoords, String playerColor)
    {
        Piece pieceGet;
        if (!board.GetPiece(currentCoords, out pieceGet)) // Si la currentCoords entré correpond à une case vide
        {
            Console.WriteLine("La position de départ entré correpond à une case vide. Veuillez entrer une position de départ valide.");
            return false;
        }
        // La pièce appartient au joueur actuel
        if (pieceGet.Color != playerColor) // La pièce sélectioné n'appartient pas au joueur actuel
        {
            Console.WriteLine("La pièce sélectionné ne vous appartient pas.");
            return false;
        }
        return true;
    }

    public static bool NewCoordsValidation(Board board,Coords currentCoords,string playerColor)
    {
        // bool result = false;
        
        // Piece pieceCurrCoords;
        // board.GetPiece(currentCoords, out pieceCurrCoords);

        // Piece pieceNewCoords;
        /*
        If ( casse choisi n'appartient PAS a case possible )
            return false;
        Else if (case vide)
            return true;
        Else if (piece.Couleur == playerColor)
            return false
        Else
            return true;



        */

        // Le mvt est authorisé
            //On récupère les PoosiblesMouvements
        // Il ne se mange pas lui même

        // Il ne se met pas en échec
        return false;
    }
}
