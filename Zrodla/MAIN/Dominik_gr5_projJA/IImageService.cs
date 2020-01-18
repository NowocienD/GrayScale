using System.Drawing;

namespace ColorToGrayScale
{
    public interface IImageService
    {
        int Length { get; }

        PixelPackage CopyOfOryginalImage { get; }

        void ImageDivider(Bitmap imageToProcess);

        Bitmap JoinIntoBigOne();
    }
}
