using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ColorToGrayScale.Helpers;
using ColorToGrayScale.ThreadsServices;

namespace ColorToGrayScale.DllServices.DllsLibs
{
    public class CppDll : Dll, IDll
    {
        private const string DllPath = @"C_DLL.dll";

        public void SingleColorChannel_Red(byte[] r, byte[] g, byte[] b) => SingleColorChannel_Red_CPP(r, g, b);

        public void SingleColorChannel_Green(byte[] r, byte[] g, byte[] b) => SingleColorChannel_Green_CPP(r, g, b);

        public void SingleColorChannel_Blue(byte[] r, byte[] g, byte[] b) => SingleColorChannel_Blue_CPP(r, g, b);

        public void Decomposition_max(byte[] r, byte[] g, byte[] b) => Decomposition_max_CPP(r, g, b);

        public void Decomposition_min(byte[] r, byte[] g, byte[] b) => Decomposition_min_CPP(r, g, b);

        public void Desaturation(byte[] r, byte[] g, byte[] b) => Desaturation_CPP(r, g, b);

        [DllImport(DllPath)]
        private static extern void SingleColorChannel_Red_CPP(byte[] r, byte[] g, byte[] b);

        [DllImport(DllPath)]
        private static extern void SingleColorChannel_Green_CPP(byte[] r, byte[] g, byte[] b);

        [DllImport(DllPath)]
        private static extern void SingleColorChannel_Blue_CPP(byte[] r, byte[] g, byte[] b);

        [DllImport(DllPath)]
        private static extern void Decomposition_max_CPP(byte[] r, byte[] g, byte[] b);

        [DllImport(DllPath)]
        private static extern void Decomposition_min_CPP(byte[] r, byte[] g, byte[] b);

        [DllImport(DllPath)]
        private static extern void Desaturation_CPP(byte[] r, byte[] g, byte[] b);
    }
}