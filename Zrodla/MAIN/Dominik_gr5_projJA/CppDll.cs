using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ColorToGrayScale
{
    public class CppDll 
    {
        private const string DllPath = @"C:\Users\qwertyuiop\Desktop\repo\Zrodla\DLL_C\x64\Release\C_DLL.dll";

        public ProcessingMethodDelegate ProcessingMethod { internal get; set; }

        public void SingleColorChannel_Red(byte[] r, byte[] g, byte[] b) => SingleColorChannel_Red_ASM(r, g, b);
            
        public void SingleColorChannel_Green(byte[] r, byte[] g, byte[] b) => SingleColorChannel_Green_ASM(r, g, b);

        public void SingleColorChannel_Blue(byte[] r, byte[] g, byte[] b) => SingleColorChannel_Blue_ASM(r, g, b);

        [DllImport(DllPath)]
        private static extern void SingleColorChannel_Red_ASM(byte[] r, byte[] g, byte[] b);

        [DllImport(DllPath)]
        private static extern void SingleColorChannel_Green_ASM(byte[] r, byte[] g, byte[] b);

        [DllImport(DllPath)]
        private static extern void SingleColorChannel_Blue_ASM(byte[] r, byte[] g, byte[] b);

        public void ChangeColorToGrayScale(object data)
        {
        }
    }
}
