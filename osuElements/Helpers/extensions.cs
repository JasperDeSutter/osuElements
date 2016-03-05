using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace osuElements.Helpers
{
    public static class FloatExtension
    {
        public static float NormalizeAngle(this float a) {
            while (a < 0) a += Constants.Math.TAU;
            return (a % Constants.Math.TAU);
        }
    }

    public static class EnumExtension
    {
        //used for triggertype -> hitsound parsing (is concatenated string)
        public static bool TryParseStartsWithEnum<TEnum>(this string line, out TEnum tEnum) {
            foreach (var value in Enum.GetValues(typeof(TEnum))) {
                if (!line.StartsWith(value.ToString())) continue;
                tEnum = (TEnum)value;
                return true;
            }
            tEnum = default(TEnum);
            return false;

        }
    }

}

namespace System.Linq
{
    public static class LinqExtensions
    {
        public static string ToString<T>(this IEnumerable<T> list, string separator) {
            return string.Join(separator, list);
        }
    }

}
