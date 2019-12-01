using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ColorToGrayScale
{
    public class ImageService : IImageService
    {
        private const int Size = 16;
        private int height;
        private int width;
        private int imageSize;

        public PixelPackage pixels { get; set; }

        public PixelPackage[] CopyArrayOfBitmap(PixelPackage[] dividedImage)
        {
            PixelPackage[] copyOfdividedImage = new PixelPackage[dividedImage.Length];
            for (int i = 0; i < dividedImage.Length; i++)
            {
                //copyOfdividedImage[i] = (PixelPackage)dividedImage[i];
            }
            return copyOfdividedImage;
        }

        public void ImageDivider(Bitmap imageToProcess)
        {
            width = imageToProcess.Width;
            height = imageToProcess.Height;
            PixelFormat pixelFormat = imageToProcess.PixelFormat;

            imageSize = width * height;
            pixels = new PixelPackage(imageSize);

            int counter = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color color = imageToProcess.GetPixel(x, y);
                    pixels.Red[counter] = color.R;
                    pixels.Green[counter] = color.G;
                    pixels.Blue[counter] = color.B;
                    counter++;
                }
            }
        }

        public Bitmap JoinIntoBigOne()
        {
            Bitmap image = new Bitmap(width, height);

            int counter = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color color = Color.FromArgb(
                        pixels.Red[counter],
                        pixels.Green[counter],
                        pixels.Blue[counter]);

                    image.SetPixel(x, y, color);
                    counter++;
                }
            }
            return image;
        }
    }
}
