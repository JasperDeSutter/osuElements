using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuElements.IO.File
{
    public interface IStreamIOStrategy
    {
        Stream ReadStream (string path);
        Stream WriteStream(string path);
    }
}
