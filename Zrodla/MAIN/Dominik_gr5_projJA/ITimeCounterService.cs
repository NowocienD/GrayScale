using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorToGrayScale
{
    public interface ITimeCounterService
    {
        int Time { get; }

        void Start();

        void Stop();
    }
}
