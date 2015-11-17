using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osuElements;
using osuElements.Curves;

namespace osuElements
{
    public class Slider : HitCircle
    {
        public Slider(HitObject hObject) : base(hObject) {
        }

        public Slider(int x, int y, Timing time, bool isNewCombo = false, HitsoundTypes hitsound = HitsoundTypes.Normal, SampleSets sampleSet = SampleSets.None, SampleSets additionSet = SampleSets.None)
            : base(x, y, time, isNewCombo, hitsound, sampleSet, additionSet) {
            Type = HoTypes.Slider;
            SliderType = SliderTypes.Linear;
            Repeat = 1;

            SliderPoints = new Position[2];
            SliderPoints[0] = StartPosition;
            SliderPoints[1] = Position.FromHitobject(0, 0);//Second point is on cursor
            Hitsound = hitsound;
            SampleSet = sampleSet;
            AdditionSet = additionSet;
            StartTime = time;
            //_curve = CurveBase.CreateCurve(SliderPoints, SliderType);
        }
        internal CurveBase _curve;
        public CurveBase Curve => _curve;

        private float TimeToCurve(float t) {
            float result = t * (Length / _curve.Length);
            return result > 1 ? 1 : (result < 0 ? 0 : result);
        }

        public Position PositionAt(float t) {
            return _curve.GetPointOnCurve(TimeToCurve(t)).Item1;
        }
        public Tuple<Position,float>[] GetAllCurvePoints(float t) {
            return _curve.GetPointsBeforeTOnCurve(TimeToCurve(t));
        }

        public SliderTypes SliderType { get; set; }
        
        /// <summary>
        /// The controlpoints of the slider
        /// </summary>
        public Position[] SliderPoints {
            get; set;
        }
        public int Repeat { get; set; }
        public float Length { get; set; }

        public int[][] PointAdditions { get; set; }
        public HitsoundTypes[] PointHisounds { get; set; }

        public override string ToString() {
            var points = new string[SliderPoints.Length - 1];
            for (int i = 1; i < SliderPoints.Length; i++) {
                points[i - 1] = SliderPoints[i].ToString();
            }
            if (!CheckAdditionsEmpty()) {
                var pas = new string[PointAdditions.Length];
                for (int i = 0; i < PointAdditions.Length; i++) {
                    pas[i] = string.Join(":", PointAdditions[i]);
                }

                return StartPosition + "," + StartTime.TimeMs + "," + (int)Type + "," + (int)Hitsound + "," + SliderType.ToString().Substring(0, 1) + "|" + string.Join("|", points) + "," + Repeat + "," + Length
                        + "," + string.Join("|", PointHisounds.Select(sel => (int)sel).ToArray()) + "," + string.Join("|", pas) + "," + string.Join(":", Additions) + ":";

            }
            else {
                return StartPosition + "," + StartTime.TimeMs + "," + (int)Type + "," + (int)Hitsound + "," + SliderType.ToString().Substring(0, 1) + "|" + string.Join("|", points) + "," + Repeat + "," + Length;
            }
        } //for writing in .osu file

        private bool CheckAdditionsEmpty() {
            if (Additions.Any(i => i != 0)) {
                return false;
            }
            return PointAdditions.SelectMany(i => i).All(j => j == 0) && PointHisounds.All(i => i == HitsoundTypes.Normal);
        } //For tostring
    }
}
