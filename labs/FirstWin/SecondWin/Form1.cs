using System;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Windows.Forms;

namespace SecondWin
{
    public partial class Form1 : Form
    {
        //Массив для сообщения из общей памяти
        private char[] message;

        //Размер введенного сообщения
        private int size1;
        private int size2;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string someString = "";
            string someString2 = "";

            //Получение существующего участка разделяемой памяти
            //Параметр - название участка
            var sharedMemory = MemoryMappedFile.OpenExisting("MemoryFile");
            //Сначала считываем размер сообщения, чтобы создать массив данного размера
            //Integer занимает 4 байта, начинается с первого байта, поэтому передаем цифры 0 и 4

            using (var reader = sharedMemory.CreateViewAccessor(0, 4, MemoryMappedFileAccess.Read))
            {
                size1 = reader.ReadInt32(0);
            }
           
            using (var reader = sharedMemory.CreateViewAccessor(4, 4, MemoryMappedFileAccess.Read))
            {
                size2 = reader.ReadInt32(0);
            }
          
            


            using (MemoryMappedViewAccessor reader = sharedMemory.CreateViewAccessor(8, (size1+size2) * 2, MemoryMappedFileAccess.Read))
            {
                //Массив символов сообщения
                message = new char[size1];
                reader.ReadArray<char>(0, message, 0, size1);
                someString = new string(message);
                message = new char[size2];
                reader.ReadArray<char>(0, message, 0, size2);
                someString2  = new string(message);
            }
          
            MessageBox.Show($"{someString} {someString2} ");



          
          
        }
    }
}