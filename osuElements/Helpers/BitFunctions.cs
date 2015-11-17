using osuElements.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuElements.Helpers
{
    public static class BitFunctions
    {
        public static bool Compare(this HoTypes a, HoTypes b)
        {
            return (a & b) > 0; //adding in binary results in 0 if both are equal
        }
        public static bool Compare(this Mods a, Mods b)
        {
            return (a & b) > 0; //adding in binary results in 0 if both are equal
        }
        public static bool Compare(this TransformTypes a, TransformTypes b)
        {
            return (a & b) > 0; //adding in binary results in 0 if both are equal
        }
        public static int GetMsb(int a, int bits)
        {
            int shift = bits;
            while (shift > 0)
            {
                var remainder = a >> shift;
                if (remainder != 0)
                {
                    return shift;
                }
                shift -= 1;
            }
            return 0;
        }
    }
}
