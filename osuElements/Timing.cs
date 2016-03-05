using System;

namespace osuElements
{
    public struct Timing : IComparable<Timing>, IComparable<int>
    {
        public Timing(int time) {
            TimeMs = time;
        }
        public int TimeMs { get; set; }
        public int Minutes { get { return TimeMs / 60000; } set { TimeMs += -Minutes * 60000 + value * 60000; } }
        public int Seconds { get { return TimeMs / 1000 - Minutes * 60; } set { TimeMs += -Seconds * 1000 + value * 1000; } }
        public int MSeconds { get { return TimeMs - Minutes * 60000 - Seconds * 1000; } set { TimeMs += -MSeconds + value; } }
        public override string ToString() => $"{Minutes.ToString("00")}:{Seconds.ToString("00")}:{MSeconds.ToString("000")}";

        public int CompareTo(Timing other) {
            return CompareTo(other.TimeMs);
        }
        public int CompareTo(int other) {
            return TimeMs.CompareTo(other);
        }
        public static implicit operator float (Timing t) {
            return t.TimeMs;
        }
        public static implicit operator Timing(float f) {
            return new Timing((int)f);
        }
        public static implicit operator int (Timing t) {
            return t.TimeMs;
        }
        public static implicit operator Timing(int i) {
            return new Timing(i);
        }
        
    }
}
