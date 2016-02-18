using System;
using System.Linq;
using System.Text;
using osuElements.Helpers;
using osuElements.Other_Models;

namespace osuElements
{
    public class Slider : HitCircle
    {
        public Slider(HitObject hObject) : base(hObject) { }

        public Slider(int x, int y, Timing time, bool isNewCombo = false, HitsoundType hitsound = HitsoundType.Normal, SampleSet sampleSet = SampleSet.None, SampleSet additionSet = SampleSet.None)
            : base(x, y, time, isNewCombo, hitsound, sampleSet, additionSet) {
            Type = HitObjectType.Slider;
            SliderType = SliderType.Linear;
            Repeat = 1;
            SliderPoints = new Position[2];
            SliderPoints[0] = StartPosition;
            SliderPoints[1] = StartPosition;//Second point is on cursor
            Hitsound = hitsound;
            SampleSet = sampleSet;
            AdditionSet = additionSet;
            StartTime = time;
        }
        internal CurveBase _curve;
        public CurveBase Curve => _curve;

        private float TimeToCurve(float t) {
            if (Curve == null) return 0;
            var result = t * (Length / _curve.Length);
            return result > 1 ? 1 : (result < 0 ? 0 : (float)result);
        }

        public Position PositionAtTime(float time) => PositionAt((time - StartTime) / Duration);

        public Position PositionAt(float t) => _curve?.GetPointOnCurve(TimeToCurve(t)).Item1 ?? StartPosition;

        public Tuple<Position, float>[] GetAllCurvePoints(float t) => _curve?.GetPointsBeforeTOnCurve(TimeToCurve(t));

        public SliderType SliderType { get; set; }

        /// <summary>
        /// The controlpoints of the slider
        /// </summary>
        public Position[] SliderPoints { get; set; }
        public double Length { get; set; }

        public int[][] PointAdditions { get; set; }
        public HitsoundType[] PointHisounds { get; set; }

        public override string ToString() {
            var sb = new StringBuilder(); //stringbuilder for performance
            sb.Append(base.ToString());
            sb.Append(",");
            sb.Append(SliderType.ToString().Substring(0, 1));
            sb.Append("|");
            for (int i = 1; i < SliderPoints.Length; i++) {
                sb.Append(SliderPoints[i].X);
                sb.Append(":");
                sb.Append(SliderPoints[i].Y);
                if (i < SliderPoints.Length) sb.Append("|");
            }
            sb.Append(",");
            sb.Append(Repeat);
            sb.Append(",");
            sb.Append(Length);
            if (CheckAdditionsEmpty()) return sb.ToString();

            sb.Append(",");
            sb.Append(string.Join("|", PointHisounds.Select(sel => ((int)sel).ToString()).ToArray()));
            sb.Append(",");
            var pas = new string[PointAdditions.Length];
            for (int i = 0; i < PointAdditions.Length; i++) {
                sb.Append(string.Join(":", PointAdditions[i].Select(e => e.ToString()).ToArray()));
                if (i < PointAdditions.Length) sb.Append("|");
            }
            sb.Append(",");
            sb.Append(string.Join(":", Additions.Select(e => e.ToString()).ToArray()));
            sb.Append(":");
            return sb.ToString();
        }

        private bool CheckAdditionsEmpty() {
            if (Additions.Any(i => i != 0)) {
                return false;
            }
            return PointAdditions.SelectMany(i => i).All(j => j == 0) && PointHisounds.All(i => i == HitsoundType.Normal);
        }
    }
}
