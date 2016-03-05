using System;
using System.Collections.Generic;
using System.Linq;
using osuElements.Helpers;

namespace osuElements
{
    public abstract class HitObject : IComparable<HitObject>, IEquatable<HitObject>, IHitsound
    {
        #region Fields

        private int _newCombo;

        #endregion

        protected HitObject(Timing time, float x, float y, bool isNewcombo = false,
            HitObjectType type = HitObjectType.None, HitObjectSoundType soundType = HitObjectSoundType.Normal) {
            StartTime = time;
            StartPosition = Position.FromHitobject(x, y);
            EndPosition = StartPosition;
            //Additions = new int[4];
            SampleSet = SampleSet.None;
            AdditionSampleSet = SampleSet.None;
            Custom = Custom.Default;
            CustomSet = 0;

            NewCombo = isNewcombo || type.HasFlag(HitObjectType.NewCombo)
                ? ((int)type & 112) >> 4 + 1
                : 0;
            Type = (HitObjectType)((int)type & 4095 - 64 - 32 - 16 - 4); //without the new combo bits
            SoundType = soundType;
        }

        #region Properties
        
        public HitObjectSoundType SoundType { get; set; }
        public SampleSet SampleSet { get; set; }
        public SampleSet AdditionSampleSet { get; set; }
        public Custom Custom { get; set; }
        public int CustomSet { get; set; }
        public string AdditionSound { get; set; } //a filename to a mp3 or wav

        public float Duration { get; set; }
        public Position StartPosition { get; set; }
        public virtual Position EndPosition { get; }
        public bool IsNewCombo => NewCombo > 0;
        public int Stack { get; set; }

        public int NewCombo
        {
            get { return _newCombo; }
            set
            {
                if (_newCombo == value) return;
                _newCombo = Math.Max(0, Math.Min(Constants.MaximumNewCombo, value));
            }
        }

        public int ComboNumber { get; set; }
        public ComboColour ComboColour { get; set; }
        public virtual int SegmentCount { get; set; } = 1;
        public Timing StartTime { get; set; }

        public virtual float EndTime
        {
            get { return StartTime + Duration; }
            set { Duration = value - StartTime; }
        }

        public HitObjectType Type { get; }

        private int HitObjectTypeForString =>
            (int)Type | (IsNewCombo ? (NewCombo - 1) << 4 : 0);

        protected string AdditionsForString =>
            $"{(int)SampleSet}:{(int)AdditionSampleSet}:{(int)Custom}:{CustomSet}:" + AdditionSound;

        #endregion

        #region Methods

        public static HitObject Parse(string line) {
            var parts = line.Split(Constants.Splitter.Comma, StringSplitOptions.RemoveEmptyEntries);
            var x = Convert.ToInt32(parts[0]);
            var y = Convert.ToInt32(parts[1]);
            var time = Convert.ToInt32(parts[2]);
            var type = (HitObjectType)Convert.ToInt32(parts[3]);
            var isNewCombo = type.IsType(HitObjectType.NewCombo);
            var hitsound = (HitObjectSoundType)Convert.ToInt32(parts[4]);


            if (type.IsType(HitObjectType.HitCircle)) //Make HitCircle
            {
                var h = new HitCircle(x, y, time, isNewCombo, type, hitsound);
                if (parts.Length > 5) GetAdditions(parts[5], h);
                return h;
            }
            if (type.IsType(HitObjectType.Spinner)) {
                //Make Spinner
                var sp = new Spinner(x, y, time, int.Parse(parts[5]), isNewCombo, hitsound);
                if (parts.Length > 6) GetAdditions(parts[6], sp);
                return sp;
            }
            if (type.IsType(HitObjectType.HoldCircle)) {
                //Make HoldCircle
                //float endtime = parts[5]
                var hc = new HoldCircle(x, y, time, int.Parse(parts[5]), isNewCombo, type, hitsound);
                if (parts.Length > 6) GetAdditions(parts[6], hc);
                return hc;
            }
            if (!type.IsType(HitObjectType.Slider)) return null;
            var s = new Slider(x, y, time, isNewCombo, type, hitsound);
            var repeat = Convert.ToInt32(parts[6]);
            var length = Convert.ToDouble(parts[7], Constants.IO.CULTUREINFO);
            s.SegmentCount = repeat;
            s.Length = length;
            var points = parts[5].Split(Constants.Splitter.Pipe);
            SliderType sliderType;
            switch (points[0]) {
                case "C":
                    sliderType = SliderType.Catmull;
                    break;
                case "B":
                    sliderType = SliderType.Bezier;
                    break;
                case "L":
                    sliderType = SliderType.Linear;
                    break;
                case "P":
                    sliderType = SliderType.PerfectCurve;
                    break;
                default:
                    sliderType = SliderType.Linear;
                    break;
            }
            s.SliderType = sliderType;
            var pointPositions = new Position[points.Length];
            pointPositions[0] = s.StartPosition;
            for (var i = 1; i < points.Length; i++) {
                var p = points[i].Split(Constants.Splitter.Colon).Select(int.Parse).ToArray();
                pointPositions[i] = Position.FromHitobject(p[0], p[1]);
            }
            s.ControlPoints = pointPositions;
            var pointHitsounds = Enumerable.Range(1, repeat + 1).Select(i => new PointHitsound()).ToList();

            if (parts.Length > 8) {
                var soundTypeParts = parts[8].Split(Constants.Splitter.Pipe);
                var soundTypeCount = soundTypeParts.Length;
                for (int i = 0; i < repeat + 1; i++) {
                    if (i > soundTypeCount) break;
                    pointHitsounds[i].SoundType = (HitObjectSoundType)int.Parse(soundTypeParts[i]);
                }
                var sampleParts = parts[9].Split(Constants.Splitter.Pipe);
                var sampleCount = sampleParts.Length;
                for (var i = 0; i < repeat + 1; i++) {
                    if (i >= sampleCount) break;
                    var sampleSplit = sampleParts[i].Split(':');
                    pointHitsounds[i].SampleSet = (SampleSet)int.Parse(sampleSplit[0]);
                    pointHitsounds[i].AdditionSampleSet = (SampleSet)int.Parse(sampleSplit[1]);
                }
                s.PointHitsounds = pointHitsounds;
                if (parts.Length > 9) {
                    GetAdditions(parts[10], s);
                }
            }
            return s;
        }


        public int CompareTo(HitObject other) {
            if (other == null) return 1;
            if (other == this) return 0;
            return StartTime == other.StartTime
                ? Type.CompareTo(other.Type)
                : StartTime.CompareTo(other.StartTime);
        }

        public bool IsHitObjectType(HitObjectType type) {
            return Type.IsType(type);
        }

        public override string ToString()
            =>
                $"{StartPosition.ToHitObjectString()},{StartTime.TimeMs},{HitObjectTypeForString},{(int)SoundType}";

        public bool Equals(HitObject other) => CompareTo(other) == 0;

        private static void GetAdditions(string part, HitObject ho) {
            if (string.IsNullOrEmpty(part)) return;
            var parts = part.Split(Constants.Splitter.Colon);
            if (parts.Length < 2) return;
            ho.SampleSet = (SampleSet)int.Parse(parts[0]);
            ho.AdditionSampleSet = (SampleSet)int.Parse(parts[1]);
            if (parts.Length < 3) return;
            ho.Custom = (Custom)int.Parse(parts[2]);
            if (parts.Length < 4) return;
            ho.CustomSet = int.Parse(parts[3]);
            if (parts.Length < 5) return;
            ho.AdditionSound = parts[4];
        }

        #endregion
    }
}