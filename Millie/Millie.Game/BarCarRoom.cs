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

            // Set that we've visited the room
            gameState.VisitedBarCar = true;

            // if Millie has visited the Bar Car
            if(hasPreviouslyVisited)
            {
                return "You're back to the bar car!";
            }

            return "Your first time into the bar car!";
        }

        /// <summary>
        /// Get a list of choices the player has in this room given a gamestate
        /// </summary>
        public override List<PlayerChoice> GetChoices(GameState gameState)
        {
            var choices = new List<PlayerChoice>();

            // Ask the Strongman about the flowers (if you don't have them)
            if (gameState.AskedAboutFlowers == false)
            {
                var talkChoice = new PlayerChoice { Id = 1, Description = "Talk to the strongman about the flowers" };
                choices.Add(talkChoice);
            }

            var drinkChoice = new PlayerChoice { Id = 2, Description = "Ask the strongman for a drink" };
            choices.Add(drinkChoice);

            // Choice to clean up the flowers
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
                if (gameState.NumberOfShotsTaken == 0)
                { 
                    gameState.NumberOfShotsTaken++;
                    return "you took a drink. you have had " + gameState.NumberOfShotsTaken + " drink(s)";
                }

                if (gameState.NumberOfShotsTaken == 1)
                {
                    gameState.NumberOfShotsTaken++;
                    gameState.BeardLength++;
                    return "you took a drink. you have had " + gameState.NumberOfShotsTaken + " drink(s). Your beard magically grows!";
                }

                else if (gameState.NumberOfShotsTaken == 2)
                {
                    gameState.NumberOfShotsTaken++;
                    return "you took a drink. you have had " + gameState.NumberOfShotsTaken + " drink(s). I wouldn't take another if I were you.";
                }

                else if (gameState.NumberOfShotsTaken == 3)
                {
                    return "you are drunk. you lose.";
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
