using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SocketDocumentShareServer
{
    class FileSave
    {
        
        public static void toFileSave(byte[] btStream,string path,string name)
        {
            FileStream fs;
            string absPath = path + '\\' + name;
            fs = new FileStream(absPath, FileMode.Create, FileAccess.Write);
            fs.Seek(0, SeekOrigin.Begin);
            fs.Write(btStream, 0, btStream.Length);
            fs.Close();
        }

        public static void WriteParams(string strSavePos, int iServerSendPort, int iServerReceivePort, string ip)
        {
            StreamWriter sw = File.CreateText("./Params.txt");
            sw.WriteLine(strSavePos);
            sw.WriteLine(iServerSendPort);
            sw.WriteLine(iServerReceivePort);
            sw.WriteLine(ip);
            sw.Flush();
            sw.Close();
        }

        public static string[] ReadParams()
        {
            StreamReader sr = File.OpenText("./Params.txt");
            string strSavePos = sr.ReadLine();
            string strServerSendPort = sr.ReadLine();
            string strServerReceivePort = sr.ReadLine();
            string ip = sr.ReadLine();
            sr.Close();
            return new string[]{ strSavePos, strServerSendPort, strServerReceivePort, ip};
        }

    }
}
