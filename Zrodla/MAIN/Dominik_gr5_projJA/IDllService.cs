using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorToGrayScale
{
    public interface IDllService
    {
        void ProcessUsingASM(Object obj);

        void ProcessUsingCPP(Object obj);
    }
}
