using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using ColorToGrayScale.DllManager.DllsLibs;
using ColorToGrayScale.Helpers;
using ColorToGrayScale.ThreadsServices;

namespace ColorToGrayScale.DllManager.DllsLibs
{
    public class Dll
    {
        public PixelPackageHelper<byte> Pixels { get; set; }

        public ProcessingMethodDelegate ProcessingMethod { internal get; set; }

        public void ChangeColorToGrayScale()
        {
            int i = ThreadService.GetI();

            while (i < Pixels.Length)
            {
                ProcessingMethod(Pixels.GetRed(i), Pixels.GetGreen(i), Pixels.GetBlue(i));
                i = ThreadService.GetI();
            }
        }
    }
}
