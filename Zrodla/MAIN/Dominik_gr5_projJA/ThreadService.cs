using System;
using System.Threading;
using static ColorToGrayScale.MainForm;

namespace ColorToGrayScale
{
    public class ThreadService<T> : IThreadsService<T>
    {
        private static readonly object Locker = new object();

        private static int count = 0;

        private Thread[] threads;

        public int ThreadsNo { internal get; set; }

        public T[] DataToProcess { get; set; }
        
        public EndOfThreads endOfThreads { internal get; set; }

        public ParameterizedThreadStart ProcessingFunction { internal get; set; }

        public static int GetI()
        {
            int i = 0;
            lock (Locker)
            {
                i = count;
                count++;
            }
            return i;
        }

        public void StartProcessing()
        {
            count = 0;
            threads = new Thread[ThreadsNo];
            for (int i = 0; i < ThreadsNo; i++)
            {
                threads[i] = new Thread(ProcessingFunction);
                threads[i].Start(DataToProcess);
            }

            Thread main = new Thread(t =>
            {
                while (!IsDone()) 
                {
                }
                endOfThreads();
            });

            main.Start();
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
