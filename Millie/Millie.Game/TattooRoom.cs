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
            var tattooRoomDescription = "You are in the Tattoo Room. It is small and cozy. There's pretty art on the walls. There is a hookah sitting next to the tattooed lady.";

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
            if (!gameState.GotTattoo && !gameState.AskAboutTattoo)
            { 
                var getTattooChoice = new PlayerChoice { Id = 1, Description = "Ask about a tattoo" };
                results.Add(getTattooChoice);
            }

            if (gameState.AskAboutTattoo && !gameState.GotTattoo)
            {

                var getNeckTattoo = new PlayerChoice { Id = 2, Description = "Get a neck tattoo" };
                results.Add(getNeckTattoo);

                var getArmTattoo = new PlayerChoice { Id = 3, Description = "Get an arm tattoo" };
                results.Add(getArmTattoo);

            }

            if (!gameState.UsedHookah)
            {
                var tryTheHookah = new PlayerChoice { Id = 4, Description = "Try the hookah" };
                results.Add(tryTheHookah);
            }

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
                    gameState.AskAboutTattoo = true;
                    return "Where do you want it?";
                }
            }

            // You get a neck tattoo
            if (choiceId == 2)
            {
                gameState.GotTattoo = true;
                gameState.GotNeckTattoo = true;
                gameState.BeardLength--;
                return "Awesome, look at this beautiful tattoo! We must cut your beard so you can show it off!";
            }

            // You get an arm tattoo
            if (choiceId == 3)
            {
                gameState.GotTattoo = true;
                gameState.GotArmTattoo = true;
                return "Awesome, look at this beautiful tattoo!";
            }

            if (choiceId == 4)
            {
                gameState.BeardLength++;
                gameState.UsedHookah = true;
                return "You take a hit off the hookah. Your beard grows!";
            }

            throw new Exception("Something weird happened");
        }
    }
}
