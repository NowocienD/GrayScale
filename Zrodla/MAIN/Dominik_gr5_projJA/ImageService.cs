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
        private PixelPackage<byte> copyOfImage;
        private PixelPackage<byte> pixels;

        public int Length { get; internal set; }

        public PixelPackage<byte> CopyOfOryginalImage
        {
            get
            {
                pixels = CopyArrayOfBitmap(copyOfImage);
                return pixels;
            }
        }

        public PixelPackage<byte> CopyArrayOfBitmap(PixelPackage<byte> imagePixelsArray)
        {
            PixelPackage<byte> copyOfdividedImage = new PixelPackage<byte>(Length);

            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    copyOfdividedImage.Red[i][j] = imagePixelsArray.Red[i][j];
                    copyOfdividedImage.Green[i][j] = imagePixelsArray.Green[i][j];
                    copyOfdividedImage.Blue[i][j] = imagePixelsArray.Blue[i][j];
                }
            }

            return copyOfdividedImage;
        }

        public void ImageDivider(Bitmap imageToProcess)
        {
            this.width = imageToProcess.Width;
            this.height = imageToProcess.Height;
            this.Length = width * height;
            this.pixels = new PixelPackage<byte>(Length);

            int counter = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y += Size)
                {
                    for (int i = 0; i < Size; i++)
                    {
                        Color color = imageToProcess.GetPixel(x, i + y);
                        pixels.Red[counter][i] = color.R;
                        pixels.Green[counter][i] = color.G;
                        pixels.Blue[counter][i] = color.B;
                        counter++;
                    }
                }
            }
            this.copyOfImage = CopyArrayOfBitmap(pixels);
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
                           pixels.Red[counter][i],
                           pixels.Green[counter][i],
                           pixels.Blue[counter][i]);

                        image.SetPixel(x, i + y, color);
                        counter++;
                    }
                }
            }
            return image;
        }
    }
}
