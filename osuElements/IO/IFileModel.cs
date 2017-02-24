using osuElements.IO.File;

namespace osuElements.IO
{
    public interface IFileModel
    {
        /// <summary>
        /// Will be true when the file has been read
        /// </summary>
        bool IsRead { get; }
        /// <summary>
        /// the full rooted path to the file
        /// </summary>
        string FullPath { get; set; }
        /// <summary>
        /// Name of the file
        /// </summary>
        string FileName { get; set; }
        /// <summary>
        /// Sub or rooted directory where the file resides
        /// </summary>
        string Directory { get; set; }
        /// <summary>
        /// Reads the file at the location specified by "FullPath"
        /// </summary>
        /// <param name="logger">A logger to pass warnings and errors to</param>
        void ReadFile(ILogger logger = null);
        /// <summary>
        /// Writes to the file at the location specified by "FullPath"
        /// </summary>
        void WriteFile();
    }
}