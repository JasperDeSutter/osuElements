using System.IO;
using osuElements.Repositories.File;

namespace osuElements.Repositories
{
    public interface IFileRepository<in T> where T : class
    {
        void ReadFile(Stream path, T t, ILogger logger = null);
        void WriteFile(Stream path, T t);
    }
}
