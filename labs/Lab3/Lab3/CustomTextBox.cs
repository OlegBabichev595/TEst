using System.Windows.Forms;
using static System.Char;

namespace Lab3
{
    public class CustomTextBox : TextBox
    {
        public bool PrivateNum { get; set; }
        public bool Let { get; set; }
        public bool Modify { get; set; }


        public override void ResetText()
        {
            if (Modify) base.ResetText();
        }


        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //MessageBox.Show(Text.Length.ToString());
            if (IsDigit(e.KeyChar) && PrivateNum)
            {
                e.Handled = false;
                base.OnKeyPress(e);
            }
            else if (IsLetter(e.KeyChar) && Let)
            {
                e.Handled = false;
                base.OnKeyPress(e);
            }
            else if (PrivateNum && Let)
            {
                e.Handled = false;
                base.OnKeyPress(e);
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}