using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangman2020.Data.Models;
using Hangman2020.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hangman2020.Pages
{
    public class TopPlayersModel : PageModel
    {
        private readonly ISiteFunctionality _siteFunctionality;

        public IList<User> TopPlayers { get; set; }

        public TopPlayersModel(ISiteFunctionality siteFunctionality)
        {
            _siteFunctionality = siteFunctionality;
        }
        public void OnGet()
        {
            TopPlayers = _siteFunctionality.GetTopPlayers();
        }
    }
}