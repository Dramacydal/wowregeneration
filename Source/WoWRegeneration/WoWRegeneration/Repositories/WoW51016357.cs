using System.IO;

namespace WoWRegeneration.Repositories
{
    public class WoW51016357 : WoWRepository
    {
        public override string GetBaseUrl()
        {
            return "http://dist.blizzard.com.edgesuite.net/wow-pod-retail/NA/15890.direct/";
        }

        public override string GetMFilName()
        {
            return "wow-16357-AE4379D2E6B819E4CC486D91FA298AC8.mfil";
        }
    }
}
