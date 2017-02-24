using System;
using System.Collections.Generic;
using System.Linq;

namespace osuElements.Replays
{
    public class KeyPress : IComparable<KeyPress>
    {
        public List<ReplayFrame> Frames { get; }

        public KeyPress(IEnumerable<ReplayFrame> frames, int nexttime, ReplayKeys keys) {
            var replayFrames = frames?.ToList() ?? new List<ReplayFrame>();
            Frames = replayFrames;

            Start = replayFrames.Count > 0 ? replayFrames.Min(f => f.Time) : 0;
            if (replayFrames.Count > 0)
                Position = new Position(replayFrames[0].X, replayFrames[0].Y);
            End = nexttime;
            ReplayKeys = keys;
        }
        public int Start { get; set; }
        public int End { get; set; }
        public ReplayKeys ReplayKeys { get; set; }
        public int Timing { get; set; }
        public Position Position { get; set; }
        public int CompareTo(KeyPress other) {
            return Start.CompareTo(other.Start);
        }

        public override string ToString() {
            return $"{Start} - {End} : {Timing}";
        }
    }
}