using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorToGrayScale
{
    public class Pack
    {
        public byte[] Red { get; set; }

        public byte[] Green { get; set; }

        public byte[] Blue { get; set; }
    }

    public class PixelPackage
    {
        private const int Size = 16;

        private Pack package;

        private Bitmap image;

        public byte[] R { get => package.Red; }

        public byte[] G { get => package.Green; }

        public byte[] B { get => package.Blue; }

        public Bitmap Get()
        {
            for (int i = 0; i < Size; i++)
            {
                image.SetPixel(0, i, Color.FromArgb(
                    package.Red[i],
                    package.Green[i],
                    package.Blue[i]));
            }
            return image;
        }

        public void Set(Bitmap image)
        {
            this.image = image;

            package = new Pack
            {
                Red = new byte[Size],
                Green = new byte[Size],
                Blue = new byte[Size],
            };

            for (int i = 0; i < Size; i++)
            {
                Color color = image.GetPixel(0, i);
                package.Red[i] = color.R;
                package.Green[i] = color.G;
                package.Blue[i] = color.B;
            }
        }
    }
}
