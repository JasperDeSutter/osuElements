using System;
using System.Collections.Generic;
using System.Linq;
using osuElements.Beatmaps;

namespace osuElements.Helpers
{
    internal static class InternalExtensions
    {
        internal static string ToString<T>(this IEnumerable<T> list, string separator) {
            return string.Join(separator, list);
        }
        internal static T[] AsArray<T>(this T t) {
            return new[] { t };
        }
        //used for triggertype -> hitsound parsing (is concatenated string)

        internal static bool TryParseStartsWithEnum<TEnum>(this string line, out TEnum tEnum) {
            foreach (var value in Enum.GetValues(typeof(TEnum))) {
                if (!line.StartsWith(value.ToString())) continue;
                tEnum = (TEnum)value;
                return true;
            }
            tEnum = default(TEnum);
            return false;
        }

        internal static float NormalizeAngle(this float a) {
            while (a < 0) a += MathHelper.TAU;
            return a % MathHelper.TAU;
        }

        internal static double NormalizeAngle(this double a) {
            while (a < 0) a += Math.PI * 2;
            return a % (Math.PI * 2);
        }

    }

    public static class publicExtensions
    {
        public static void DoEach(this IEnumerable<HitObject> hitObjects, Action<HitObject> action) {
            foreach (var hitObject in hitObjects) {
                action.Invoke(hitObject);
            }
        }
        public static IEnumerable<HitObject> GetActive(this IEnumerable<HitObject> hitObjects, double time) {
            return hitObjects.Where(hitObject => time > hitObject.EndTime && time < hitObject.EndTime);
        }
    }
}