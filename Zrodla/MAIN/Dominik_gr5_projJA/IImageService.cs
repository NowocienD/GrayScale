using System.Drawing;

namespace ColorToGrayScale
{
    public interface IImageService
    {
        int Length { get; }

        PixelPackageHelper<byte> CopyOfOryginalImage { get; }

        void ImageDivider(Bitmap imageToProcess);

        Bitmap JoinIntoBigOne();
    }
}
