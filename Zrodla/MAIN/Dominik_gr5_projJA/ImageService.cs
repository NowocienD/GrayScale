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

        public PixelPackage[] CopyArrayOfBitmap(PixelPackage[] dividedImage)
        {
            PixelPackage[] copyOfdividedImage = new PixelPackage[dividedImage.Length];
            for (int i = 0; i < dividedImage.Length; i++)
            {
                //copyOfdividedImage[i] = (PixelPackage)dividedImage[i];
            }
            return copyOfdividedImage;
        }

        public PixelPackage[] ImageDivider(Bitmap imageToProcess)
        {
            width = imageToProcess.Width;
            height = imageToProcess.Height;
            PixelFormat pixelFormat = imageToProcess.PixelFormat;

            int numberOfVerticalParts = height / Size;

            if (height % Size != 0)
            {
                height = Size * numberOfVerticalParts;
                imageToProcess = imageToProcess.Clone(
                    new Rectangle(
                        0,
                        0,
                        width,
                        height),
                    pixelFormat);
            }

            PixelPackage[] smallerImagesToProcess = new PixelPackage[width * numberOfVerticalParts];

            int counter = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y += Size)
                {
                    Rectangle rect = new Rectangle(
                            x,
                            y,
                            1,
                            Size);

                    Bitmap a = (Bitmap)imageToProcess.Clone(rect, pixelFormat);

                    smallerImagesToProcess[counter] = new PixelPackage();
                    smallerImagesToProcess[counter].Set(a);
                    counter++;
                }
            }
            return smallerImagesToProcess;
        }

        public Bitmap JoinIntoBigOne(PixelPackage[] smallImagesToProcess)
        {
            Bitmap image = new Bitmap(width, height);

            Graphics graphic = Graphics.FromImage(image);

            int counter = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y += Size)
                {
                    Rectangle rectangle = new Rectangle(
                        x,
                        y,
                        1,
                        Size);

                    graphic.DrawImage(
                        smallImagesToProcess[counter].Get(),
                        rectangle);

                    counter++;
                }
            }
            return image;
        }
    }
}
