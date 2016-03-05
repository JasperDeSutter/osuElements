using System;
using System.Collections.Generic;
using System.Linq;
using osuElements.Helpers;

namespace osuElements.Repositories.File
{
    public class ListFileLine<TModel, TValue> : FileLine<TModel, List<TValue>>
    {
        public ListFileLine(string property, List<TValue> defaultvalue) : base(property, defaultvalue) { }
        public ListFileLine(string property, TValue defaultvalue) : base(property, new List<TValue>()) {
            _listDefaultValue = defaultvalue;
            _isListDefaultValue = true;
        } //todo
        private readonly TValue _listDefaultValue;
        private readonly bool _isListDefaultValue;
        public override string GetLine(TModel model) {
            var list = Value.GetValue(model) as List<TValue>;
            return string.Format(Format, Key, list.ToString(","));
        }

        public char ListSeparator { get; set; } = ',';
        public override object GetValue(string value) {
            return value.Split(new[] { ListSeparator }, StringSplitOptions.RemoveEmptyEntries).
                Select(p => (TValue)Convert.ChangeType(p.Trim(), typeof(TValue), Constants.IO.CULTUREINFO)).ToList();
        }

        public override bool IsDefault(TModel model) {
            var list = Value.GetValue(model) as List<TValue>;
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