using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuReaderWPF.Models
{
    public class Timing:IComparable<Timing>
    {
        public int TimeMS { get; set; }
        public int Minutes { get { return TimeMS / 60000; } }
        public int Seconds { get { return TimeMS/1000 - Minutes*60; } }
        public int MSeconds { get { return TimeMS - Minutes * 60000 - Seconds * 1000; } }
        public override string ToString()
        {
            return Minutes + ":" + Seconds + ":" + MSeconds;
        }
        public int CompareTo(Timing other)
        {
            return this.TimeMS.CompareTo(other.TimeMS);
        }
    }
}
