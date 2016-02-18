using System.Linq;
using osuElements.Helpers;
using osuElements.Other_Models;

namespace osuElements
{
    public class Spinner : HitObject
    {
        public Spinner(HitObject hObject) : base(hObject) { }
        public Spinner(int x, int y, Timing time, Timing endTime, bool isNewCombo = false, HitsoundType hitsound = HitsoundType.Normal, SampleSet sampleSet = SampleSet.None, SampleSet additionSet = SampleSet.None)
            : base(time, x, y, isNewCombo, HitObjectType.Spinner, hitsound) {
            EndTime = endTime;
            SampleSet = sampleSet;
            AdditionSet = additionSet;
        }
        public override string ToString() => $"{base.ToString()},{EndTime},{string.Join(":", Additions.Select(e => e.ToString()).ToArray())}:";
    }
}
