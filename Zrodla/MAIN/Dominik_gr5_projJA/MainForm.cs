using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ColorToGrayScale
{
    public partial class MainForm : Form
    {
        private readonly IImageService imageService;

        private readonly IThreadsService threadsService;

        private readonly ITimeCounterService timeCounter;

        private Bitmap imageToProcess;

        private int processorCount;

        private Bitmap[] dividedImage;
                
        public MainForm(
            IImageService _imageService,
            IThreadsService _threadsService,
            ITimeCounterService _timeCounterService)
        {
            InitializeComponent();
            imageService = _imageService;
            threadsService = _threadsService;
            this.timeCounter = _timeCounterService;
        }

        public delegate void EndOfThreads();

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
            IDll chosenDll;

            if (radioButton_ASM.Checked == true)
            {
                chosenDll = new AsmDll();
            }
            else if (radioButton_dotNet.Checked == true)
            {
                //chosemDll = new CppDll();
                chosenDll = new AsmDll();
            }
            else
            {
                throw new Exception();
            }

            chosenDll.ProcessingMethod = chosenDll.ColorChanger;
            
            threadsService.ProcessingFunction = chosenDll.ChangeColorToGrayScale;
            threadsService.EndOfThreads = new EndOfThreads(UpdateModifiedPhoto);
            threadsService.ThreadsNo = processorCount;
            threadsService.DataToProcess = dividedImage;
                        
            timeCounter.Start();
            threadsService.StartProcessing();
        }
    }
}
