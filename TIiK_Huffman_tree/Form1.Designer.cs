
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
            this.output = new System.Windows.Forms.RichTextBox();
            this.saveToFile = new System.Windows.Forms.Button();
            this.openCoded_button = new System.Windows.Forms.Button();
            this.showCode = new System.Windows.Forms.CheckBox();
            this.clearConsole = new System.Windows.Forms.Button();
            this.JSONTable = new System.Windows.Forms.CheckBox();
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
            this.saveToFile.Location = new System.Drawing.Point(26, 59);
            this.saveToFile.Name = "saveToFile";
            this.saveToFile.Size = new System.Drawing.Size(99, 23);
            this.saveToFile.TabIndex = 4;
            this.saveToFile.Text = "Encode File";
            this.saveToFile.UseVisualStyleBackColor = true;
            this.saveToFile.Click += new System.EventHandler(this.saveToFile_Click);
            // 
            // openCoded_button
            // 
            this.openCoded_button.Location = new System.Drawing.Point(134, 59);
            this.openCoded_button.Name = "openCoded_button";
            this.openCoded_button.Size = new System.Drawing.Size(98, 23);
            this.openCoded_button.TabIndex = 5;
            this.openCoded_button.Text = "Decode File";
            this.openCoded_button.UseVisualStyleBackColor = true;
            this.openCoded_button.Click += new System.EventHandler(this.openCoded_button_Click);
            // 
            // showCode
            // 
            this.showCode.AutoSize = true;
            this.showCode.Location = new System.Drawing.Point(238, 63);
            this.showCode.Name = "showCode";
            this.showCode.Size = new System.Drawing.Size(85, 17);
            this.showCode.TabIndex = 6;
            this.showCode.Text = "Show codes";
            this.showCode.UseVisualStyleBackColor = true;
            // 
            // clearConsole
            // 
            this.clearConsole.Location = new System.Drawing.Point(452, 57);
            this.clearConsole.Name = "clearConsole";
            this.clearConsole.Size = new System.Drawing.Size(98, 23);
            this.clearConsole.TabIndex = 7;
            this.clearConsole.Text = "Clear Log";
            this.clearConsole.UseVisualStyleBackColor = true;
            this.clearConsole.Click += new System.EventHandler(this.clearConsole_Click);
            // 
            // JSONTable
            // 
            this.JSONTable.AutoSize = true;
            this.JSONTable.Location = new System.Drawing.Point(329, 63);
            this.JSONTable.Name = "JSONTable";
            this.JSONTable.Size = new System.Drawing.Size(84, 17);
            this.JSONTable.TabIndex = 8;
            this.JSONTable.Text = "JSON Table";
            this.JSONTable.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 418);
            this.Controls.Add(this.JSONTable);
            this.Controls.Add(this.clearConsole);
            this.Controls.Add(this.showCode);
            this.Controls.Add(this.openCoded_button);
            this.Controls.Add(this.saveToFile);
            this.Controls.Add(this.output);
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
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Button saveToFile;
        private System.Windows.Forms.Button openCoded_button;
        private System.Windows.Forms.CheckBox showCode;
        private System.Windows.Forms.Button clearConsole;
        private System.Windows.Forms.CheckBox JSONTable;
    }
}

