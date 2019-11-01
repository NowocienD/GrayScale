using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace Dominik_gr5_projJA
{
    class ThreadService : IThreadsService
    {
        private Thread[] threads;
        private int threadsNo;
        public Bitmap[] smallImagesToProcess;

        public void Spliter(int threadsNo, ParameterizedThreadStart func)
        {
            this.threadsNo = threadsNo;
            threads = new Thread[threadsNo];

            for (int i = 0; i < threadsNo; i++)
            {
                threads[i] = new Thread(func);
            }
        }
        public void StartProcessing(Bitmap[] smallerImagesToProcess)
        {
            for (int i = 0; i < threadsNo; i++)
            {
                threads[i].Start(smallerImagesToProcess[i]);
            }
        }

        public bool isDone()
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
