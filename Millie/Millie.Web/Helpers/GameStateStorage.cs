using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Millie.Web.Helpers
{
    public static class GameStateStorage
    {
        public static Game.GameState GetGameState(HttpContextBase context)
        {
            // Check if the game state exists in cache
            var gameState = context.Cache["GameState"];

            // If it doesn't exist in cache, create a new game state and cache it
            if (gameState == null)
            {
                gameState = new Game.GameState();
                StoreGameState(context, (Game.GameState)gameState);
            }

            // Return the game state
            return (Game.GameState)gameState;
        }

        public static void StoreGameState(HttpContextBase context, Game.GameState gameState)
        {
            context.Cache.Insert("GameState", gameState);
        }

        public static void ClearGameState(HttpContextBase context)
        {
            context.Cache.Remove("GameState");
        }
    }
}