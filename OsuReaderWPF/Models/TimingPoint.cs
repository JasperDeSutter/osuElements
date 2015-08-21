using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace osuElements
{
    public class TimingPoint:IEquatable<TimingPoint>,IComparable<TimingPoint>
    {
        public Timing Offset { get; set; }
        
        private float bpmvalue;

        public float MillisecondsPerBeat { get { return IsTiming ? bpmvalue : -1; } set { if (IsTiming)bpmvalue = value; } }
        public float BPM   //BPM value in editor
        {
            get { return 60000/MillisecondsPerBeat; }
            set { MillisecondsPerBeat = 60000/value; }
        }

        public float SliderSpeed { get { return IsTiming ? 0 : bpmvalue; } set { if (!IsTiming)bpmvalue = value; } }
        public float SliderVMultiplier //the value you see in editor
        {
            get { return -100f/SliderSpeed; }
            set { SliderSpeed = value/-100f; }
        }

        public int TimeSignature { get; set; }//values between 4 and 7
        public SampleSets SampleSet { get; set; }
        public int CustomSampleSet { get; set; } // 0 is not custom
        public int VolumePercentage { get; set; } // 0 -> 100
        public bool IsTiming { get; set; } //TimingPoint Type
        public TimingPointOptions Options { get; set; }

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

        public TimingPoint(Timing offset, float bpm, int signature, SampleSets sampleSet, int customSet, int volume, bool isTiming, TimingPointOptions options)
        {
            Offset = offset;
            bpmvalue = bpm;
            TimeSignature = signature;
            SampleSet = sampleSet;
            CustomSampleSet = customSet;
            VolumePercentage = volume;
            IsTiming = isTiming;
            Options = options;
        }
        public override string ToString()
        {
            return Offset.TimeMS + "," + (IsTiming? MillisecondsPerBeat : SliderSpeed) + "," + TimeSignature + "," + (int)SampleSet + "," + CustomSampleSet + "," + VolumePercentage + "," + Convert.ToInt32(IsTiming) + "," + (int)Options;
        }
        public bool Equals(TimingPoint other)
        {
            return CompareTo(other)==0;
        }
        public int CompareTo(TimingPoint other)
        {
            return this.Offset.CompareTo(other.Offset);
        }
    }
}
