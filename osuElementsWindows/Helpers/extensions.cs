using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using osuElements.Beatmaps;

namespace osuElements.Helpers
{
    public static class AngleExtension
    {
        public static float NormalizeAngle(this float a) {
            while (a < 0) a += MathHelper.TAU;
            return a % MathHelper.TAU;
        }
        public static double NormalizeAngle(this double a) {
            while (a < 0) a += Math.PI * 2;
            return a % (Math.PI * 2);
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

    public static class LinqExtensions
    {
        internal static string ToString<T>(this IEnumerable<T> list, string separator) {
            return string.Join(separator, list);
        }
        internal static T[] AsArray<T>(this T t) {
            return new[] { t };
        }
    }
}