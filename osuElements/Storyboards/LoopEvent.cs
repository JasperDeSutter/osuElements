using System;
using System.Collections.Generic;
using System.Linq;
using osuElements.Helpers;

namespace osuElements.Storyboards
{
    public class LoopEvent : ITransformable
    {
        public LoopEvent(int starttime, int loopcount = 1) {
            StartTime = starttime;
            Loopcount = loopcount;
            Transformations = new List<TransformationEvent>();
        }

        #region Properties
        public List<TransformationEvent> Transformations { get; set; }
        public virtual TransformTypes TransformType { get; } = TransformTypes.L;
        public int StartTime { get; set; }
        public int Loopcount { get; set; }

        public virtual int EndTime
        {
            get
            {
                return Transformations.Count < 1
                    ? StartTime
                    : StartTime + Transformations.Max(t => t.EndTime) * Loopcount;
            }
            set { throw new InvalidOperationException("Cannot set the endtime of a loopevent"); }
        }

        #endregion

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
        
        public void AddTransformation(TransformationEvent e) {
            Transformations.Add(e);
            Transformations.Sort();
        }

        #endregion
    }
}