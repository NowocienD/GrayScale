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

        public void Info(string message)
        {
            WriteToLog(String.Format("Debug |{0}| {1} ", System.DateTime.Now.ToString(), message));
        }

        public void Warning(string message)
        {
            WriteToLog(String.Format("Debug |{0}| {1} ", System.DateTime.Now.ToString(), message));
        }

        public void Error(string message)
        {
            WriteToLog(String.Format("Debug |{0}| {1} ", System.DateTime.Now.ToString(), message));
        }
        private void WriteToLog(string message)
        {
            file.Write(Encoding.ASCII.GetBytes(message), 0, message.Length);
        }
    }
}
