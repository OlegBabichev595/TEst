using System;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form2 : Form
    {
        private string userNameValid = "oleg";
        private string passwordValid = "123456";
        private Form1 _form;
        public Form2(Form1 form)
        {
            InitializeComponent();
            _form = form;
            _form.SendData += Form_SendData;
            this.FormClosed += Form2_FormClosed;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            _form.Close();
        }

        private bool Form_SendData(string userName, string password)
        {
            return userNameValid == userName && passwordValid == password;
        }
        


        

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
