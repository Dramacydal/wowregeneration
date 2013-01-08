using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WoWRegeneration.Data;

namespace WoWRegeneration.UI
{
    public class ConsoleDownloadProgressBar
    {
        private int FilesCount { get; set; }
        private int CurrentFileIndex { get; set; }
        private DateTime LastUpdate { get; set; }
        private bool Updating { get; set; }

        public ConsoleDownloadProgressBar(int filescount)
        {
            FilesCount = filescount;
            LastUpdate = DateTime.Now;
            CurrentFileIndex = 1;
            Updating = false;
        }

        public void FileComplete()
        {
            CurrentFileIndex = CurrentFileIndex + 1;            
        }

        public void Update(FileObject file, float pourcentage, long bytesReceived, long totalBytes)
        {
            if (file == null)
                return;
            if (Updating == true)
                return;
            Updating = true;

            bool force = (pourcentage == 0 && bytesReceived == 0 && totalBytes == 0);
            //if (DateTime.Now.Subtract(LastUpdate).TotalMilliseconds >= 100 || force)
            {
                LastUpdate = DateTime.Now;

                int y = Console.CursorTop;

                SetText("Downloading : " + AlignText(file.Path, 50, false), ConsoleColor.Yellow, 0, y + 1);
                SetText("File        : " + AlignText(CurrentFileIndex.ToString() + "/" + FilesCount.ToString(), 50, false), ConsoleColor.Yellow, 0, y + 2);
                SetText("File Size   : " + AlignText(humanReadableByteCount(totalBytes), 50, false), ConsoleColor.Yellow, 0, y + 3);
                SetText("Downloaded  : " + AlignText(humanReadableByteCount(bytesReceived), 50, false), ConsoleColor.Yellow, 0, y + 4);
                SetText("Pourcent    : " + AlignText(pourcentage.ToString() + "%", 50, false), ConsoleColor.Yellow, 0, y + 5);

                Console.CursorTop = y;
            }
            Updating = false;
        }

        private void SetPosition(int x, int y)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
        }

        public String humanReadableByteCount(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                len = len / 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            return String.Format("{0:0.##} {1}", len, sizes[order]);
        }

        private string AlignText(string value, int lenght, bool alignRight)
        {
            if (value.Length > lenght)
                value = value.Substring(0, lenght);
            if (value.Length < lenght)
            {
                if (alignRight)
                {
                    while (value.Length < lenght)
                        value = " " + value;
                }
                else
                {
                    while (value.Length < lenght)
                        value = value + " ";
                }
            }
            return value;
        }

        public void SetText(string value, ConsoleColor color, int x, int y)
        {
            SetPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ResetColor();
        }
    }
}
