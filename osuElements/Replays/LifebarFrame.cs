using System;

namespace osuElements.Replays
{
    public struct LifebarFrame: IEquatable<LifebarFrame>,IComparable<LifebarFrame>
    {
        public int Time { get; set; }
        public float Life { get; set; }
        public bool Equals(LifebarFrame other) {
            return Time == other.Time && Life == other.Life;
        }
        public int CompareTo(LifebarFrame other) {
            return Time == other.Time ? 
                Life.CompareTo(other.Life) : Time.CompareTo(other.Time);
        }
        public override string ToString() {
            return $"{Time}|{Life}";
        }
    }
}
