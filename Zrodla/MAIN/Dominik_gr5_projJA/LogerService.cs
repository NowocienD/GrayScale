using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorToGrayScale
{
    public class LogerService : ILogerService
    {
        private string filePath = "log.txt";

        private FileStream file;

        public LogerService()
        {
            file = File.OpenWrite(filePath);
        }

        public void Debug(string message)
        {
            WriteToLog(String.Format("Debug |{0}| {1} ", System.DateTime.Now.ToString(), message));
        }

        public void Info(string message)
        {
            WriteToLog(String.Format("Info |{0}| {1} ", System.DateTime.Now.ToString(), message));
        }

        public void Warning(string message)
        {
            WriteToLog(String.Format("Warning |{0}| {1} ", System.DateTime.Now.ToString(), message));
        }

        public void Error(string message)
        {
            WriteToLog(String.Format("Error |{0}| {1} ", System.DateTime.Now.ToString(), message));
        }

        private void WriteToLog(string message)
        {
            File.AppendAllText(filePath, message);
        }
    }
}
