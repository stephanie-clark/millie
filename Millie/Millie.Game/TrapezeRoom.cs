﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie.Game
{
    public class TrapezeRoom : Room
    {

        /// <summary>
        /// Get a description of the room given a current state of the game
        /// </summary>
        public override string GetDescription(GameState gameState)
        {
            {
                // Determine if we've previously visited
                var hasPreviouslyVisited = gameState.VisitedTrapezeRoom;

                // Description of the main tent
                var TrapezeRoomDescription = "You are at the top of the trapeze.";

                // Set that we've visited the room
                gameState.VisitedTrapezeRoom = true;

                // If millie is drunk
                if (gameState.NumberOfShotsTaken == 3)
                {
                    gameState.NumberOfShotsTaken = 0;
                    gameState.DrankElixer = true;
                    return "You're too drunk to talk to. Here, drink this elixer. You'll feel better. " + TrapezeRoomDescription;
                }


                // if Millie has not visited all three rooms yet
                if (!gameState.VisitedMainTent || !gameState.VisitedTattooRoom || !gameState.VisitedBarCar)
                {
                    return TrapezeRoomDescription + "No one is here. you're too early. Go visit some more friends.";
                }

                return TrapezeRoomDescription;
            }
        }

        public override List<PlayerChoice> GetChoices(GameState gameState)
        {

            var choices = new List<PlayerChoice>();

            // You can approach the SA only if you have visited all three rooms
            if (gameState.VisitedMainTent && gameState.VisitedTattooRoom && gameState.VisitedBarCar && !gameState.MadeFinalChoice)
            { 
                var meetAdmirer = new PlayerChoice { Id = 1, Description = "Meet your secret admirer" };
                choices.Add(meetAdmirer);

                var runAway = new PlayerChoice { Id = 2, Description = "Run Away" };
                choices.Add(runAway);
            }

            return choices;
        }

        public override string ProcessChoice(GameState gameState, int choiceId)
        {

            if (choiceId == 1)
            {
                gameState.MadeFinalChoice = true;
                var gameOver = "Game Over!";

                if(gameState.BeardLength >= 4)
                {
                    return "Your beard is so long and beautiful! " + gameOver;
                }

                if (gameState.BeardLength >= 2)
                {
                    return "Your beard is pretty nice, but I wish it was longer! " + gameOver;
                }

                if (gameState.BeardLength >= 0)
                {
                    return "What happened to your beard??! " + gameOver;
                }

                return "GAME OVER!";
            }

            if (choiceId == 2)
            {
                gameState.MadeFinalChoice = true;
                return "You run away. You'll never know who your secret admirer was. So sad.";
            }

            throw new NotImplementedException();
        }
    }
}
