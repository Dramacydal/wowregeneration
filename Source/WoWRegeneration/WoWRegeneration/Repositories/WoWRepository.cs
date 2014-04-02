using System.IO;

namespace WoWRegeneration.Repositories
{
    public abstract class WoWRepository
    {
        /// <summary>
        ///     Will return wow version name, for user display
        /// </summary>
        /// <returns>wow version name</returns>
        public string GetVersionName()
        {
            return "World of Warcraft - Build " + GetBuild();
        }

        /// <summary>
        ///     Will return base url for downloads
        /// </summary>
        /// <returns>base url for downloads</returns>
        public abstract string GetBaseUrl();

        /// <summary>
        ///     Will return mfil file filename
        /// </summary>
        /// <returns>mfil file filename</returns>
        public abstract string GetMFilName();

        /// <summary>
        ///     Will return default local directory to download
        /// </summary>
        /// <returns>default local directory to download</returns>
        public string GetDefaultDirectory()
        {
            return "WoW-" + GetBuild() + Path.DirectorySeparatorChar;
        }

        public string GetBuild()
        {
            return GetMFilName().Split('-')[1];
        }
    }
}