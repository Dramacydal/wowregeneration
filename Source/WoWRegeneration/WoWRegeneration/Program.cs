using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WoWRegeneration
{
    class Program
    {
        public static string ExecutionPath { get; set; }

        /// <summary>
        /// Program start point
        /// </summary>
        /// <param name="args">No params required</param>
        private static void Main(string[] args)
        {
            Program.InitConsole();
            
            WoWRegeneration.Process();

            Program.WaitUntilEnd();
        }

        /// <summary>
        /// Print an empty line on console
        /// </summary>
        public static void Log()
        {
            Program.Log("", ConsoleColor.White);
        }

        /// <summary>
        /// Print a value on console, with default color (white)
        /// </summary>
        /// <param name="value">value to print on console</param>
        public static void Log(string value)
        {
            Program.Log(value, ConsoleColor.White);
        }

        /// <summary>
        /// Print a value on console, with specified color
        /// </summary>
        /// <param name="value">value to print on console</param>
        /// <param name="color">forecolor to use</param>
        public static void Log(string value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        /// <summary>
        /// Initialize console
        /// </summary>
        private static void InitConsole()
        {
            Console.Clear();
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            Console.Title = "WoW Regeneration - " + version.ToString();
            ExecutionPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (!ExecutionPath.EndsWith("\\"))
                ExecutionPath = ExecutionPath + "\\";
        }

        /// <summary>
        /// Fonction to avoid console close 
        /// </summary>
        private static void WaitUntilEnd()
        {
            Program.Log("Press enter to exit program.");
            Console.ReadLine();
        }
    }
}
