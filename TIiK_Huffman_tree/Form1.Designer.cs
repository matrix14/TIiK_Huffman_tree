
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
            this.saveToFile = new System.Windows.Forms.Button();
            this.openCoded_button = new System.Windows.Forms.Button();
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
            this.output.Size = new System.Drawing.Size(524, 308);
            this.output.TabIndex = 3;
            this.output.Text = "";
            // 
            // saveToFile
            // 
            this.saveToFile.Location = new System.Drawing.Point(132, 59);
            this.saveToFile.Name = "saveToFile";
            this.saveToFile.Size = new System.Drawing.Size(96, 23);
            this.saveToFile.TabIndex = 4;
            this.saveToFile.Text = "Save To File";
            this.saveToFile.UseVisualStyleBackColor = true;
            this.saveToFile.Click += new System.EventHandler(this.saveToFile_Click);
            // 
            // openCoded_button
            // 
            this.openCoded_button.Location = new System.Drawing.Point(234, 59);
            this.openCoded_button.Name = "openCoded_button";
            this.openCoded_button.Size = new System.Drawing.Size(98, 23);
            this.openCoded_button.TabIndex = 5;
            this.openCoded_button.Text = "Decode File";
            this.openCoded_button.UseVisualStyleBackColor = true;
            this.openCoded_button.Click += new System.EventHandler(this.openCoded_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 418);
            this.Controls.Add(this.openCoded_button);
            this.Controls.Add(this.saveToFile);
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
        private System.Windows.Forms.Button saveToFile;
        private System.Windows.Forms.Button openCoded_button;
    }
}

