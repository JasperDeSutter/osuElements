using System.IO;
using osuElements.IO.File;

namespace osuElements.IO
{
    public interface IFileRepository<in T> where T : class
    {
        void ReadFile(Stream inStream, T t, ILogger logger = null);
        void WriteFile(Stream outStream, T instance);
    }
}
