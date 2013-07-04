using System.Collections.Generic;
using System.Linq;

namespace WoWRegeneration.Repositories
{
    public static class RepositoriesManager
    {
        static RepositoriesManager()
        {
            Repositories = new List<IWoWRepository> { new WoW434(), new WoW50315890() };
        }

        public static List<IWoWRepository> Repositories { get; set; }

        public static IWoWRepository GetRepositoryByMfil(string mfil)
        {
            return Repositories.FirstOrDefault(item => item.GetMFilName() == mfil);
        }
    }
}