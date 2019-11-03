using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ColorToGrayScale
{
    public partial class MainForm : Form
    {
        private readonly IImageService imageService;

        private readonly IThreadsService<Bitmap> threadsService;

        private Bitmap imageToProcess;

        private int processorCount;

        public MainForm(
            IImageService _imageService,
            IThreadsService<Bitmap> _threadsService)
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
            this.imageToProcess = new Bitmap(Image.FromFile(@"C:\Users\Dominik\Pictures\rose-blue-flower-rose-blooms-67636.jpeg"));
            pictureBox_original.Image = imageToProcess;
        }

        private void TrackBar_Threads_Scroll(object sender, EventArgs e)
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
           threadsService.threadsNo = processorCount;
            threadsService.dataToProcess = imageService.ImageDivider(imageToProcess, processorCount);
            threadsService.Spliter(new ImageProcessor().processingMethod);

            int startTime, endTime;
            startTime = Environment.TickCount;
            threadsService.StartProcessing();
            while (!threadsService.isDone())
            { 
            }
            endTime = Environment.TickCount;

            label_time.Text = (endTime - startTime).ToString() + " ms";
            pictureBox_modified.Image = imageService.JoinIntoBigOne(threadsService.dataToProcess);
        }
    }
}
