using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman2020.Data.Models.InGame
{   
    /// <summary>
    /// Model, který obsahuje jeden znak a jeho stav (uhodlý/neuhodlý)
    /// </summary>
    public class CharInWord
    {   
        public char Letter { get; set; }
        public bool Guessed { get; set; }
    }
}
