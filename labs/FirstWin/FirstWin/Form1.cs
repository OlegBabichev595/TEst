using System;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.Windows.Forms;

namespace FirstWin
{
    public partial class Form1 : Form
    {
        public char[] message = "123456".ToCharArray();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            var userName = textBox1.Text;
            var password = textBox2.Text;
            var size1 = (textBox1.Text.Length);
            var size2= (textBox2.Text.Length);
            var sharedMemory = MemoryMappedFile.CreateOrOpen("MemoryFile", (size1 + size2) * 2 + 8);
            
            using (var writer = sharedMemory.CreateViewAccessor(0, (size1 + size2) * 2 + 4))
            {
               
                writer.Write(0, size1);
                writer.Write(4, size2);
          
                writer.WriteArray<char>(8, userName.ToCharArray(), 0, userName.Length);
            }

            Process.Start(@"D:\ГАВНО\TEst\labs\FirstWin\SecondWin\bin\Debug\netcoreapp3.1/SecondWin.exe");
            this.Hide();
            
        }
    }
}