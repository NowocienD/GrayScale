using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ColorToGrayScale
{
    public class CppDll : ICppDll
    {
        [DllImport(@"C:\Users\qwertyuiop\Desktop\repo\Zrodla\DLL_C\x64\Release\C_DLL.dll")]
        public static extern int ColorChange(byte[] r, byte[] g, byte[] b);

        public void ChangeColorToGrayScale(Bitmap image)
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

        public void SingleColorChannel(Object img)
        {
            Bitmap image = (Bitmap)img;
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y += 8)
                {
                    byte[] newColorArrayRed = new byte[8];
                    byte[] newColorArrayGreen = new byte[8];
                    byte[] newColorArrayBlue = new byte[8];
                    for (int i = 0; i < 8; i++)
                    {
                        Color oldColor = image.GetPixel(x, y);
                        newColorArrayRed[0] = oldColor.R;
                        newColorArrayGreen[0] = oldColor.G;
                        newColorArrayBlue[0] = oldColor.B;
                    }

                    ColorChange(newColorArrayRed, newColorArrayGreen, newColorArrayBlue);

                    for (int i = 0; i < 8; i++)
                    {
                        image.SetPixel(x, y + i, Color.FromArgb(newColorArrayRed[i], newColorArrayGreen[i], newColorArrayBlue[i]));
                    }

                    //image.SetPixel(x, y, Color.FromArgb(newColor, newColor, newColor));
                }
            }
        }
    }
}
