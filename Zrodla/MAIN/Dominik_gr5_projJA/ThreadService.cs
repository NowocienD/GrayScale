using System;
using System.Drawing;
using System.Threading;
using static ColorToGrayScale.MainForm;

namespace ColorToGrayScale
{
    public class ThreadService : IThreadsService
    {
        private static readonly object Locker = new object();

        private static int count = 0;

        private readonly ILogerService loger;

        private Thread[] threads;

        private TimeCounterHelper timeCounter = new TimeCounterHelper();

        public ThreadService(ILogerService logerService)
        {
            this.loger = logerService;
        }
        
        public string Time { get => timeCounter.Time; }

        public int ThreadsCount { internal get; set; }
                
        public EndOfThreads EndOfThreads { internal get; set; }

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
            timeCounter.Start();
            count = 0;
            threads = new Thread[ThreadsCount];
            for (int i = 0; i < ThreadsCount; i++)
            {
                threads[i] = new Thread(ProcessingFunction);
                threads[i].Start();
            }

            loger.Debug(String.Format("Utworzono {0} watkow.", ThreadsCount));

            Thread mainThread = new Thread(t =>
            {
                while (!IsDone())
                {
                }
                EndOfThreads();
            });

            mainThread.Start();
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
            timeCounter.Stop();
            return true;
        }
    }
}
