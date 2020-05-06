using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using ColorToGrayScale.Exceptions;
using System.Collections.Generic;
using ColorToGrayScale.LoggingService;
using ColorToGrayScale.DllManager;
using System.Linq;

namespace ColorToGrayScale
{
    public partial class MainForm : Form
    {
        private readonly IImageService imageService;

        private readonly IDllService dllManager;

        private readonly IThreadsService threadsService;

        private readonly ITimeCounterService timeCounter;

        private readonly ILogerService loger;

        private readonly LogForm logForm;

        private int processorCount;

        public MainForm(
            IImageService _imageService,
            IThreadsService _threadsService,
            ITimeCounterService _timeCounterService,
            ILogerService logerService,
            Form logForm,
            IDllService dllManager)
        {
            InitializeComponent();
            AddControlsToGroupbox(groupBox_methodChoose);
            this.imageService = _imageService;
            this.threadsService = _threadsService;
            this.timeCounter = _timeCounterService;
            this.loger = logerService;
            this.logForm = logForm as LogForm;
            this.dllManager = dllManager;

            loger.Info(String.Format("Prawidlowa inicjalizacja"));
        }

        public delegate void EndOfThreads();

        private void AddControlsToGroupbox(GroupBox groupBox_methodChoose)
        {
            string[] methodsInDllInterface = typeof(IDll).GetMethods().Where(x => !x.IsSpecialName).Where(x => !x.Name.Contains("Change")).Select(x => x.Name).ToArray();

            int numberOfMethods = methodsInDllInterface.Count();
            int offset = 30;

            int heightOffset = (groupBox_methodChoose.Size.Height - offset) / (numberOfMethods / 2);

            for (int i = 0; i < numberOfMethods; i++)
            {
                RadioButton temporaryRadioButton = new System.Windows.Forms.RadioButton();
                temporaryRadioButton.AutoSize = true;
                temporaryRadioButton.Checked = i == 0;
                temporaryRadioButton.Name = String.Format("{0}_radioButton", methodsInDllInterface[i]);
                temporaryRadioButton.Size = new System.Drawing.Size(groupBox_methodChoose.Size.Width / 2, 17);
                temporaryRadioButton.TabIndex = 1;
                temporaryRadioButton.TabStop = true;
                temporaryRadioButton.Text = methodsInDllInterface[i];
                temporaryRadioButton.UseVisualStyleBackColor = true;

                groupBox_methodChoose.Controls.Add(temporaryRadioButton);

                int tempWidhtOffset = 30;
                if (i % 2 != 0)
                {
                    tempWidhtOffset += groupBox_methodChoose.Size.Width / 2;
                }

                temporaryRadioButton.Location = new System.Drawing.Point(tempWidhtOffset, offset + (heightOffset * (i / 2)));
            }
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.processorCount = Environment.ProcessorCount;
            trackBar_Threads.Value = processorCount;
            label_Threads.Text = processorCount.ToString();
            loger.Info(String.Format("Poprawnie uruchomiono okno {0}", this.Name));
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
                Bitmap imageToProcess = new Bitmap(Image.FromFile(openFileDialog.FileName));

                loger.Debug("Rozpoczęcie dzielenia obrazu");
                timeCounter.Start();
                imageService.ImageDivider(imageToProcess);
                timeCounter.Stop();
                time_divide_label.Text = timeCounter.Time;
                loger.Debug(String.Format("Obraz podzielony w czasie {0} ms.", timeCounter.Time));

                pictureBox_original.Image = imageToProcess;
                BitmapParts_label.Text = imageService.Length.ToString();
                StartBTN.Enabled = true;
            }
            catch (System.IO.FileNotFoundException exception)
            {
                loger.Error(exception.Message);
                MessageBox.Show(String.Format("Nie znaleziono pliku:\n\r{0}", exception.Message));
            }
            catch (NotDivisibleBy16Exception exception)
            {
                loger.Error(exception.Message);
                MessageBox.Show(String.Format("Jestem leniwym programista i zamiast obrobic zdjęcie wymagam zeby jego wysokosc byla podzielna przez 16. \n\r\n\r {0}", exception.Message));
            }
            catch (Exception exception)
            {
                loger.Error(exception.Message);

                //inne podejscie do wykatkow. Próba implementacji RTTI w języku C# 
                if (exception is ArgumentException)
                {
                    MessageBox.Show(exception.GetType().ToString());
                }
                else if (exception is OutOfMemoryException)
                {
                    MessageBox.Show(exception.GetType().ToString());
                }
                else
                {
                    MessageBox.Show(String.Format("Błąd łądowania zdjęcia.\n\r\n\r{0}", exception.Message));
                }
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
                loger.Debug(String.Format("Obraz przetworzony w czasie {0} ms.", timeCounter.Time));

                timeCounter.Start();
                pictureBox_modified.Image = imageService.JoinIntoBigOne();
                timeCounter.Stop();
                time_join_label.Text = timeCounter.Time;
                loger.Debug(String.Format("Obraz polaczony w czasie {0} ms.", timeCounter.Time));

                StartBTN.Enabled = true;
            }
        }
        
        private void StartBTN_Click(object sender, EventArgs e)
        {
            label_time.Text = string.Empty;
            StartBTN.Enabled = false;

            dllManager.ChooseDll(this.groupBox_dllChose);
            dllManager.ChooseMethod(this.groupBox_methodChoose);
            IDll dll = dllManager.Dll;
            dll.Pixels = imageService.CopyOfOryginalImage;

            threadsService.ProcessingFunction = dll.ChangeColorToGrayScale;
            threadsService.EndOfThreads = new EndOfThreads(UpdateModifiedPhoto);
            threadsService.ThreadsCount = processorCount;
                        
            timeCounter.Start();
            threadsService.StartProcessing();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            const int RamMBUsageWarning = 1000;
            Process proc = Process.GetCurrentProcess();
            double memory = Math.Round(proc.PrivateMemorySize64 / 1e+6, 0);
            proc.Dispose();

            if (memory > RamMBUsageWarning)
            {
                loger.Warning(String.Format("Zuycie ramu większe niż {0}MB.", RamMBUsageWarning));
            }

            RAMUsage_label.Text = memory.ToString();
        }

        private void OpenLogs_Button_Click(object sender, EventArgs e)
        {
            if (!logForm.IsDisposed)
            {
                logForm.Show();
                loger.Debug(String.Format("Wcisnieto przycisk {0}", (sender as Button).Text));
                loger.Info(String.Format("Wlaczono okno {0}", (logForm as Form).Text));
            }
            else
            {
                loger.Warning(String.Format("Okno {0} zorstlo zniszczone.", logForm.GetType().ToString()));
                MessageBox.Show(String.Format("Jestem leniwym programista #2 i nie uruchomie wylaczonego okna.{1}{1}Okno {0} zorstlo zniszczone.", logForm.GetType().ToString(), Environment.NewLine));
            }
        }
    }
}