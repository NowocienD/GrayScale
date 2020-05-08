using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using ColorToGrayScale.Helpers;

namespace ColorToGrayScale.DllServices.DllsLibs
{
    public delegate void ProcessingMethodDelegate(byte[] r, byte[] g, byte[] b);

    public interface IDll
    {
        ProcessingMethodDelegate ProcessingMethod { set; }

        PixelPackageHelper<byte> Pixels { get; set; }

        void ChangeColorToGrayScale();

        void SingleColorChannel_Red(byte[] r, byte[] g, byte[] b);

        void SingleColorChannel_Green(byte[] r, byte[] g, byte[] b);

        void SingleColorChannel_Blue(byte[] r, byte[] g, byte[] b);

        void Decomposition_max(byte[] r, byte[] g, byte[] b);

        void Decomposition_min(byte[] r, byte[] g, byte[] b);

        void Desaturation(byte[] r, byte[] g, byte[] b);
    }
}
