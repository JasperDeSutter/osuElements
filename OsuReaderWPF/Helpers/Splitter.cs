using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuReaderWPF.Helpers
{
    public class Splitter
    {
        public static char Space()
        {
            char[] c = new char[]{' '};
            return c[0];
        }
        public static char[] Comma()
        {
            return new char[] { ',' };
        }
        public static char[] Colon()
        {
            return new char[] { ':' };
        }
        public static char[] Pipe()
        {
            return new char[] { '|' };
        }
        public static char[] Bracket()
        {
            char[] c = new char[] { '[' };
            return c;
        }
    }
}
