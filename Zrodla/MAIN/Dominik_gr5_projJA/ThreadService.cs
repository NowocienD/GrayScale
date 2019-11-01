using System.Threading;

namespace ColorToGrayScale
{
    class ThreadService<T> : IThreadsService<T>
    {
        private Thread[] threads;
        public int threadsNo { get; set; }
        public T[] dataToProcess { get; set; }

        public void Spliter(ParameterizedThreadStart func)
        {
            threads = new Thread[threadsNo];

            for (int i = 0; i < threadsNo; i++)
            {
                threads[i] = new Thread(func);
            }
        }
        public void StartProcessing()
        {
            for (int i = 0; i < threadsNo; i++)
            {
                threads[i].Start(dataToProcess[i]);
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
