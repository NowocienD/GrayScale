using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColorToGrayScale.DllManager.DllsLibs;

namespace ColorToGrayScale.DllManager
{
    public class DllService : IDllService
    {
        private readonly Dictionary<string, IDll> dllTypes = new Dictionary<string, IDll>
        {
            { "ASM", new AsmDll() },
            { "CPP", new CppDll() },
        };

        public IDll Dll { get; internal set; }

        public void ChooseDll(GroupBox groupBox)
        {
            // wybor ddl na podsawie tekstu z radioButtona zaznaczonego w wyslanym goupboxie
            RadioButton checkedRadioButton = groupBox.Controls.Cast<RadioButton>()
                                                              .Where(x => x.Checked)
                                                              .FirstOrDefault();

            Dll = dllTypes.Where(x => checkedRadioButton.Text.ToUpper().Contains(x.Key))
                          .First()
                          .Value;
        }

        public void ChooseMethod(GroupBox groupBox)
        {
            if (Dll == null)
            {
                throw new ArgumentNullException(String.Format("In var {0}", groupBox.Name));
            }

            // wybor metody na podsawie tekstu z radioButtona
            RadioButton checkedRadioButton = groupBox.Controls
                .Cast<RadioButton>()
                .Where(x => x.Checked)
                .First();

            var selectedMethod = Dll.GetType()
                .GetMethods()
                .Where(x => checkedRadioButton.Name.ToUpper().Contains(x.Name.ToUpper()))
                .First();

            Dll.ProcessingMethod = (ProcessingMethodDelegate)Delegate.CreateDelegate(typeof(ProcessingMethodDelegate), null, selectedMethod);
        }
    }
}
