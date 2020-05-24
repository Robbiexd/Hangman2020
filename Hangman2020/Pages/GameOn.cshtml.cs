﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Hangman2020.Data.Models.InGame;
using Hangman2020.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hangman2020.Pages
{
    [Authorize]
    public class GameOnModel : PageModel
    {
        private readonly ISiteFunctionality _siteFunctionality;
        

        public InGame GameData { get; set; }
        public string CategoryName { get; set; }

        public string ImagePath { get; set; }

        public int Hearts { get; set; } = 8;


        public GameOnModel(ISiteFunctionality siteFunctionality)
        {
            _siteFunctionality = siteFunctionality;
        }

        public void OnGet(int id)
        {
            GameData = _siteFunctionality.GetCurrentGameData(id);
            CategoryName = _siteFunctionality.GetCategoryName(id);
            Hearts = Hearts - GameData.TriedLetters.Count();
        }

        public IActionResult OnPostPlayGame(char letter)
        {
            _siteFunctionality.TryToGuessLetter(letter, GameData);
            return RedirectToPage("GameOn");
        }


    }
}