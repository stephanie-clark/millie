using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Millie.Web.Models
{
    public class TrapezeViewModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TrapezeViewModel()
        {
            Choices = new List<PlayerChoiceViewModel>();
        }

        /// <summary>
        /// The description of the room that you're in
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The choices the player has to interact in their room
        /// </summary>
        public List<PlayerChoiceViewModel> Choices { get; set; }
    }
}