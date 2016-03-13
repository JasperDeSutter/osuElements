using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace osuElements.IO.File
{
    public class CollectionFileSection<TValue, TModel> : IFileSection<TModel>
    {
        private readonly PropertyInfo _listProperty;
        private readonly Func<string, TValue> _parseFunc;
        private readonly Func<TValue, string> _toStringFunc;

        private ICollection<TValue> _list;


        public CollectionFileSection(Expression<Func<TModel, ICollection<TValue>>> propertySelector, string section, Func<string, TValue> parseFunc,
            Func<TValue, string> toStringFunc) {
            Section = section;
            _listProperty = (propertySelector.Body as MemberExpression).Member as PropertyInfo;
            _parseFunc = parseFunc;
            _toStringFunc = toStringFunc;
        }

        public string Section { get; set; }

        public bool ReadLine(string line) {
            _list.Add(_parseFunc(line));
            return true;
        }

        public void SetModel(TModel model) {
            var value = _listProperty.GetValue(model);

            _list = value as ICollection<TValue>;
        }

        public bool WriteIfEmpty { get; set; }

        public List<string> AllLines() {
            var result = new List<string>();
            if (_list == null) return result;
            if (Section != null) result.Add($"[{Section}]");
            if (_list.Count < 1) return WriteIfEmpty ? result : new List<string>();
            result.AddRange(_list.Select(T => _toStringFunc(T)));
            result.Add("");
            return result;
        }

        public IFileSection<TModel> GetCopy() {
            return (IFileSection<TModel>)MemberwiseClone();
        }

    }
}