using System.Threading;

namespace ColorToGrayScale
{
    public class ThreadService<T> : IThreadsService<T>
    {
        private Thread[] threads;

        private int count;

        public int ThreadsNo { internal get; set; }

        public T[] DataToProcess { get; set; }

        public ParameterizedThreadStart ProcessingFunction { internal get; set; }

        public Thread MainThread { get; set; }

        public void StartProcessing()
        {
            threads = new Thread[ThreadsNo];
            for (int i = 0; i < ThreadsNo; i++)
            {
                threads[i] = new Thread(ProcessingFunction);
                threads[i].Start(DataToProcess[i]);
            }
            count = ThreadsNo;

            MainThread = new Thread(StartProcessing2);
            MainThread.Start();
        }

        public void StartProcessing2(object obj)
        {
            while (count < DataToProcess.Length)
            {
                WhichIsFree();
            }
         }

        private void WhichIsFree()
        {
            for (int i = 0; i < ThreadsNo; i++)
            {
                if (threads[i].ThreadState == ThreadState.Stopped)
                {
                    threads[i] = new Thread(ProcessingFunction);
                    threads[i].Start(DataToProcess[count]);
                    count++;
                    return;
                }
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
