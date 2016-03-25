using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Millie.Web.Models
{
    public class TattooRoomViewModel
    {
        // A list of choices for the player
        public TattooRoomViewModel()
        {
            Choices = new List<PlayerChoiceViewModel>();
        }

        public string Description { get; set; }

        public List<PlayerChoiceViewModel> Choices { get; set; }

    }
}