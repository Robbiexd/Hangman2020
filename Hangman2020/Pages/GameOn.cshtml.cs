using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hangman2020.Pages
{
    public class GameOnModel : PageModel
    {
        public int CatId { get; set; }

        public void OnGet(int id)
        {
            CatId = id;
        }

        // TODO uložit vse do sessionu 
    }
}