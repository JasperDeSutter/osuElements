using System;
using System.Collections.Generic;
using System.Linq;
using osuElements.Helpers;

namespace osuElements.Storyboards
{
    public class LoopEvent : ITransformable
    {
        #region Properties
        public List<TransformationEvent> Transformations { get; set; }
        public int LoopDuration
        {
            get
            {
                return Transformations.Count < 1 ? 0 : Transformations.Max(t => t.EndTime) - Transformations.Min(t => t.StartTime);
            }
        }
        public virtual TransformTypes TransformType { get; } = TransformTypes.L;
        public int StartTime { get; set; }
        public int Loopcount { get; set; }

        public int EndTime { get; set; }

        #endregion
        public LoopEvent(int starttime, int loopcount = 1) {
            StartTime = starttime;
            Loopcount = loopcount;
            Transformations = new List<TransformationEvent>();
        }

        #region Methods

        public static bool TryParse(string line, out LoopEvent l) {
            var parts = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            l = null;
            if (parts.Length < 3 || parts[0].Trim() != "L") return false;
            int time, loop;
            if (!int.TryParse(parts[1], out time)) return false;
            if (!int.TryParse(parts[2], out loop)) return false;
            l = new LoopEvent(time, loop);
            return true;
        }

        public static LoopEvent Parse(string line) {
            var parts = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return new LoopEvent(int.Parse(parts[1]), int.Parse(parts[2]));
        }

        public override string ToString() {
            return $"{TransformType},{StartTime},{Loopcount}";
        }

        public void AddTransformation(params TransformationEvent[] transforms) {
            Transformations.AddRange(transforms);
            Transformations.Sort();
            EndTime = Transformations.Max(t => t.EndTime);
        }

        public virtual void OptimizeLoop() {
            var first = Transformations.Min(t => t.StartTime);
            if (StartTime == first) return;
            var difference = first - StartTime;
            StartTime += difference;
            foreach (var transform in Transformations) {
                transform.StartTime -= difference;
                transform.EndTime -= difference;
            }
        }

        #endregion
    }
}