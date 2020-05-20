using Hangman2020.Data.Models;
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
        /// <param name="id"></param>
        void SaveGame(string key, string id);

        /// <summary>
        /// Gets List of all categories
        /// </summary>
        /// <returns></returns>
        IList<Category> GetCategories();
    }
}
