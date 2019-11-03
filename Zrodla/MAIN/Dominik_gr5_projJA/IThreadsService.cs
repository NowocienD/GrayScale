using System.Threading;

namespace ColorToGrayScale
{
    public interface IThreadsService<T>
    {
        int threadsNo { set; }

        T[] dataToProcess { get; set; }

        ParameterizedThreadStart Func { set; }

        void StartProcessing();

        bool IsDone();
    }
}
