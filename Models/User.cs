using System.Collections.Generic;

namespace TweeterFeed.Models
{
    /// <summary>
    /// User domain object.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            this.Following = new List<User>();
            this.Tweets = new List<Tweet>();
        }

        /// <summary>
        /// Gets or sets Username of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets list of users that the user is following
        /// </summary>
        public List<User> Following { get; set; }

        /// <summary>
        /// Gets or sets the user's tweets
        /// </summary>
        public List<Tweet> Tweets { get; set; }
    }
}
