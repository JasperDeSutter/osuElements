using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuElements
{
    internal class Statics
    {
        public static IFormatProvider CULTURE = new System.Globalization.CultureInfo("en-US");
        public static CultureInfo CULTURE2 = new CultureInfo("en-US", false);
        public const float HardRockMultiplier = 1.4f;
        public const float EasyMultiplier = 0.5f;
        public const float DTMultiplier = 3.0f/2;
        public const float HTMultiplier = 3.0f/4;
        public const float CircleSizeModMultiplier = 1.3f;
        public const int OsuResolutionWidth = 512;
        public const int OsuResolutionHeight = 384;
        public static readonly double OsuScreenProportion = OsuResolutionWidth / OsuResolutionHeight;
    }
}
