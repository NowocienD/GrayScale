using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorToGrayScale.Exceptions
{
    public class NotDivisibleBy16Exception : Exception
    {
        public NotDivisibleBy16Exception()
        {
        }

        public NotDivisibleBy16Exception(string message)
            : base(message)
        {
        }

        public NotDivisibleBy16Exception(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
