using System.Threading;

namespace ColorToGrayScale
{
    public class ThreadService<T> : IThreadsService<T>
    {
        private Thread[] threads;

        public int ThreadsNo { internal get; set; }

        public T[] DataToProcess { get; set; }

        public ParameterizedThreadStart ProcessingFunction { internal get; set; }

        public void StartProcessing()
        {
            threads = new Thread[ThreadsNo];
            for (int i = 0; i < ThreadsNo; i++)
            {
                threads[i] = new Thread(ProcessingFunction);
                threads[i].Start(DataToProcess[i]);
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
