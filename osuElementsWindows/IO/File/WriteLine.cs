using System.Collections.Generic;

namespace osuElements.IO.File
{
    public class WriteLine<T>:IFileLine<T>
    {
        private readonly string _line;

        public WriteLine(string line) {
            _line = line;
            WriteIfDefault = true;
        }
        
        public bool WriteIfDefault { get; set; }
        public bool IsDefault(T model) {
            return false;
        }

        public void GetLine(T model, List<string> result) {
            result.Add(_line);
        }
        
        public bool Match(T model, string line) {
            return false;
        }
    }
}