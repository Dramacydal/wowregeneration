using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using WoWRegeneration.Repositories;

namespace WoWRegeneration.Data
{
    public class FileDownloader
    {
        private IWoWRepository Repository { get; set; }
        private List<FileObject> Files { get; set; }
        private FileObject CurrentFile { get; set; }
        private int CurrentFileIndex { get; set; }
        private string BasePath { get; set; }

        private UI.ConsoleDownloadProgressBar Progress { get; set; }

        public FileDownloader(IWoWRepository repository, List<FileObject> files)
        {
            Files = files;
            BasePath = repository.getDefaultDirectory();
            
            Progress = new UI.ConsoleDownloadProgressBar(Files.Count);
        }

        public void Start()
        {
            CurrentFileIndex = 0;
            Program.Log("Downloading " + Files.Count + " Files", ConsoleColor.Yellow);
            DownloadNextFile();
            Console.CursorLeft = 0;
            Progress.Update(CurrentFile, 0, 0, 0);
            while (CurrentFile != null)
            {
                System.Threading.Thread.Sleep(100);
            }
            Console.Clear();
        }

        public void DownloadNextFile()
        {
            if (CurrentFileIndex >= Files.Count)
            {
                CurrentFile = null;
                return;
            }
            CurrentFile = Files[CurrentFileIndex];
            // Create Directories
            if (!System.IO.Directory.Exists(BasePath + CurrentFile.Directory))
                System.IO.Directory.CreateDirectory(BasePath + CurrentFile.Directory);
            // Delete unfinished downloads
            if (System.IO.File.Exists(BasePath + CurrentFile.Path))
                System.IO.File.Delete(BasePath + CurrentFile.Path);

            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
            client.DownloadFileAsync(new Uri(CurrentFile.Url), BasePath + CurrentFile.Path);
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Progress.Update(CurrentFile, (float)(Math.Round(((double)e.BytesReceived / (double)e.TotalBytesToReceive) * 100, 2)), e.BytesReceived, e.TotalBytesToReceive);
        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            WoWRegeneration.CurrentSession.CompletedFiles.Add(CurrentFile.Path);
            WoWRegeneration.CurrentSession.SaveSession();
            CurrentFileIndex = CurrentFileIndex + 1;
            Console.CursorTop = Console.CursorTop + 7;
            Console.CursorLeft = 0;
            Progress.FileComplete();
            DownloadNextFile();
        }

    }
}
