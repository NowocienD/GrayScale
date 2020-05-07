using System;

namespace ColorToGrayScale
{
    public class TimeCounterHelper
    {
        private int startTime;

        private int stopTime;

        public string Time
        {
            get => (stopTime - startTime).ToString() + " ms";
        }

        public void Start()
        {
            startTime = Environment.TickCount;
        }

        public void Stop()
        {
            stopTime = Environment.TickCount;
        }
    }
}
