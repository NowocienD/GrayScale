using System;
using System.Drawing;

namespace ColorToGrayScale
{
    public class DllService : IDllService
    {
        private readonly ICppDll cppDll;

        private readonly IDll asmDll;

        public DllService(
            ICppDll cppDll,
            IDll asmDll)
        {
            this.cppDll = cppDll;
            this.asmDll = asmDll;
        }

        public void ProcessUsingASM(Object image)
        {
            asmDll.ChangeColorToGrayScale((Bitmap[])image);
        }

        public void ProcessUsingCPP(Object image)
        {
            cppDll.ChangeColorToGrayScale((Bitmap)image);
        }
    }
}
