using System;

namespace osuElements.Helpers
{
    //Types
    public enum SliderType
    {
        Catmull,
        Bezier,
        Linear,
        PerfectCurve,
    }
    public enum SliderStyle
    {
        Opaque = 1,
        Transparent = 2,
        Toonsliders = 3,
        LegacyOpenGl = 4
    }
    [Flags]
    public enum HitObjectType  //Newcombo is additive (hitcircle newcombo = 5)
    {
        None = 0,
        HitCircle = 1,
        Slider = 2,
        NewCombo = 4,
        Spinner = 8,
        CustomCombo = 112,
        HoldCircle = 128,
        ManiaLong=HoldCircle
    }

    //Hitsounds
    [Flags]
    public enum HitObjectSoundType  //Sounds are additive, so for multiple sounds just add the values (whistle + clap would be 10)
    {
        Normal = 0,
        Whistle = 2,
        Finish = 4,
        Clap = 8
    }
    public enum SampleSet
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
}
