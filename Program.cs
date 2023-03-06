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
            while (!CurrentCoordsValidation(board, currentCoords, playerColor))
            {
                currentCoords = AskCoords();
            }

            Console.WriteLine("Ou voulez vous mettre cette pièce ? Entrez l'emplacement voulue.");
            Coords newCoords = AskCoords();
            while (!NewCoordsValidation(board, newCoords, currentCoords, playerColor))
            {
                Console.WriteLine("Ou voulez vous mettre cette pièce ? Entrez l'emplacement voulue.");
                newCoords = AskCoords();
            }

            win = MovePiece(board, currentCoords, newCoords);
            board.PrintBoard();
            playerColor = MajPlayerColor(playerColor);
        } while (!win);
    }

    public static string MajPlayerColor(string currentPlayerColor)
    {
        switch (currentPlayerColor)
        {
            case "white":
                return "black";
            case "black":
                return "white";
            default:
                return "error";
        }
    }

    public static Coords AskCoords()
    {
        string? stringCoords = null;
        Coords result;
        stringCoords = Console.ReadLine();
        while (string.IsNullOrEmpty(stringCoords) || !Coords.TryParse(stringCoords, out result))
        {
            Console.WriteLine("Ce que vous avez saisis ne correspond pas à des coordonnées (ex: A5).Veuillez entrer des coordonnées valides.");
            stringCoords = Console.ReadLine();
        }
        result = new Coords();
        Coords.TryParse(stringCoords, out result);
        return result;
    }

    public static bool CurrentCoordsValidation(Board board, Coords currentCoords, String playerColor)
    {
        Piece pieceGet;
        if (!board.GetPiece(currentCoords, out pieceGet)) // Si la currentCoords entré correpond à une case vide
        {
            Console.WriteLine("La position de départ entré correpond à une case vide. Veuillez entrer une position de départ valide:");
            return false;
        }
        // La pièce appartient au joueur actuel
        if (pieceGet.Color != playerColor) // La pièce sélectioné n'appartient pas au joueur actuel
        {
            Console.WriteLine("La pièce sélectionné ne vous appartient pas. Veuillez entrer une position de départ valide:");
            return false;
        }
        //A intégrer: La pièce est bloqué (ex: tour au premier tour)
        return true;
    }

    public static bool NewCoordsValidation(Board board, Coords newCoords, Coords currentCoords, String playerColor)
    {
        // Il ne faut pas quelle soit identique à la case de départ
        if (newCoords.Line == currentCoords.Line && newCoords.Column == currentCoords.Column)
        {
            Console.WriteLine("La case d'arrivé choisie est identique à la case de départ. Veuillez en choisir un autre.");
            return false;
        }

        // Il n'y a pas une pièce de la couleur du joueur acutel sur la case d'arrivé (Il ne se mange pas lui même)
        Piece pieceAtNewCoords;
        if (board.GetPiece(newCoords, out pieceAtNewCoords) && pieceAtNewCoords.Color == playerColor) //On vérifie qu'il y est bien une pièce à l'emplacement voule
        {
            Console.WriteLine("Vous ne pouvez pas manger une de vos pièces. Veuillez entrer une position d'arrivé valide:");
            return false;
        }

        // La case finale est accessible sans colisions

        return true;

    }

    static public bool MovePiece(Board board, Coords currentPosition, Coords newPosition) //A réécrire après modif de la signature de GetPiece
    {
        bool win = false;
        Piece eatenPiece;
        bool eatbool = board.GetPiece(newPosition, out eatenPiece);
        if (eatbool) // Le joueur a mangé une pièce
        {
            if (eatenPiece.GetType() == typeof(King))
            {
                Console.WriteLine("Vous avec gagné. Félicitations. ");
                win = true;
            }
            else
            {
                Console.WriteLine("Vous avez mangez une piece.");
            }
        }
        else
        {
            Console.WriteLine("Vous n'avez mangez aucune piece.");
        }

        Piece currentPiece;
        board.GetPiece(currentPosition, out currentPiece);

        Object[,] boardObj = new Object[8, 8];
        boardObj = (Object[,])board.board;
        boardObj[8 - currentPosition.Line, Board.ColumnToInt(currentPosition.Column)] = new Object();
        boardObj[8 - newPosition.Line, Board.ColumnToInt(newPosition.Column)] = currentPiece;

        return win;
    }

    // public static List<Coords> AccessiblesCoords(Board board, Coords pieceCoords)
    // //Renvoie la liste des coordonnées accessible pour une pièce vu la configuration actuelle du plateau
    // {
    //     Piece currentPiece;
    //     board.GetPiece(currentCoords, out currentPiece);
    //     Type pieceType = currentPiece.GetType();

    //     if (pieceType == typeof(Knight) || pieceType == typeof(King)) // King, Knight non concernés: ils peuvent prendre sur tout les cases qui leurs sont accessibles (attention Pawn l'es bien sur la case de devant)
    //     {
    //         return currentPiece.PossiblesMoves();
    //     }
    //     else if (pieceType == typeof(Pawn))
    //     {

    //     }
    //     else // Si c'est Rook, Queen ou Bishop on traite ensemble
    //     {
    //         List<(char, int)> possiblesMoves = currentPiece.PossiblesMoves();
    //         return possiblesMoves;
    //     }

    // }

}
