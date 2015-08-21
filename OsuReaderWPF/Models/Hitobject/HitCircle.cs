using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osuElements;
namespace osuElements
{
    public class HitCircle:HitObject
    {
        //public double Radius { get; set; }

        public HitCircle(HitObject hObject) : base(hObject) { }
        public HitCircle(int x, int y, Timing time, bool isNewCombo = false, HitsoundTypes hitsound = HitsoundTypes.Normal, SampleSets sampleSet = SampleSets.None, SampleSets additionSet = SampleSets.None)
            : base(time, x, y, isNewCombo,HOTypes.HitCircle,hitsound)
        {
            SampleSet = sampleSet;
            AdditionSet = additionSet;
        }

        public override int NewCombo
        {
            get
            {
                if(IsNewCombo){
                    if ((int)Type > 16)
                    {
                        return ((int)Type >> 4) + 1;
                    }
                    else return 1;
                }
                else return 0;
            }
        }

        public override string ToString()
        {
            return base.ToString()+ "," + string.Join(":", Additions) + ":";
        }
    }
}
