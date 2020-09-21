namespace Lab3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NumbersCheckBox = new System.Windows.Forms.CheckBox();
            this.SymbolsCheckBox = new System.Windows.Forms.CheckBox();
            this.ModifyCheckBox = new System.Windows.Forms.CheckBox();
            this.ClearButon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NumbersCheckBox
            // 
            this.NumbersCheckBox.AutoSize = true;
            this.NumbersCheckBox.Location = new System.Drawing.Point(45, 149);
            this.NumbersCheckBox.Name = "NumbersCheckBox";
            this.NumbersCheckBox.Size = new System.Drawing.Size(75, 19);
            this.NumbersCheckBox.TabIndex = 0;
            this.NumbersCheckBox.Text = "Numbers";
            this.NumbersCheckBox.UseVisualStyleBackColor = true;
            this.NumbersCheckBox.CheckedChanged += new System.EventHandler(this.NumbersCheckBox_CheckedChanged);
            // 
            // SymbolsCheckBox
            // 
            this.SymbolsCheckBox.AutoSize = true;
            this.SymbolsCheckBox.Location = new System.Drawing.Point(45, 174);
            this.SymbolsCheckBox.Name = "SymbolsCheckBox";
            this.SymbolsCheckBox.Size = new System.Drawing.Size(71, 19);
            this.SymbolsCheckBox.TabIndex = 1;
            this.SymbolsCheckBox.Text = "Symbols";
            this.SymbolsCheckBox.UseVisualStyleBackColor = true;
            this.SymbolsCheckBox.CheckedChanged += new System.EventHandler(this.SymbolsCheckBox_CheckedChanged);
            // 
            // ModifyCheckBox
            // 
            this.ModifyCheckBox.AutoSize = true;
            this.ModifyCheckBox.Location = new System.Drawing.Point(45, 199);
            this.ModifyCheckBox.Name = "ModifyCheckBox";
            this.ModifyCheckBox.Size = new System.Drawing.Size(64, 19);
            this.ModifyCheckBox.TabIndex = 2;
            this.ModifyCheckBox.Text = "Modify";
            this.ModifyCheckBox.UseVisualStyleBackColor = true;
            this.ModifyCheckBox.CheckedChanged += new System.EventHandler(this.ModifyCheckBox_CheckedChanged);
            // 
            // ClearButon
            // 
            this.ClearButon.Location = new System.Drawing.Point(373, 187);
            this.ClearButon.Name = "ClearButon";
            this.ClearButon.Size = new System.Drawing.Size(75, 23);
            this.ClearButon.TabIndex = 3;
            this.ClearButon.Text = "Clear";
            this.ClearButon.UseVisualStyleBackColor = true;
            this.ClearButon.Click += new System.EventHandler(this.ClearButon_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 222);
            this.Controls.Add(this.ClearButon);
            this.Controls.Add(this.ModifyCheckBox);
            this.Controls.Add(this.SymbolsCheckBox);
            this.Controls.Add(this.NumbersCheckBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox NumbersCheckBox;
        private System.Windows.Forms.CheckBox SymbolsCheckBox;
        private System.Windows.Forms.CheckBox ModifyCheckBox;
        private System.Windows.Forms.Button ClearButon;
    }
}

