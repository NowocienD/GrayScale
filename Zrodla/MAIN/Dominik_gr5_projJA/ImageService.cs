using System.Drawing;

namespace ColorToGrayScale
{
    public class ImageService : IImageService
    {
        private const int Size = 16;
        private int height;
        private int width;

        public Bitmap[] CopyArrayOfBitmap(Bitmap[] dividedImage)
        {
            Bitmap[] copyOfdividedImage = new Bitmap[dividedImage.Length];
            for (int i = 0; i < dividedImage.Length; i++)
            {
                copyOfdividedImage[i] = (Bitmap)dividedImage[i].Clone();
            }
            return copyOfdividedImage;
        }

        public Bitmap[] ImageDivider(Bitmap imageToProcess)
        {
            width = imageToProcess.Width;
            height = imageToProcess.Height;

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
                    imageToProcess.PixelFormat);
            }
            
            Bitmap[] smallerImagesToProcess = new Bitmap[width * numberOfVerticalParts];

            System.Drawing.Imaging.PixelFormat format = imageToProcess.PixelFormat;

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

                    smallerImagesToProcess[counter] = imageToProcess.Clone(rect, format);
                    counter++;
                }
            }
            return smallerImagesToProcess;
        }

        public Bitmap JoinIntoBigOne(Bitmap[] smallImagesToProcess)
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
                        smallImagesToProcess[counter],
                        rectangle);

                    counter++;
                }
            }
            return image;
        }
    }
}
