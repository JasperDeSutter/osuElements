using System;

namespace osuElements.Beatmaps
{
    public enum OverlayPosition
    {
        NoChange,
        Below,
        Above,
    }
    /// <summary>
    /// Whether countown gets displayed and the speed of it
    /// </summary>
    public enum CountDown
    {
        None,
        Normal,
        Half,
        Double
    }

    [Flags]
    public enum TimingPointOptions
    {
        None = 0,
        KiaiTime = 1,
        OmitFirstBarLine = 8
    }
    public enum TimeSignature
    {
        /// <summary>
        /// 3/4, tripple
        /// </summary>
        Waltz = 3,
        /// <summary>
        /// 4/4, quadruple
        /// </summary>
        CommonTime = 4,
        /// <summary>
        /// 5/4
        /// </summary>
        Quintuple = 5,
        /// <summary>
        /// 6/4
        /// </summary>
        Sextuple = 6,
        /// <summary>
        /// 7/4
        /// </summary>
        Septuple = 7

    }
    public enum SliderType
    {
        /// <summary>
        /// Use n-point Catmull-rom interpolation for the curve
        /// </summary>
        Catmull,
        /// <summary>
        /// Use n-point bezier interpolation for the curve segments
        /// Can also contain Linear segments
        /// </summary>
        Bezier,
        /// <summary>
        /// Use linear interpolation between two points
        /// </summary>
        Linear,
        /// <summary>
        /// Interpolates the curve on the circumference of a circle defined by 3 points
        /// </summary>
        PerfectCurve,
    }
    [Flags]
    public enum HitObjectType  //Newcombo is additive (hitcircle and newcombo = 5)
    {
        None = 0,
        HitCircle = 1,
        Slider = 2,
        NewCombo = 4,
        Spinner = 8,
        CustomCombo = 112,
        HoldCircle = 128,
        ManiaLong = HoldCircle
    }
}
