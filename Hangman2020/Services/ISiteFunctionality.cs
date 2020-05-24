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

        /// <summary>
        /// Loads the saved progress from session
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        InGame LoadGameState(string key); 

        /// <summary>
        /// Gets List of all categories
        /// </summary>
        /// <returns></returns>
        IList<Category> GetCategories();

        /// <summary>
        /// Gets the name of a category by Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets all the game data from session or creates new game data 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        InGame GetCurrentGameData(int categoryId);

        /// <summary>
        /// A method thats executed when a user tries to guess a letter in the word
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="game"></param>
        void TryToGuessLetter(char letter, InGame game);
    }
}
