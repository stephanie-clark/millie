using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Millie.Web.Models
{
    public class BarCarViewModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BarCarViewModel()
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