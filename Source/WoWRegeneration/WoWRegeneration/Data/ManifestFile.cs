using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using WoWRegeneration.Repositories;

namespace WoWRegeneration.Data
{
    public class ManifestFile
    {
        private const string LOCALE_DETECT_LINE = "serverpath=locale_";

        private List<string> Lines { get; set; }

        public ManifestFile()
        {
            Lines = new List<string>();
        }

        public List<string> getLocales()
        {
            List<string> tmp = new List<string>();
            foreach (string line in Lines)
            {
                if (line.StartsWith(LOCALE_DETECT_LINE))
                {
                    tmp.Add(line.Replace(LOCALE_DETECT_LINE, ""));
                }
            }
            return tmp;
        }

        public List<FileObject> GenerateFileList()
        {
            IWoWRepository repository = RepositoriesManager.getRepositoryByMfil(WoWRegeneration.CurrentSession.MFil);

            List<FileObject> tmp = new List<FileObject>();

            foreach (string line in Lines)
            {
                if (IsLineARepositorFile(repository, line))
                {
                    FileObject file = new FileObject();
                    file.Path = getFilePath(line);
                    if (file.Path == null)
                        continue;
                    file.Url = line;
                    file.Info = getFileInfo(repository, line);
                    if (IsAcceptedFile(repository, file))
                        tmp.Add(file);
                }
            }

            return tmp;
        }

        private bool IsAcceptedFile(IWoWRepository repository, FileObject file)
        {
            if (file.Filename != "base-Win.MPQ" && file.Filename != "DSI_Act1_800.avi")
                return false;

            if (WoWRegeneration.CurrentSession.OS == "Win" && file.Filename == "base-OSX.MPQ")
                return false;

            if (WoWRegeneration.CurrentSession.OS == "OSX" && file.Filename == "base-Win.MPQ")
                return false;

            if (file.Filename == "alternate.MPQ" && file.Info != WoWRegeneration.CurrentSession.Locale)
                return false;

            if (WoWRegeneration.CurrentSession.CompletedFiles.Contains(file.Path) && System.IO.File.Exists(Program.ExecutionPath + repository.getDefaultDirectory() + file.Path))
            {
                Program.Log("Skipping " + file.Filename + " allready downloaded", ConsoleColor.DarkGray);
                return false;
            }
            else if (WoWRegeneration.CurrentSession.CompletedFiles.Contains(file.Path))
            {
                WoWRegeneration.CurrentSession.CompletedFiles.Remove(file.Path);
                WoWRegeneration.CurrentSession.SaveSession();
            }

            if (file.Directory == "Data/")
            {
                return true;
            }
            else if (file.Directory.StartsWith("Data/Interface/"))
            {
                return true;
            }
            else if (file.Directory.StartsWith("Data/" + WoWRegeneration.CurrentSession.Locale))
            {
                return true;
            }
            return false;
        }

        private string getFilePath(string line)
        {
            int index = Lines.IndexOf(line);
            if (Lines[index + 1].StartsWith("name="))
            {
                return Lines[index + 1].Replace("name=", "");
            }
            return null;
        }

        private string getFileInfo(IWoWRepository repository, string line)
        {
            int index = Lines.IndexOf(line);
            for (int n = 1; n <= 5; n++)
            {
                string next = Lines[index + n];
                if (IsLineARepositorFile(repository, next))
                    return null;
                if (next.StartsWith("path=locale_"))
                    return next.Replace("path=locale_", "");
            }
            return null;
        }

        private bool IsLineARepositorFile(IWoWRepository repository, string line)
        {
            if (line.StartsWith(repository.getBaseUrl()))
            {
                if (line.Substring(line.Length - 4, 1) == ".")
                {
                    return true;
                }
            }
            return false;
        }

        public static ManifestFile FromRepository(Repositories.IWoWRepository repository)
        {
            try
            {
                ManifestFile manifest = new ManifestFile();
                WebClient client = new WebClient();

                string content = client.DownloadString(repository.getBaseUrl() + repository.getMFilName());
                string[] lines = content.Split('\n');

                foreach (string line in lines)
                {
                    manifest.Lines.Add(line.Trim().Replace("file=", repository.getBaseUrl()));
                }

                return manifest;
            }
            catch (Exception ex)
            {
                Program.Log("Unable to retrieve Manifest file", ConsoleColor.Red);
                Program.Log(ex.Message, ConsoleColor.Red);
            }
            return null;
        }
    }
}
