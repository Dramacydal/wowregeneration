using System.Collections.Generic;
using WoWRegeneration.Data;
using WoWRegeneration.Repositories;
using WoWRegeneration.UI;

namespace WoWRegeneration
{
    public static class WoWRegeneration
    {
        public static Data.Session CurrentSession { get; set; }

        public static void Process()
        {
            Data.Session previousSession = Data.Session.LoadSession();

            if (previousSession == null)
            {
                WoWRegeneration.EntryPointNewSession();
            }
            else if (previousSession.SessionCompleted == true)
            {
                WoWRegeneration.EntryPointNewSession();
            }
            else
            {
                if (!UserInputs.SelectContinueSession(previousSession))
                    WoWRegeneration.EntryPointNewSession();
                else
                    WoWRegeneration.EntryPointResumeSession(previousSession);
            }
        }

        private static void EntryPointNewSession()
        {
            IWoWRepository repository = UserInputs.SelectRepository();
            ManifestFile manifest = ManifestFile.FromRepository(repository);
            string locale = UserInputs.SelectLocale(manifest);
            string os = UserInputs.SelectOS();

            WoWRegeneration.CurrentSession = new Data.Session(repository.getMFilName(), locale, os);
            WoWRegeneration.CurrentSession.SaveSession();

            WoWRegeneration.StartProcess(manifest);
        }

        private static void EntryPointResumeSession(Data.Session previousSession)
        {
            WoWRegeneration.CurrentSession = previousSession;
            
            IWoWRepository repository = RepositoriesManager.getRepositoryByMfil(CurrentSession.MFil);
            ManifestFile manifest = ManifestFile.FromRepository(repository);
            string locale = CurrentSession.Locale;
            string os = CurrentSession.OS;

            WoWRegeneration.CurrentSession.SaveSession();

            WoWRegeneration.StartProcess(manifest);
        }

        private static void StartProcess(ManifestFile manifest)
        {
            Program.Log("Generating file list");
            IWoWRepository repository = RepositoriesManager.getRepositoryByMfil(CurrentSession.MFil);
            List<FileObject> files = manifest.GenerateFileList();

            FileDownloader Downloader = new FileDownloader(repository, files);
            Downloader.Start();
            CurrentSession.SessionCompleted = true;
            CurrentSession.SaveSession();
            CurrentSession.Destroy();
            Program.Log("Download Complete !!", System.ConsoleColor.Green);
        }


    }
}
