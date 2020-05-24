using Hangman2020.Data.Models;
using Hangman2020.Data.Models.InGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman2020.Services
{
    public interface ISiteFunctionality
    {
        /// <summary>
        /// gets logged in users id
        /// </summary>
        /// <returns></returns>
        string GetUserId();

        /// <summary>
        /// string = game id
        /// </summary>
        /// <param name="key"></param>
        /// <param name="wordId"></param>
        void SaveGameState(string key, InGame inGame); 

        InGame LoadGameState(string key); 

        /// <summary>
        /// Gets List of all categories
        /// </summary>
        /// <returns></returns>
        IList<Category> GetCategories();

        string GetCategoryName(int categoryId);

        /// <summary>
        /// Gets random word from the category that has not been guessed and splits it into chars
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        string GetRandomWord(int categoryId); 

        /// <summary>
        /// Gets a list of players and their guessed words
        /// </summary>
        /// <returns></returns>
        IList<User> GetTopPlayers(); // TODO Get top players

        InGame GetCurrentGameData(int categoryId);
    }
}
