using SocketDocumentShareClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketDocumentShareClient;


namespace SocketDocumentShareServer
{
    //发送文件名，文件
    
    class FileSend
    {
        string[] strFilesPath = new string[100];
        public FileSend()
        {
            
        }

        public int readFolder(string strPath)
        {
            int i = 0;
            DirectoryInfo f = new DirectoryInfo(strPath);
            foreach (FileInfo fi in f.GetFiles())
            {
                strFilesPath[i] = fi.FullName;
                i++;
                Console.WriteLine(fi.FullName);
            }
            return i;
        }
        public byte[] EncodeFolder()
        {
            // btFolder = new byte[1024*5];
            byte[] btFolder = SerializeNDeserialize.Serialize(strFilesPath);
            return btFolder;
        }
    }

    [Serializable]
    class SerFileSend
    {
        public SerFileSend() { }
    }

}
