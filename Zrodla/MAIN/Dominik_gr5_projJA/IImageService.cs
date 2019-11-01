using System.Drawing;

namespace ColorToGrayScale
{
    /// <summary>
    /// Interfejs Usługi Image.
    /// pozwala na podzielenie i pozniejsze polaczenie obrazu na mniejsze w zaleśności od ilosći wątków.
    /// Celem jest pozniejsze szybsze przetwarzanie obrazu.
    /// </summary>
    public interface IImageService
    {
        /// <summary>
        /// Metoda dzieląca obraz na n mniejszych
        /// Umożlia pozniejsze jego przetwarzanie na większej ilości wątków
        /// </summary>
        /// <param name="imageToProcess">Obraz do przetworzenia</param>
        /// <param name="threadsNo">Liczba wątków na których będzie wykonywana operacja przetwarzania obrazu</param>
        /// <returns>Tablica z podzielonym obrazem na n częsci</returns>
        Bitmap[] ImageDivider(Bitmap imageToProcess, int threadsNo);

        /// <summary>
        /// Metoda łącząca wiele mniejszych przetworzonych obrazów w jeden cały
        /// </summary>
        /// <param name="smallImagesToProcess">Tablica zawierajaca mniejsze obrazy do polaczenia</param>
        /// <returns>Ostateczny obraz w docelowym rozmiarze</returns>
        Bitmap JoinIntoBigOne(Bitmap[] smallImagesToProcess);
    }
}
