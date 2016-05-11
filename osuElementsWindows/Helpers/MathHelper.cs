using System;
using System.Linq;

namespace osuElements.Helpers
{
    internal static class MathHelper
    {
        public static double Lerp(double t, double a, double b) {
            return a + t * (b - a);
        }
        public static float Lerp(float t, float a, float b) {
            return a + t * (b - a);
        }
        public static float Clamp(float f, float min = 0f, float max = 1f) {
            return Math.Min(max, Math.Max(min, f));
        }
        public static bool Between(float value, float min, float max) {
            return value < max && value > min;
        }

        internal static bool TestNanInfinite(params float[] values) {
            return values.Any(value => float.IsNaN(value) || float.IsInfinity(value));
        }
        internal static bool TestNanInfinite(params double[] values) {
            return values.Any(value => double.IsNaN(value) || double.IsInfinity(value));
        }

        public const float PI = 3.141592635897931f;

        /// <summary>
        /// Pi / 2
        /// </summary>
        public const float PI2 = PI / 2f;

        /// <summary>
        /// Pi * 2
        /// </summary>
        public const float TAU = PI * 2f;
    }
}