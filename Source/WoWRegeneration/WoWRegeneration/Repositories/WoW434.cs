using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWRegeneration.Repositories
{
    public class WoW434 : IWoWRepository
    {
        public string getVersionName()
        {
            return "World of Warcraft 4.3.4";
        }

        public string getBaseUrl()
        {
            return "http://blizzard.vo.llnwd.net/o16/content/wow-pod-retail/EU/15050.direct/";
        }

        public string getMFilName()
        {
            return "wow-15595-0C3502F50D17376754B9E9CB0109F4C5.mfil";
        }

        public string getDefaultDirectory()
        {
            return "WoW434\\";
        }
    }
}
