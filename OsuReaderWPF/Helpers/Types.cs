using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuReaderWPF.Helpers
{
    public enum SliderTypes
    {
        Catmull,
        Bezier,
        Linear,
        PerfectCurve,
    }
    [Flags]
    public enum HitsoundTypes  //Sounds are additive, so for multiple sounds just add the values (whistle + clap would be 10)
    {
        Normal = 0,
        Whistle = 2,
        Finish = 4,
        Clap = 8
    }
    [Flags]
    public enum HOTypes  //Newcombo is additive (hitcircle newcombo = 5)
    {
        None =0,
        HitCircle = 1,
        Slider = 2,
        NewCombo = 4,
        Spinner = 8
    }
    public enum SampleSets
    {
        All = -1,
        None = 0,
        Normal = 1,
        Soft = 2,
        Drum = 3,
    }
    public enum Custom
    {
        Default,
        Custom1,
        Custom2,
    }
    [Flags]
    public enum TimingPointOptions
    {
        None = 0,
        KiaiTime = 1,
        OmitFirstBarLine = 8
    }
}
