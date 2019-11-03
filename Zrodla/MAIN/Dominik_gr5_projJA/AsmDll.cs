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
        [DllImport(@"C:\Users\Dominik\source\repos\ASM_DLL\x64\Release\ASM_DLL.dll")]
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
