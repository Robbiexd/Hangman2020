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

        private Word GetRandomWord(int categoryId)
        {
            // Z databaze vytahne vsechna slova ktera patri k dane kategorii a ulozi je do listu
            IList<Word> words = _db.Words.Where(o => o.CategoryId == categoryId).AsNoTracking().ToList();
            Random random = new Random();
            int randomId = random.Next(0, words.Count() - 1);
            return words[randomId]; // nasledne vytahne nahodne slovo z tohoto listu
        }

        public IList<User> GetTopPlayers()
        {
            IList<User> list = _db.ApplicationUsers.OrderByDescending(o => o.GuessedWordCount).AsNoTracking().ToList();
            return list;
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
            var game = CurrentGame;
            // pokud neni zadna hra aktivni v session, vytvori se nova
            if(game.Word is null)
            {
                game.Word = GetRandomWord(categoryId); // vytahne random slovo z database podle zvoleneho tematu

                // pro kazde pismeno v hadanem slove priradi toto pismenko do property Letter v modelu CharInWord nastavi jeho stav Guessed = false
                foreach(var letter in game.Word.Text)
                {
                    CharInWord charInWord = new CharInWord { Guessed = false, Letter = letter };
                    game.WordChars.Add(charInWord);
                }
                game.CategoryName = GetCategoryName(categoryId);
                game.GameProgress = 0;
                SaveGameState("activegame", game);
            }
            return game;
        }

        public string GetCategoryName(int categoryId)
        {
            return _db.Categories.Where(o => o.Id == categoryId).AsNoTracking().FirstOrDefault().Name;
        }

        public void TryToGuessLetter(string letter)
        {
            bool letterGuessed = false;

            foreach(CharInWord l in CurrentGame.WordChars)
            {
                // pokud se písmeno uhodlo (jedno jestli je malé nebo velké)
                if(l.Letter.ToString() == letter || l.Letter.ToString().ToUpper() == letter || l.Letter.ToString().ToLower() == letter)
                {
                    letterGuessed = l.Guessed = true;
                    CurrentGame.GameProgress++;
                }
            }

            // pokud se písmeno neuhodlo
            if(!letterGuessed)
            {
                CurrentGame.TriedLetters.Add(letter);
            }

            SaveGameState("activegame", CurrentGame);
        }

        public bool GamesWon()
        {
            // pokud je celé slovo uhodlé
            if (CurrentGame.GameProgress == CurrentGame.WordChars.Count())
            {      
                // uloží se uhodnuté slovo do databaze
                GuessedWord guessedWord = new GuessedWord { UserId = GetUserId(), WordId = CurrentGame.Word.Id };

                // pricte 1 k GuessedWordCount právě přihlášeného uživatele
                _db.ApplicationUsers.Where(o => o.Id == GetUserId()).SingleOrDefault().GuessedWordCount++;

                _db.GuessedWords.Add(guessedWord);
                _db.SaveChanges();
             
                RestartGame();

                return true;
            }
            return false;
        }

        public bool GamesLost()
        {
            // pokud již uživatel vypotřeboval všechny své pokusy - životy
            if (CurrentGame.TriedLetters.Count() >= 8)
            {

                RestartGame();
                return true;
            }
            return false;
        }

        // smaže se postup hry a uloží do session
        public void RestartGame()
        {
            CurrentGame = null;
            SaveGameState("activegame", CurrentGame);
        }
    }
}
