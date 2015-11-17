using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuElements.Helpers
{
    internal class Constants
    {
        internal class Math
        {
            public const float Pi = 3.141592635897931f;
            /// <summary>
            /// Pi / 2
            /// </summary>
            public const float Pi2 = Pi / 2;
            /// <summary>
            /// Pi * 2
            /// </summary>
            public const float TwoPi = Pi * 2;
        }
        //parsing and writing
        public static readonly IFormatProvider FORMATPROVIDER = new System.Globalization.CultureInfo("en-US");
        public static readonly CultureInfo CULTUREINFO = new CultureInfo("en-US", false);
        public const string NewLine = "/r/n";
        //gameplay
        public const float HardRockMultiplier = 1.4f;
        public const float EasyMultiplier = 0.5f;
        public const float DtMultiplier = 3.0f/2;
        public const float HtMultiplier = 3.0f/4;
        public const float CircleSizeModMultiplier = 1.3f;
        //drawing
        public static readonly Position CENTER_OF_SCREEN = new Position(256, 192);
    }
}
