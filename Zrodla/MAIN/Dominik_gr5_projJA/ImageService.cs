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

        public PixelPackage Pixels { get; set; }

        public PixelPackage CopyOfOryginalImage { get; set; }

        public PixelPackage CopyArrayOfBitmap(PixelPackage dividedImage)
        {
            int length = dividedImage.Length;
            PixelPackage copyOfdividedImage = new PixelPackage(length);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    copyOfdividedImage.Red[i][j] = dividedImage.Red[i][j];
                    copyOfdividedImage.Green[i][j] = dividedImage.Green[i][j];
                    copyOfdividedImage.Blue[i][j] = dividedImage.Blue[i][j];
                }
            }

            return copyOfdividedImage;
        }

        public void ImageDivider(Bitmap imageToProcess)
        {
            width = imageToProcess.Width;
            height = imageToProcess.Height;
            PixelFormat pixelFormat = imageToProcess.PixelFormat;

            imageSize = width * height;
            Pixels = new PixelPackage(imageSize);

            int counter = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y += Size)
                {
                    for (int i = 0; i < Size; i++)
                    {
                        Color color = imageToProcess.GetPixel(x, i + y);
                        Pixels.Red[counter][i] = color.R;
                        Pixels.Green[counter][i] = color.G;
                        Pixels.Blue[counter][i] = color.B;
                        counter++;
                    }
                }
            }

            this.CopyOfOryginalImage = CopyArrayOfBitmap(Pixels);
        }

        public Bitmap JoinIntoBigOne()
        {
            Bitmap image = new Bitmap(width, height);

            int counter = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y += Size)
                {
                    for (int i = 0; i < Size; i++)
                    {
                        Color color = Color.FromArgb(
                           Pixels.Red[counter][i],
                           Pixels.Green[counter][i],
                           Pixels.Blue[counter][i]);

                        image.SetPixel(x, i + y, color);
                        counter++;
                    }
                }
            }
            return image;
        }
    }
}
