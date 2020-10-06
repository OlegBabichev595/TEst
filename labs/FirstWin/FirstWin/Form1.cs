using System;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.Net;
using System.Net.Sockets;
using System.Text;
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
            SendMessageFromSocket(11000,userName + password);


        }
        static void SendMessageFromSocket(int port,string message)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[1024];

            // Соединяемся с удаленным устройством

            // Устанавливаем удаленную точку для сокета
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Соединяем сокет с удаленной точкой
            sender.Connect(ipEndPoint);

            Console.Write("Entry message: ");
            string userName = "Oleg";


            byte[] msg = Encoding.UTF8.GetBytes(message);


            int bytesSent = sender.Send(msg);

            // Получаем ответ от сервера
            int bytesRec = sender.Receive(bytes);


            var s = Encoding.UTF8.GetString(bytes, 0, bytesRec);
            if (s.Equals("true"))
            {
                MessageBox.Show(s);
            }
         
            // Используем рекурсию для неоднократного вызова SendMessageFromSocket()
            if (s == "error")
            {
                SendMessageFromSocket(port, message);
            }

            // Освобождаем сокет
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}

