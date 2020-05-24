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

        public List<char> TriedLetters { get; set; } = new List<char>();

        public int Hearts { get; set; }

        public string Word { get; set; }

    }
}
