using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Millie.Web.Controllers
{
    public class BeardController : Controller
    {
        // GET: Beard
        public ActionResult Status()
        {
            // Grab the game state
            var gameState = Helpers.GameStateStorage.GetGameState();

            // Build up the view model
            var viewModel = new Models.BeardStatusViewModel { BeardLength = gameState.BeardLength };

            return View(viewModel);
        }
    }
}