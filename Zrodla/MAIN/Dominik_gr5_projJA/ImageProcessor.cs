using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ColorToGrayScale
{
    public class ImageProcessor
    {
        [DllImport(@"C:\Users\Dominik\source\repos\C_DLL\x64\Release\C_DLL.dll")]
        public static extern int ColorChange(int r, int g, int b);

        public void processingMethod(Object obj)
        {
            Bitmap image = (Bitmap)obj;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color oldColor = image.GetPixel(x, y);
                    int colorS = ColorChange(oldColor.R, oldColor.G, oldColor.B);
                    Color newColor = Color.FromArgb(colorS, colorS, colorS);

                    image.SetPixel(x, y, newColor);
                }
            }
        }
    }
}
