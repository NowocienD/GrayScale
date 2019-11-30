using System.Threading;
using static ColorToGrayScale.MainForm;

namespace ColorToGrayScale
{
    public interface IThreadsService<T>
    {
        int ThreadsNo { set; }

        T[] DataToProcess { get; set; }

        ParameterizedThreadStart ProcessingFunction { set; }

        void StartProcessing();

        bool IsDone();

        EndOfThreads endOfThreads { set; }
    }
}
