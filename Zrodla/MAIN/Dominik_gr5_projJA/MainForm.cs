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
using ColorToGrayScale.helpers;

namespace ColorToGrayScale
{
    public partial class MainForm : Form
    {
        private readonly IImageService imageService;

        private readonly IDllService dllManager;

        private readonly IThreadsService threadsService;

        private readonly ILogerService loger;
        
        private int processorCount;

        public MainForm(
            IImageService _imageService,
            IThreadsService _threadsService,
            ILogerService logerService,
            IDllService dllManager)
        {
            InitializeComponent();
            AddControlsToGroupbox(groupBox_methodChoose);

            this.imageService = _imageService;
            this.threadsService = _threadsService;
            this.loger = logerService;
            this.dllManager = dllManager;

            loger.Info(String.Format("Prawidlowa inicjalizacja"));
        }

        public delegate void EndOfThreads();

        private void AddControlsToGroupbox(GroupBox groupBox_methodChoose)
        {
            string[] methodsInDllInterface = typeof(IDll).GetMethods().Where(x => !x.IsSpecialName).Where(x => !x.Name.Contains("Change")).Select(x => x.Name).ToArray();

            int numberOfMethods = methodsInDllInterface.Count();
            int offset = 30;

            int heightOffset = (groupBox_methodChoose.Size.Height - offset) / numberOfMethods * 2;

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

                TimeCounterHelper time = new TimeCounterHelper();
                time.Start();
                imageService.ImageDivider(imageToProcess);
                time.Stop();
                time_divide_label.Text = time.Time;
                loger.Debug(String.Format("Obraz podzielony w czasie {0} ms.", time.Time));

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
                    MessageBox.Show(String.Format("Błąd łądowania zdjęcia.{0}{0}{1}", Environment.NewLine, exception.Message));
                }
            }
        }

        private void UpdateModifiedPhoto()
        {
            if (label_time.InvokeRequired)
            {
                label_time.Invoke(new EndOfThreads(UpdateModifiedPhoto));
            }
            else
            {
                label_time.Text = threadsService.Time;
                loger.Debug(String.Format("Obraz przetworzony w czasie {0} ms.", threadsService.Time));

                TimeCounterHelper time = new TimeCounterHelper();
                time.Start();
                pictureBox_modified.Image = imageService.JoinIntoBigOne();
                time.Stop();
                time_join_label.Text = time.Time;
                loger.Debug(String.Format("Obraz polaczony w czasie {0} ms.", time.Time));

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
                        
            threadsService.StartProcessing();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            RAMUsage_label.Text = new RamUsageHelper().RamUsage();
        }

        private void OpenLogs_Button_Click(object sender, EventArgs e)
        {
            loger.ShowLogForm();
        }
    }
}