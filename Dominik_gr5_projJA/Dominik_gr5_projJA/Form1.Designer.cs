namespace Dominik_gr5_projJA
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_dotNet = new System.Windows.Forms.RadioButton();
            this.radioButton_ASM = new System.Windows.Forms.RadioButton();
            this.trackBar_Threads = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PhotoBTN = new System.Windows.Forms.Button();
            this.StartBTN = new System.Windows.Forms.Button();
            this.label_Threads = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Threads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_dotNet);
            this.groupBox1.Controls.Add(this.radioButton_ASM);
            this.groupBox1.Location = new System.Drawing.Point(196, 297);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wybór DLL";
            // 
            // radioButton_dotNet
            // 
            this.radioButton_dotNet.AutoSize = true;
            this.radioButton_dotNet.Location = new System.Drawing.Point(287, 31);
            this.radioButton_dotNet.Name = "radioButton_dotNet";
            this.radioButton_dotNet.Size = new System.Drawing.Size(61, 17);
            this.radioButton_dotNet.TabIndex = 1;
            this.radioButton_dotNet.TabStop = true;
            this.radioButton_dotNet.Text = "c# DLL";
            this.radioButton_dotNet.UseVisualStyleBackColor = true;
            // 
            // radioButton_ASM
            // 
            this.radioButton_ASM.AutoSize = true;
            this.radioButton_ASM.Location = new System.Drawing.Point(32, 31);
            this.radioButton_ASM.Name = "radioButton_ASM";
            this.radioButton_ASM.Size = new System.Drawing.Size(67, 17);
            this.radioButton_ASM.TabIndex = 0;
            this.radioButton_ASM.TabStop = true;
            this.radioButton_ASM.Text = "asm DLL";
            this.radioButton_ASM.UseVisualStyleBackColor = true;
            // 
            // trackBar_Threads
            // 
            this.trackBar_Threads.Location = new System.Drawing.Point(196, 403);
            this.trackBar_Threads.Maximum = 64;
            this.trackBar_Threads.Minimum = 1;
            this.trackBar_Threads.Name = "trackBar_Threads";
            this.trackBar_Threads.Size = new System.Drawing.Size(396, 45);
            this.trackBar_Threads.TabIndex = 1;
            this.trackBar_Threads.Value = 1;
            this.trackBar_Threads.Scroll += new System.EventHandler(this.trackBar_Threads_Scroll);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(196, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(396, 264);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // PhotoBTN
            // 
            this.PhotoBTN.Location = new System.Drawing.Point(54, 332);
            this.PhotoBTN.Name = "PhotoBTN";
            this.PhotoBTN.Size = new System.Drawing.Size(127, 37);
            this.PhotoBTN.TabIndex = 3;
            this.PhotoBTN.Text = "Wybierz zdjęcie";
            this.PhotoBTN.UseVisualStyleBackColor = true;
            this.PhotoBTN.Click += new System.EventHandler(this.PhotoBTN_Click);
            // 
            // StartBTN
            // 
            this.StartBTN.Location = new System.Drawing.Point(608, 332);
            this.StartBTN.Name = "StartBTN";
            this.StartBTN.Size = new System.Drawing.Size(127, 37);
            this.StartBTN.TabIndex = 4;
            this.StartBTN.Text = "Start";
            this.StartBTN.UseVisualStyleBackColor = true;
            // 
            // label_Threads
            // 
            this.label_Threads.AutoSize = true;
            this.label_Threads.Location = new System.Drawing.Point(374, 387);
            this.label_Threads.Name = "label_Threads";
            this.label_Threads.Size = new System.Drawing.Size(35, 13);
            this.label_Threads.TabIndex = 5;
            this.label_Threads.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(672, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Czas:";
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_time.Location = new System.Drawing.Point(672, 84);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(36, 17);
            this.label_time.TabIndex = 7;
            this.label_time.Text = "0:00";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Threads);
            this.Controls.Add(this.StartBTN);
            this.Controls.Add(this.PhotoBTN);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.trackBar_Threads);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Threads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_dotNet;
        private System.Windows.Forms.RadioButton radioButton_ASM;
        private System.Windows.Forms.TrackBar trackBar_Threads;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button PhotoBTN;
        private System.Windows.Forms.Button StartBTN;
        private System.Windows.Forms.Label label_Threads;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

