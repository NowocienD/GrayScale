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

        private Bitmap imageToProcess;

        private int processorCount;

        private Bitmap[] dividedImage;

        private Bitmap[] copyOfdividedImage;

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

                timeCounter.Start();
                dividedImage = imageService.ImageDivider(imageToProcess);
                copyOfdividedImage = imageService.CopyArrayOfBitmap(dividedImage);

                timeCounter.Stop();
                time_divide_label.Text = timeCounter.Time;

                pictureBox_original.Image = imageToProcess;
                StartBTN.Enabled = true;
                BitmapParts_label.Text = dividedImage.Length.ToString();

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
                label_time.Text = timeCounter.Time;
                timeCounter.Start();
                pictureBox_modified.Image = imageService.JoinIntoBigOne(threadsService.DataToProcess);
                StartBTN.Enabled = true;
                timeCounter.Stop();
                time_join_label.Text = timeCounter.Time;
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
            //else if (radioButton_dotNet.Checked == true)
            //{
            //chosenDll = new CppDll();
            //}
            else
            {
                throw new Exception();
            }

            if (RSCC_radio.Checked)
            {
                chosenDll.ProcessingMethod = chosenDll.SingleColorChannel_Red;
            }
            else if (GSCC_radio.Checked)
            {
                chosenDll.ProcessingMethod = chosenDll.SingleColorChannel_Green;
            }
            else if (BSCC_radio.Checked)
            {
                chosenDll.ProcessingMethod = chosenDll.SingleColorChannel_Blue;
            }
            else if (decomposition_max_radio.Checked)
            {
                chosenDll.ProcessingMethod = chosenDll.Decomposition_max;
            }
            else if (decomposition_min_radio.Checked)
            {
                chosenDll.ProcessingMethod = chosenDll.Decomposition_min;
            }
            else if (desaturation_radio.Checked)
            {
                chosenDll.ProcessingMethod = chosenDll.Desaturation;
            }
            else
            {
                throw new Exception();
            }
            
            dividedImage = imageService.CopyArrayOfBitmap(copyOfdividedImage);
            threadsService.ProcessingFunction = chosenDll.ChangeColorToGrayScale;
            threadsService.EndOfThreads = new EndOfThreads(UpdateModifiedPhoto);
            threadsService.ThreadsNo = processorCount;
            threadsService.DataToProcess = dividedImage;
                        
            timeCounter.Start();
            threadsService.StartProcessing();
            imageToProcess.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var memory = 0.0;
            Process proc = Process.GetCurrentProcess();
            memory = Math.Round(proc.PrivateMemorySize64 / 1e+6, 2);
            proc.Dispose();

            RAMUsage_label.Text = memory.ToString();
        }
    }
}
