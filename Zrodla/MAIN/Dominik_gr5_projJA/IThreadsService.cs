using System.Drawing;
using System.Threading;
using static ColorToGrayScale.MainForm;

namespace ColorToGrayScale
{
    public interface IThreadsService
    {
        string Time { get; }

        int ThreadsCount { set; }
        
        ParameterizedThreadStart ProcessingFunction { set; }

        EndOfThreads EndOfThreads { set; }

        void StartProcessing();

        bool IsDone();
    }
}
