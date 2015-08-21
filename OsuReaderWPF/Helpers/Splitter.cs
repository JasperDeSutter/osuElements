using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuElements
{
    public class Splitter
    {
        public static char Space
        {
            get
            {
                char[] c = new char[] { ' ' };
                return c[0];
            }
        }
        public static char[] Comma
        {
            get
            {
                return new char[] { ',' };
            }
        }
        public static char[] Colon
        {
            get
            {
                return new char[] { ':' };
            }
        }
        public static char[] Pipe
        {
            get
            {
                return new char[] { '|' };
            }
        }
        public static char[] Bracket
        {
            get
            {
                return new char[] { '[' };
            }
        }
    }
}
