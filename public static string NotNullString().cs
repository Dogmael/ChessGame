    public static string NotNullString()
    {
        //On verifie que l'utilisateur entre qlq chose
        string? stringCoordsNull = null;
        string stringCoords ="InitialValue";
        do
        {
            stringCoordsNull = Console.ReadLine();
            if (string.IsNullOrEmpty(stringCoordsNull))
            {
                Console.WriteLine("Vous n'avez rien entré. Veuillez saisir des coordonnées.");
            }
            else
            {
                stringCoords = stringCoordsNull;
            }
        } while (string.IsNullOrEmpty(stringCoordsNull));
        return stringCoords;
    }