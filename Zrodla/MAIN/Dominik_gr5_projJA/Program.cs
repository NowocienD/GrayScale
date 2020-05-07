using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ColorToGrayScale.DllManager;
using ColorToGrayScale.Exceptions;
using ColorToGrayScale.LoggingService;
using SimpleInjector;

namespace ColorToGrayScale
{
    public static class Program
    {
        private static Container container;

        [STAThread]
        public static void Main()
        {
            if (!File.Exists("C_DLL.dll"))
            {
                // tak, mam swiadomosc istnienia DllNotFoundException();
                throw new DllFileNotExistException("C_DLL.dll");
            }

            if (!File.Exists("ASM_DLL.dll"))
            {
                throw new DllFileNotExistException("ASM_DLL.dll");
            }

            if (!Environment.Is64BitProcess)
            {
                throw new Notx64bitProcessException();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            Application.Run(container.GetInstance<MainForm>());
        }

        private static void Bootstrap()
        {
            container = new Container();
            container.Register<MainForm>();

            container.Register<IImageService, ImageService>();
            container.Register<IThreadsService, ThreadService>();
            container.RegisterSingleton<ILogerService, LogerService>();
            container.Register<IDllService, DllService>();
        }
    }
}