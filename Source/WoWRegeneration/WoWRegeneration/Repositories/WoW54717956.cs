using System.IO;

namespace WoWRegeneration.Repositories
{
    public class WoW54717956 : WoWRepository
    {
        public override string GetBaseUrl()
        {
            return "http://dist.blizzard.com.edgesuite.net/wow-pod-retail/EU/15890.direct/";
        }

        public override string GetMFilName()
        {
            return "wow-17956-C7A0B02EAC7E9E577A22EDAEBE7B75B3.mfil";
        }
    }
}
