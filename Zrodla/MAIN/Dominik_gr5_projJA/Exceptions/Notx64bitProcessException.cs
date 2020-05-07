using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorToGrayScale.Exceptions
{
    public class Notx64bitProcessException : DllNotFoundException
    {
        public Notx64bitProcessException()
        {
        }

        public Notx64bitProcessException(string message)
            : base(message)
        {
        }

        public Notx64bitProcessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
