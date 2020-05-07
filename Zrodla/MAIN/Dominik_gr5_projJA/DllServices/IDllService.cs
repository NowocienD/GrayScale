using System.Windows.Forms;

namespace ColorToGrayScale.DllManager
{
    public interface IDllService
    {
        IDll Dll { get; }

        void ChooseDll(GroupBox groupBox);

        void ChooseMethod(GroupBox groupBox);
    }
}
