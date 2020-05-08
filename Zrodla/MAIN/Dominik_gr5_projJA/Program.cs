using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ColorToGrayScale.DllManager;
using ColorToGrayScale.Exceptions;
using ColorToGrayScale.ImageServices;
using ColorToGrayScale.LoggingService;
using ColorToGrayScale.ThreadsServices;
using SimpleInjector;

namespace ColorToGrayScale
{
    public static class Program
    {
        private static readonly string[] LibList = { "C_DLL.dll", "ASM_DLL.dll" };

        private static Container container;

        [STAThread]
        public static void Main()
        {
            foreach (string lib in LibList)
            {
                if (!File.Exists(lib))
                {
                    // tak, mam swiadomosc istnienia DllNotFoundException();
                    throw new DllFileNotExistException(lib);
                }
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