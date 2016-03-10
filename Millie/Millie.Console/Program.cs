using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var tattooRoom = new Game.TattooRoom();
            var gameState = new Game.GameState();

            var description = tattooRoom.GetDescription(gameState);
            var choices = tattooRoom.GetChoices(gameState);

            System.Console.WriteLine(description);
            System.Console.WriteLine("Millie Has Tat: " + gameState.GotTattoo);
            foreach (var choice in choices) System.Console.WriteLine(" - " + choice.Description);

            tattooRoom.ProcessChoice(gameState, 1);
            description = tattooRoom.GetDescription(gameState);
            System.Console.WriteLine("Millie Has Tat: " + gameState.GotTattoo);
            System.Console.WriteLine(description);
            
        }
    }
}
