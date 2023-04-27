using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.CodeDom;

namespace Bookmarklet_Creator
{
    public partial class Form1 : Form
    {
        void encoder()
        {
            str = str.Replace(";", "%3B");
            str = str.Replace("\n", "");
            str = Regex.Replace(str, @"\s+", " ");
        }
        string final;
        bool New = false;
        string str;
        public Form1()
        {
            InitializeComponent();
            final = Textboxinput.Text = "Delete this & Enter Javascript code here...";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textboxoutput.Text = "";
            str = Textboxinput.Text;
            encoder();
            final = textboxoutput.Text = "(function()%7B" + str + "%7D)()%3B";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (New == false)
            {
                New = true;
                MessageBox.Show("Please note when you try to apply your bookmark to your browser page, you must type in 'javascript:' without the apostrophes in front of the code you paste", "Please Note...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Clipboard.SetText(final);
            }
            else
            {
                Clipboard.SetText(final);
            }
        }

        private void Textboxinput_TextChanged(object sender, EventArgs e)
        {
            str = Textboxinput.Text;
            encoder();
            //final = textboxoutput.Text = "" + str + "";
            final = textboxoutput.Text = "(function()%7B" + str + "%7D)()%3B";
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            float fontSize = (float)numericUpDown1.Value;
            Textboxinput.Font = new Font(Textboxinput.Font.FontFamily, fontSize, Textboxinput.Font.Style);
        }

        private void saveAsTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Title = "Pick file location";
            saveFileDialog1.Filter = "Javascript .js|*.js";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, Textboxinput.Text);
            }



            //string username = Environment.UserName;
            //string filePath = $@"C:\Users\{username}\Desktop\Javascript.js";
            //File.WriteAllText(filePath, Textboxinput.Text);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Pick file location";
            saveFileDialog1.Filter = "Text File .txt|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, Textboxinput.Text);

            }
        }
    }
}

