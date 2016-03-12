using System;
using osuElements.Helpers;

namespace osuElements.Beatmaps
{
    public class TimingPoint : IEquatable<TimingPoint>, IComparable<TimingPoint>
    {
        public double Offset { get; set; }

        public double Value { get; set; }

        public double MillisecondsPerBeat => IsTiming ? Value : -1;

        public double Bpm   //BPM value in editor
        {
            get { return 60000 / MillisecondsPerBeat; }
            set { Value = 60000 / value; }
        }

        public double SliderSpeed => IsTiming ? 0 : Value;

        public double SliderVelocityMultiplier //the value you see in editor
        {
            get { return -100 / SliderSpeed; }
            set { Value = value / -100; }
        }

        public int TimeSignature { get; set; }//values Between 4 and 7
        public SampleSet SampleSet { get; set; }
        public int CustomSampleSet { get; set; } // 0 is not custom
        public int VolumePercentage { get; set; } // 0 -> 100
        public bool IsTiming { get; set; } //TimingPoint Type
        public TimingPointOption Option { get; set; }

        public TimingPoint() {

        }

        public TimingPoint(double offset, double bpm) : this(offset, bpm, 4, SampleSet.None, 0, 0, true, TimingPointOption.None) { }
        public TimingPoint(double offset, double bpm, int signature, SampleSet sampleSet, int customSet, int volume, bool isTiming, TimingPointOption option) {
            Offset = offset;
            Value = bpm;
            TimeSignature = signature;
            SampleSet = sampleSet;
            CustomSampleSet = customSet;
            VolumePercentage = volume;
            IsTiming = isTiming;
            Option = option;
        }
        public override string ToString() {
            return Offset + "," + (IsTiming ? MillisecondsPerBeat : SliderSpeed) + "," + TimeSignature + "," + (int)SampleSet + "," + CustomSampleSet + "," + VolumePercentage + "," + Convert.ToInt32(IsTiming) + "," + (int)Option;
        }
        public bool Equals(TimingPoint other) {
            return CompareTo(other) == 0;
        }
        public int CompareTo(TimingPoint other) {
            return Offset.CompareTo(other.Offset);
        }
        public static TimingPoint Parse(string line) {
            TimingPoint result;
            var parts = line.Split(','.AsArray(), StringSplitOptions.RemoveEmptyEntries);
            var offset = double.Parse(parts[0], Constants.CULTUREINFO);
            var bpm = double.Parse(parts[1], Constants.CULTUREINFO);
            if (parts.Length > 2) {
                var signature = Convert.ToInt32(parts[2]);
                var sampleSet = (SampleSet)Convert.ToInt32(parts[3]);
                var customSet = Convert.ToInt32(parts[4]);
                var volume = parts.Length > 6 ? Convert.ToInt32(parts[5]) : 100;
                var isTiming = parts.Length <= 6 || Convert.ToBoolean(Convert.ToInt32(parts[6]));
                var option = parts.Length > 7 ? (TimingPointOption)Convert.ToInt32(parts[7]) : TimingPointOption.None;

                result = new TimingPoint(offset, bpm, signature, sampleSet, customSet, volume, isTiming, option);
            }
            else {
                result = new TimingPoint(offset, bpm);
            }
            return result;
        }
    }
}
