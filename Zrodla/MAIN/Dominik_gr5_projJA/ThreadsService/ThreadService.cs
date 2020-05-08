using System;
using System.Drawing;
using System.Threading;
using ColorToGrayScale.Helpers;
using ColorToGrayScale.LoggingService;
using static ColorToGrayScale.MainForm;

namespace ColorToGrayScale.ThreadsServices
{
    public class ThreadService : IThreadsService
    {
        private static readonly object Locker = new object();

        private static int count = 0;

        private readonly TimeCounterHelper timeCounter;

        private readonly ILogerService loger;

        private Thread[] threads;

        private int threadsReady;

        public ThreadService(ILogerService logerService)
        {
            this.loger = logerService;
            this.timeCounter = new TimeCounterHelper();
        }

        public string Time { get => timeCounter.Time; }

        public int ThreadsCount { internal get; set; }

        public EndOfThreads EndOfThreads { internal get; set; }

        public ThreadStart ProcessingFunction { internal get; set; }

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
            threadsReady = 0;

            ThreadStart ts = ProcessingFunction;
            ts += ThreadDone;

            threads = new Thread[ThreadsCount];
            for (int i = 0; i < ThreadsCount; i++)
            {
                threads[i] = new Thread(ts);
                threads[i].Start();
            }

            loger.Debug(String.Format("Utworzono {0} watkow.", ThreadsCount));
        }

        private void ThreadDone()
        {
            threadsReady++;
            if (threadsReady == ThreadsCount)
            {
                timeCounter.Stop();
                EndOfThreads();
            }
        }
    }
}
