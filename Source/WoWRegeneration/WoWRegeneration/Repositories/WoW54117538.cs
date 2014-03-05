using System.IO;

namespace WoWRegeneration.Repositories
{
    public class WoW54117538 : IWoWRepository
    {
        public string GetVersionName()
        {
            return "World of Warcraft 5.4.1 (17538)";
        }

        public string GetBaseUrl()
        {
            return "http://dist.blizzard.com.edgesuite.net/wow-pod-retail/EU/15890.direct/";
        }

        public string GetMFilName()
        {
            return "wow-17538-D19C28133E590DA14BB58645AB1E7A48.mfil";
        }

        public string GetDefaultDirectory()
        {
            return "WoW541-17538" + Path.DirectorySeparatorChar;
        }
    }
}
