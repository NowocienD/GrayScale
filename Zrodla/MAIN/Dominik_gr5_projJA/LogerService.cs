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
            string textToWrite = String.Format("Info |{0}| {1} ", System.DateTime.Now.ToString(), message);
            file.Write(Encoding.ASCII.GetBytes(textToWrite), 0, textToWrite.Length);
        }

        public void Warning(string message)
        {
            string textToWrite = String.Format("Warning |{0}| {1} ", System.DateTime.Now.ToString(), message);
            file.Write(Encoding.ASCII.GetBytes(textToWrite), 0, textToWrite.Length);
        }

        public void Error(string message)
        {
            string textToWrite = String.Format("Error |{0}| {1} ", System.DateTime.Now.ToString(), message);
            file.Write(Encoding.ASCII.GetBytes(textToWrite), 0, textToWrite.Length);
        }
    }
}
