using System;
using osuElements.Helpers;

namespace osuElements.Replays
{
    public struct ReplayFrame : IComparable<ReplayFrame>
    {
        public int TimeOffset { get; set; }
        public int Time { get; set; }
        public float X => Position.X;
        public float Y => Position.Y;
        public Position Position { get; set; }
        public ReplayKeys Keys { get; set; }
        public int CompareTo(ReplayFrame other) {
            return Time == other.Time
                ? (Keys == other.Keys
                    ? (X == other.X ?
                        Y.CompareTo(other.Y)
                        : X.CompareTo(other.X))
                    : Keys.CompareTo(other.Keys))
                : Time.CompareTo(other.Time);
        }
        public override string ToString() {
            return $"{Time}|{X}|{Y}|{(int)Keys}";
        }
    }
}
