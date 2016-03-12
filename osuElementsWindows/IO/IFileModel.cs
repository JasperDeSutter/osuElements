using osuElements.IO.File;

namespace osuElements.IO
{
    public interface IFileModel
    {
        bool IsRead { get; }
        string FullPath { get; set; }
        string FileName { get; set; }
        string Directory { get; set; }
        void ReadFile(ILogger logger = null);
        void WriteFile();
    }
}