using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIiK_Huffman_tree
{
    public partial class Form1 : Form
    {
        private String filepath = "";
        private Dictionary<string, int> charAmount = new Dictionary<string, int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void selectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Select file",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName.Text = openFileDialog1.SafeFileName;
                filepath = openFileDialog1.FileName;
                this.entropyCalc.Enabled = true;
            }
        }
        private string bytesToString(byte[] bytes)
        {
            return "{" + string.Join(",", bytes) + "}";
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void entropyCalc_Click(object sender, EventArgs e)
        {
            if (filepath.Trim().Equals(""))
            {
                MessageBox.Show("Nie wybrano pliku!");
                return;
            }

            string text = File.ReadAllText(filepath, Encoding.UTF8);

            for (int i = 0; i < text.Length; i++)
            {
                if(charAmount.ContainsKey(text[i].ToString())) {
                    charAmount[text[i].ToString()] += 1;
                } else
                {
                    charAmount.Add(text[i].ToString(), 1);
                }
            }

            output.Text = "";
            int sum = 0;
            foreach (var i in charAmount) 
            {
                sum += i.Value;
                if (i.Value > 0)
                    output.Text += String.Format("Char: {0} ({1}) - {2}\n", this.bytesToString(Encoding.UTF8.GetBytes(i.Key)), i.Key, i.Value);
            }
            output.Text += String.Format("Lenght of file: {0}, sum of all chars: {1}\n", text.Length, sum);
        }
    }
}
