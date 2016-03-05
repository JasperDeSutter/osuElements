using System.Linq;
using osuElements.Helpers;

namespace osuElements
{
    public class HitCircle : HitObject
    {
        public HitCircle(int x, int y, Timing time, bool isNewCombo = false, HitObjectType type = HitObjectType.HitCircle, HitObjectSoundType soundType = HitObjectSoundType.Normal, SampleSet sampleSet = SampleSet.None, SampleSet additionSampleSet = SampleSet.None)
            : base(time, x, y, isNewCombo, type, soundType) {
            SampleSet = sampleSet;
            AdditionSampleSet = additionSampleSet;
        }

        public override float EndTime { get { return StartTime; } set { } }
        public override int SegmentCount { get { return 1; } set { } }
        public override string ToString() => base.ToString() + "," + AdditionsForString;
    }
}
