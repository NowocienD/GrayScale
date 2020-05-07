using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ColorToGrayScale.helpers;

namespace ColorToGrayScale.LoggingService
{
    public partial class LogForm : Form
    {
        private readonly ILogerService loger;
        
        public LogForm(ILogerService logerService)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.loger = logerService;
        }

        private void Search_Button_Click(object sender, EventArgs e)
        {
            RegexHelper regex = new RegexHelper();

            regex.AddSearchPattern(Debug_checkBox.Checked, "(?:Debug)");
            regex.AddSearchPattern(Info_checkBox.Checked, "(?:Info)");
            regex.AddSearchPattern(Warning_checkBox.Checked, "(?:Warning)");
            regex.AddSearchPattern(Error_checkBox.Checked, "(?:Error)");

            Output_textBox.Text = loger.ReadLog(regex);
        }

        private void Hide_button_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
