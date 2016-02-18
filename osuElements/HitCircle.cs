using System.Linq;
using osuElements.Helpers;
using osuElements.Other_Models;

namespace osuElements
{
    public class HitCircle : HitObject
    {
        public HitCircle(HitObject hObject) : base(hObject) { }
        public HitCircle(int x, int y, Timing time, bool isNewCombo = false, HitsoundType hitsound = HitsoundType.Normal, SampleSet sampleSet = SampleSet.None, SampleSet additionSet = SampleSet.None)
            : base(time, x, y, isNewCombo, HitObjectType.HitCircle, hitsound)
        {
            SampleSet = sampleSet;
            AdditionSet = additionSet;
        }

        public override int NewCombo
        {
            get
            {
                if (!IsNewCombo) return 0;
                if ((int)Type <= 16) return 1;
                return ((int)Type >> 4) + 1;
            }
        }
        public override float EndTime { get { return StartTime; } set { } }
        public override int Repeat { get { return 1; } set { } }
        public override string ToString() => $"{base.ToString()},{string.Join(":", Additions.Select(e => e.ToString()).ToArray())}:";
    }
}
