using System.Linq;
using osuElements.Helpers;

namespace osuElements
{
    public class Spinner : HitObject
    {
        public Spinner(int x, int y, Timing time, Timing endTime, bool isNewCombo = false, HitObjectSoundType soundType = HitObjectSoundType.Normal, SampleSet sampleSet = SampleSet.None, SampleSet additionSampleSet = SampleSet.None)
            : base(time, x, y, isNewCombo, HitObjectType.Spinner | HitObjectType.NewCombo, soundType) {
            EndTime = endTime;
            SampleSet = sampleSet;
            AdditionSampleSet = additionSampleSet;
        }
        public override string ToString() => $"{base.ToString()},{EndTime},{AdditionsForString}:";
    }
}
