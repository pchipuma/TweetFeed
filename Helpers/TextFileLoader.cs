using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TweeterFeed.Models;

namespace TweeterFeed.Helpers
{
    public class TextFileLoader : IFileLoader
    {
        /// <summary>
        /// List of users
        /// </summary>
        private static List<User> Users;

        /// <summary>
        /// Creates the list of users
        /// </summary>
        /// <param name="filename">file name with users information</param>
        public List<User> LoadUsers(string filename)
        {
                Users = new List<User>();
                var lines = File.ReadAllLines(filename);
                foreach (var line in lines)
                {
                    string delimiter = "follows";
                    if (line.Contains(delimiter))
                    {
                        var users = line.Split(new[] { delimiter }, StringSplitOptions.None);
                        string username = users[0].Trim();
                        User user = Users.Find(u => u.Username == username);
                        if (user == null)
                        {
                            user = new User();
                            user.Username = username;
                            Users.Add(user);
                        }

                        var list = users[1].Split(',');
                        foreach (var item in list)
                        {
                            string userfollowing = item.Trim();
                            User f = Users.Find(u => u.Username == userfollowing);
                            if (f == null)
                            {
                                f = new User();
                                f.Username = userfollowing;
                                user.Following.Add(f);
                                Users.Add(f);
                            }
                            else
                            {
                                User alreadyFollowing = user.Following.Find(c => c.Username == userfollowing);
                                if (alreadyFollowing == null)
                                {
                                    user.Following.Add(f);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input encountered in user input file");
                        continue;
                    }
                    
                }
                return Users;
        }

        /// <summary>
        /// Read the tweets file 
        /// </summary>
        /// <param name="filename">full path to the tweet file</param>
        public List<Tweet> LoadTweets(string filename)
        {
            try
            {
                List<Tweet> tweets = new List<Tweet>();
                string[] tweetlines = File.ReadAllLines(filename);
                foreach (var tweetline in tweetlines)
                {
                    char delimiter = '>';
                    if (tweetline.Contains(delimiter))
                    {
                        string[] usertweet = tweetline.Split('>');
                        User user = Users.Find(u => u.Username == usertweet[0]);
                        if (user != null)
                        {
                            Tweet tweet = new Tweet();
                            tweet.Id = tweets.Count() + 1;
                            tweet.Username = usertweet[0].Trim();
                            tweet.TweetText = usertweet[1].Trim();
                            user.Tweets.Add(tweet);
                            tweets.Add(tweet);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input encountered in tweet input file");
                        continue;
                    }
                }
                return tweets;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
