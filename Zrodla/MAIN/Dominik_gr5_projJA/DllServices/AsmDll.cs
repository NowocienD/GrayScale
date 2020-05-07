using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security;

namespace ColorToGrayScale
{
    public class AsmDll : IDll
    {
        private const string DllPath = @"ASM_DLL.dll";

        public ProcessingMethodDelegate ProcessingMethod { internal get; set; }

        public PixelPackageHelper<byte> Pixels { get; set; }

        public void SingleColorChannel_Red(byte[] r, byte[] g, byte[] b) => SingleColorChannel_Red_ASM(r, g, b);

        public void SingleColorChannel_Green(byte[] r, byte[] g, byte[] b) => SingleColorChannel_Green_ASM(r, g, b);

        public void SingleColorChannel_Blue(byte[] r, byte[] g, byte[] b) => SingleColorChannel_Blue_ASM(r, g, b);

        public void Decomposition_max(byte[] r, byte[] g, byte[] b) => Decomposition_max_ASM(r, g, b);

        public void Decomposition_min(byte[] r, byte[] g, byte[] b) => Decomposition_min_ASM(r, g, b);

        public void Desaturation(byte[] r, byte[] g, byte[] b) => Desaturation_ASM(r, g, b);

        public void ChangeColorToGrayScale(object data)
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
        private static extern void SingleColorChannel_Red_ASM(byte[] r, byte[] g, byte[] b);

        [DllImport(DllPath)]
        private static extern void SingleColorChannel_Green_ASM(byte[] r, byte[] g, byte[] b);

        [DllImport(DllPath)]
        private static extern void SingleColorChannel_Blue_ASM(byte[] r, byte[] g, byte[] b);

        [DllImport(DllPath)]
        private static extern void Decomposition_max_ASM(byte[] r, byte[] g, byte[] b);

        [DllImport(DllPath)]
        private static extern void Decomposition_min_ASM(byte[] r, byte[] g, byte[] b);

        [DllImport(DllPath)]
        private static extern void Desaturation_ASM(byte[] r, byte[] g, byte[] b);
    }
}
