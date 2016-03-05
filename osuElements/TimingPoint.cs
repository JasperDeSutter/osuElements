using System;
using osuElements.Helpers;

namespace osuElements
{
    public class TimingPoint:IEquatable<TimingPoint>,IComparable<TimingPoint>
    {
        public Timing Offset { get; set; }
        
        private double _bpmvalue;

        public double MillisecondsPerBeat { get { return IsTiming ? _bpmvalue : -1; } set { if (IsTiming)_bpmvalue = value; } }
        public double Bpm   //BPM value in editor
        {
            get { return 60000/MillisecondsPerBeat; }
            set { MillisecondsPerBeat = 60000/value; }
        }

        public double SliderSpeed { get { return IsTiming ? 0 : _bpmvalue; } set { if (!IsTiming)_bpmvalue = value; } }
        public double SliderVelocityMultiplier //the value you see in editor
        {
            get { return -100/SliderSpeed; }
            set { SliderSpeed = value/-100; }
        }

        public int TimeSignature { get; set; }//values between 4 and 7
        public SampleSet SampleSet { get; set; }
        public int CustomSampleSet { get; set; } // 0 is not custom
        public int VolumePercentage { get; set; } // 0 -> 100
        public bool IsTiming { get; set; } //TimingPoint Type
        public TimingPointOption Option { get; set; }
        
        public TimingPoint(Timing offset, double bpm):this(offset,bpm,4,SampleSet.None,0,0,true,TimingPointOption.None){}
        public TimingPoint(Timing offset, double bpm, int signature, SampleSet sampleSet, int customSet, int volume, bool isTiming, TimingPointOption option)
        {
            Offset = offset;
            _bpmvalue = bpm;
            TimeSignature = signature;
            SampleSet = sampleSet;
            CustomSampleSet = customSet;
            VolumePercentage = volume;
            IsTiming = isTiming;
            Option = option;
        }
        public override string ToString()
        {
            return Offset.TimeMs + "," + (IsTiming? MillisecondsPerBeat : SliderSpeed) + "," + TimeSignature + "," + (int)SampleSet + "," + CustomSampleSet + "," + VolumePercentage + "," + Convert.ToInt32(IsTiming) + "," + (int)Option;
        }
        public bool Equals(TimingPoint other)
        {
            return CompareTo(other)==0;
        }
        public int CompareTo(TimingPoint other)
        {
            return Offset.CompareTo(other.Offset);
        }
        public static TimingPoint Parse(string line) {
            TimingPoint result;
            var parts = line.Split(Constants.Splitter.Comma, StringSplitOptions.RemoveEmptyEntries);
            var offset = new Timing(Convert.ToInt32(float.Parse(parts[0], Constants.IO.CULTUREINFO)));
            var bpm = double.Parse(parts[1], Constants.IO.CULTUREINFO);
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
