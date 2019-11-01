using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Dominik_gr5_projJA
{
    class ImageProcessor
    {
        private int threadsNo;
        private Bitmap imageToProcess;
        private Bitmap[] smallerImagesToProcess;
        private Thread[] threads;

        public Bitmap imageDTO { get; internal set; }

        public ImageProcessor(int threadsNo, Bitmap img, bool dllSelect)
        {
            this.threadsNo = threadsNo;
            this.imageToProcess = img;
            threads = new Thread[threadsNo];
            smallerImagesToProcess = new Bitmap[threadsNo];
        }

        public void threadsSpliter()
        {
            for (int i = 0; i < threadsNo; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(processingMethod));
            }
        }

        public void ImageDivider()
        {
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
        }

        public void processingMethod(Object im)
        {
            Bitmap image = (Bitmap)im;
            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                {
                    Color color = ToGrayScaleCSharp.Process(image.GetPixel(x, y));

                    image.SetPixel(
                        x,
                        y, 
                        color);
                }
        }

        public void Start()
        {
            for (int i = 0; i < threadsNo; i++)
            {
                threads[i].Start(smallerImagesToProcess[i]);
            }
        }

        public bool checkIfDone()
        {
            foreach (Thread t in threads)
                if (t.ThreadState != ThreadState.Stopped)
                    return false;
            return true;
        }

        public void JoinIntoBigOne()
        {
            Rectangle rect = new Rectangle(
                    0,
                    0,
                    imageToProcess.Width,
                    imageToProcess.Height);

            imageDTO = imageToProcess.Clone(rect, imageToProcess.PixelFormat);

            Graphics graphic = Graphics.FromImage(imageDTO);
            
            int offset = 0;
            foreach (Bitmap image in smallerImagesToProcess)
            {
                Rectangle rectangle = new Rectangle(offset, 0, image.Width, image.Height);

                graphic.DrawImage(
                    image,
                    rectangle);
                offset += image.Width;
            }
        }
    }
}
