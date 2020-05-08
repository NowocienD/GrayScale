using System.Drawing;
using ColorToGrayScale.Helpers;

namespace ColorToGrayScale.ImageServices
{
    public interface IImageService
    {
        int Length { get; }

        PixelPackageHelper<byte> CopyOfOryginalImage { get; }

        void ImageDivider(Bitmap imageToProcess);

        Bitmap JoinIntoBigOne();
    }
}
