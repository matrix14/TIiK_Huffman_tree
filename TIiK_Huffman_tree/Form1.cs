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

using Newtonsoft.Json;

namespace TIiK_Huffman_tree
{
    public partial class Form1 : Form
    {
        private String filepath = "";
        private Dictionary<string, int> charAmount = new Dictionary<string, int>();
        private Dictionary<string, float> charPropability = new Dictionary<string, float>();
        private Dictionary<string, float> charDataSize = new Dictionary<string, float>();
        private List<HuffmanAlgorithm.Node> trees = new List<HuffmanAlgorithm.Node>();

        private string text;
        private Dictionary<string, string> charactersCode;
        private string charactersCodeJSON;

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

            charAmount.Clear();
            charPropability.Clear();
            charDataSize.Clear();
            trees.Clear();

            text = File.ReadAllText(filepath, Encoding.UTF8);

            int wholeCount = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if(charAmount.ContainsKey(text[i].ToString())) {
                    charAmount[text[i].ToString()] += 1;
                } else {
                    charAmount.Add(text[i].ToString(), 1);
                }
                wholeCount++;
            }

            foreach (var i in charAmount)
            {
                charPropability.Add(i.Key, (float)((float)i.Value / (float)(wholeCount)));
            }

            foreach (var i in charPropability)
            {
                if (i.Value == 0)
                    charDataSize.Add(i.Key, 0);
                else
                    charDataSize.Add(i.Key, (float)Math.Log(((double)1 / (double)i.Value), 2));
                    //charDataSize.Add(i.Key, (int)Math.Ceiling(Math.Log(((double)1 / (double)i.Value), 2)));
            }

            foreach (KeyValuePair<string, float> el in charPropability)
            {
                trees.Add(new HuffmanAlgorithm.Node(el.Value, el.Key));
            }

            HuffmanAlgorithm.Node huffamnTree = HuffmanAlgorithm.buildHuffmansTree(trees);
            charactersCode = HuffmanAlgorithm.codeDFS(huffamnTree, "", new Dictionary<string, string>());

            var charAmountSorted = from entry in charAmount orderby entry.Value descending select entry;

            output.Text = String.Format("{0,-6} \t{1,-6} \t{2, -10} \t{3, -15} \t{4,-10}\n", "Char", "Amount", "Propability", "Data size", "Hoffnan Code");
            foreach (var i in charAmountSorted)
            {
                if (i.Value > 0)
                    output.Text += String.Format("{0,-6} \t{1,-6} \t{2, -10} \t{3, -15} \t{4,-10}\n", "(" + i.Key + ")", i.Value, Math.Round(charPropability[i.Key], 6), charDataSize[i.Key], charactersCode[i.Key]);
            }
            output.Text += String.Format("\nLenght of file: {0}, number of diefferent chars: {1}\n", text.Length, charactersCode.Count);

            float messageEntropy = 0;

            foreach (var i in charPropability)
                if (i.Value > 0)
                    messageEntropy += i.Value * charDataSize[i.Key];

            output.Text += String.Format("Entropy: {0}\n", messageEntropy);

            charactersCodeJSON = JsonConvert.SerializeObject(charactersCode);

            //Dictionary<string, string> deserialized = (Dictionary<string, string>)JsonConvert.DeserializeObject(charactersCodeJSON);
            Dictionary<string, string> weatherForecast = JsonConvert.DeserializeObject<Dictionary<string, string>>(charactersCodeJSON); //dictionary from string //dev
        }

        private void saveToFile_Click(object sender, EventArgs e)
        {
            if (filepath.Trim().Equals("")||text.Trim().Equals(""))
            {
                MessageBox.Show("Nie wybrano pliku!");
                return;
            }
            String directoryName = Path.GetDirectoryName(filepath);
            String filenameNew = Path.GetFileNameWithoutExtension(fileName.Text)+"_coded.bin";

            FileHandler.saveToFile(charactersCodeJSON, directoryName + "\\" + filenameNew, text, charactersCode);
            
        }
    }
}
