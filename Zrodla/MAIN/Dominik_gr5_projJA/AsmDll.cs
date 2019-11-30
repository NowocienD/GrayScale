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
        //public delegate void ProcessingMethodDelegate(byte[] r, byte[] g, byte[] b);

        public ProcessingMethodDelegate ProcessingMethod { internal get; set; }

        [DllImport(@"C:\Users\qwertyuiop\source\repos\asm_dll_2017\x64\Release\asm_dll_2017.dll")]
        public static extern void ColorChange(byte[] r, byte[] g, byte[] b);

        public void ChangeColorToGrayScale(object data)
        {
            Bitmap[] image = (Bitmap[])data;

            //ProcessingMethod = ColorChange;
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
