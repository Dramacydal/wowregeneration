using System.IO;

namespace WoWRegeneration.Repositories
{
    public class WoW54718019 : IWoWRepository
    {
        public string GetVersionName()
        {
            return "World of Warcraft 5.4.7 (18019)";
        }

        public string GetBaseUrl()
        {
            return "http://dist.blizzard.com.edgesuite.net/wow-pod-retail/EU/15890.direct/";
        }

        public string GetMFilName()
        {
            return "wow-18019-7EEF2887F2B28FC3BCB6251A5F9AFC9A.mfil";
        }

        public string GetDefaultDirectory()
        {
            return "WoW547-17956" + Path.DirectorySeparatorChar;
        }
    }
}
