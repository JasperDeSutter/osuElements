using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace osuElements.Helpers
{
    public static class FloatExtension
    {
        public static float NormalizeAngle(this float a)
        {
            while (a < 0) a += Constants.Math.TwoPi;
            return (a % Constants.Math.TwoPi);
        }
    }
}
