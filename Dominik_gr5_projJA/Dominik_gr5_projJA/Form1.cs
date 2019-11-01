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
        private readonly IThreadsService threadsService;

        public Form1(
            IImageService _imageService,
            IThreadsService _threadsService)
        {
            InitializeComponent();
            imageService = _imageService;
            threadsService = _threadsService;
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


            threadsService.Spliter(processorCount, new ImageProcessor().processingMethod);

            Bitmap[] b = imageService.ImageDivider(imageToProcess, processorCount);

            int startTime, endTime;
            startTime = Environment.TickCount & Int32.MaxValue;
            threadsService.StartProcessing(b);
            while (!threadsService.isDone()) ;
            endTime = Environment.TickCount & Int32.MaxValue;

            label_time.Text = (endTime - startTime).ToString();
            pictureBox_modified.Image = imageService.JoinIntoBigOne(b);
        }
    }
}
