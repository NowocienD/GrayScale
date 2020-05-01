using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ColorToGrayScale
{
    public class LogerService : ILogerService
    {
        private const string FilePath = "log.txt";

        public void Debug(string message)
        {
            WriteToLog(String.Format("Debug |{0}| {1}{2}", System.DateTime.Now.ToString(), message, Environment.NewLine));
        }

        public void Info(string message)
        {
            WriteToLog(String.Format("Info |{0}| {1}{2}", System.DateTime.Now.ToString(), message, Environment.NewLine));
        }

        public void Warning(string message)
        {
            WriteToLog(String.Format("Warning |{0}| {1}{2}", System.DateTime.Now.ToString(), message, Environment.NewLine));
        }

        public void Error(string message)
        {
            WriteToLog(String.Format("Error |{0}| {1}{2}", System.DateTime.Now.ToString(), message, Environment.NewLine));
        }

        public List<string> ReadLog(string regexPattern)
        {
            string[] lines = ReadFromFile();

            Regex regex = new Regex(regexPattern);
            List<string> list = new List<string>();

            foreach (string line in lines)
            {
                if (regex.IsMatch(line))
                {
                    list.Add(line);
                }
            }
            return list;          
        }

        private void WriteToLog(string message)
        {
            File.AppendAllText(FilePath, message);
        }

        private string[] ReadFromFile()
        {
            if (!File.Exists(FilePath))
            {
                return null;
            }
            return File.ReadAllLines(FilePath);
        }
    }
}
