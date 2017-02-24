using System.Globalization;

namespace osuElements.Helpers
{
    internal static class Constants
    {
        public static readonly Position CenterOfScreen = new Position(256, 192);
        public const int MaximumNewCombo = 7;
        public static readonly CultureInfo Cultureinfo = new CultureInfo("en-US");
        public const float HardRockMultiplier = 1.4f;
        public const float EasyMultiplier = 0.5f;
        public const float DtMultiplier = 3.0f / 2;
        public const float HtMultiplier = 3.0f / 4;
        public const float CircleSizeModMultiplier = 1.3f;

        public const int MaxApiScoreResults = 100;
        public const int MaxApiEventDays = 31;
        public const int MaxApiBeatmapResults = 500;
    }
}
