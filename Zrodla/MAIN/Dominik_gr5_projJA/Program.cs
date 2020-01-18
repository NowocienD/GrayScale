using System;
using System.Drawing;
using System.Windows.Forms;
using SimpleInjector;

namespace ColorToGrayScale
{
    public static class Program
    {
        private static Container container;

        [STAThread]
        public static void Main()
        {
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
            container.Register<ITimeCounterService, TimeCounterService>();
        }
    }
}