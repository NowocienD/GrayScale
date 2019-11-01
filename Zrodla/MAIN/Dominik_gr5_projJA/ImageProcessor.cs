using System;
using System.Drawing;

namespace ColorToGrayScale
{
    class ImageProcessor
    {
        public void processingMethod(Object obj)
        {
            Bitmap image = (Bitmap)obj;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color color = ToGrayScaleCSharp.Process(image.GetPixel(x, y));

                    image.SetPixel(x, y, color);
                }
            }
        }
    }
}
