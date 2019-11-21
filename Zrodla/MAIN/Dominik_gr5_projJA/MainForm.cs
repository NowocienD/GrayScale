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
            
#if DEBUG
            this.imageToProcess = new Bitmap(Image.FromFile(@"C:\Users\Dominik\Pictures\rose-blue-flower-rose-blooms-67636.jpeg"));
            pictureBox_original.Image = imageToProcess;            
            StartBTN.Enabled = true;            
#endif
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
                pictureBox_original.Image = imageToProcess;
                StartBTN.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Błąd łądowania zdjęcia \n\n" + exception.Message);
            }
        }

        private void StartBTN_Click(object sender, EventArgs e)
        {
            if (radioButton_ASM.Checked == true)
            {
                threadsService.ProcessingFunction = dllService.ProcessUsingASM;
            }
            else if (radioButton_dotNet.Checked == true)
            {
                threadsService.ProcessingFunction = dllService.ProcessUsingCPP;
            }
            else
            {
                throw new Exception();
            }

            threadsService.ThreadsNo = processorCount;
            threadsService.DataToProcess = imageService.ImageDivider(imageToProcess);
                        
            timeCounter.Start();
            threadsService.StartProcessing();
            while (!threadsService.IsDone());
            timeCounter.Stop();

            label_time.Text = timeCounter.Time.ToString() + " ms";
            pictureBox_modified.Image = imageService.JoinIntoBigOne(threadsService.DataToProcess);
        }
    }
}
