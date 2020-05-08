using System.Drawing;
using System.Threading;
using static ColorToGrayScale.MainForm;

namespace ColorToGrayScale.ThreadsServices
{
    public interface IThreadsService
    {
        string Time { get; }

        int ThreadsCount { set; }

        ThreadStart ProcessingFunction { set; }

        EndOfThreads EndOfThreads { set; }

        void StartProcessing();
    }
}
