using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osuElements;

namespace osuElements
{
    public class Spinner:HitObject
    {
        public Spinner(HitObject hObject) : base(hObject) { }
        public Spinner(int x, int y, Timing time, Timing endTime, bool isNewCombo = false, HitsoundTypes hitsound = HitsoundTypes.Normal, SampleSets sampleSet = SampleSets.None, SampleSets additionSet = SampleSets.None)
            : base(time, x, y, isNewCombo,HOTypes.HitCircle,hitsound)
        {
            EndTime = endTime;
            SampleSet = sampleSet;
            AdditionSet = additionSet;
        }
        public override string ToString()
        {
            return base.ToString() + ',' + (int)EndTime +','+ string.Join(":", Additions) + ":";
        }
    }
}
