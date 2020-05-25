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

        public List<User> users { get; set; }

        public TopPlayersModel()
        {

        }
        public void OnGet()
        {

        }
    }
}