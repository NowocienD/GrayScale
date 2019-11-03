using System.Threading;

namespace ColorToGrayScale
{
    public class ThreadService<T> : IThreadsService<T>
    {
        private Thread[] threads;

        public int threadsNo { internal get; set; }

        public T[] dataToProcess { get; set; }

        public ParameterizedThreadStart Func { internal get; set; }

        public void StartProcessing()
        {
            threads = new Thread[threadsNo];
            for (int i = 0; i < threadsNo; i++)
            {
                threads[i] = new Thread(Func);
                threads[i].Start(dataToProcess[i]);
            }
        }

        public bool IsDone()
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
