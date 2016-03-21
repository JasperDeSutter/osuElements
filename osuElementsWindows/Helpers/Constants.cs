using System.Globalization;

namespace osuElements.Helpers
{
    internal class Constants
    {
        public static readonly Position CENTER_OF_SCREEN = new Position(256, 192);
        internal const int MAXIMUM_NEW_COMBO = 7;
        public static readonly CultureInfo CULTUREINFO = new CultureInfo("en-US");
        public const float HARD_ROCK_MULTIPLIER = 1.4f;
        public const float EASY_MULTIPLIER = 0.5f;
        public const float DT_MULTIPLIER = 3.0f / 2;
        public const float HT_MULTIPLIER = 3.0f / 4;
        public const float CIRCLE_SIZE_MOD_MULTIPLIER = 1.3f;
    }
}
