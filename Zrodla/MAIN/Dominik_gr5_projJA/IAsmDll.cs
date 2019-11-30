using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static ColorToGrayScale.AsmDll;

namespace ColorToGrayScale
{
    public interface IAsmDll
    {
        void ChangeColorToGrayScale(object data);

        ProcessingMethodDelegate ProcessingMethod { set; }
    }
}
