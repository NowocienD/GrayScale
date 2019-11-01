using System;
using System.Drawing;
using System.Windows.Forms;
using SimpleInjector;

namespace Dominik_gr5_projJA
{
    static class Program
    {

        private static Container container;

        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap(); 
            Application.Run( container.GetInstance<Form1>() );
        }

        private static void Bootstrap()
        {
            container = new Container();
            container.Register<Form1>();

            container.Register<IImageService, ImageService>();
            container.Register<IThreadsService<Bitmap>, ThreadService<Bitmap>>();
        }
    }
}