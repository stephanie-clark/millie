﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Millie.Web.Controllers
{
    public class MainTentController : Controller
    {
        // GET: MainTent
        public ActionResult Index()
        {
            // New up the game state and room
            Game.GameState gameState = Helpers.GameStateStorage.GetGameState();
            Game.MainTentRoom mainTentRoom = new Game.MainTentRoom();

            // Build up a view model
            var viewModel = new Models.MainTentViewModel();
            viewModel.Description = mainTentRoom.GetDescription(gameState);

            // Store the game state
            Helpers.GameStateStorage.StoreGameState(gameState);

            // Get the choices view model
            List<Game.PlayerChoice> choices = mainTentRoom.GetChoices(gameState);
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
            var mainTentRoom = new Game.MainTentRoom();
            var gameState = Helpers.GameStateStorage.GetGameState();

            // Process the choice
            var result = mainTentRoom.ProcessChoice(gameState, choiceId);

            // Store the game state back in cache
            Helpers.GameStateStorage.StoreGameState(gameState);

            // Store the result in the view bag
            ViewBag.ProcessChoiceResponse = result;

            // Return the view
            return Index();
        }
    }
}