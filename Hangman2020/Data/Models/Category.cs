using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman2020.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string CategoryName { get; set; }

    }
}
