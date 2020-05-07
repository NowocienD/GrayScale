using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorToGrayScale
{
    public class PixelPackageHelper<T>
    {
        private const int Size = 16;

        public PixelPackageHelper(int len)
        {
            Length = len;
            Red = new T[len][];
            Green = new T[len][];
            Blue = new T[len][];

            for (int i = 0; i < len; i++)
            {
                Red[i] = new T[Size];
                Green[i] = new T[Size];
                Blue[i] = new T[Size];
            }
        }

        public int Length { get; internal set; }

        public T[][] Red { get; internal set; }

        public T[][] Green { get; internal set; }

        public T[][] Blue { get; internal set; }

        public T[] GetRed(int i)
        {
            return Red[i];
        }

        public T[] GetGreen(int i)
        {
            return Green[i];
        }

        public T[] GetBlue(int i)
        {
            return Blue[i];
        }
    }
}
