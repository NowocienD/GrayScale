using System.Threading;

namespace ColorToGrayScale
{
    public interface IThreadsService<T>
    {
        int ThreadsNo { set; }

        T[] DataToProcess { get; set; }

        ParameterizedThreadStart ProcessingFunction { set; }

        void StartProcessing();

        bool IsDone();
        
        Thread MainThread { get; set; }
    }
}
