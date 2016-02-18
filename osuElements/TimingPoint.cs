using System;
using osuElements.Helpers;

namespace osuElements.Other_Models
{
    public class TimingPoint:IEquatable<TimingPoint>,IComparable<TimingPoint>
    {
        public Timing Offset { get; set; }
        
        private float _bpmvalue;

        public float MillisecondsPerBeat { get { return IsTiming ? _bpmvalue : -1; } set { if (IsTiming)_bpmvalue = value; } }
        public float Bpm   //BPM value in editor
        {
            get { return 60000/MillisecondsPerBeat; }
            set { MillisecondsPerBeat = 60000/value; }
        }

        public float SliderSpeed { get { return IsTiming ? 0 : _bpmvalue; } set { if (!IsTiming)_bpmvalue = value; } }
        public float SliderVMultiplier //the value you see in editor
        {
            get { return -100f/SliderSpeed; }
            set { SliderSpeed = value/-100f; }
        }

        public int TimeSignature { get; set; }//values between 4 and 7
        public SampleSet SampleSet { get; set; }
        public int CustomSampleSet { get; set; } // 0 is not custom
        public int VolumePercentage { get; set; } // 0 -> 100
        public bool IsTiming { get; set; } //TimingPoint Type
        public TimingPointOption Option { get; set; }

        /*public TimingPoint(Timing offset,TimingPoint tp)
        {
            Offset = offset;
            bpmvalue = tp.IsTiming? tp.MillisecondsPerBeat :  tp.SliderSpeed;
            Options = tp.Options;
            if (tp.IsTiming)
            {
                TimeSignature = tp.TimeSignature;
            }
            else
            {

            }
        }*/
        public TimingPoint(Timing offset, float bpm):this(offset,bpm,4,SampleSet.None,0,0,true,TimingPointOption.None)
        {

        }
        public TimingPoint(Timing offset, float bpm, int signature, SampleSet sampleSet, int customSet, int volume, bool isTiming, TimingPointOption option)
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
    }
}
