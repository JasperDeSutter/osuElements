using System;

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
        public static float Clamp(float f, float min = 0, float max = 1) {
            return Math.Min(max, Math.Max(min, f));
        }
        public static bool Between(float value, float min, float max) {
            return value < max && value > min;
        }


        public const float PI = 3.141592635897931f;

        /// <summary>
        /// Pi / 2
        /// </summary>
        public const float PI2 = PI / 2;

        /// <summary>
        /// Pi * 2
        /// </summary>
        public const float TAU = PI * 2;
    }
}