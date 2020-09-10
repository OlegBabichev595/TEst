namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EditButton = new System.Windows.Forms.Button();
            this.CreateTwoMatrixButton = new System.Windows.Forms.Button();
            this.AddTwoMatrixButton = new System.Windows.Forms.Button();
            this.DimenssionLabel = new System.Windows.Forms.Label();
            this.DemenssionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditButton.Location = new System.Drawing.Point(19, 139);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 0;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // CreateTwoMatrixButton
            // 
            this.CreateTwoMatrixButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreateTwoMatrixButton.Location = new System.Drawing.Point(109, 139);
            this.CreateTwoMatrixButton.Name = "CreateTwoMatrixButton";
            this.CreateTwoMatrixButton.Size = new System.Drawing.Size(121, 23);
            this.CreateTwoMatrixButton.TabIndex = 1;
            this.CreateTwoMatrixButton.Text = "CreateTwoMatrix";
            this.CreateTwoMatrixButton.UseVisualStyleBackColor = true;
            // 
            // AddTwoMatrixButton
            // 
            this.AddTwoMatrixButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddTwoMatrixButton.Location = new System.Drawing.Point(236, 139);
            this.AddTwoMatrixButton.Name = "AddTwoMatrixButton";
            this.AddTwoMatrixButton.Size = new System.Drawing.Size(130, 23);
            this.AddTwoMatrixButton.TabIndex = 2;
            this.AddTwoMatrixButton.Text = "AddTwoMatrix";
            this.AddTwoMatrixButton.UseVisualStyleBackColor = true;
            // 
            // DimenssionLabel
            // 
            this.DimenssionLabel.AutoSize = true;
            this.DimenssionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DimenssionLabel.Location = new System.Drawing.Point(12, 9);
            this.DimenssionLabel.Name = "DimenssionLabel";
            this.DimenssionLabel.Size = new System.Drawing.Size(82, 16);
            this.DimenssionLabel.TabIndex = 3;
            this.DimenssionLabel.Text = "Dimenssion:";
            // 
            // DemenssionTextBox
            // 
            this.DemenssionTextBox.Location = new System.Drawing.Point(100, 8);
            this.DemenssionTextBox.Name = "DemenssionTextBox";
            this.DemenssionTextBox.Size = new System.Drawing.Size(100, 20);
            this.DemenssionTextBox.TabIndex = 4;
            this.DemenssionTextBox.Text = "5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 174);
            this.Controls.Add(this.DemenssionTextBox);
            this.Controls.Add(this.DimenssionLabel);
            this.Controls.Add(this.AddTwoMatrixButton);
            this.Controls.Add(this.CreateTwoMatrixButton);
            this.Controls.Add(this.EditButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button CreateTwoMatrixButton;
        private System.Windows.Forms.Button AddTwoMatrixButton;
        private System.Windows.Forms.Label DimenssionLabel;
        private System.Windows.Forms.TextBox DemenssionTextBox;
    }
}

