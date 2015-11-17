using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace osuElements
{
    public class HoldCircle : HitCircle
    {
        public HoldCircle(HitObject hObject) : base(hObject) { }
        public HoldCircle(int x, int y, Timing starttime, Timing endtime, bool isNewCombo = false, HitsoundTypes hitsound = HitsoundTypes.Normal, SampleSets sampleSet = SampleSets.None, SampleSets additionSet = SampleSets.None)
            : base(x, y, starttime, isNewCombo, hitsound, sampleSet, additionSet) {
            EndTime = endtime;
        }
    }
}
