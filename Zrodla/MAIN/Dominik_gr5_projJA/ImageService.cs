using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace ColorToGrayScale
{
    class ImageService : IImageService
    {
        public Bitmap[] ImageDivider(Bitmap imageToProcess, int threadsNo)
        {
            Bitmap[] smallerImagesToProcess;
            smallerImagesToProcess = new Bitmap[threadsNo];

            int offset = imageToProcess.Width / threadsNo;
            int startWidht = 0;
            int height = imageToProcess.Height;

            System.Drawing.Imaging.PixelFormat format = imageToProcess.PixelFormat;

            for (int i = 0; i < threadsNo; i++)
            {
                Rectangle rect = new Rectangle(
                        startWidht,
                        0,
                        offset,
                        height);

                smallerImagesToProcess[i] = imageToProcess.Clone(rect, format);

                startWidht += offset;
            }

            return smallerImagesToProcess;
        }

        public Bitmap JoinIntoBigOne(Bitmap[] smallImagesToProcess)
        {
            int width = 0;
            int height = smallImagesToProcess[0].Height;
            foreach (Bitmap item in smallImagesToProcess)
            {
                width += item.Width;
            }

            Rectangle rect = new Rectangle(
                    0,
                    0,
                    width,
                    height);

            Bitmap imageDTO = new Bitmap(width, height); // imageToProcess.Clone(rect, pxFormat);

            Graphics graphic = Graphics.FromImage(imageDTO);

            int offset = 0;
            foreach (Bitmap image in smallImagesToProcess)
            {
                Rectangle rectangle = new Rectangle(offset, 0, image.Width, image.Height);

                graphic.DrawImage(
                    image,
                    rectangle);

                offset += image.Width;
            }

            return imageDTO;
        }
    }
}
