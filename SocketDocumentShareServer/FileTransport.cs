using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketDocumentShareServer
{
    class FileTransport
    {
        private string filename;
        private byte[] btFilename;
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
            return btFile;
        }
        public int returnLength()
        {
            return (int)datasize;
        }
    }
}
