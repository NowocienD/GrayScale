using System.Drawing;

namespace ColorToGrayScale
{
    public interface IImageService
    {
        int Length { get; }

        PixelPackage<byte> CopyOfOryginalImage { get; }

        void ImageDivider(Bitmap imageToProcess);

        Bitmap JoinIntoBigOne();
    }
}
