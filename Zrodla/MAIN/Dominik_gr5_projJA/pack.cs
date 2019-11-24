using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorToGrayScale
{
    public class aaa
    {
        public pack[] SetOfPackages { get; set; }

    }

    public class pack
    {
        public byte[] Red { get; set; }

        public byte[] Green { get; set; }

        public byte[] Blue { get; set; }
    }

    public class abc
    {
        private const int Size = 16;

        private pack Package;

        public byte[] R { get => Package.Red; }
        public byte[] G { get => Package.Green; }
        public byte[] B { get => Package.Blue; }

        private Bitmap image;

        public Bitmap Get()
        {
            for (int i = 0; i < Size; i++)
            {
                image.SetPixel(0, i, Color.FromArgb(
                    Package.Red[i],
                    Package.Green[i],
                    Package.Blue[i]));
            }
            return image;
        }

        public void Set(Bitmap image)
        {
            this.image = image;

            Package = new pack();
            Package.Red = new byte[Size];
            Package.Green = new byte[Size];
            Package.Blue = new byte[Size];

            for (int i = 0; i < Size; i++)
            {
                Color color = image.GetPixel(0, i);
                Package.Red[i] = color.R;
                Package.Green[i] = color.G;
                Package.Blue[i] = color.B;
            }
        }
    }
}
