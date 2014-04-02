using System.IO;

namespace WoWRegeneration.Repositories
{
    public class WoW54117538 : WoWRepository
    {
        public override string GetBaseUrl()
        {
            return "http://dist.blizzard.com.edgesuite.net/wow-pod-retail/EU/15890.direct/";
        }

        public override string GetMFilName()
        {
            return "wow-17538-D19C28133E590DA14BB58645AB1E7A48.mfil";
        }
    }
}
