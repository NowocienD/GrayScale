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
        PixelPackage Pixels { get; set; }

        PixelPackage CopyOfOryginalImage { get; set; }

        void ImageDivider(Bitmap imageToProcess);

        Bitmap JoinIntoBigOne();

        PixelPackage CopyArrayOfBitmap(PixelPackage dividedImage);
    }
}
