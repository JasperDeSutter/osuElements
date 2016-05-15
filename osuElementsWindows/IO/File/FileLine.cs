using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using osuElements.Helpers;

namespace osuElements.IO.File
{
    public class FileLine<TModel, TValue> : IFileLine<TModel>
    {
        public FileLine(Expression<Func<TModel, TValue>> propertySelector, TValue defaultValue = default(TValue)) {
            Property = (PropertyInfo)((MemberExpression)propertySelector.Body).Member;
            Key = Property.Name;
            DefaultValue = defaultValue;
            _type = typeof(TValue);
        }
        public FileLine(string property, TValue defaultvalue = default(TValue)) {
            Property = typeof(TModel).GetRuntimeProperty(property);
            Key = property;
            DefaultValue = defaultvalue;
            _type = typeof(TValue);
        }

        public delegate bool TryParseDelegate(string line, out TValue result);

        private readonly Type _type;
        public string Key { get; set; }
        public PropertyInfo Property { get; set; }
        public TValue DefaultValue { get; set; }
        public string Format { get; set; } = "{0}: {1}";
        public char[] Separator { get; set; } = { ':' };
        public bool WriteIfDefault { get; set; }
        public bool WriteEnumAsInt { get; set; }
        public TryParseDelegate TryParse { get; set; }
        public Func<string, TValue> ReadFunc { get; set; }
        public Func<TValue, string> WriteFunc { get; set; }
        public virtual bool IsDefault(TModel model) {
            return Property != null && Equals((TValue)Property.GetValue(model), DefaultValue);
        }

        public virtual void GetLine(TModel model, List<string> result) {
            result.Add(GetLine(model));
        }
        public virtual string GetLine(TModel model) {
            var value = Property.GetValue(model);
            if (WriteFunc != null) return WriteFunc((TValue)value);
            string result;
            if (_type == typeof(string)) result = (string)value;
            else if (_type == typeof(bool)) result = (bool)value ? "1" : "0";
            else if (WriteEnumAsInt && DefaultValue is Enum) result = "" + (int)value;
            else {
                var formattable = value as IFormattable;
                result = formattable?.ToString(null, Constants.Cultureinfo) ?? value.ToString();
            }
            return string.Format(Format, Key, result);
        }
        public virtual object GetValue(string value) {
            if (ReadFunc != null)
                return ReadFunc.Invoke(value);

            if (_type == typeof(string))
                return value;

            if (_type == typeof(bool)) {
                if (value == "1")
                    return true;
                if (value == "0")
                    return false;
                throw new FormatException("The value was not 0 or 1 where a boolean was expected");
            }
            if (_type == typeof(Colour) || _type == typeof(Colour?))
                return Colour.Parse(value);

            if (DefaultValue is Enum)
                return Enum.Parse(typeof(TValue), value);

            return Convert.ChangeType(value, _type, Constants.Cultureinfo);
        }

        public void SetActualValue(TModel model, object value) {
            Property.SetValue(model, value);
        }


        public virtual bool Match(TModel model, string line) {
            if (TryParse != null) {
                TValue result;
                if (!TryParse.Invoke(line, out result)) return false;
                SetActualValue(model, result);
                return true;
            }
            var parts = line.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) return false;
            if (Key != parts[0]) return false;
            SetActualValue(model, GetValue(parts[1].Trim()));
            return true;
        }
    }
}