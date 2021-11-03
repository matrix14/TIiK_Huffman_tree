
namespace TIiK_Huffman_tree
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
            this.selectFile = new System.Windows.Forms.Button();
            this.fileName = new System.Windows.Forms.Label();
            this.entropyCalc = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // selectFile
            // 
            this.selectFile.Location = new System.Drawing.Point(26, 30);
            this.selectFile.Name = "selectFile";
            this.selectFile.Size = new System.Drawing.Size(99, 23);
            this.selectFile.TabIndex = 0;
            this.selectFile.Text = "Select File";
            this.selectFile.UseVisualStyleBackColor = true;
            this.selectFile.Click += new System.EventHandler(this.selectFile_Click);
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.Location = new System.Drawing.Point(131, 35);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(0, 13);
            this.fileName.TabIndex = 1;
            // 
            // entropyCalc
            // 
            this.entropyCalc.Enabled = false;
            this.entropyCalc.Location = new System.Drawing.Point(26, 59);
            this.entropyCalc.Name = "entropyCalc";
            this.entropyCalc.Size = new System.Drawing.Size(99, 23);
            this.entropyCalc.TabIndex = 2;
            this.entropyCalc.Text = "Calculate Entropy";
            this.entropyCalc.UseVisualStyleBackColor = true;
            this.entropyCalc.Click += new System.EventHandler(this.entropyCalc_Click);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(26, 88);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(368, 308);
            this.output.TabIndex = 3;
            this.output.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 418);
            this.Controls.Add(this.output);
            this.Controls.Add(this.entropyCalc);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.selectFile);
            this.Name = "Form1";
            this.Text = "TIiK Huffman Tree coding";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button selectFile;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.Button entropyCalc;
        private System.Windows.Forms.RichTextBox output;
    }
}

