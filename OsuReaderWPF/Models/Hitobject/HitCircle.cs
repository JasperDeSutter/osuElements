using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsuReaderWPF.Helpers;
namespace OsuReaderWPF.Models
{
    public class HitCircle:HitObject
    {
        public double Radius { get; set; }

        public HitCircle(HitObject hObject) : base(hObject) { }
        public HitCircle(int x, int y, Timing time, double radius, bool isNewCombo = false, HitsoundTypes hitsound = HitsoundTypes.Normal, SampleSets sampleSet = SampleSets.None, SampleSets additionSet = SampleSets.None)
            : base(time, x, y, isNewCombo,HOTypes.HitCircle,hitsound)
        {
            Radius = radius;
            SampleSet = sampleSet;
            AdditionSet = additionSet;
        }

        public override string ToString()
        {
            return base.ToString()+ "," + string.Join(":", Additions) + ":";
        }
    }
}
