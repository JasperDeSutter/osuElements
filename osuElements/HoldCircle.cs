using System.Linq;
using osuElements.Helpers;

namespace osuElements
{
    public class HoldCircle : HitCircle
    {
        public HoldCircle(int x, int y, Timing starttime, Timing endtime, bool isNewCombo = false, HitObjectType type = HitObjectType.HoldCircle, HitObjectSoundType soundType = HitObjectSoundType.Normal, SampleSet sampleSet = SampleSet.None, SampleSet additionSampleSet = SampleSet.None)
            : base(x, y, starttime, isNewCombo, type, soundType, sampleSet, additionSampleSet) {
            EndTime = endtime;
        }

        public override string ToString() => $"{base.ToString()},{EndTime},{AdditionsForString}";
    }
}
