using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Millie.Web.Helpers
{
    public static class GameStateStorage
    {
        private static string ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\szuro\Dropbox\Development\gihub\millie\Millie\Millie.Web\App_Data\Database.mdf;Integrated Security=True";

        public static Game.GameState GetGameState()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                // Open the connection
                connection.Open();

                // Query the database for our game state
                var serializedGameState = connection
                                .Query<string>("select SerializedGameState from GameState where username = @username", new { username = "Stephanie" })
                                .FirstOrDefault();

                // Close the connection
                connection.Close();

                // If no state was found - return a new one
                if (serializedGameState == null) return new Game.GameState();

                // Deserialize the json string into a game state and return that
                return JsonConvert.DeserializeObject<Game.GameState>(serializedGameState);                
            }
        }

        public static void StoreGameState(Game.GameState gameState)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                // Open the connection
                connection.Open();

                // Serialize the game state
                var serializedGameState = JsonConvert.SerializeObject(gameState);

                // Save it
                connection.Query(@"
                                    delete from GameState where Username = @Username
                                    insert GameState(Username, SerializedGameState) values (@Username, @SerializedGameState)",
                                new { Username = "Stephanie", SerializedGameState = serializedGameState });

                // Close the connection
                connection.Close();
            }
                
        }

        public static void ClearGameState()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                // Open the connection
                connection.Open();

                // Save it
                connection.Query(@"delete from GameState where Username = @Username", new { Username = "Stephanie" });

                // Close the connection
                connection.Close();
            }
        }
    }
}