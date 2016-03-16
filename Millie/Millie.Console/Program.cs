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
            var barCarRoom = new Game.BarCarRoom();
            var gameState = new Game.GameState();

            // Start with a beardlentgh of 3
            gameState.BeardLength = 2;

            // Go to the bar car
            System.Console.WriteLine(barCarRoom.GetDescription(gameState));

            //Display the choices
            foreach (var choice in barCarRoom.GetChoices(gameState))
            {
                System.Console.WriteLine(" - " + choice.Description);
            }

            // Speak to the strongman
            System.Console.WriteLine(barCarRoom.ProcessChoice(gameState, 1));

            // Go to the tattoo room
            System.Console.WriteLine(tattooRoom.GetDescription(gameState));

            //Display the TATTO choices
            foreach (var choice in tattooRoom.GetChoices(gameState))
            {
                System.Console.WriteLine(" - " + choice.Description);
            }

            // Ask about a tattoo
            System.Console.WriteLine(tattooRoom.ProcessChoice(gameState, 1));

            // Display TATT choices
            foreach (var choice in tattooRoom.GetChoices(gameState))
            {
                System.Console.WriteLine(" - " + choice.Description);
            }

            System.Console.WriteLine("Your beard length is: " + gameState.BeardLength);

            // Get a neck tattoo
            System.Console.WriteLine(tattooRoom.ProcessChoice(gameState, 2));

            System.Console.WriteLine("Your beard length is: " + gameState.BeardLength);

            // Take a puff from the hookah
            System.Console.WriteLine(tattooRoom.ProcessChoice(gameState, 4));

            System.Console.WriteLine("Your beard length is: " + gameState.BeardLength);

            // Display TATT choices
            foreach (var choice in tattooRoom.GetChoices(gameState))
            {
                System.Console.WriteLine(" - " + choice.Description);
            }

            // Go to the bar car
            System.Console.WriteLine(barCarRoom.GetDescription(gameState));

            // Talk to the strongman again
            System.Console.WriteLine(barCarRoom.ProcessChoice(gameState, 1));

            //Display the choices
            foreach (var choice in barCarRoom.GetChoices(gameState))
            {
                System.Console.WriteLine(" - " + choice.Description);
            }

            // Take a drink
            System.Console.WriteLine(barCarRoom.ProcessChoice(gameState, 2));
            System.Console.WriteLine("Your beard length is: " + gameState.BeardLength);

            // Pick up the flowers
            System.Console.WriteLine(barCarRoom.ProcessChoice(gameState, 3));

            //Display the choices
            foreach (var choice in barCarRoom.GetChoices(gameState))
            {
                System.Console.WriteLine(" - " + choice.Description);
            }

            // Take another drink
            System.Console.WriteLine(barCarRoom.ProcessChoice(gameState, 2));
            System.Console.WriteLine("Your beard length is: " + gameState.BeardLength);

            // Go to the tattoo room
            System.Console.WriteLine(tattooRoom.GetDescription(gameState));

            // Get a tattoo
            System.Console.WriteLine(tattooRoom.ProcessChoice(gameState, 1));



            // Go to the bar car
            System.Console.WriteLine(barCarRoom.GetDescription(gameState));

            //Display the choices
            foreach (var choice in barCarRoom.GetChoices(gameState))
            {
                System.Console.WriteLine(" - " + choice.Description);
            }



            // Take another drink
            System.Console.WriteLine(barCarRoom.ProcessChoice(gameState, 2));
            System.Console.WriteLine("Your beard length is: " + gameState.BeardLength);

            // Go to the tatt room
            System.Console.WriteLine(tattooRoom.GetDescription(gameState));

            //Display the choices
            foreach (var choice in barCarRoom.GetChoices(gameState))
            {
                System.Console.WriteLine(" - " + choice.Description);
            }

            // Ask about arm wrestling
            System.Console.WriteLine(barCarRoom.ProcessChoice(gameState, 4));

            //Display the choices
            foreach (var choice in barCarRoom.GetChoices(gameState))
            {
                System.Console.WriteLine(" - " + choice.Description);
            }

            // Arm wrestle
            System.Console.WriteLine(barCarRoom.ProcessChoice(gameState, 5));
            System.Console.WriteLine("Your beard length is: " + gameState.BeardLength);

            // Take another drink
            System.Console.WriteLine(barCarRoom.ProcessChoice(gameState, 2));
            System.Console.WriteLine("Your beard length is: " + gameState.BeardLength);

            // print out new gamestate stat (tattoo) and new room description
            //System.Console.WriteLine(barCarRoom.GetDescription(gameState));

        }
    }
}
