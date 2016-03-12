using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace osuElements.IO.File
{
    internal class MultiFileLine<TModel, TValue> : FileLine<TModel, TValue>
    {
        private readonly List<TValue> _defaultValue;
        public MultiFileLine(Expression<Func<TModel, List<TValue>>> propertySelector, List<TValue> defaultValue) : base("") {
            _defaultValue = defaultValue;
            Regex = new Regex(@"\d+");
            Property = (propertySelector.Body as MemberExpression).Member as PropertyInfo;
        }

        public override bool IsDefault(TModel model) {
            var list = (List<TValue>)Property.GetValue(model);
            if (list == null || _defaultValue == null) return false;
            if (list.Count != _defaultValue.Count) return false;
            return list.Where((t, i) => _defaultValue[i].Equals(t)).Any();
        }

        public override void GetLine(TModel model, List<string> result) {
            var list = (List<TValue>)Property.GetValue(model);
            result.AddRange(WriteFunc != null
                ? list.Select(WriteFunc)
                : list.Select((c, i) => string.Format(Format, Key + (i + 1), c)));
        }

        public Regex Regex { get; set; }

        public override bool Match(TModel model, string line) {
            var list = (List<TValue>)Property.GetValue(model);
            if (TryParse != null) {
                TValue result;
                if (!TryParse.Invoke(line, out result)) return false;
                list.Add(result);
                return true;
            }
            var parts = line.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) return false;
            if (!parts[0].TrimStart().StartsWith(Key)) return false;
            var indexpart = Regex.Match(parts[0]).Value.Trim();
            var index = int.Parse(indexpart);

            lock (list) {
                //list.Insert(index - 1, (TValue)GetValue(parts[1].Trim()));
                while (list.Count < index) list.Add(default(TValue));
                list[index - 1] = (TValue)GetValue(parts[1].Trim());
                return true;
            }
        }
    }
}