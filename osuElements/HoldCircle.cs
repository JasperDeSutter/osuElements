using System.Linq;
using osuElements.Helpers;
using osuElements.Other_Models;

namespace osuElements
{
    public class HoldCircle : HitCircle
    {
        public HoldCircle(HitObject hObject) : base(hObject) { }
        public HoldCircle(int x, int y, Timing starttime, Timing endtime, bool isNewCombo = false, HitsoundType hitsound = HitsoundType.Normal, SampleSet sampleSet = SampleSet.None, SampleSet additionSet = SampleSet.None)
            : base(x, y, starttime, isNewCombo, hitsound, sampleSet, additionSet) {
            EndTime = endtime;
        }
        public override string ToString() => $"{base.ToString()},{EndTime},{string.Join(":", Additions.Select(e=>e.ToString()).ToArray())}:";
    }
}
