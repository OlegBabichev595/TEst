using System;
using System.Windows.Forms;

namespace Lab6
{
    public delegate bool VeriFyPassword(string userName, string password);
    
    public partial class Form1 : Form
    {
        public event VeriFyPassword SendData;
        private int CountOfLogin = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this);
            if ((bool)SendData?.Invoke(UserNameTextBox.Text, PasswordTextBox.Text))
            {
                this.Hide();
                MessageBox.Show($"Hellow {UserNameTextBox.Text}");
                form.Show();
            }
            else
            {
                CountOfLogin -= 1;
                if (CountOfLogin == 0)
                {
                    MessageBox.Show("Try Later", "Invalid password or username");
                }
                else 
                {
                    MessageBox.Show($" count of try : {CountOfLogin}", "Invalid password or username");
                }
               
                
            }
           
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
