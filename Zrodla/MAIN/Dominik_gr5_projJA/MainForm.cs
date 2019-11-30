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

        private readonly ITimeCounterService timeCounter;

        private readonly IDllService dllService;

        private Bitmap imageToProcess;

        private int processorCount;

        private Bitmap[] dividedImage;

        public delegate void EndOfThreads();
        
        public MainForm(
            IImageService _imageService,
            IThreadsService<Bitmap> _threadsService,
            ITimeCounterService _timeCounterService,
            IDllService _dllService)
        {
            InitializeComponent();
            imageService = _imageService;
            threadsService = _threadsService;
            this.timeCounter = _timeCounterService;
            this.dllService = _dllService;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.processorCount = Environment.ProcessorCount;
            trackBar_Threads.Value = processorCount;
            label_Threads.Text = processorCount.ToString();
        }

        private void TrackBar_Threads_Scroll(object sender, EventArgs e)
        {
            processorCount = trackBar_Threads.Value;
            label_Threads.Text = processorCount.ToString();
        }

        private void PhotoBTN_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            try
            {
                this.imageToProcess = new Bitmap(Image.FromFile(openFileDialog.FileName));
                dividedImage = imageService.ImageDivider(imageToProcess);
                pictureBox_original.Image = imageToProcess;
                StartBTN.Enabled = true;

                pictureBox_modified.Image = imageToProcess;
            }
            catch
            {
                MessageBox.Show("Błąd łądowania zdjęcia");
            }
        }

        private void UpdateModifiedPhoto()
        {
            timeCounter.Stop();

            if (label_time.InvokeRequired)
            {
                label_time.Invoke(new EndOfThreads(UpdateModifiedPhoto));
            }
            else
            {
                label_time.Text = timeCounter.Time.ToString() + " ms"; 
                pictureBox_modified.Image = imageService.JoinIntoBigOne(threadsService.DataToProcess);
                StartBTN.Enabled = true;
            }
        }

        private void StartBTN_Click(object sender, EventArgs e)
        {
            label_time.Text = string.Empty;
            StartBTN.Enabled = false;

            if (radioButton_ASM.Checked == true)
            {
                threadsService.ProcessingFunction = dllService.ProcessUsingASM;
            }
            else if (radioButton_dotNet.Checked == true)
            {
                threadsService.ProcessingFunction = dllService.ProcessUsingASM;
            }
            else
            {
                throw new Exception();
            }

            threadsService.endOfThreads = new EndOfThreads(UpdateModifiedPhoto);
            threadsService.ThreadsNo = processorCount;
            threadsService.DataToProcess = dividedImage;
                        
            timeCounter.Start();
            threadsService.StartProcessing();
        }
    }
}
