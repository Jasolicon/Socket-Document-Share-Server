using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            fs.Write(btStream, 0, btStream.Length);
            fs.Close();
        }
    }
}
