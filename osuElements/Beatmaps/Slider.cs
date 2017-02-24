using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using osuElements.Beatmaps.Curves;
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

        public int ScorePointCount { get; set; }
        public override int MaxCombo => 1 + SegmentCount * (ScorePointCount + 1); //+1 for sliderendcircles

        public CurveBase Curve { get; private set; }
        public override HitObject Clone() {
            var result = (Slider)base.Clone();
            result.PointHitsounds = new List<PointHitsound>();
            foreach (var p in PointHitsounds) {
                result.PointHitsounds.Add(new PointHitsound { SampleSet = p.SampleSet, AdditionSampleSet = p.AdditionSampleSet, Custom = p.Custom, SoundType = p.SoundType });
            }
            result.ControlPoints = new Position[ControlPoints.Length];
            Array.Copy(ControlPoints, result.ControlPoints, ControlPoints.Length);
            //no copy of curve
            return result;
        }

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
                        SliderType = SliderType.Bezier; //lets default to bezier here
                    break;
            }
            Curve = CurveBase.CreateCurve(ControlPoints, SliderType, Length);
        }

        public sealed override int SegmentCount { get; set; }

        public override Position EndPosition => Curve?.EndPosition ?? ControlPoints.Last();


        public override Position PositionAtTime(double time) {
            var tfull = SegmentCount * (time - StartTime) / Duration;
            var currepeat = (int)(tfull % 2);
            if (currepeat == 1)
                tfull = 2 - tfull;
            return PositionAt(Math.Max(0, tfull % 1));
        }

        public Position PositionAt(double t) => Curve?.GetPointOnCurve(t) ?? StartPosition;

        public List<CurveSegment> GetAllCurvePoints(double t) => Curve?.GetPointsBeforeTOnCurve(1);

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
            sb.Append(Length.ToString(Constants.Cultureinfo));

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

        public HitSound[] GetPointHitsounds(int point) {
            return PointHitsounds[point].InheritSoundsFrom(this).GetHitSounds();
        }

        public class PointHitsound : IHitsound
        {
            public bool IsDefault() {
                return SampleSet == SampleSet.None && AdditionSampleSet == SampleSet.None &&
                       SoundType == HitObjectSoundType.Normal;
            }

            public SampleSet SampleSet { get; set; }
            public SampleSet AdditionSampleSet { get; set; }
            public HitObjectSoundType SoundType { get; set; }

            public Custom Custom { get; set; }
            public int Volume { get; set; }

            public override string ToString() {
                return $"{SampleSet},{AdditionSampleSet},{Custom}:{SoundType}";
            }
        }
    }
}