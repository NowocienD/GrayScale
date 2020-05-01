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

namespace ColorToGrayScale.LoggingService
{
    public partial class LogForm : Form
    {
        private readonly ILogerService loger;

        public LogForm(ILogerService logerService)
        {
            InitializeComponent();
            this.loger = logerService;
        }

        private void AddSeparatorToRegex(ref string regexPattern)
        {
            if (regexPattern.Length > 0)
            {
                regexPattern += "|";
            }
        }

        private void Search_Button_Click(object sender, EventArgs e)
        {
            string regexPattern = string.Empty;
            if (Debug_checkBox.Checked)
            {
                AddSeparatorToRegex(ref regexPattern);
                regexPattern += "(?:Debug)";
            }
            if (Info_checkBox.Checked)
            {
                AddSeparatorToRegex(ref regexPattern);
                regexPattern += "(?:Info)";
            }
            if (Warning_checkBox.Checked)
            {
                AddSeparatorToRegex(ref regexPattern);
                regexPattern += "(?:Warning)";
            }
            if (Error_checkBox.Checked)
            {
                AddSeparatorToRegex(ref regexPattern);
                regexPattern += "(?:Error)";
            }

            Output_textBox.Text = loger.ReadLog(regexPattern);
        }
    }
}
