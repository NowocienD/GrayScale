using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dominik_gr5_projJA
{
    public partial class Form1 : Form
    {
        private Bitmap imageToProcess;
        private int processorCount;

        private readonly IImageService imageService;

        public Form1(IImageService _imageService)
        {
            InitializeComponent();
            imageService = _imageService;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.processorCount = System.Environment.ProcessorCount;
            trackBar_Threads.Value = processorCount;
            label_Threads.Text = processorCount.ToString();
        }

        private void trackBar_Threads_Scroll(object sender, EventArgs e)
        {
            processorCount = trackBar_Threads.Value;
            label_Threads.Text = processorCount.ToString();
        }

        private void PhotoBTN_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            Image imageToProcess = Image.FromFile(openFileDialog1.FileName);
            pictureBox_original.Image = imageToProcess;
            this.imageToProcess = new Bitmap(imageToProcess);
        }

        private void StartBTN_Click(object sender, EventArgs e)
        {
            int start, stop;

            ImageProcessor imp = new ImageProcessor(processorCount, imageToProcess, true);
            Bitmap[] b = imageService.ImageDivider(imageToProcess, processorCount);
            imp.smallerImagesToProcess = b; 

            imp.threadsSpliter();

            start = Environment.TickCount & Int32.MaxValue;
            imp.Start();
            while (!imp.checkIfDone()) ;
            stop = Environment.TickCount & Int32.MaxValue;

            Bitmap btm = imageService.JoinIntoBigOne(b);

            label_time.Text = (stop - start).ToString();

            pictureBox_modified.Image = btm;
        }
    }
}
