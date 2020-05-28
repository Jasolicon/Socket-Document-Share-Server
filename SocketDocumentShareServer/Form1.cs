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
using SocketDocumentShareClient;

namespace SocketDocumentShareServer
{
    public partial class Form1 : Form
    {
        private string strSavePos;
        int iServerSendPort;
        int iServerReceivePort;
        string ip;
        bool isChanged = false;
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
        private void changed(object sender, EventArgs e)
        {
            isChanged = true;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(isChanged)
            {
                iServerSendPort = int.Parse(tbPortSend.Text);
                iServerReceivePort = int.Parse(tbPortReceive.Text);
                ip = textBox2.Text;
                FileSave.WriteParams(strSavePos, iServerSendPort, iServerReceivePort, ip);
            }
            
            ServerSocket server = new ServerSocket(ip,iServerReceivePort,strSavePos);
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("./Params.txt"))
            {
                string[] p = FileSave.ReadParams();
                strSavePos = p[0];
                iServerSendPort = int.Parse(p[1]);
                iServerReceivePort = int.Parse(p[2]);
                ip = p[3];
                textBox1.Text = strSavePos;
                textBox2.Text = ip;
                tbPortSend.Text = iServerSendPort.ToString();
                tbPortReceive.Text = iServerReceivePort.ToString();
                isChanged = false;
            }
            Console.WriteLine(isChanged.ToString());
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
