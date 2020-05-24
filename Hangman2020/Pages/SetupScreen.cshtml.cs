using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangman2020.Data.Models;
using Hangman2020.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Hangman2020.Pages
{   
    [Authorize]
    public class SetupScreenModel : PageModel
    {
        private readonly ILogger<SetupScreenModel> _logger;
        private readonly ISiteFunctionality _siteFunctionality;

        public IList<Category> Categories;

        public SetupScreenModel(ILogger<SetupScreenModel> logger, ISiteFunctionality siteFunctionality)
        {
            _logger = logger;
            _siteFunctionality = siteFunctionality;
        }
        public void OnGet()
        {
            Categories = _siteFunctionality.GetCategories();
        }
    }
}