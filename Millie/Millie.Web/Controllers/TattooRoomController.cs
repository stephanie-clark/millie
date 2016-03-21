using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Millie.Web.Controllers
{
    public class TattooRoomController : Controller
    {
        public ActionResult Index()
        {
            // New up the game state and room
            Game.GameState gameState = new Game.GameState();
            Game.TattooRoom tattooRoom = new Game.TattooRoom();

            // Build up a view model
            var viewModel = new Models.TattooRoomViewModel();
            viewModel.Description = tattooRoom.GetDescription(gameState);

            // Get the choices view model
            List<Game.PlayerChoice> choices = tattooRoom.GetChoices(gameState);
            foreach(Game.PlayerChoice choice in choices)
            {
                // Convert the choice into a choice view model
                var playerChoiceViewModel = new Models.PlayerChoiceViewModel(choice);
                viewModel.Choices.Add(playerChoiceViewModel);                
            }

            // Return the view
            return View(viewModel);
        }
    }
}