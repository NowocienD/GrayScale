using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dominik_gr5_projJA
{
    public interface IImageService
    {
        Bitmap[] ImageDivider(Bitmap imageToProcess, int threadsNo);
        Bitmap JoinIntoBigOne(Bitmap[] smallImagesToProcess);
    }
}
