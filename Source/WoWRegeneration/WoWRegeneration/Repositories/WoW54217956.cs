using System.IO;

namespace WoWRegeneration.Repositories
{
    public class WoW54217956 : IWoWRepository
    {
        public string GetVersionName()
        {
            return "World of Warcraft 5.4.2 (17956)";
        }

        public string GetBaseUrl()
        {
            return "http://dist.blizzard.com.edgesuite.net/wow-pod-retail/EU/15890.direct/";
        }

        public string GetMFilName()
        {
            return "wow-17956-C7A0B02EAC7E9E577A22EDAEBE7B75B3.mfil";
        }

        public string GetDefaultDirectory()
        {
            return "WoW542-17956" + Path.DirectorySeparatorChar;
        }
    }
}
