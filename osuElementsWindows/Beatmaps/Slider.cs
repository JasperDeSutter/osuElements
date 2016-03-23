using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using osuElements.Curves;
using osuElements.Helpers;

namespace osuElements.Beatmaps
{
    public class Slider : HitObject
    {
        public Slider(Position position, int startTime, bool isNewCombo = false,
            HitObjectType type = HitObjectType.Slider,
            HitObjectSoundType soundType = HitObjectSoundType.Normal)
            : base(startTime, position, isNewCombo, type | HitObjectType.Slider, soundType) {
            SliderType = SliderType.Linear;
            SegmentCount = 1;
            ControlPoints = new[] { StartPosition };
            PointHitsounds = new List<PointHitsound>();
        }

        public CurveBase Curve { get; private set; }


        public void CreateCurve(bool forceRefresh = false) {
            if (!forceRefresh && Curve != null) return;
            switch (ControlPoints.Length) {
                case 1:
                    throw new InvalidOperationException("Don't try to make a curve with just 1 controlpoint!");
                case 2:
                    SliderType = SliderType.Linear;
                    break;
                case 3:
                    //length == 3 can be either be B P or C, just not L
                    if (SliderType == SliderType.Linear) SliderType = SliderType.PerfectCurve;
                    break;
                default:
                    //length > 3 can be either be B or C, not L or P
                    if (SliderType == SliderType.PerfectCurve || SliderType == SliderType.Linear)
                        SliderType = SliderType.Bezier; //let's default to bezier here
                    break;
            }
            Curve = CurveBase.CreateCurve(ControlPoints, SliderType);
        }

        public sealed override int SegmentCount { get; set; }

        public override Position EndPosition => Curve?.GetPointOnCurve(TimeToCurve(1)).Item1 ?? ControlPoints.Last();
        
        private float TimeToCurve(float t) {
            if (Curve == null) return t;
            var result = t * (Length / Curve.Length);
            return MathHelper.Clamp((float)result);
        }

        public Position PositionAtTime(float time) {
            var tfull = SegmentCount * (time - StartTime) / Duration;
            var currepeat = (int)(tfull % 2);
            if (currepeat == 1)
                tfull = 2 - tfull;
            return PositionAt(tfull%1);
        }

        public Position PositionAt(float t) => Curve?.GetPointOnCurve(TimeToCurve(t)).Item1 ?? StartPosition;

        public Tuple<Position, float>[] GetAllCurvePoints(float t) => Curve?.GetPointsBeforeTOnCurve(TimeToCurve(t));

        public SliderType SliderType { get; set; }

        public Position[] ControlPoints { get; set; }
        public double Length { get; set; }

        public List<PointHitsound> PointHitsounds { get; set; }

        public override string ToString() {
            var sb = new StringBuilder(); //stringbuilder for performance

            sb.Append(base.HitobjectToString);
            sb.Append(",");
            sb.Append(SliderType.ToString().Substring(0, 1));
            sb.Append("|");
            sb.Append(ControlPoints.Skip(1).Select(c => $"{c.XForHitobject}:{c.YForHitobject}").ToString("|"));
            sb.Append(",");
            sb.Append(SegmentCount);
            sb.Append(",");
            sb.Append(Length.ToString(Constants.CULTUREINFO));

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

            public override string ToString() {
                return $"{SampleSet},{AdditionSampleSet},{Custom}:{SoundType}";
            }
        }
    }
}