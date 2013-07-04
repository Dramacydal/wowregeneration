namespace WoWRegeneration.Repositories
{
    class WoW50315890 : IWoWRepository
    {
        public string GetVersionName()
        {
            return "World of Warcraft 5.0.3 (15890)";
        }

        public string GetBaseUrl()
        {
            return "http://dist.blizzard.com.edgesuite.net/wow-pod-retail/EU/15890.direct/";
        }

        public string GetMFilName()
        {
            return "wow-16685-316B45CD12C97A28679D819134CA1B7B.mfil";
        }

        public string GetDefaultDirectory()
        {
            return "WoW503-15890\\";
        }
    }
}
