using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osuElements;
namespace osuElements
{
    public class Slider : HitCircle
    {
        public Slider(HitObject hObject): base(hObject)
        {
        }

        public Slider(int x, int y, Timing time, bool isNewCombo = false, HitsoundTypes hitsound = HitsoundTypes.Normal, SampleSets sampleSet = SampleSets.None, SampleSets additionSet = SampleSets.None)
            : base(x, y, time, isNewCombo, hitsound, sampleSet, additionSet)
        {
            Type = HOTypes.Slider;
            SliderType = SliderTypes.Linear;
            Repeat = 1;
            
            StartPosition = new Position(x, y);
            CurvePoints[0] = StartPosition;
            CurvePoints[1] = new Position(0, 0, true);
            Hitsound = hitsound;
            SampleSet = sampleSet;
            AdditionSet = additionSet;
            StartTime = time;
            
            //Second point is on cursor
        }

        public SliderTypes SliderType { get; set; }
        public Position[] CurvePoints { get; set; }
        public int Repeat { get; set; }
        public float Length { get; set; }
        
        public int[][] PointAdditions { get; set; }
        public HitsoundTypes[] PointHisounds { get; set; }

        public override string ToString()
        {
            string[] points = new string[CurvePoints.Length - 1];
            for (int i = 1; i < CurvePoints.Length; i++)
            {
                points[i - 1] = CurvePoints[i].ToString();
            }
            if(!CheckAdditionsEmpty() ){
            string[] pas = new string[PointAdditions.Length];
                for (int i = 0; i < PointAdditions.Length; i++)
                {
                    pas[i] = string.Join(":", PointAdditions[i]);
                }

                return StartPosition + "," + StartTime.TimeMS + "," + (int)Type + "," + (int)Hitsound + "," + SliderType.ToString().Substring(0, 1) + "|" + string.Join("|", points) + "," + Repeat + "," + Length
                        + "," + string.Join("|", PointHisounds.Select(sel=>(int)sel).ToArray()) + "," + string.Join("|", pas) + "," + string.Join(":", Additions) + ":";

            }
            else
            {
                return StartPosition + "," + StartTime.TimeMS + "," + (int)Type + "," + (int)Hitsound + "," + SliderType.ToString().Substring(0, 1) + "|" + string.Join("|", points) + "," + Repeat + "," + Length;
            }
        } //for writing in .osu file

        private bool CheckAdditionsEmpty()
        {
            foreach(int i in Additions) if( i != 0) return false;
            foreach (int[] i in PointAdditions)
            {
                foreach (int j in i)if (j != 0) return false;
            }
            foreach (HitsoundTypes i in PointHisounds) if (i != HitsoundTypes.Normal) return false;
            return true;
        } //For tostring
    }
}
