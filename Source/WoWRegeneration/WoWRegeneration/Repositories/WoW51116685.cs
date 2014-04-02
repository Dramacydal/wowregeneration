using System.IO;

namespace WoWRegeneration.Repositories
{
    public class WoW51116685 : WoWRepository
    {
        public override string GetBaseUrl()
        {
            return "http://dist.blizzard.com.edgesuite.net/wow-pod-retail/EU/15890.direct/";
        }

        public override string GetMFilName()
        {
            return "wow-16685-316B45CD12C97A28679D819134CA1B7B.mfil";
        }
    }
}
