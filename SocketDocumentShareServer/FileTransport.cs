using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketDocumentShareClient
{
    [Serializable]
    public class FileMemeber
    {
        private byte[] btFilename;
        public byte[] BtFileName
        {
            get { return btFilename; }
        }
        private long datasize = 0;
        public int iDatasize
        {
            get { return (int)datasize; }
        }
        public long lDatasize
        {
            get { return datasize; }
        }
        private byte[] btFile;
        public byte[] BtFile
        {
            get { return btFile; }
        }
        public FileMemeber(FileTransport ft)
        {
            btFile = ft.returnFileStream();
            btFilename = ft.BtFileName;
            datasize = ft.returnLength();
        }
    }
    public class FileTransport
    {
        private string filename;
        private byte[] btFilename;
        public byte[] BtFileName
        {
            set { btFilename = value; }
            get { return btFilename; }
        }
        private FileStream file;
        private string filepath;
        private long datasize = 0;
        private byte[] btFile;
        FileTransport()
        {

        }
        public FileTransport(string str, string path)
        {
            filename = str;
            btFilename = Encoding.UTF8.GetBytes(filename);
            filepath = path;
            file = File.Open(filepath, FileMode.Open);
            datasize = file.Length;

        }

        public byte[] returnFileStream()
        {
            btFile = new byte[datasize];
            int btnum = file.Read(btFile, 0, (int)datasize);
            datasize = btnum;
            Console.WriteLine("文件读取完成");
            return btFile;
        }
        public int returnLength()
        {
            return (int)datasize;
        }

    }
}
