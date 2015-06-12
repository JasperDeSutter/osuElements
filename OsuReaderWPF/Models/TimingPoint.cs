using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsuReaderWPF.Helpers;
namespace OsuReaderWPF.Models
{
    public class TimingPoint
    {
        public Timing Offset { get; set; }
        public double MsPB { get; set; } //miliseconds per beat

        public double BPM   //BPM value in editor
        {
            get { return 60000/MsPB; }
            set { MsPB = 60000/value; }
        }
        
        public double SliderSpeed { get; set; }

        public double SliderVMultiplier //the value you see in editor
        {
            get { return SliderSpeed/-100.0; }
            set { SliderSpeed = -100.0/value; }
        }
        public int TimeSignature { get; set; }//values between 4 and 7
        public SampleSets SampleSet { get; set; }
        public int CustomSampleSet { get; set; } // 0 is not custom
        public int VolumePercentage { get; set; } // 0 -> 100
        public bool IsTiming { get; set; } //TimingPoint Type
        public TimingPointOptions Options { get; set; }

        public TimingPoint(Timing offset, double bpm, int signature, SampleSets sampleSet, int customSet, int volume, bool isTiming, TimingPointOptions options)
        {
            Offset = offset;
            if (isTiming) MsPB = bpm;
            else SliderSpeed = bpm;
            TimeSignature = signature;
            SampleSet = sampleSet;
            CustomSampleSet = customSet;
            VolumePercentage = volume;
            IsTiming = isTiming;
            Options = options;
        }
        public override string ToString()
        {
            return Offset.TimeMS + "," + (IsTiming? MsPB : SliderSpeed) + "," + TimeSignature + "," + (int)SampleSet + "," + CustomSampleSet + "," + VolumePercentage + "," + Convert.ToInt32(IsTiming) + "," + (int)Options;
        }
    }
}
