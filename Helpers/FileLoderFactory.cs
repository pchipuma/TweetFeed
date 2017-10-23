
namespace TweeterFeed.Helpers
{
    /// <summary>
    /// Helper class for instantiating fileloaders
    /// </summary>
    public static class FileLoderFactory
    {
        /// <summary>
        /// Creates appropriate file loader depending on file type. Can be expanded to include other file types
        /// </summary>
        /// <param name="filetype">Type of file</param>
        /// <returns>A file loader object</returns>
        public static IFileLoader CreateFileLoader(string filetype)
        {
            IFileLoader fileloader = null;
            if (filetype == ".txt")
            {
                fileloader = new TextFileLoader();
            }
            return fileloader;
        }
    }
}
