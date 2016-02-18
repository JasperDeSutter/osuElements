using System;
using System.Globalization;

namespace osuElementsWindows
{
    internal class Constants
    {
        internal class Io
        {
            //public static readonly IFormatProvider FORMATPROVIDER = new CultureInfo("en-US");
            public static readonly CultureInfo CULTUREINFO = new CultureInfo("en-US");
            public const NumberStyles NUMBER_STYLE = NumberStyles.Any;
            public const string NEW_LINE = "/r/n";
            public const StringSplitOptions removeEmptyEntries = StringSplitOptions.RemoveEmptyEntries;
        }
            
        
    }
}
