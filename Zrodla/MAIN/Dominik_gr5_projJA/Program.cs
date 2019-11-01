﻿using System;
using System.Drawing;
using System.Windows.Forms;
using SimpleInjector;

namespace ColorToGrayScale
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
            Application.Run( container.GetInstance<MainForm>() );
        }
        /// <summary>
        /// Metoda zarządająca kontenerem usług 
        /// Próba implementacji dependency injection w aplikacji Windows Forms
        /// </summary>
        private static void Bootstrap()
        {
            container = new Container();
            container.Register<MainForm>();

            container.Register<IImageService, ImageService>();
            container.Register<IThreadsService<Bitmap>, ThreadService<Bitmap>>();
        }
    }
}