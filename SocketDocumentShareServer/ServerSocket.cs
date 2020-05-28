using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Reflection;
using SocketDocumentShareServer;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using SocketDocumentShareClient;

namespace WindowsThread
{
    
    class ServerSocket
    {
        private Socket server;
        private byte[] result = new byte[1024*1024*10];
        
        private string path;
        //private string name;
        //public ServerSocket()
        //{
        //    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("192.168.1.105"), 180);
        //    server.Bind(ipep);
        //    server.Listen(200);
        //    Thread t = new Thread(ListenClientConnect);
        //    t.Start();
        //    Console.WriteLine("Server socket 建立");

        //}
        public ServerSocket(string ip,int port,string p)
        {
            path = p;
            //name = n;
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), port);
            server.Bind(ipep);
            server.Listen(200);
            Thread t = new Thread(ListenClientConnect);
            t.Start();
            Console.WriteLine("Server socket 建立");

        }
        public void ListenClientConnect()
        {
            while (true)
            {
                Socket client = server.Accept();
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start(client);
            }
        }
        public void ReceiveMessage(object client)
        {
            Socket mclient = client as Socket;
            while (true)
            {
                //try
                //{
                    //接收数据
                    int receiveNumber = mclient.Receive(result);
                    Console.WriteLine("长度{0}", receiveNumber);
                    if(receiveNumber == 0)
                    {
                        Console.WriteLine("未收到数据");
                        return;
                    }
                    try 
                    {

                    //FileTransport fs = Deserialize(result) as FileTransport;
                    FileMemeber fm = SerializeNDeserialize.Deserialize(result) as FileMemeber;
                    FileSave.toFileSave(fm.BtFile, path, Encoding.UTF8.GetString(fm.BtFileName));
                    //FileSave.toFileSave(result, path, "whatever.jpg");
                        //向客户端返回信息
                        string sendStr = "已成功收到信息";
                        byte[] bs = Encoding.UTF8.GetBytes(sendStr);
                        mclient.Send(bs, bs.Length, 0);
                        //mclient.Close();
                        Console.WriteLine("返回数据结束");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.WriteLine("未成功接收文件");
                    }
                    
                    
                //}
                //catch(Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //    //mclient.Shutdown(SocketShutdown.Both);//禁止发送和上传
                //    //mclient.Close();
                //    break;
                //}
                //finally
                //{
                //    mclient.Close();
                //}
            }
        }

    }
    class ServerSocketSend : ServerSocket
    {
        public ServerSocketSend(string ip, int port, string p) : base(ip, port, p) { }
        public void SendMessage(object client)
        {
            Socket socket = client as Socket;
            
        }
    }
}
