using System.Drawing;

namespace ColorToGrayScale
{
    public static class ToGrayScaleCSharp
    {
        public static Color Process(Color color)
        {
            int grayScaleColor = (color.R + color.G + color.B) / 3;
            return Color.FromArgb(
                grayScaleColor,
                grayScaleColor,
                grayScaleColor);
        }
    }
}
