using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorToGrayScale.helpers;

namespace ColorToGrayScale
{
    public interface ILogerService
    {
        void ShowLogForm();

        void Debug(string message);

        void Info(string message);

        void Warning(string message);
        
        void Error(string message);

        string ReadLog(RegexHelper regex);
    }
}
