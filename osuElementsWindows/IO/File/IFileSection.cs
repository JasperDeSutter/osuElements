using System.Collections.Generic;

namespace osuElements.IO.File
{
    public interface IFileSection<in T>
    {
        string Section { get; set; }
        bool ReadLine(string line);
        void SetModel(T model);
        List<string> AllLines();
        IFileSection<T> GetCopy();
    }
}