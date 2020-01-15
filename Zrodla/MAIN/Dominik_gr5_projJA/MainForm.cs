using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ColorToGrayScale
{
    public partial class MainForm : Form
    {
        private readonly IImageService imageService;

        private readonly IThreadsService threadsService;

        private readonly ITimeCounterService timeCounter;

        private int processorCount;

        //private Bitmap imageToProcess;

        //private PixelPackage dividedImage;

        //private PixelPackage copyOfdividedImage;

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

            //try
            //{
            Bitmap imageToProcess = new Bitmap(Image.FromFile(openFileDialog.FileName));

            imageToProcess = imageToProcess.Clone(new Rectangle(0, 0, imageToProcess.Width, imageToProcess.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            timeCounter.Start();
            imageService.ImageDivider(imageToProcess);
            timeCounter.Stop();
            time_divide_label.Text = timeCounter.Time;

            pictureBox_original.Image = imageToProcess;
            StartBTN.Enabled = true;
            BitmapParts_label.Text = imageService.pixels.Length.ToString();

            imageService.copy = imageService.CopyArrayOfBitmap(imageService.pixels);

            try 
            { 
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
                label_time.Text = timeCounter.Time;

                timeCounter.Start();
                pictureBox_modified.Image = imageService.JoinIntoBigOne();
                timeCounter.Stop();
                time_join_label.Text = timeCounter.Time;

                StartBTN.Enabled = true;
            }
        }

        private void ChooseFunction(IDll dll)
        {
            if (RSCC_radio.Checked)
            {
                dll.ProcessingMethod = dll.SingleColorChannel_Red;
            }
            else if (GSCC_radio.Checked)
            {
                dll.ProcessingMethod = dll.SingleColorChannel_Green;
            }
            else if (BSCC_radio.Checked)
            {
                dll.ProcessingMethod = dll.SingleColorChannel_Blue;
            }
            else if (decomposition_max_radio.Checked)
            {
                dll.ProcessingMethod = dll.Decomposition_max;
            }
            else if (decomposition_min_radio.Checked)
            {
                dll.ProcessingMethod = dll.Decomposition_min;
            }
            else if (desaturation_radio.Checked)
            {
                dll.ProcessingMethod = dll.Desaturation;
            }
            else
            {
                throw new Exception();
            }
        }

        private IDll ChooseDll()
        {
            if (radioButton_ASM.Checked == true)
            {
                return new AsmDll();
            }
            else if (radioButton_dotNet.Checked == true)
            {
                return new CppDll();
            }
            else
            {
                throw new Exception();
            }
        }

        private void StartBTN_Click(object sender, EventArgs e)
        {
            imageService.pixels = imageService.CopyArrayOfBitmap(imageService.copy);
            label_time.Text = string.Empty;
            StartBTN.Enabled = false;

            IDll dll = ChooseDll();
            ChooseFunction(dll);
            
            //dll.Pixels = imageService.pixels;

            dll.Pixels = imageService.pixels;

            threadsService.ProcessingFunction = dll.ChangeColorToGrayScale;
            threadsService.EndOfThreads = new EndOfThreads(UpdateModifiedPhoto);
            threadsService.ThreadsNo = processorCount;
            //threadsService.DataToProcess = imageService.pixels;
                        
            timeCounter.Start();
            threadsService.StartProcessing();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            double memory;
            Process proc = Process.GetCurrentProcess();
            memory = Math.Round(proc.PrivateMemorySize64 / 1e+6, 0);
            proc.Dispose();

            RAMUsage_label.Text = memory.ToString();
        }
    }
}