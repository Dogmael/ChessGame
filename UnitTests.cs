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
        [Fact]
        public void Test1()
        {
            Knight newKnight = new Knight(('e', 3), "black");
            List<(char, int)> results = newKnight.PossiblesMoves();
            List<(char, int)> expectResult = new List<(char, int)> { ('d', 5), ('f', 5), ('c', 4), ('g', 4), ('d', 1), ('f', 1), ('c', 2), ('g', 2) };
            bool isEqual = results.ToHashSet().SetEquals(expectResult);
            Assert.True(isEqual,".PossiblesMoves() renvoit des valeurs erronées pour les arguements: ((e,3),\"black\")");
        }

        // public void AskCoordsTest()
        // {

        // }


    }



}