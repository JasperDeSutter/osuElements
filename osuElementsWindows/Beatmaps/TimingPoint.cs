using System;
using osuElements.Helpers;

namespace osuElements.Beatmaps
{
    public class TimingPoint : IEquatable<TimingPoint>, IComparable<TimingPoint>, IHitsound
    {
        public double Offset { get; set; }

        public double Value { get; set; }
        /// <summary>
        /// The length in ms of one whole beat
        /// Timing-only
        /// </summary>
        public double BeatLength => IsTiming ? Value : -1;
        /// <summary>
        /// The amount of beats that occur within one minute
        /// Timing-only
        /// </summary>
        public double Bpm
        {
            get { return 60000 / BeatLength; }
            set { Value = 60000 / value; }
        }
        /// <summary>
        /// The multiplier for slider speed
        /// To be multiplied with the Beatmap multiplier
        /// </summary>
        public double SliderVelocityMultiplier //the value you see in editor
        {
            get { return -100 / Value; }
            set { Value = value / -100; }
        }
        /// <summary>
        /// The amount of beats in a bar.
        /// Values between 4 and 7
        /// </summary>
        public TimeSignature TimeSignature { get; set; }
        public SampleSet SampleSet { get; set; }
        public Custom Custom { get; set; }
        /// <summary>
        /// Get-only, for IHitsound purposes
        /// </summary>
        public SampleSet AdditionSampleSet
        {
            get { return SampleSet.None; }
            set { throw new InvalidOperationException("A TimingPoint's AdditionSampleSet can't be set."); }
        }
        /// <summary>
        /// Get-only, for IHitsound purposes
        /// </summary>
        public HitObjectSoundType SoundType
        {
            get { return HitObjectSoundType.Normal; }
            set { throw new InvalidOperationException("A TimingPoint's SoundType can't be set"); }
        }
        public int Volume { get; set; }
        /// <summary>
        /// If true, Timingpoint is used for Timing (BPM)
        /// If false, Timingpoint is used for sliderspeed
        /// </summary>
        public bool IsTiming { get; set; }
        public TimingPointOptions Options { get; set; }
        /// <summary>
        /// Creates a BPM-TimingPoint
        /// </summary>
        /// <param name="offset">the starttime of this timing</param>
        public TimingPoint(double offset, double bpm)
            : this(offset, bpm, TimeSignature.CommonTime, SampleSet.None, 0, 0, true, TimingPointOptions.None) { }


        public TimingPoint(double offset, double value, TimeSignature signature, SampleSet sampleSet, Custom custom, int volume,
            bool isTiming, TimingPointOptions options) {
            Offset = offset;
            Value = value;
            TimeSignature = signature;
            SampleSet = sampleSet;
            Custom = custom;
            Volume = volume;
            IsTiming = isTiming;
            Options = options;
        }

        public TimingPoint() { }

        public override string ToString() {
            return
                $"{(int)Offset},{Value.ToString(Constants.CULTUREINFO)},{(int)TimeSignature},{(int)SampleSet}" +
                $",{(int)Custom},{Volume},{(IsTiming ? 1 : 0)},{(int)Options}";
        }

        public bool Equals(TimingPoint other) {
            return CompareTo(other) == 0;
        }

        /// <summary>
        /// Compares by offset, and then by timing
        /// </summary>
        public int CompareTo(TimingPoint other) {
            return Offset == other.Offset ?
                other.IsTiming.CompareTo(IsTiming) :
                Offset.CompareTo(other.Offset);
        }

        public static TimingPoint Parse(string line) {
            TimingPoint result;
            var parts = line.Split(','.AsArray(), StringSplitOptions.RemoveEmptyEntries);
            var offset = int.Parse(parts[0], Constants.CULTUREINFO);
            var bpm = double.Parse(parts[1], Constants.CULTUREINFO);
            if (parts.Length > 2) {
                var signature = (TimeSignature)int.Parse(parts[2]);
                var sampleSet = (SampleSet)int.Parse(parts[3]);
                var customSet = (Custom)int.Parse(parts[4]);
                var volume = parts.Length > 5 ? int.Parse(parts[5]) : 100;
                var isTiming = parts.Length < 7 || Convert.ToBoolean(int.Parse(parts[6]));
                var option = parts.Length > 7 ? (TimingPointOptions)int.Parse(parts[7]) : TimingPointOptions.None;

                result = new TimingPoint(offset, bpm, signature, sampleSet, customSet, volume, isTiming, option);
            }
            else {
                result = new TimingPoint(offset, bpm);
            }
            return result;
        }
    }
}