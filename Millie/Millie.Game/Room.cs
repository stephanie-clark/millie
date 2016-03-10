using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie.Game
{
    public abstract class Room
    {
        public int Id { get; set; }

        /// <summary>
        /// Get a description of the room given a current state of the game
        /// </summary>
        public abstract string GetDescription(GameState gameState);

        /// <summary>
        /// Get a list of choices the player has in this room given a gamestate
        /// </summary>
        public abstract List<PlayerChoice> GetChoices(GameState gameState);

        /// <summary>
        /// Process the choice a player made
        /// </summary>
        public abstract string ProcessChoice(GameState gameState, int choiceId);
    }
}
