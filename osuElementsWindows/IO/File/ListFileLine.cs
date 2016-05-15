using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using osuElements.Helpers;

namespace osuElements.IO.File
{
    public class ListFileLine<TModel, TValue> : FileLine<TModel, List<TValue>>
    {
        public ListFileLine(Expression<Func<TModel, List<TValue>>> propertySelector, List<TValue> defaultvalue) : base(propertySelector, defaultvalue) { }
        public ListFileLine(Expression<Func<TModel, List<TValue>>> propertySelector, TValue defaultvalue) : base(propertySelector, new List<TValue>()) {
            _listDefaultValue = defaultvalue;
            _isListDefaultValue = true;
        }
        private readonly TValue _listDefaultValue;
        private readonly bool _isListDefaultValue;
        public override string GetLine(TModel model) {
            var list = Property.GetValue(model) as List<TValue>;
            return string.Format(Format, Key, list.ToString(","));
        }

        public char ListSeparator { get; set; } = ',';
        public override object GetValue(string value) {
            return value.Split(new[] { ListSeparator }, StringSplitOptions.RemoveEmptyEntries).
                Select(p => (TValue)Convert.ChangeType(p.Trim(), typeof(TValue), Constants.Cultureinfo)).ToList();
        }

        public override bool IsDefault(TModel model) {
            var list = Property.GetValue(model) as List<TValue>;
            if (list == null)
                return DefaultValue == null;
            if (_isListDefaultValue) {
                return list.All(v => v.Equals(_listDefaultValue));
            }
            if (DefaultValue == null) return false;
            return list.SequenceEqual(DefaultValue);
        }
    }
}