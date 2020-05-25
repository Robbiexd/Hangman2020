using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman2020.Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<GuessedWord> guessedWords { get; set; }
        public int GuessedWordCount { get; set; }
    }
}
