using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TweeterFeed.Helpers;
using TweeterFeed.Models;

namespace TweeterFeed
{
    /// <summary>
    /// Main program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// List of users
        /// </summary>
        private static List<User> users;

        /// <summary>
        /// List of tweets
        /// </summary>
        private static List<Tweet> tweets = new List<Tweet>();

        /// <summary>
        /// Program entry point
        /// </summary>
        /// <param name="args">Arguments list</param>
        public static void Main(string[] args)
        {
            try 
            {
                if (args.Length == 2)
                {
                    string usersfile = AppDomain.CurrentDomain.BaseDirectory + args[0];
                    string tweetsfile = AppDomain.CurrentDomain.BaseDirectory + args[1];
                    string extension = Path.GetExtension(tweetsfile);
                    IFileLoader fileloader = FileLoderFactory.CreateFileLoader(extension);
                    users = fileloader.LoadUsers(usersfile);
                    tweets = fileloader.LoadTweets(tweetsfile);
                    List<User> sortedUsers = users.OrderBy(u => u.Username).ToList();
                    foreach (User user in sortedUsers)
                    {
                        PrintTweets(user);
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect parameters supplied");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Write("\nPress any key to exit...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Prints users and their tweets to the console
        /// </summary>
        /// <param name="user">User object</param>
        private static void PrintTweets(User user)
        {
            List<Tweet> usertweets = new List<Tweet>();
            usertweets.AddRange(user.Tweets);
            foreach (var follow in user.Following)
            {
                usertweets.AddRange(follow.Tweets);
            }

            usertweets = usertweets.OrderBy(t => t.Id).ToList();
            Console.WriteLine(user.Username);
            foreach (var tweet in usertweets)
            {
                Console.WriteLine("\t@{0}: {1}", tweet.Username, tweet.TweetText);
            }
        }
    }
}