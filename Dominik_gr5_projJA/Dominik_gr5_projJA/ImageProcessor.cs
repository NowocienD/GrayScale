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
        public Bitmap[] smallerImagesToProcess;
        private Thread[] threads;

        public Bitmap imageDTO { get; internal set; }

        public ImageProcessor(int threadsNo, Bitmap img, bool dllSelect)
        {
            this.threadsNo = threadsNo;
            this.imageToProcess = img;
            threads = new Thread[threadsNo];
        }

        public void threadsSpliter()
        {
            for (int i = 0; i < threadsNo; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(processingMethod));
            }
        }


        public void processingMethod(Object obj)
        {
            Bitmap image = (Bitmap)obj;

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
            {
                if (t.ThreadState != ThreadState.Stopped)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
