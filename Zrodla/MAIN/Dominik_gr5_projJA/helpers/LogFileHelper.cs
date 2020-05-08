using System;
using System.IO;

namespace ColorToGrayScale.Helpers
{
    public static class LogFileHelper
    {
        private static string filePath = "log.txt";

        public static void WriteToLogFile(string message)
        {
            File.AppendAllText(filePath, message);
        }

        public static string[] ReadFromLogFile()
        {
            if (!File.Exists(filePath))
            {
                return Array.Empty<string>();
            }

            return File.ReadAllLines(filePath);
        }
    }
}
