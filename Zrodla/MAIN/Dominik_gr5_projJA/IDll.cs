using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ColorToGrayScale
{
    public delegate void ProcessingMethodDelegate(byte[] r, byte[] g, byte[] b);

    public interface IDll
    {
        ProcessingMethodDelegate ProcessingMethod { set; }

        void ChangeColorToGrayScale(object data);

        void ColorChanger(byte[] r, byte[] g, byte[] b);
    }
}
