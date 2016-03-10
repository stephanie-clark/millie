using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie.Game
{
    /// <summary>
    /// Represents a choice a player can make in a room
    /// </summary>
    public class PlayerChoice
    {
        /// <summary>
        /// The id of the choice
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The description of the choice
        /// </summary>
        public string Description { get; set; }
    }
}
