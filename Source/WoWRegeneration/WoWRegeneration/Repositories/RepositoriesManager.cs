using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWRegeneration.Repositories
{
    public static class RepositoriesManager
    {
        public static List<IWoWRepository> Repositories { get; set; }

        static RepositoriesManager()
        {
            Repositories = new List<IWoWRepository>();
            Repositories.Add(new WoW434());
        }

        public static IWoWRepository getRepositoryByMfil(string mfil)
        {
            foreach (IWoWRepository item in Repositories)
            {
                if (item.getMFilName() == mfil)
                    return item;
            }
            return null;
        }
    }
}
