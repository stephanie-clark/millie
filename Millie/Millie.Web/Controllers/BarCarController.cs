using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Millie.Web.Controllers
{
    public class BarCarController : Controller
    {
        // GET: BarCar
        public ActionResult Index()
        {
            // New up the game state and room
            var gameState = new Game.GameState();
            var barCarRoom = new Game.BarCarRoom();

            // Build up a view model
            var viewModel = new Models.BarCarViewModel();
            viewModel.Description = barCarRoom.GetDescription(gameState);

            // Get the choices view model
            var choices = barCarRoom.GetChoices(gameState);
            foreach (var choice in choices)
            {
                var choiceViewModel = new Models.PlayerChoiceViewModel(choice);
                viewModel.Choices.Add(choiceViewModel);
            }

            // Return the view
            return View(viewModel);
        }
    }
}