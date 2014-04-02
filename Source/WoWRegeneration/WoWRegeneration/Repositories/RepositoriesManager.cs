using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WoWRegeneration.Repositories
{
    public static class RepositoriesManager
    {
        static RepositoriesManager()
        {
            Repositories = new List<WoWRepository>();

            foreach (var t in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (t.IsSubclassOf(typeof(WoWRepository)))
                {
                    object formulas = t.GetConstructor(new Type[] { }).Invoke(new Object[] { });
                    Repositories.Add((WoWRepository)formulas);
                }
            }
        }

        public static List<WoWRepository> Repositories { get; set; }

        public static WoWRepository GetRepositoryByMfil(string mfil)
        {
            return Repositories.FirstOrDefault(item => item.GetMFilName() == mfil);
        }
    }
}