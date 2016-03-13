using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie.Game
{
    public class TattooRoom : Room
    {
        /// <summary>
        /// Get a description of the room given a current state of the game
        /// </summary>
        public override string GetDescription(GameState gameState)
        {
            // Determine if we've previously visited
            var hasPreviouslyVisited = gameState.VisitedTattooRoom;

            // Set that we've visited the room
            gameState.VisitedTattooRoom = true;

            // Give the general description
            var tattooRoomDescription = "You are in the Tattoo Room. It is small and cozy. There's pretty art on the walls.";

            // If millie is drunk
            if (gameState.NumberOfShotsTaken == 3)
            {
                gameState.NumberOfShotsTaken = 0;
                gameState.DrankElixer = true;
                return "You're too drunk to talk to. Here, drink this elixer. You'll feel better. " + tattooRoomDescription;
            }

            // if Millie has visited the Tattood Lady
            if (hasPreviouslyVisited)
            {
                return "Welcome back! " + tattooRoomDescription;
            }

            return tattooRoomDescription + "This is your first time here.";            
        }

       

        /// <summary>
        /// Get a list of choices the player has in this room given a gamestate
        /// </summary>
        public override List<PlayerChoice> GetChoices(GameState gameState)
        {
            var results = new List<PlayerChoice>();

            // Get a tattoo, if Millie doesn't already have one
            if (!gameState.GotTattoo)
            { 
                var getTattooChoice = new PlayerChoice { Id = 1, Description = "Get a tattoo" };
                results.Add(getTattooChoice);
            }

            var someOtherChoice = new PlayerChoice { Id = 2, Description = "Some other choice" };
            results.Add(someOtherChoice);

            return results;
        }

        /// <summary>
        /// Process the choice a player made
        /// </summary>
        public override string ProcessChoice(GameState gameState, int choiceId)
        {
            if (choiceId == 1)
            {
                if (gameState.GotTattoo)
                {
                    return "You already have a tattoo, I won't give you two on the same day.";
                }
                else
                {
                    gameState.GotTattoo = true;
                    return "You got a tattoo! It's lovely!";
                }
            }

            if (choiceId == 2)
                return "Some other result";

            throw new Exception("Something weird happened");
        }
    }
}
