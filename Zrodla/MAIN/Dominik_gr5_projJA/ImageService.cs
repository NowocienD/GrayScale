using System.Drawing;

namespace ColorToGrayScale
{
    public class ImageService : IImageService
    {
        private int size = 16;
        private int height;
        private int width;

        public Bitmap[] ImageDivider(Bitmap imageToProcess)
        {
            width = imageToProcess.Width;
            height = imageToProcess.Height;

            int numberOfVerticalParts = height / size;

            if (height % size != 0)
            {
                height = size * numberOfVerticalParts;
                imageToProcess = imageToProcess.Clone(
                    new Rectangle(
                        0,
                        0,
                        width,
                        height),
                    imageToProcess.PixelFormat);
            }

            int partsNumber = width * numberOfVerticalParts;

            Bitmap[] smallerImagesToProcess = new Bitmap[width * numberOfVerticalParts];

            System.Drawing.Imaging.PixelFormat format = imageToProcess.PixelFormat;

            int counter = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y += size)
                {
                    Rectangle rect = new Rectangle(
                            x,
                            y,
                            1,
                            size);

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
                for (int y = 0; y < height; y += size)
                {
                    Rectangle rectangle = new Rectangle(
                        x,
                        y,
                        1,
                        size);

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
