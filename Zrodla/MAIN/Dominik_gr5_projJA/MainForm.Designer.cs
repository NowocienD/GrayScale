namespace ColorToGrayScale
{
    partial class MainForm
    {
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
            this.components = new System.ComponentModel.Container();
            this.groupBox_dllChose = new System.Windows.Forms.GroupBox();
            this.radioButton_CPP = new System.Windows.Forms.RadioButton();
            this.radioButton_ASM = new System.Windows.Forms.RadioButton();
            this.trackBar_Threads = new System.Windows.Forms.TrackBar();
            this.pictureBox_original = new System.Windows.Forms.PictureBox();
            this.PhotoBTN = new System.Windows.Forms.Button();
            this.StartBTN = new System.Windows.Forms.Button();
            this.label_Threads = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox_modified = new System.Windows.Forms.PictureBox();
            this.groupBox_methodChoose = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BitmapParts_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.time_divide_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.time_join_label = new System.Windows.Forms.Label();
            this.timer_500ms = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.RAMUsage_label = new System.Windows.Forms.Label();
            this.OpenLogs_Button = new System.Windows.Forms.Button();
            this.groupBox_dllChose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Threads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_modified)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_dllChose
            // 
            this.groupBox_dllChose.Controls.Add(this.radioButton_CPP);
            this.groupBox_dllChose.Controls.Add(this.radioButton_ASM);
            this.groupBox_dllChose.Location = new System.Drawing.Point(13, 282);
            this.groupBox_dllChose.Name = "groupBox_dllChose";
            this.groupBox_dllChose.Size = new System.Drawing.Size(168, 70);
            this.groupBox_dllChose.TabIndex = 0;
            this.groupBox_dllChose.TabStop = false;
            this.groupBox_dllChose.Text = "Wybór DLL";
            // 
            // radioButton_CPP
            // 
            this.radioButton_CPP.AutoSize = true;
            this.radioButton_CPP.Location = new System.Drawing.Point(32, 42);
            this.radioButton_CPP.Name = "radioButton_CPP";
            this.radioButton_CPP.Size = new System.Drawing.Size(66, 17);
            this.radioButton_CPP.TabIndex = 1;
            this.radioButton_CPP.Text = "cpp DLL";
            this.radioButton_CPP.UseVisualStyleBackColor = true;
            // 
            // radioButton_ASM
            // 
            this.radioButton_ASM.AutoSize = true;
            this.radioButton_ASM.Checked = true;
            this.radioButton_ASM.Location = new System.Drawing.Point(32, 19);
            this.radioButton_ASM.Name = "radioButton_ASM";
            this.radioButton_ASM.Size = new System.Drawing.Size(67, 17);
            this.radioButton_ASM.TabIndex = 0;
            this.radioButton_ASM.TabStop = true;
            this.radioButton_ASM.Text = "asm DLL";
            this.radioButton_ASM.UseVisualStyleBackColor = true;
            // 
            // trackBar_Threads
            // 
            this.trackBar_Threads.Location = new System.Drawing.Point(196, 440);
            this.trackBar_Threads.Maximum = 64;
            this.trackBar_Threads.Minimum = 1;
            this.trackBar_Threads.Name = "trackBar_Threads";
            this.trackBar_Threads.Size = new System.Drawing.Size(396, 45);
            this.trackBar_Threads.TabIndex = 1;
            this.trackBar_Threads.Value = 1;
            this.trackBar_Threads.Scroll += new System.EventHandler(this.TrackBar_Threads_Scroll);
            // 
            // pictureBox_original
            // 
            this.pictureBox_original.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_original.Location = new System.Drawing.Point(13, 12);
            this.pictureBox_original.Name = "pictureBox_original";
            this.pictureBox_original.Size = new System.Drawing.Size(380, 256);
            this.pictureBox_original.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_original.TabIndex = 2;
            this.pictureBox_original.TabStop = false;
            // 
            // PhotoBTN
            // 
            this.PhotoBTN.Location = new System.Drawing.Point(13, 365);
            this.PhotoBTN.Name = "PhotoBTN";
            this.PhotoBTN.Size = new System.Drawing.Size(168, 47);
            this.PhotoBTN.TabIndex = 3;
            this.PhotoBTN.Text = "Wybierz zdjęcie";
            this.PhotoBTN.UseVisualStyleBackColor = true;
            this.PhotoBTN.Click += new System.EventHandler(this.PhotoBTN_Click);
            // 
            // StartBTN
            // 
            this.StartBTN.Enabled = false;
            this.StartBTN.Location = new System.Drawing.Point(12, 418);
            this.StartBTN.Name = "StartBTN";
            this.StartBTN.Size = new System.Drawing.Size(168, 47);
            this.StartBTN.TabIndex = 4;
            this.StartBTN.Text = "Start";
            this.StartBTN.UseVisualStyleBackColor = true;
            this.StartBTN.Click += new System.EventHandler(this.StartBTN_Click);
            // 
            // label_Threads
            // 
            this.label_Threads.AutoSize = true;
            this.label_Threads.Location = new System.Drawing.Point(381, 415);
            this.label_Threads.Name = "label_Threads";
            this.label_Threads.Size = new System.Drawing.Size(35, 13);
            this.label_Threads.TabIndex = 5;
            this.label_Threads.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(619, 415);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Czas:";
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label_time.Location = new System.Drawing.Point(619, 440);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(51, 25);
            this.label_time.TabIndex = 7;
            this.label_time.Text = "0:00";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // pictureBox_modified
            // 
            this.pictureBox_modified.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_modified.Location = new System.Drawing.Point(408, 12);
            this.pictureBox_modified.Name = "pictureBox_modified";
            this.pictureBox_modified.Size = new System.Drawing.Size(380, 256);
            this.pictureBox_modified.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_modified.TabIndex = 8;
            this.pictureBox_modified.TabStop = false;
            // 
            // groupBox_methodChoose
            // 
            this.groupBox_methodChoose.Location = new System.Drawing.Point(196, 282);
            this.groupBox_methodChoose.Name = "groupBox_methodChoose";
            this.groupBox_methodChoose.Size = new System.Drawing.Size(396, 130);
            this.groupBox_methodChoose.TabIndex = 2;
            this.groupBox_methodChoose.TabStop = false;
            this.groupBox_methodChoose.Text = "Wybór funkcji";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(621, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "ilość paczek z danymi:";
            // 
            // BitmapParts_label
            // 
            this.BitmapParts_label.AutoSize = true;
            this.BitmapParts_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BitmapParts_label.Location = new System.Drawing.Point(621, 301);
            this.BitmapParts_label.Name = "BitmapParts_label";
            this.BitmapParts_label.Size = new System.Drawing.Size(16, 17);
            this.BitmapParts_label.TabIndex = 10;
            this.BitmapParts_label.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(621, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Czas dzielenia obrazu";
            // 
            // time_divide_label
            // 
            this.time_divide_label.AutoSize = true;
            this.time_divide_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.time_divide_label.Location = new System.Drawing.Point(621, 335);
            this.time_divide_label.Name = "time_divide_label";
            this.time_divide_label.Size = new System.Drawing.Size(16, 17);
            this.time_divide_label.TabIndex = 10;
            this.time_divide_label.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(621, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Czas łączenia obrazów";
            // 
            // time_join_label
            // 
            this.time_join_label.AutoSize = true;
            this.time_join_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.time_join_label.Location = new System.Drawing.Point(621, 369);
            this.time_join_label.Name = "time_join_label";
            this.time_join_label.Size = new System.Drawing.Size(16, 17);
            this.time_join_label.TabIndex = 10;
            this.time_join_label.Text = "0";
            // 
            // timer_500ms
            // 
            this.timer_500ms.Enabled = true;
            this.timer_500ms.Interval = 500;
            this.timer_500ms.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(621, 386);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Użycie RAMu [MB]";
            // 
            // RAMUsage_label
            // 
            this.RAMUsage_label.AutoSize = true;
            this.RAMUsage_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.RAMUsage_label.Location = new System.Drawing.Point(621, 403);
            this.RAMUsage_label.Name = "RAMUsage_label";
            this.RAMUsage_label.Size = new System.Drawing.Size(16, 17);
            this.RAMUsage_label.TabIndex = 10;
            this.RAMUsage_label.Text = "0";
            // 
            // OpenLogs_Button
            // 
            this.OpenLogs_Button.Location = new System.Drawing.Point(720, 418);
            this.OpenLogs_Button.Name = "OpenLogs_Button";
            this.OpenLogs_Button.Size = new System.Drawing.Size(68, 58);
            this.OpenLogs_Button.TabIndex = 11;
            this.OpenLogs_Button.Text = "Logi";
            this.OpenLogs_Button.UseVisualStyleBackColor = true;
            this.OpenLogs_Button.Click += new System.EventHandler(this.OpenLogs_Button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.OpenLogs_Button);
            this.Controls.Add(this.RAMUsage_label);
            this.Controls.Add(this.time_join_label);
            this.Controls.Add(this.time_divide_label);
            this.Controls.Add(this.BitmapParts_label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StartBTN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox_methodChoose);
            this.Controls.Add(this.pictureBox_modified);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Threads);
            this.Controls.Add(this.PhotoBTN);
            this.Controls.Add(this.pictureBox_original);
            this.Controls.Add(this.trackBar_Threads);
            this.Controls.Add(this.groupBox_dllChose);
            this.Name = "MainForm";
            this.Text = " ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox_dllChose.ResumeLayout(false);
            this.groupBox_dllChose.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Threads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_modified)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_dllChose;
        private System.Windows.Forms.RadioButton radioButton_CPP;
        private System.Windows.Forms.RadioButton radioButton_ASM;
        private System.Windows.Forms.TrackBar trackBar_Threads;
        private System.Windows.Forms.PictureBox pictureBox_original;
        private System.Windows.Forms.Button PhotoBTN;
        private System.Windows.Forms.Button StartBTN;
        private System.Windows.Forms.Label label_Threads;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pictureBox_modified;
        private System.Windows.Forms.GroupBox groupBox_methodChoose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label BitmapParts_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label time_divide_label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label time_join_label;
        private System.Windows.Forms.Timer timer_500ms;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label RAMUsage_label;
        private System.Windows.Forms.Button OpenLogs_Button;


        //private System.Windows.Forms.RadioButton SingleColorChannel_Green_radioButton;
        //private System.Windows.Forms.RadioButton BSCC_radio;
        //private System.Windows.Forms.RadioButton RSCC_radio;
        //private System.Windows.Forms.RadioButton desaturation_radio;
        //private System.Windows.Forms.RadioButton decomposition_min_radio;
        //private System.Windows.Forms.RadioButton decomposition_max_radio;
    }
}

