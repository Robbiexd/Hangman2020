using Hangman2020.Data;
using Hangman2020.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman2020.Services
{
    public class BussinessLogic : ISiteFunctionality
    {
        private readonly ApplicationDbContext _db;
        private readonly ISession _session;
        private readonly IHttpContextAccessor _hca;

        public BussinessLogic(ApplicationDbContext db, IHttpContextAccessor hca)
        {
            _db = db;
            _session = hca.HttpContext.Session;
            _hca = hca;
        }

        IList<Category> ISiteFunctionality.GetCategories()
        {
            IList<Category> list = _db.Categories.AsNoTracking().ToList();
            return list;
        }

        IList<char> ISiteFunctionality.GetRandomWord(int categoryId, int userId)
        {
            throw new NotImplementedException();
        }

        IList<User> ISiteFunctionality.GetTopPlayers()
        {
            throw new NotImplementedException();
        }

        string ISiteFunctionality.GetUserId()
        {
            return _hca.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? default;
        }

        void ISiteFunctionality.SaveWordState(string key, string id)
        {
            _session.Set(key, Encoding.UTF8.GetBytes(id));
        }
    }
}
