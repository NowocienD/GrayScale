using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorToGrayScale
{
    public class TimeCounterService : ITimeCounterService
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
