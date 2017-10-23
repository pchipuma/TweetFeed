using System.ComponentModel.DataAnnotations;

namespace TweeterFeed.Models
{
    /// <summary>
    /// Tweet object
    /// </summary>
    public class Tweet
    {
        /// <summary>
        /// Tweet text
        /// </summary>
        private string tweetText;

        /// <summary>
        /// Gets or sets unique id for the tweet
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets username of the user tweeting
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the tweet text
        /// </summary>
        public string TweetText 
        {
            get
            {
                return this.tweetText;
            } 

            set
            {
                if (value.Length > 140)
                {
                    this.tweetText = value.Substring(0, 140);
                }
                else
                {
                    this.tweetText = value;
                }
            } 
        }
    }
}