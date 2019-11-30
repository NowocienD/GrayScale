using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ColorToGrayScale
{
    public class AsmDll : IDll
    {
        public ProcessingMethodDelegate ProcessingMethod { internal get; set; }

        public void SingleColorChannel_Red(byte[] r, byte[] g, byte[] b) => SingleColorChannel_Red_ASM(r, g, b);

        public void SingleColorChannel_Green(byte[] r, byte[] g, byte[] b) => SingleColorChannel_Green_ASM(r, g, b);

        public void SingleColorChannel_Blue(byte[] r, byte[] g, byte[] b) => SingleColorChannel_Blue_ASM(r, g, b);

        [DllImport(@"C:\Users\qwertyuiop\source\repos\asm_dll_2017\x64\Release\asm_dll_2017.dll")]
        private static extern void SingleColorChannel_Red_ASM(byte[] r, byte[] g, byte[] b);

        [DllImport(@"C:\Users\qwertyuiop\source\repos\asm_dll_2017\x64\Release\asm_dll_2017.dll")]
        private static extern void SingleColorChannel_Green_ASM(byte[] r, byte[] g, byte[] b);

        [DllImport(@"C:\Users\qwertyuiop\source\repos\asm_dll_2017\x64\Release\asm_dll_2017.dll")]
        private static extern void SingleColorChannel_Blue_ASM(byte[] r, byte[] g, byte[] b);

        public void ChangeColorToGrayScale(object data)
        {
            Bitmap[] image = (Bitmap[])data;

            int i = ThreadService.GetI();

            while (i < image.Length) 
            {                 
                PixelPackage pixels = new PixelPackage();
                pixels.Set(image[i]);

                ProcessingMethod(pixels.R, pixels.G, pixels.B);

                //ColorChange(pixels.R, pixels.G, pixels.B);

                image[i] = pixels.Get();

                i = ThreadService.GetI();
            } 
        }
    }
}
