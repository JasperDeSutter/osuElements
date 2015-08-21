using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuElements
{
    public class Timing:IComparable<Timing>,IComparable<int>
    {
        public Timing(int time)
        {
            TimeMS = time;
        }
        public int TimeMS { get; set; }
        public int Minutes { get { return TimeMS / 60000; } set { TimeMS += - Minutes * 60000 + value * 60000; } }
        public int Seconds { get { return TimeMS / 1000 - Minutes * 60; } set { TimeMS +=  - Seconds * 1000 + value * 1000; } }
        public int MSeconds { get { return TimeMS - Minutes * 60000 - Seconds * 1000; } set { TimeMS +=  - MSeconds + value; } }
        public override string ToString()
        {
            return Minutes + ":" + Seconds + ":" + MSeconds;
        }
        public int CompareTo(Timing other)
        {
            return this.CompareTo(other.TimeMS);
        }
        public int CompareTo(int other)
        {
            return this.TimeMS.CompareTo(other);
        }
        public static implicit operator float(Timing t)
        {
            return (float)t.TimeMS;
        }
        public static implicit operator Timing(float f)
        {
            return new Timing((int)f);
        }
        public static implicit operator int(Timing t)
        {
            return t.TimeMS;
        }
        public static implicit operator Timing(int i)
        {
            return new Timing(i);
        }
    }
}
