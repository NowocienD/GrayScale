using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;


namespace Dominik_gr5_projJA
{
    public interface IThreadsService
    {
        void Spliter(int threadsNo, ParameterizedThreadStart func);
        void StartProcessing(Bitmap[] smallerImagesToProcess);
        bool isDone();
    }
}
