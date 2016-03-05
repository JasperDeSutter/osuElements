using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace osuElements.Repositories.File
{
    public class ObjectListFileSection<TValue, TModel> : IFileSection<TModel>
    {
        #region Fields

        private readonly PropertyInfo _listProperty;
        private readonly Func<string, TValue> _parseFunc;
        private readonly Func<TValue, string> _toStringFunc;

        private List<TValue> _list;

        private TModel _model;

        #endregion

        public ObjectListFileSection(string listname, string section, Func<string, TValue> parseFunc,
            Func<TValue, string> toStringFunc) {
            Section = section;
            _listProperty = typeof (TModel).GetRuntimeProperty(listname);
            _parseFunc = parseFunc;
            _toStringFunc = toStringFunc;
        }

        #region Properties

        public string Section { get; set; }

        #endregion

        #region Methods

        public bool ReadLine(string line) {
            _list.Add(_parseFunc(line));
            return true;
        }

        public void SetModel(TModel model) {
            _model = model;
            _list = _listProperty.GetValue(model) as List<TValue>;
        }

        public List<string> AllLines() {
            var result = new List<string>{$"[{Section}]"};
            var list = _listProperty.GetValue(_model) as List<TValue>;
            if (list != null) {
                result.AddRange(list.Select(T => _toStringFunc(T)));
            }
            result.Add("");
            return result;
        }

        public IFileSection<TModel> GetCopy() {
            return (IFileSection<TModel>) MemberwiseClone();
        }

        #endregion
    }
}