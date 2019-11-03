using System;
using System.Drawing;

namespace ColorToGrayScale
{
    public class DllService : IDllService
    {
        private readonly ICppDll cppDll;

        private readonly IAsmDll asmDll;

        public DllService(
            ICppDll cppDll,
            IAsmDll asmDll)
        {
            this.cppDll = cppDll;
            this.asmDll = asmDll;
        }

        public void ProcessUsingASM(Object obj)
        {
            Bitmap image = (Bitmap)obj;
            asmDll.ChangeColorToGrayScale(image);
        }

        public void ProcessUsingCPP(Object obj)
        {
            Bitmap image = (Bitmap)obj;
            cppDll.ChangeColorToGrayScale(image);


        }
    }
}
