using Hangman2020.Data;
using Hangman2020.Data.Models;
using Hangman2020.Data.Models.InGame;
using Hangman2020.Helpers;
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
        public InGame CurrentGame { get; private set; }
        public BussinessLogic(ApplicationDbContext db, IHttpContextAccessor hca)
        {
            _db = db;
            _session = hca.HttpContext.Session;
            _hca = hca;
            CurrentGame = LoadGameState("activegame");
        }

        public IList<Category> GetCategories()
        {
            IList<Category> list = _db.Categories.AsNoTracking().ToList();
            return list;
        }

        public string GetRandomWord(int categoryId)
        {
            // Z databaze vytahne vsechna slova ktera patri k dane kategorii a ulozi je do listu
            IList<Word> words = _db.Words.Where(o => o.CategoryId == categoryId).AsNoTracking().ToList();
            Random random = new Random();
            int randomId = random.Next(0, words.Count() - 1);
            return words[randomId].Text; // nasledne vytahne nahodne slovo z tohoto listu
        }

        public IList<User> GetTopPlayers()
        {
            throw new NotImplementedException();
        }

        public string GetUserId()
        {
            return _hca.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? default;
        }

        public InGame LoadGameState(string key)
        {
            InGame result = _session.Get<InGame>(key);
            if (typeof(InGame).IsClass && result == null) result = (InGame)Activator.CreateInstance(typeof(InGame));
            return result;
        }

        public void SaveGameState(string key, InGame inGame)
        {
            _session.Set(key, inGame);
        }

        public InGame GetCurrentGameData(int categoryId)
        {
            var game = LoadGameState("activegame");
            // pokud neni zadna hra aktivni v session, vytvori se nova
            if(game.Word is null)
            {
                game.Word = GetRandomWord(categoryId); // vytahne random slovo z database podle zvoleneho tematu

                // pro kazde pismeno v hadanem slove priradi toto pismenko do property Letter v modelu CharInWord nastavi jeho stav Guessed = false
                foreach(var letter in game.Word)
                {
                    CharInWord charInWord = new CharInWord { Guessed = false, Letter = letter };
                    game.WordChars.Add(charInWord);
                }
                SaveGameState("activegame", game);
            }
            return game;
        }

        public string GetCategoryName(int categoryId)
        {
            return _db.Categories.Where(o => o.Id == categoryId).AsNoTracking().FirstOrDefault().Name;
        }

        public void TryToGuessLetter(char letter, InGame game)
        {
            bool guessed = false;
            foreach(CharInWord l in game.WordChars)
            {
                if(l.Letter == letter)
                {
                    guessed = l.Guessed = true;
                }
            }

            if(!guessed)
            {
                game.TriedLetters.Add(letter);
            }

            SaveGameState("activegame", game);
        }
    }
}
