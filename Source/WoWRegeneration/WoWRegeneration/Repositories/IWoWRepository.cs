using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWRegeneration.Repositories
{
    public interface IWoWRepository
    {
        /// <summary>
        /// Will return wow version name, for user display
        /// </summary>
        /// <returns>wow version name</returns>
        string getVersionName();

        /// <summary>
        /// Will return base url for downloads
        /// </summary>
        /// <returns>base url for downloads</returns>
        string getBaseUrl();

        /// <summary>
        /// Will return mfil file filename
        /// </summary>
        /// <returns>mfil file filename</returns>
        string getMFilName();

        /// <summary>
        /// Will return default local directory to download
        /// </summary>
        /// <returns>default local directory to download</returns>
        string getDefaultDirectory();
    }
}
