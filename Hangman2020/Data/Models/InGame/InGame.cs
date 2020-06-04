using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman2020.Data.Models.InGame
{
    /// <summary>
    /// Model, který drží všechna herní data aktivní hry (ukládá do session)
    /// </summary>
    public class InGame
    {

        public List<CharInWord> WordChars { get; set; } = new List<CharInWord>();

        public List<string> TriedLetters { get; set; } = new List<string>();

        public Word Word { get; set; }

        public string CategoryName { get; set; }

        public int GameProgress { get; set; }

        public string UserId { get; set; }

    }
}
