using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sio = System.IO;

namespace osuElements.IO.File
{
    public class StreamIOStrategy : IStreamIOStrategy
    {
        public Stream ReadStream(string path)
        {
            return Read(path);
        }

        public Stream WriteStream(string path)
        {
            return Write(path);
        }


        protected virtual Stream Read(string path)
        {
            return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        }

        protected virtual Stream Write(string path)
        {
            if (sio.File.Exists(path))
                sio.File.Delete(path);

            return new FileStream(path, FileMode.Create);
        }


    }
}
