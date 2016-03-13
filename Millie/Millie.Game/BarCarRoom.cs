using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie.Game
{
    public class BarCarRoom : Room
    {
        /// <summary>
        /// Get a description of the room given a current state of the game
        /// </summary>
        public override string GetDescription(GameState gameState)
        {
            // Determine if we've previously visited
            var hasPreviouslyVisited = gameState.VisitedBarCar;

            // Description of the bar car
            var barCarDescription = "The bar car is beautiful. ";

            // Set that we've visited the room
            gameState.VisitedBarCar = true;

            // if Millie has visited the Bar Car and has not picked up the flowers
            if(hasPreviouslyVisited && !gameState.HasFlowers)
            {
                return barCarDescription + "Welcome back! There are still flowers everywhere. How strange.";
            }

            // if Millie has visited the Bar Car and HAS picked up the flowers already
            if(hasPreviouslyVisited && gameState.HasFlowers )
            {
                return barCarDescription + "Welcome back! THe flowers are gone.";
            }

            return barCarDescription + "This is your first time here. There are flowers everywhere. How strange.";
        }

        /// <summary>
        /// Get a list of choices the player has in this room given a gamestate
        /// </summary>
        public override List<PlayerChoice> GetChoices(GameState gameState)
        {
            var choices = new List<PlayerChoice>();

            // Ask the Strongman about the flowers (if you don't already have them)
            if (gameState.AskedAboutFlowers == false)
            {
                var talkChoice = new PlayerChoice { Id = 1, Description = "Talk to the strongman about the flowers" };
                choices.Add(talkChoice);
            }

            // Ask for a drink
            var drinkChoice = new PlayerChoice { Id = 2, Description = "Ask the strongman for a drink" };
            choices.Add(drinkChoice);

            // Choice to clean up the flowers, but only if you've already asked about them
            if (gameState.AskedAboutFlowers && !gameState.HasFlowers)
            {
                var cleanFlowers = new PlayerChoice { Id = 3, Description = "Clean up the flowers" };
                choices.Add(cleanFlowers);
            }

            return choices;
        }

        /// <summary>
        /// Process the choice a player made
        /// </summary>
        public override string ProcessChoice(GameState gameState, int choiceId)
        {
            // Process talking to the strongman
            if (choiceId == 1)
            {
                // Note that you'va asked about the flowers
                gameState.AskedAboutFlowers = true;

                // If you have a tattoo - he likes it
                if (gameState.GotTattoo) return "Cool tattoo!";

                // Otherwise he just says hello
                return "'Sup";
            }

            // Process if you take a drink
            if (choiceId == 2)
            {
                // One Drink
                if (gameState.NumberOfShotsTaken == 0)
                { 
                    gameState.NumberOfShotsTaken++;
                    return "you took a drink. you have had " + gameState.NumberOfShotsTaken + " drink(s)";
                }

                // Two Drinks
                else if (gameState.NumberOfShotsTaken == 1)
                {
                    gameState.NumberOfShotsTaken++;
                    gameState.BeardLength++;
                    return "you took a drink. you have had " + gameState.NumberOfShotsTaken + " drink(s). Your beard magically grows! That's cool. You can stop drinking now.";
                }

                // Three drinks
                else if (gameState.NumberOfShotsTaken == 2)
                {
                    gameState.NumberOfShotsTaken++;
                    gameState.BeardLength++;
                    return "you took a drink. you have had " + gameState.NumberOfShotsTaken + " drink(s). You beard grows again... but I wouldn't take another if I were you. seriously.";
                }

                // Four drinks
                else if (gameState.NumberOfShotsTaken >= 3)
                {
                    return "you are drunk. you lose. can't say you weren't warned!";
                }

                else
                {
                    return "durr";
                }
            }

            // Process if you pick up the flowers
            if (choiceId == 3)
            {
                gameState.HasFlowers = true;
                return "you pick up the flowers";
                
            }

            // Unsupported choice
            return "I don't understand what you're trying to do...";
        }
    }
}
