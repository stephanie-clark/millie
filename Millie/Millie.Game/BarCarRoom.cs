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
            var barCarDescription = "You are in the bar car. ";

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

            // Ask for a drink (if you haven't had the elixer)
            if (!gameState.DrankElixer)
            {
                var drinkChoice = new PlayerChoice { Id = 2, Description = "Ask the strongman for a drink" };
                choices.Add(drinkChoice);
            }

            // Choice to clean up the flowers, but only if you've already asked about them
            if (gameState.AskedAboutFlowers && !gameState.HasFlowers)
            {
                var cleanFlowers = new PlayerChoice { Id = 3, Description = "Clean up the flowers" };
                choices.Add(cleanFlowers);
            }

            // Choice to ask about arm wrestling, but only if you have at least a small beard and haven't asked about it yet
            if (gameState.BeardLength >= 1 && !gameState.AskedAboutArmWrestling)
            {
                var askArmWrestle = new PlayerChoice { Id = 4, Description = "Ask the strongman about arm wrestling." };
                choices.Add(askArmWrestle);
            }

            // If you've already asked about arm wresting, you can arm wrestle 
            if (gameState.AskedAboutArmWrestling)
            {
                var ArmWrestle = new PlayerChoice { Id = 5, Description = "Arm wrestle the strongman!" };
                choices.Add(ArmWrestle);
            }



            return choices;
        }

        /// <summary>
        /// Process the choice a player made
        /// </summary>
        public override string ProcessChoice(GameState gameState, int choiceId)
        {
            // Process talking to the strongman about the flowers
            if (choiceId == 1)
            {
                // Note that you'va asked about the flowers
                gameState.AskedAboutFlowers = true;

                var explainFlowers = "These flowers are from my girlfriend. We got into a fight and she's trying to say sorry. She's a magician though man. She can make flowers appear out of thin air. It kinda looses it's romanticness after a while.";

                if (gameState.ApproachGoats && gameState.GotTattoo)
                {
                    return "You smell like goats... but I like your tattoo!" + explainFlowers;
                }

                // If you have a tattoo - he likes it
                if (gameState.GotTattoo)
                {
                    return "Wow, cool tattoo! " + explainFlowers;
                }

                // If you have been near the goats, you smell bad
                if (gameState.ApproachGoats)
                {
                    return "You smell like goats. " + explainFlowers;
                }

                // Otherwise he just says hello
                return "These flowers are from my girlfriend. We got into a fight and she's trying to say sorry. She's a magician though man. She can make flowers appear out of thin air. It kinda looses it's romanticness after a while.";
            }

            // Process if you take a drink
            if (choiceId == 2)
            {
                // One Drink
                if (gameState.NumberOfShotsTaken == 0)
                { 
                    gameState.NumberOfShotsTaken++;
                    return "you took a drink. you have had " + gameState.NumberOfShotsTaken + " drink";
                }

                // Two Drinks
                else if (gameState.NumberOfShotsTaken == 1)
                {
                    gameState.NumberOfShotsTaken++;
                    gameState.BeardLength++;
                    return "you took a drink. you have had " + gameState.NumberOfShotsTaken + " drinks. Your beard magically grows! That's cool. You can stop drinking now.";
                }

                // Three drinks
                else if (gameState.NumberOfShotsTaken == 2)
                {
                    gameState.NumberOfShotsTaken++;
                    gameState.BeardLength++;
                    return "you took a drink. you have had " + gameState.NumberOfShotsTaken + " drinks. You beard grows again... but I wouldn't take another if I were you. seriously.";
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

            // Process if you ask about arm wrestling
            if (choiceId == 4)
            {
                gameState.AskedAboutArmWrestling = true;
                return "'ARE YOU SURE? I NEVER LOSE!'  'I'll let you cut off my beard if I win!' 'Are you really really sure?'";
            }

            if (choiceId == 5)
            {
                if(gameState.BeardLength >= 2)
                {
                    gameState.BeardLength = gameState.BeardLength - 2;
                    return "Strongman wins and cuts off your beard.";
                }
                else if(gameState.BeardLength <= 1)
                {
                    gameState.BeardLength = gameState.BeardLength - 1;
                    return "Strongman wins and cuts off your beard.";
                }
                
                
            }

            // Unsupported choice
            return "I don't understand what you're trying to do...";
        }
    }
}
