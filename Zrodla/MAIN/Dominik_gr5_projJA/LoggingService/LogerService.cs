using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ColorToGrayScale.Helpers;
using ColorToGrayScale.LoggingService;

namespace ColorToGrayScale.LoggingService
{
    public class LogerService : ILogerService
    {
        private readonly LogsForm logForm;

        public LogerService()
        {
            logForm = new LogsForm(this);
        }

        public void ShowLogForm()
        {
            if (!logForm.IsDisposed)
            {
                logForm.Show();
                Info(String.Format("Wlaczono okno {0}", logForm.GetType().ToString()));
            }
            else
            {
                Error(String.Format("Okno {0} zorstlo zniszczone.", logForm.GetType().ToString()));
                System.Windows.Forms.MessageBox.Show(String.Format("Jestem leniwym programista #2 i nie uruchomie wylaczonego okna.{1}{1}Okno {0} zorstlo zniszczone.", logForm.GetType().ToString(), Environment.NewLine));
            }
        }

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

        public void WriteToLog(string message)
        {
            LogFileHelper.WriteToLogFile(message);
        }

        public string ReadLog(RegexHelper regex)
        {
            return regex.SearchString(Environment.NewLine, LogFileHelper.ReadFromLogFile());
        }
    }
}
