using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorToGrayScale
{
    public class PixelPackage
    {
        private const int Size = 16;

        public PixelPackage(int len)
        {
            Length = len;
            Red = new byte[len][];
            Green = new byte[len][];
            Blue = new byte[len][];

            for (int i = 0; i < len; i++)
            {
                Red[i] = new byte[Size];
                Green[i] = new byte[Size];
                Blue[i] = new byte[Size];
            }
        }
        public int Length { get; internal set; }

        public byte[][] Red { get; internal set; }

        public byte[][] Green { get; internal set; }

        public byte[][] Blue { get; internal set; }

        public byte[] GetRed(int i)
        {
            return Red[i];
        }

        public byte[] GetGreen(int i)
        {
            return Green[i];
        }

        public byte[] GetBlue(int i)
        {
            return Blue[i];
        }
    }
}
