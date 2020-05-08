using System.Windows.Forms;
using ColorToGrayScale.DllManager.DllsLibs;

namespace ColorToGrayScale.DllManager
{
    public interface IDllService
    {
        IDll Dll { get; }

        void ChooseDll(GroupBox groupBox);

        void ChooseMethod(GroupBox groupBox);
    }
}