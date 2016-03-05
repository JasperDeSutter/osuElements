using System.Collections.Generic;
using System.Reflection;

namespace osuElements.Repositories.File
{
    public class MultipleFileSection<TValue, TModel> : IFileSection<TModel> where TValue : new()
    {
        private readonly PropertyInfo _listProperty;

        public string Section { get; }
        string IFileSection<TModel>.Section { get; set; }

        public bool ReadLine(string line) {
           return _fileSection.ReadLine(line);
        }
        
        public void SetModel(TModel model) {
            _model = model;
            var item = new TValue();
            var list = _listProperty.GetValue(model) as List<TValue>;
            list?.Add(item);
            _fileSection.SetModel(item);
        }

        private TModel _model ;

        public List<string> AllLines() {
            var list = _listProperty.GetValue(_model) as List<TValue>;
            var result = new List<string>();
            if (list == null) return result;
            foreach (var u in list) {
                _fileSection.SetModel(u);
                result.AddRange(_fileSection.AllLines());
            }
            return result;
        }

        public IFileSection<TModel> GetCopy() {
            return (IFileSection<TModel>) MemberwiseClone();
        }

        private readonly FileSection<TValue> _fileSection;

        public MultipleFileSection(string listname, string section, params IFileLine<TValue>[] fileLines) {
            Section = section;
            _fileSection = new FileSection<TValue>(section, fileLines);
            _listProperty = typeof(TModel).GetRuntimeProperty(listname);
        }
    }
}