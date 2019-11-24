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

        public void ChangeColorToGrayScale2(Bitmap image)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    //Color oldColor = image.GetPixel(x, y);
                    //int newColor = ColorChange(oldColor.R, oldColor.G, oldColor.B);
                    //image.SetPixel(x, y, Color.FromArgb(newColor, newColor, newColor));
                }
            }
        }

        public void ChangeColorToGrayScale(Bitmap image)
        {
            const int size = 16;

            byte[] newColorArrayRed = new byte[size];
            byte[] newColorArrayGreen = new byte[size];
            byte[] newColorArrayBlue = new byte[size];

            for (int i = 0; i < size; i++)
            {
                Color oldColor = image.GetPixel(0, 0 + i);
                newColorArrayRed[i] = oldColor.R;
                newColorArrayGreen[i] = oldColor.G;
                newColorArrayBlue[i] = oldColor.B;
            }

            ColorChange(newColorArrayRed, newColorArrayGreen, newColorArrayBlue);

            for (int i = 0; i < size; i++)
            {
                image.SetPixel(0, 0 + i, Color.FromArgb(newColorArrayRed[i], newColorArrayGreen[i], newColorArrayBlue[i]));
            }
        }

        public void ChangeColorToGrayScale22(Bitmap image)
        {
            const int size = 16;
            //Bitmap image = (Bitmap)img;
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height - 16; y += size)
                {
                    byte[] newColorArrayRed = new byte[size];
                    byte[] newColorArrayGreen = new byte[size];
                    byte[] newColorArrayBlue = new byte[size];
                    for (int i = 0; i < size; i++)
                    {
                        Color oldColor = image.GetPixel(x, y + i);
                        newColorArrayRed[i] = oldColor.R;
                        newColorArrayGreen[i] = oldColor.G;
                        newColorArrayBlue[i] = oldColor.B;
                    }

                    ColorChange(newColorArrayRed, newColorArrayGreen, newColorArrayBlue);

                    try
                    {
                        for (int i = 0; i < size; i++)
                        {
                            image.SetPixel(x, y + i, Color.FromArgb(newColorArrayRed[i], newColorArrayGreen[i], newColorArrayBlue[i]));
                        }
                    }
                    catch 
                    { 
                    }
                    //image.SetPixel(x, y, Color.FromArgb(newColor, newColor, newColor));
                }
            }
        }
    }
}
