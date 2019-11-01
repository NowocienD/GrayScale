using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;


namespace Dominik_gr5_projJA
{
    public interface IThreadsService<T>
    {
        int threadsNo { get; set; }
        T[] dataToProcess { get; set; }
        void Spliter(ParameterizedThreadStart func);
        void StartProcessing();
        bool isDone();
    }
}
