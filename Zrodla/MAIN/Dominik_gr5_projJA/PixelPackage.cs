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
        //private const int Size = 16;
        
        //private Bitmap image;

        public byte[] Red { get; internal set; }

        public byte[] Green { get; internal set; }

        public byte[] Blue { get; internal set; }

        public int Length { get; internal set; }

        public PixelPackage(int i)
        {
            Length = i;
            i += 16;
            Red = new byte[i];
            Green = new byte[i];
            Blue = new byte[i];
        }

        public byte[] Get_red(int i)
        {
            byte[] dto = new byte[16];
            Array.Copy(Red, i, dto, 0, 16);
            return dto;
        }
        public byte[] Get_green(int i)
        {
            byte[] dto = new byte[16];
            for (int j = 0; j < 16; j++)
            {
                dto[j] = Green[i + j];
            }
            return dto;
        }
        public byte[] Get_blue(int i)
        {
            byte[] dto = new byte[16];
            for (int j = 0; j < 16; j++)
            {
                dto[j] = Blue[i + j];
            }
            return dto;
        }

        //public Bitmap Get()
        //{
        //    for (int i = 0; i < Size; i++)
        //    {
        //        //image.SetPixel(0, i, Color.FromArgb(
        //            Red[i],
        //            Green[i],
        //            Blue[i]));
        //    }
        //    return image;
        //}

        //public void Set(Bitmap image)
        //{
        //    this.image = image;

        //    Red = new byte[Size];
        //    Green = new byte[Size];
        //    Blue = new byte[Size];

        //    for (int i = 0; i < Size; i++)
        //    {
        //        Color color = image.GetPixel(0, i);
        //        Red[i] = color.R;
        //        Green[i] = color.G;
        //        Blue[i] = color.B;
        //    }
        //}
    }
}
