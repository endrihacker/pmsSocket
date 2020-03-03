using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            string mesazhiPerDergim = "\u0002GHLH|1||||||READ|\u0003";
           // this.richTextBox1.Text = mesazhiPerDergim;
           
            System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();

            clientSocket.Connect("192.168.1.66", 1028);

           this.richTextBox1.Text += "Client Socket Program - Server Connected ...\n\n";

            NetworkStream serverStream = clientSocket.GetStream();


            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(mesazhiPerDergim);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            this.richTextBox1.Text += returndata.ToString()+"\n\n";
          
        }
    }
}
