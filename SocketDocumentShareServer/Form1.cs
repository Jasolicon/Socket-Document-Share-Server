using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsThread;

namespace SocketDocumentShareServer
{
    public partial class Form1 : Form
    {
        private string strSavePos;
        int iServerSendPort;
        int iServerReceivePort;
        string ip;
        //ServerSocket server = new ServerSocket();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSavePos_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog1.ShowDialog();
            if(res == DialogResult.OK)
            {
                strSavePos = folderBrowserDialog1.SelectedPath;
                textBox1.Text = strSavePos;
            }
            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(tbPortSend.Text!=null && tbPortReceive.Text!=null && textBox1.Text != null && textBox2.Text!=null)
            {
                iServerSendPort = int.Parse(tbPortSend.Text);
                iServerReceivePort = int.Parse(tbPortReceive.Text);
                ip = textBox2.Text;
            }
            ServerSocket server = new ServerSocket(ip,iServerReceivePort,strSavePos,"default.jpg");
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
