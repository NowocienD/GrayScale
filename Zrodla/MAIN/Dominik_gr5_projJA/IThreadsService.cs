using System.Threading;

namespace ColorToGrayScale
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
