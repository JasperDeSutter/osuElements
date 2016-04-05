using System;
using System.Linq;
using osuElements.Helpers;
//using HitObjectSoundType = osuElements.Helpers.HitObjectSoundType;
//using HitObjectType = osuElements.Helpers.HitObjectType;

namespace osuElements.Beatmaps
{
    public abstract class HitObject : IComparable<HitObject>, IEquatable<HitObject>, IHitsound
    {
        private int _newCombo;

        protected HitObject(int startTime, Position position, bool isNewcombo, HitObjectType type, HitObjectSoundType soundType) {
            StartTime = startTime;
            StartPosition = position;
            NewCombo = isNewcombo || type.HasFlag(HitObjectType.NewCombo)
                ? 1 + ((int)(type & HitObjectType.CustomCombo) >> 4)
                : 0;
            Type = type ^ (type & (HitObjectType.CustomCombo | HitObjectType.NewCombo)); //take out new combo bits (64, 32, 16 and 4)
            SoundType = soundType;
        }

        #region Properties
        
        public Position StartPosition { get; set; }
        public virtual Position EndPosition => StartPosition;
        public int StackCount { get; set; }
        public HitObjectType Type { get; }

        #region HitSounds
        public HitObjectSoundType SoundType { get; set; }
        public SampleSet SampleSet { get; set; }
        public SampleSet AdditionSampleSet { get; set; }
        public Custom Custom { get; set; }
        public int Volume { get; set; }

        /// <summary>
        /// A custom sound to play when the hitobject is hit
        /// </summary>
        public string AdditionSound { get; set; }

        //these come from the osu!framework
        public bool Whistle
        {
            get { return SoundType.IsType(HitObjectSoundType.Whistle); }
            set
            {
                if (value)
                    SoundType |= HitObjectSoundType.Whistle;
                else
                    SoundType &= ~HitObjectSoundType.Whistle;
            }
        }
        public bool Finish
        {
            get { return SoundType.IsType(HitObjectSoundType.Finish); }
            set
            {
                if (value)
                    SoundType |= HitObjectSoundType.Finish;
                else
                    SoundType &= ~HitObjectSoundType.Finish;
            }
        }
        public bool Clap
        {
            get { return SoundType.IsType(HitObjectSoundType.Clap); }
            set
            {
                if (value)
                    SoundType |= HitObjectSoundType.Clap;
                else
                    SoundType &= ~HitObjectSoundType.Clap;
            }
        }
        #endregion

        #region ComboColour
        public Colour Colour { get; set; }

        /// <summary>
        /// Zero-based index for which color to use
        /// </summary>
        public int ColourOffset { get; set; }

        /// <summary>
        /// The one-based index of this hitobject in the current combo.
        /// (number displayed on the hitobject)
        /// </summary>
        public int ComboNumber { get; set; }
        public bool IsNewCombo => NewCombo > 0;
        public bool LastInCombo { get; set; }

        /// <summary>
        /// How many colours to skip on new combo.
        /// Value must be between 1 and 7
        /// </summary>
        public int NewCombo
        {
            get { return _newCombo; }
            set
            {
                if (_newCombo == value) return;
                _newCombo = Math.Max(1, Math.Min(Constants.MAXIMUM_NEW_COMBO, value));
            }
        }

        /// <summary>
        /// The amount of combo the player gets if played perfectly
        /// </summary>
        public virtual int MaxCombo { get; } = 1;
        #endregion

        #region Time
        public int StartTime { get; set; }

        public int EndTime { get; set; }

        /// <summary>
        /// The time between starttime and endtime
        /// </summary>
        public int Duration
        {
            get { return EndTime - StartTime; }
            set { EndTime = value + StartTime; }
        }

        /// <summary>
        /// How many times the hitobject repeats (for repeat sliders)
        /// </summary>
        public virtual int SegmentCount
        {
            get { return 1; }
            set { }
        }

        /// <summary>
        /// The total time one segment is active
        /// </summary>
        public double SegmentDuration => Duration * 1.0 / SegmentCount;
        #endregion
        
        protected string AdditionsForString =>
            $"{(int)SampleSet}:{(int)AdditionSampleSet}:{(int)Custom}:{Volume}:" + AdditionSound;

        #endregion

        #region Methods

        public virtual Position PositionAtTime(double time) {
            return StartPosition;
        }

        public virtual void Update(double time){}

        public virtual HitObject Clone() {
            var result = (HitObject)MemberwiseClone();
            //add copies of reference types
            return result;
        }
        public static HitObject Parse(string line) {
            var parts = line.Split(','.AsArray(), StringSplitOptions.RemoveEmptyEntries);
            var position = Position.FromHitobject(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]));
            var time = Convert.ToInt32(parts[2]);
            var type = (HitObjectType)Convert.ToInt32(parts[3]);
            var isNewCombo = type.IsType(HitObjectType.NewCombo);
            var hitsound = (HitObjectSoundType)Convert.ToInt32(parts[4]);

            if (type.IsType(HitObjectType.HitCircle)) //Make HitCircle
            {
                var h = new HitCircle(position, time, isNewCombo, type, hitsound);
                if (parts.Length > 5) GetAdditions(parts[5], h);
                return h;
            }
            if (type.IsType(HitObjectType.Spinner)) {
                //Make Spinner
                var sp = new Spinner(position, time, int.Parse(parts[5]), type, hitsound);
                if (parts.Length > 6) GetAdditions(parts[6], sp);
                return sp;
            }
            if (type.IsType(HitObjectType.HoldCircle)) {
                //Make HoldCircle
                var hc = new HoldCircle(position, time, time, isNewCombo, type, hitsound);
                if (parts.Length < 6) return hc;

                var endstring = parts[5];
                var endstringparts = endstring.Split(':'.AsArray(), StringSplitOptions.RemoveEmptyEntries);
                hc.EndTime = int.Parse(endstringparts[0]);
                GetAdditions(endstring.Substring(endstring.IndexOf(':')), hc);

                return hc;
            }
            if (!type.IsType(HitObjectType.Slider)) return null;
            var s = new Slider(position, time, isNewCombo, type, hitsound);
            //type and points
            var points = parts[5].Split('|');
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
                var p = points[i].Split(':').Select(int.Parse).ToArray();
                pointPositions[i] = Position.FromHitobject(p[0], p[1], false);
            }
            s.ControlPoints = pointPositions;
            //repeat count
            s.SegmentCount = int.Parse(parts[6]);
            var pointcount = s.SegmentCount + 1;
            //length
            if (parts.Length > 7) s.Length = Convert.ToDouble(parts[7], Constants.CULTUREINFO);
            //hitsounds
            var pointHitsounds = Enumerable.Range(1, pointcount).Select(i => new Slider.PointHitsound()).ToList();
            if (parts.Length < 9) return s;
            var soundTypeParts = parts[8].Split('|');
            for (var i = 0; i < pointcount + 1; i++) {
                if (i >= soundTypeParts.Length) break;
                pointHitsounds[i].SoundType = (HitObjectSoundType)int.Parse(soundTypeParts[i]);
            }
            s.PointHitsounds = pointHitsounds;
            //point samplesets
            if (parts.Length < 10) return s;
            var sampleParts = parts[9].Split('|');
            for (var i = 0; i < pointcount + 1; i++) {
                if (i >= sampleParts.Length) break;
                var sampleSplit = sampleParts[i].Split(':');
                pointHitsounds[i].SampleSet = (SampleSet)int.Parse(sampleSplit[0]);
                pointHitsounds[i].AdditionSampleSet = (SampleSet)int.Parse(sampleSplit[1]);
            }
            //slider samplesets
            if (parts.Length > 10)
                GetAdditions(parts[10], s);
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

        public override string ToString() => HitobjectToString;

        protected string HitobjectToString => $"{StartPosition.ToHitObjectString()},{StartTime},{(int)Type | (IsNewCombo ? ((NewCombo - 1) << 4) + 4 : 0)},{(int)SoundType}";

        public bool Equals(HitObject other) => CompareTo(other) == 0;

        private static void GetAdditions(string part, HitObject ho) {
            if (string.IsNullOrEmpty(part)) return;
            var parts = part.Split(':'.AsArray(), StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) return;
            ho.SampleSet = (SampleSet)int.Parse(parts[0]);
            ho.AdditionSampleSet = (SampleSet)int.Parse(parts[1]);
            if (parts.Length < 3) return;
            ho.Custom = (Custom)int.Parse(parts[2]);
            if (parts.Length < 4) return;
            ho.Volume = int.Parse(parts[3]);
            if (parts.Length < 5) return;
            ho.AdditionSound = parts[4];
        }

        #endregion
    }
}