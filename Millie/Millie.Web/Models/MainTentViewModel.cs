using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Millie.Web.Models
{
    public class MainTentViewModel
    {
        // A list of choices for the player
        public MainTentViewModel()
        {
            Choices = new List<PlayerChoiceViewModel>();
        }

        public string Description { get; set; }

        public List<PlayerChoiceViewModel> Choices { get; set; }

    }
}