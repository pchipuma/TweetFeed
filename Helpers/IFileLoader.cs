using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweeterFeed.Models;

namespace TweeterFeed.Helpers
{
    public interface IFileLoader
    {
        /// <summary>
        /// Creates the list of users from a file
        /// </summary>
        /// <param name="filename">file name with users information</param>
        /// <returns>List of Users</returns>
        List<User> LoadUsers(string filename);

        /// <summary>
        /// Read the tweets file 
        /// </summary>
        /// <param name="filename">full path to the tweet file</param>
        /// <returns>List of Tweets</returns>
        List<Tweet> LoadTweets(string filename);

    }
}
