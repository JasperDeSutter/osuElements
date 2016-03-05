using System.Globalization;

namespace osuElements.Helpers
{
    internal class Constants
    {
        internal static class Math
        {
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

        internal static class IO
        {
            //public static readonly IFormatProvider FORMATPROVIDER = new CultureInfo("en-US");
            public static readonly CultureInfo CULTUREINFO = new CultureInfo("en-US");
            public const NumberStyles NUMBER_STYLE = NumberStyles.Any;
            public const string NEW_LINE = "/r/n";
        }

        internal static class Splitter
        {
            public static char Space => ' ';
            public static char[] Comma => new[] { ',' };

            public static char[] Colon => new[] { ':' };

            public static char[] Pipe => new[] { '|' };

            public static char[] Bracket => new[] { '[' };
        }

        internal static class Beatmap
        {
            public const float HARD_ROCK_MULTIPLIER = 1.4f;
            public const float EASY_MULTIPLIER = 0.5f;
            public const float DT_MULTIPLIER = 3.0f / 2;
            public const float HT_MULTIPLIER = 3.0f / 4;
            public const float CIRCLE_SIZE_MOD_MULTIPLIER = 1.3f;
        }

        //drawing
        public static readonly Position CENTER_OF_SCREEN = new Position(256, 192);
        internal const int MaximumNewCombo = 7;
    }
}
