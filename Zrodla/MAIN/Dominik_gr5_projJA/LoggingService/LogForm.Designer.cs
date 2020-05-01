namespace ColorToGrayScale.LoggingService
{
    partial class LogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Warning_checkBox = new System.Windows.Forms.CheckBox();
            this.Info_checkBox = new System.Windows.Forms.CheckBox();
            this.Debug_checkBox = new System.Windows.Forms.CheckBox();
            this.Error_checkBox = new System.Windows.Forms.CheckBox();
            this.Output_textBox = new System.Windows.Forms.TextBox();
            this.Search_Button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Warning_checkBox);
            this.groupBox1.Controls.Add(this.Info_checkBox);
            this.groupBox1.Controls.Add(this.Debug_checkBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(102, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Level";
            // 
            // Warning_checkBox
            // 
            this.Warning_checkBox.AutoSize = true;
            this.Warning_checkBox.Location = new System.Drawing.Point(6, 65);
            this.Warning_checkBox.Name = "Warning_checkBox";
            this.Warning_checkBox.Size = new System.Drawing.Size(66, 17);
            this.Warning_checkBox.TabIndex = 2;
            this.Warning_checkBox.Text = "Warning";
            this.Warning_checkBox.UseVisualStyleBackColor = true;
            // 
            // Info_checkBox
            // 
            this.Info_checkBox.AutoSize = true;
            this.Info_checkBox.Location = new System.Drawing.Point(6, 42);
            this.Info_checkBox.Name = "Info_checkBox";
            this.Info_checkBox.Size = new System.Drawing.Size(44, 17);
            this.Info_checkBox.TabIndex = 1;
            this.Info_checkBox.Text = "Info";
            this.Info_checkBox.UseVisualStyleBackColor = true;
            // 
            // Debug_checkBox
            // 
            this.Debug_checkBox.AutoSize = true;
            this.Debug_checkBox.Location = new System.Drawing.Point(6, 19);
            this.Debug_checkBox.Name = "Debug_checkBox";
            this.Debug_checkBox.Size = new System.Drawing.Size(58, 17);
            this.Debug_checkBox.TabIndex = 0;
            this.Debug_checkBox.Text = "Debug";
            this.Debug_checkBox.UseVisualStyleBackColor = true;
            // 
            // Error_checkBox
            // 
            this.Error_checkBox.AutoSize = true;
            this.Error_checkBox.Location = new System.Drawing.Point(18, 100);
            this.Error_checkBox.Name = "Error_checkBox";
            this.Error_checkBox.Size = new System.Drawing.Size(48, 17);
            this.Error_checkBox.TabIndex = 3;
            this.Error_checkBox.Text = "Error";
            this.Error_checkBox.UseVisualStyleBackColor = true;
            // 
            // Output_textBox
            // 
            this.Output_textBox.Location = new System.Drawing.Point(159, 28);
            this.Output_textBox.Multiline = true;
            this.Output_textBox.Name = "Output_textBox";
            this.Output_textBox.ReadOnly = true;
            this.Output_textBox.Size = new System.Drawing.Size(629, 410);
            this.Output_textBox.TabIndex = 4;
            // 
            // Search_Button
            // 
            this.Search_Button.Location = new System.Drawing.Point(12, 415);
            this.Search_Button.Name = "Search_Button";
            this.Search_Button.Size = new System.Drawing.Size(141, 23);
            this.Search_Button.TabIndex = 5;
            this.Search_Button.Text = "Szukaj";
            this.Search_Button.UseVisualStyleBackColor = true;
            this.Search_Button.Click += new System.EventHandler(this.Search_Button_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Search_Button);
            this.Controls.Add(this.Output_textBox);
            this.Controls.Add(this.Error_checkBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "LogForm";
            this.Text = "LogForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox Warning_checkBox;
        private System.Windows.Forms.CheckBox Info_checkBox;
        private System.Windows.Forms.CheckBox Debug_checkBox;
        private System.Windows.Forms.CheckBox Error_checkBox;
        private System.Windows.Forms.TextBox Output_textBox;
        private System.Windows.Forms.Button Search_Button;
    }
}