using Hangman2020.Data;
using Hangman2020.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman2020.Services
{
    public class BussinessLogic : ISiteFunctionality
    {
        private readonly ApplicationDbContext _db;

        public BussinessLogic(ApplicationDbContext db)
        {
            _db = db;
        }

        IList<Category> ISiteFunctionality.GetCategories()
        {
            IList<Category> list = _db.Categories.AsNoTracking().ToList();
            return list;
        }

        string ISiteFunctionality.GetUserId()
        {
            throw new NotImplementedException();
        }

        void ISiteFunctionality.SaveGame(string key, string id)
        {
            throw new NotImplementedException();
        }
    }
}
