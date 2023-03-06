using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

// Attention bien sauvegarder avant de relancer les tests. 

namespace ChessGame
{
    public class testClass
    {
        // [Fact]
        // public void Test1()
        // {
        //     Knight newKnight = new Knight(('e', 3), "black");
        //     List<(char, int)> results = newKnight.PossiblesMoves();
        //     List<(char, int)> expectResult = new List<(char, int)> { ('d', 5), ('f', 5), ('c', 4), ('g', 4), ('d', 1), ('f', 1), ('c', 2), ('g', 2) };
        //     bool isEqual = results.ToHashSet().SetEquals(expectResult);
        //     Assert.True(isEqual,".PossiblesMoves() renvoit des valeurs erronées pour les arguements: ((e,3),\"black\")");
        // }

        // public void AskCoordsTest()
        // {

        // }

// PossiblesMoves pour Queen en a1 -> 
// (b, 1)
// (c, 1)
// (d, 1)
// (e, 1)
// (f, 1)
// (g, 1)
// (h, 1)
// (a, 2)
// (a, 3)
// (a, 4)
// (a, 5)
// (a, 6)
// (a, 7)
// (a, 8)
// (b, 2)
// (c, 3)
// (d, 4)
// (e, 5)
// (f, 6)
// (g, 7)
// (h, 8)

// PossiblesMoves pour Queen en d3 -> 
// (a, 3)
// (b, 3)
// (c, 3)
// (e, 3)
// (f, 3)
// (g, 3)
// (h, 3)
// (d, 1)
// (d, 2)
// (d, 4)
// (d, 5)
// (d, 6)
// (d, 7)
// (d, 8)
// (f, 1)
// (e, 2)
// (c, 4)
// (b, 5)
// (a, 6)
// (b, 1)
// (c, 2)
// (e, 4)
// (f, 5)
// (g, 6)
// (h, 7)

// PossiblesMoves: bishop c4 ->
// (a, 6)
// (b, 5)
// (d, 3)
// (e, 2)
// (f, 1)
// (a, 2)
// (b, 3)
// (d, 5)
// (e, 6)
// (f, 7)
// (g, 8)


// PossiblesMoves: rook e4 -> 
// (a, 4)
// (b, 4)
// (c, 4)
// (d, 4)
// (f, 4)
// (g, 4)
// (h, 4)
// (e, 1)
// (e, 2)
// (e, 3)
// (e, 5)
// (e, 6)
// (e, 7)
// (e, 8)

// PossiblesMoves: pawn e4 -> 
// (d, 5)
// (e, 5)

// PossiblesMoves: Knight e4 ->
// (d, 2)
// (f, 2)
// (d, 6)
// (f, 6)
// (c, 3)
// (g, 3)
// (c, 5)
// (g, 5)



// Cas à tester pour mouvement pièce : tour au premier coup, pion bloqué devant 

//Créer des board de test pour les mvts interdits
    }
}