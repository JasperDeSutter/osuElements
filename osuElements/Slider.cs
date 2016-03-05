using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using osuElements.Curves;
using osuElements.Helpers;

namespace osuElements
{
    public class Slider : HitObject
    {
        public Slider(int x, int y, Timing time, bool isNewCombo = false, HitObjectType type = HitObjectType.Slider,
            HitObjectSoundType soundType = HitObjectSoundType.Normal, SampleSet sampleSet = SampleSet.None, SampleSet additionSampleSet = SampleSet.None)
            : base(time, x, y, isNewCombo, type | HitObjectType.Slider, soundType) {
            SampleSet = sampleSet;
            AdditionSampleSet = additionSampleSet;
            SliderType = SliderType.Linear;
            SegmentCount = 1;
            ControlPoints = new Position[2];
            ControlPoints[0] = StartPosition;
            ControlPoints[1] = StartPosition;//Second point is on cursor
            SoundType = soundType;
            SampleSet = sampleSet;
            AdditionSampleSet = additionSampleSet;
            StartTime = time;
            PointHitsounds = new List<PointHitsound>();
        }
        internal CurveBase _curve;
        public CurveBase Curve => _curve;

        private float TimeToCurve(float t) {
            if (Curve == null) return 0;
            var result = t * (Length / _curve.Length);
            return result > 1 ? 1 : (result < 0 ? 0 : (float)result);
        }

        public override Position EndPosition => _curve?.GetPointOnCurve(1).Item1 ?? ControlPoints.Last();

        public Position PositionAtTime(float time) => PositionAt((time - StartTime) / Duration);

        public Position PositionAt(float t) => _curve?.GetPointOnCurve(TimeToCurve(t)).Item1 ?? StartPosition;

        public Tuple<Position, float>[] GetAllCurvePoints(float t) => _curve?.GetPointsBeforeTOnCurve(TimeToCurve(t));

        public SliderType SliderType { get; set; }

        public Position[] ControlPoints { get; set; }
        public double Length { get; set; }

        public List<PointHitsound> PointHitsounds { get; set; }

        public override string ToString() {
            var sb = new StringBuilder(); //stringbuilder for performance
            sb.Append(base.ToString());
            sb.Append(",");
            sb.Append(SliderType.ToString().Substring(0, 1));
            sb.Append("|");
            sb.Append(ControlPoints.Skip(1).Select(c => $"{c.XForHitobject}:{c.YForHitobject}").ToString("|"));
            sb.Append(",");
            sb.Append(SegmentCount);
            sb.Append(",");
            sb.Append(Length);

            //TODO check if additions should be added
            if (PointHitsounds.All(p => p.IsDefault())) return sb.ToString();
            sb.Append(",");
            sb.Append(PointHitsounds.Select(p => (int)p.SoundType).ToString("|"));
            sb.Append(",");
            sb.Append(PointHitsounds.Select(p => "" + (int)p.SampleSet + ":" + (int)p.AdditionSampleSet).ToString("|"));
            sb.Append(",");
            sb.Append(AdditionsForString);
            return sb.ToString();
        }

    }
    public class PointHitsound : IHitsound
    {
        public bool IsDefault() {
            return SampleSet == SampleSet.None && AdditionSampleSet == SampleSet.None &&
                   SoundType == HitObjectSoundType.Normal && Custom == Custom.Default;
        }
        public SampleSet SampleSet { get; set; }
        public SampleSet AdditionSampleSet { get; set; }
        public HitObjectSoundType SoundType { get; set; }
        public Custom Custom
        {
            get { return Custom.Default; }
            set { }
        }
    }
}
