using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuReaderWPF.Helpers
{
    public class Statics
    {
        public static IFormatProvider CULTURE = new System.Globalization.CultureInfo("en-US");
        public static CultureInfo CULTURE2 = new CultureInfo("en-US", false);
    }
}
