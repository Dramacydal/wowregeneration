using System.IO;

namespace WoWRegeneration.Repositories
{
    public class WoW54718019 : WoWRepository
    {
        public override string GetBaseUrl()
        {
            return "http://dist.blizzard.com.edgesuite.net/wow-pod-retail/EU/15890.direct/";
        }

        public override string GetMFilName()
        {
            return "wow-18019-7EEF2887F2B28FC3BCB6251A5F9AFC9A.mfil";
        }
    }
}
