﻿using System;
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
    public static class HuffmanAlgorithm
    {
        public static List<Node> findTwoSmallestPropabilities(List<Node> trees)
        {
            Node smallest = new Node(0);
            Node secSmallest = new Node(0);

            foreach (Node e in trees)
            {
                if (smallest.propability > e.propability)
                {
                    secSmallest = smallest;
                    smallest = e;
                }
                else if (secSmallest.propability > e.propability)
                {
                    secSmallest = e;
                }
            }

            return new List<Node> { smallest, secSmallest };
        }

        public static Node buildHuffmansTree(List<Node> nodes)
        {
            List<Node> nodesCopy = new List<Node>;

            foreach(Node e in nodes)
            {
                nodesCopy.Add(new Node(e));
            }

            return buildHuffmansTreeIteration(nodesCopy)[0];
        }

        private static List<Node> buildHuffmansTreeIteration(List<Node> trees)
        {
            Node newTree = new Node();

            List<Node> smallersNodes = findTwoSmallestPropabilities(trees);
            newTree.addNode(smallersNodes[0]);
            newTree.addNode(smallersNodes[1]);
            trees.Remove(smallersNodes[0]);
            trees.Remove(smallersNodes[1]);
            trees.Add(newTree);

            if(trees.Count == 1)
            {
                return trees;
            }
            else
            {
                return buildHuffmansTreeIteration(trees);
            }
        }
    }

    public class Node
    {
        public string character = null;
        public float propability = 0;
        public Node rightNode = null;
        public Node leftNode = null;

        public Node(float propability = 0, string character = null)
        {
            this.character = character;
            this.propability = propability;
        }

        public Node(Node node)
        {
            this.character = node.character;
            this.propability = node.propability;
        }

        public void addNode(Node addedNode)
        {
            if (this.leftNode != null)
            {
                this.leftNode = addedNode;
            }
            else if(this.rightNode != null)
            {
                this.rightNode = addedNode;
            }
            else
            {
                throw new Exception("Nodes already occupied");
            }

            this.propability += addedNode.propability;
        }
    }

    public partial class Form1 : Form
    {
        private String filepath = "";
        private Dictionary<string, int> charAmount = new Dictionary<string, int>();
        private Dictionary<string, float> charPropability = new Dictionary<string, float>();
        private Dictionary<string, int> charDataSize = new Dictionary<string, int>();
        private List<Node> trees = new List<Node>;

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

            string text = File.ReadAllText(filepath, Encoding.UTF8);

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
                    charDataSize.Add(i.Key, (int)Math.Ceiling(Math.Log(((double)1 / (double)i.Value), 2)));
            }

            output.Text = String.Format("{0,-6} \t{1,-6} \t{2, -10} \t{3, -10}\n", "Char", "Amount", "Propability", "Data size");
            foreach (var i in charAmount) 
            {
                if (i.Value > 0)
                    output.Text += String.Format("{0,-6} \t{1,-6} \t{2,-10} \t{3,-10} \n", "("+i.Key+")", i.Value, Math.Round(charPropability[i.Key], 6), charDataSize[i.Key]);
            }
            output.Text += String.Format("Lenght of file: {0}, sum of all chars: {1}\n", text.Length, wholeCount);

            float messageEntropy = 0;

            foreach (var i in charPropability)
                if (i.Value > 0)
                    messageEntropy += i.Value * charDataSize[i.Key];

            output.Text += String.Format("Entropy: {0}\n", messageEntropy);


            foreach (KeyValuePair<string, float> e in charPropability)
            {
                trees.Add(new Node(e.Value, e.Key));
            }


            Node huffamnTree = HuffmanAlgorithm.buildHuffmansTree(trees);
            output.Text += String.Format("Huffman tree root propability: {0}\n", huffamnTree.propability);



        }
    }
}
