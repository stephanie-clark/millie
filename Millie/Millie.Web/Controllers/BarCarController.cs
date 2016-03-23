﻿using System;
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
            Game.GameState gameState = Helpers.GameStateStorage.GetGameState(HttpContext);
            Game.BarCarRoom barCarRoom = new Game.BarCarRoom();

            // Build up a view model
            var viewModel = new Models.BarCarViewModel();
            viewModel.Description = barCarRoom.GetDescription(gameState);

            // Get the choices view model
            List<Game.PlayerChoice> choices = barCarRoom.GetChoices(gameState);
            foreach (Game.PlayerChoice choice in choices)
            {
                // Convert the choice into a choice view model
                var playerChoiceViewModel = new Models.PlayerChoiceViewModel(choice);
                viewModel.Choices.Add(playerChoiceViewModel);
            }

            // Return the view
            return View("Index", viewModel);
        }

        public ActionResult ProcessChoice(int choiceId)
        {
            // Get the game state and the room
            var barCarRoom = new Game.BarCarRoom();
            var gameState = Helpers.GameStateStorage.GetGameState(HttpContext);

            // Process the choice
            var result = barCarRoom.ProcessChoice(gameState, choiceId);

            // Store the game state back in cache
            Helpers.GameStateStorage.StoreGameState(HttpContext, gameState);

            // Store the result in the view bag
            ViewBag.ProcessChoiceResponse = result;

            // Return the view
            return Index();
        }
    }
}