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
        [DllImport(@"C:\Users\Dominik\Desktop\repos\asembler-\Zrodla\DLL_C\x64\Release\C_DLL.dll")]
        public static extern int ColorChange(int r, int g, int b);

        public void ChangeColorToGrayScale(Bitmap image)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color oldColor = image.GetPixel(x, y);
                    int newColor = ColorChange(oldColor.R, oldColor.G, oldColor.B);
                    image.SetPixel(x, y, Color.FromArgb(newColor, newColor, newColor));
                }
            }
        }
    }
}
