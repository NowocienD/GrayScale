using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ColorToGrayScale.Exceptions
{
    [Serializable]
    public class DllFileNotExistException : DllNotFoundException
    {
        public DllFileNotExistException()
        {
        }

        public DllFileNotExistException(string message)
            : base(String.Format("DLL file \"{0}\" not found.", message))
        {
        }

        public DllFileNotExistException(string message, Exception innerException)
            : base(String.Format("DLL file \"{0}\" not found.", message), innerException)
        {
        }

        protected DllFileNotExistException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
