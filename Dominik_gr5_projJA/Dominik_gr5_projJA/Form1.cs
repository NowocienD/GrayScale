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
        private Image imageToProcess; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int processorCount = System.Environment.ProcessorCount;
            trackBar_Threads.Value = processorCount;
            label_Threads.Text = processorCount.ToString();
        }

        private void trackBar_Threads_Scroll(object sender, EventArgs e)
        {
            label_Threads.Text = trackBar_Threads.Value.ToString();
        }

        private void PhotoBTN_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            imageToProcess = Image.FromFile(openFileDialog1.FileName);
            pictureBox1.Image = imageToProcess;
        }
    }
}
