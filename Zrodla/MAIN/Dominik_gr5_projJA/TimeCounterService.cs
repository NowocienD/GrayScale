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

        public int Time 
        { 
            get => stopTime - startTime; 
            internal set => Time = value; 
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
