using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ColorToGrayScale
{
    public class AsmDll : IAsmDll
    {
        [DllImport(@"C:\Users\qwertyuiop\source\repos\asm_dll_2017\x64\Release\asm_dll_2017.dll")]
        public static extern int ColorChange(byte[] r, byte[] g, byte[] b);

        public void ChangeColorToGrayScale(Bitmap[] image)
        {
            int i = ThreadService.GetI();

            while (i < image.Length) 
            {                 
                PixelPackage pixels = new PixelPackage();
                pixels.Set(image[i]);

                ColorChange(pixels.R, pixels.G, pixels.B);

                image[i] = pixels.Get();

                i = ThreadService.GetI();
            } 
        }
    }
}
