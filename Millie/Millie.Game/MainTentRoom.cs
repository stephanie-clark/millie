using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie.Game
{
    public class MainTentRoom : Room
    {

        /// <summary>
        /// Get a description of the room given a current state of the game
        /// </summary>
        public override string GetDescription(GameState gameState)
        {
            {
                // Determine if we've previously visited
                var hasPreviouslyVisited = gameState.VisitedMainTent;

                // Description of the main tent
                var mainTentDescription = "You are in the main tent. The lion tamer is here with goats instead of lions! She seems like she's in a really bad mood.";

                // Set that we've visited the room
                gameState.VisitedMainTent = true;

                // If millie is drunk
                if (gameState.NumberOfShotsTaken == 3)
                {
                    gameState.NumberOfShotsTaken = 0;
                    gameState.DrankElixer = true;
                    return "You're too drunk to talk to. Here, drink this elixer. You'll feel better. " + mainTentDescription;
                }

                // if Millie has visited already
                if (hasPreviouslyVisited)
                {
                    return mainTentDescription + "Welcome back!";
                }

                return mainTentDescription + "This is your first time here.";
            }
        }

        public override List<PlayerChoice> GetChoices(GameState gameState)
        {

            var choices = new List<PlayerChoice>();

            // Compliment the lion tamer
            var saySomethingNice = new PlayerChoice { Id = 1, Description = "Compliment the lion tamer" };
            choices.Add(saySomethingNice);

            // If you have complimented the lion tamer, you can ask about the lion's shampoo
            if (gameState.GaveCompliment)
            {
                var askAboutShampoo = new PlayerChoice { Id = 2, Description = "Ask about the Lion's Shampoo" };
                choices.Add(askAboutShampoo);
            }

            // Ask the Lion Tamer about the goats
            if (!gameState.AskAboutGoats)
            {
                var askGoats = new PlayerChoice { Id = 3, Description = "Ask about the goats" };
                choices.Add(askGoats);
            }

            // If you have asked about the goats, you can approach them
            if (gameState.AskAboutGoats)
            {
                var approachGoats = new PlayerChoice { Id = 4, Description = "Go pet the goats!" };
            }



            throw new NotImplementedException();
        }

        public override string ProcessChoice(GameState gameState, int choiceId)
        {

            if (choiceId == 1)
            {
                gameState.GaveCompliment = true;
                return "'Your face is glowing and your hair looks lovely, lion tamer.' Says Millie. 'Wow thanks! Want to know my secret? Every morning I apply the Lion Mane Shampoo. It really works wonders!'";
            }

            if (choiceId == 2)
            {
                gameState.BeardLength++;
                return "The lion tamer pulls a bottle from her pocket. 'Open your hands!' She puts some on your palm and you run it through your beard. Your beard grows!";
            }

            if (choiceId == 3)
            {
                // Note that you'va asked about the goats
                gameState.AskAboutGoats = true;

                return "The lions are sick so I'm practicing with goats! They are hungry, so be careful if you pet them!";
   
            }

            // Approach the goats
            if (choiceId == 4)
            {
                // If you have the flowers, the goats eat the flowers
                if (gameState.HasFlowers)
                {
                    return "The goats notice the flowers in your beard and eat them!";
                }

                // If you don't have the flowers, the goats eat your beard
                else if (!gameState.HasFlowers)
                {
                    gameState.BeardLength--;
                    return "The goats nuzzle you but they're distracted by hunger and take a few bites from your beard!";
                }

            }

            throw new NotImplementedException();
        }
    }
}
