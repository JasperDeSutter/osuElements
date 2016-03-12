using System.Collections.Generic;

namespace osuElements.IO.File
{
    public interface IFileLine<in TModel>
    {
       // string Key { get; set; }
        bool WriteIfDefault { get; set; }
        bool IsDefault(TModel model);
        void GetLine(TModel model, List<string> result);
        //object GetValue(string value);
        bool Match(TModel model, string line);
    }
}