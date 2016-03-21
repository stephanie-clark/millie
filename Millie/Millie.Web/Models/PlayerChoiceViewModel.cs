using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Millie.Web.Models
{
    public class PlayerChoiceViewModel
    {
        public PlayerChoiceViewModel(Game.PlayerChoice playerChoice)
        {
            Id = playerChoice.Id;
            Description = playerChoice.Description;
        }

        /// <summary>
        /// The id of the choice
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// The description of the choice
        /// </summary>
        public string Description { get; private set; }
    }
}