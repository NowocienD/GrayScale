using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ColorToGrayScale.Helpers;
using ColorToGrayScale.ThreadsServices;

namespace ColorToGrayScale.DllManager.DllsLibs
{
    public class CppDll : IDll
    {
        private const string DllPath = @"C_DLL.dll";

        public ProcessingMethodDelegate ProcessingMethod { internal get; set; }

        public PixelPackageHelper<byte> Pixels { get; set; }

        public void SingleColorChannel_Red(byte[] r, byte[] g, byte[] b) => SingleColorChannel_Red_CPP(r, g, b);

        public void SingleColorChannel_Green(byte[] r, byte[] g, byte[] b) => SingleColorChannel_Green_CPP(r, g, b);

        public void SingleColorChannel_Blue(byte[] r, byte[] g, byte[] b) => SingleColorChannel_Blue_CPP(r, g, b);

        public void Decomposition_max(byte[] r, byte[] g, byte[] b) => Decomposition_max_CPP(r, g, b);

        public void Decomposition_min(byte[] r, byte[] g, byte[] b) => Decomposition_min_CPP(r, g, b);

        public void Desaturation(byte[] r, byte[] g, byte[] b) => Desaturation_CPP(r, g, b);

        public void ChangeColorToGrayScale()
        {
            int i = ThreadService.GetI();

            while (i < Pixels.Length)
            {
                for (int j = 0; j < 1; j++)
                {
                    ProcessingMethod(Pixels.GetRed(i), Pixels.GetGreen(i), Pixels.GetBlue(i));
                }

                i = ThreadService.GetI();
            }
        }

        [DllImport(DllPath)]
        private static extern void SingleColorChannel_Red_CPP(byte[] r, byte[] g, byte[] b);

        [DllImport(DllPath)]
        private static extern void SingleColorChannel_Green_CPP(byte[] r, byte[] g, byte[] b);

        [DllImport(DllPath)]
        private static extern void SingleColorChannel_Blue_CPP(byte[] r, byte[] g, byte[] b);

        [DllImport(DllPath)]
        private static extern void Decomposition_max_CPP(byte[] r, byte[] g, byte[] b);

        [DllImport(DllPath)]
        private static extern void Decomposition_min_CPP(byte[] r, byte[] g, byte[] b);

        [DllImport(DllPath)]
        private static extern void Desaturation_CPP(byte[] r, byte[] g, byte[] b);
    }
}