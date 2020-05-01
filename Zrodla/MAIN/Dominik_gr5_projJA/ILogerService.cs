using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorToGrayScale
{
    public interface ILogerService
    {
        void Debug(string message);

        void Info(string message);

        void Warning(string message);
        
        void Error(string message);

        List<string> ReadLog(string regexPattern);
    }
}
