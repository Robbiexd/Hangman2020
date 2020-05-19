using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman2020.Data.Models
{
    public class GuessedWord
    {
        [Key]
        public int Id { get; set; }
        public int WordId { get; set; }

        [ForeignKey("WordId")]
        public Word Word { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
