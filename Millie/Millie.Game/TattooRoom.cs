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

            // If Millie has already received a tattoo comment on it
            if (gameState.GotTattoo) return "Cool tattoo!";

            // if Millie has visited the Tattood Lady
            if (hasPreviouslyVisited)
            {
                return "Visited Tattoo Room";
            }

            return "Has not visited Tattoo Room";            
        }

        /// <summary>
        /// Get a list of choices the player has in this room given a gamestate
        /// </summary>
        public override List<PlayerChoice> GetChoices(GameState gameState)
        {
            var results = new List<PlayerChoice>();

            var getTattooChoice = new PlayerChoice { Id = 1, Description = "Get a tattoo" };
            results.Add(getTattooChoice);

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
                    return "You already have one";
                }
                else
                {
                    gameState.GotTattoo = true;
                    return "You got a tattoo!";
                }
            }

            if (choiceId == 2)
                return "Some other result";

            throw new Exception("Something weird happened");
        }
    }
}
