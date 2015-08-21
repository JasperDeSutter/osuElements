using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuElements
{
    public static class BitFunctions
    {
        public static bool Compare(this HOTypes a, HOTypes b)
        {
            return (a & b) > (HOTypes)0; //adding in binary results in 0 if both are equal
        }
        public static bool Compare(this Mods a, Mods b)
        {
            return (a & b) > (Mods)0; //adding in binary results in 0 if both are equal
        }
        public static bool Compare(this TransformTypes a, TransformTypes b)
        {
            return (a & b) > (TransformTypes)0; //adding in binary results in 0 if both are equal
        }
        public static int GetMSB(int a, int bits)
        {
            int shift = bits;
            int remainder;
            while (shift > 0)
            {
                remainder = a >> shift;
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
