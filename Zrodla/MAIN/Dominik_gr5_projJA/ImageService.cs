using System.Drawing;

namespace ColorToGrayScale
{
    public class ImageService : IImageService
    {
        private int WidthOfSmallerPart = 1;

        public Bitmap[] ImageDivider(Bitmap imageToProcess)
        {
            int startWidht = 0;
            int width = imageToProcess.Width;
            int height = imageToProcess.Height;

            Bitmap[] smallerImagesToProcess = new Bitmap[width / WidthOfSmallerPart];

            System.Drawing.Imaging.PixelFormat format = imageToProcess.PixelFormat;

            for (int i = 0; i < width / WidthOfSmallerPart; i++)
            {
                Rectangle rect = new Rectangle(
                        startWidht,
                        0,
                        WidthOfSmallerPart,
                        height);

                smallerImagesToProcess[i] = imageToProcess.Clone(rect, format);

                startWidht += WidthOfSmallerPart;
            }

            return smallerImagesToProcess;
        }

        public Bitmap JoinIntoBigOne(Bitmap[] smallImagesToProcess)
        {
            int width = smallImagesToProcess.Length * WidthOfSmallerPart;
            int height = smallImagesToProcess[0].Height;

            Bitmap imageDTO = new Bitmap(width, height);

            Graphics graphic = Graphics.FromImage(imageDTO);

            int offset = 0;
            foreach (Bitmap image in smallImagesToProcess)
            {
                Rectangle rectangle = new Rectangle(offset, 0, image.Width, image.Height);

                graphic.DrawImage(
                    image,
                    rectangle);

                offset += WidthOfSmallerPart;
            }

            return imageDTO;
        }
    }
}
