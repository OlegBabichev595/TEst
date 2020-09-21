using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private CustomTextBox _cst;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _cst = new CustomTextBox
            {
                Width = 300,
                Height = 40,
                Multiline = true,
                PrivateNum = true,
                Let = true,
                Location = new Point(278, 66)
            };
            NumbersCheckBox.Checked = true;
            SymbolsCheckBox.Checked = true;
            Controls.Add(_cst);
        }

        private void ClearButon_Click(object sender, EventArgs e)
        {
            _cst.ResetText();
        }

        private void ModifyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _cst.Modify = ModifyCheckBox.Checked;
        }

        private void NumbersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _cst.PrivateNum = NumbersCheckBox.Checked;
            if (NumbersCheckBox.Checked || SymbolsCheckBox.Checked) return;
            SymbolsCheckBox.Checked = true;
            _cst.Let = SymbolsCheckBox.Checked;
        }

        private void SymbolsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _cst.Let = SymbolsCheckBox.Checked;
            if (NumbersCheckBox.Checked || SymbolsCheckBox.Checked) return;
            NumbersCheckBox.Checked = true;
            _cst.Let = SymbolsCheckBox.Checked;
        }
    }
}