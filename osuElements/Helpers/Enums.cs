using System;

namespace osuElements.Helpers
{
    [Flags]
    public enum HitObjectSoundType : byte
    {
        Normal = 0,
        Whistle = 2,
        Finish = 4,
        Clap = 8
    }

    public enum SampleSet : byte
    {
        /// <summary>
        /// Inherit from parent(timingpoint)
        /// </summary>
        None = 0,
        Normal = 1,
        Soft = 2,
        Drum = 3,
    }

    /// <summary>
    /// the custom set the sample plays from
    /// use (Custom)int for higher values
    /// </summary>
    public enum Custom : byte
    {
        /// <summary>
        /// Use skin or osu! hitsounds
        /// </summary>
        Default,

        /// <summary>
        /// Use a custom defined hitsound set
        /// </summary>
        Custom1,
        Custom2,
    }
    public enum ScoreRank : byte
    {
        /// <summary>
        /// SS Hidden/Flashlight
        /// </summary>
        XH,
        /// <summary>
        /// S Hidden/Flashlight
        /// </summary>
        SH,
        /// <summary>
        /// SS
        /// </summary>
        X,
        S,
        A,
        B,
        C,
        D,
        /// <summary>
        /// Fail
        /// </summary>
        F,
        /// <summary>
        /// For osu!db scores
        /// </summary>
        NoRank,
    }
}