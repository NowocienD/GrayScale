using System.Windows.Forms;
using ColorToGrayScale.DllServices.DllsLibs;

namespace ColorToGrayScale.DllServices
{
    public interface IDllService
    {
        IDll Dll { get; }

        void ChooseDll(GroupBox groupBox);

        void ChooseMethod(GroupBox groupBox);
    }
}