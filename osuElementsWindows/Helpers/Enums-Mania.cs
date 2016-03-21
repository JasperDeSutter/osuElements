using System;

namespace osuElements.Helpers
{
    [Flags]
    public enum ManiaKeys
    {
        None,
        K1 = 1,
        K2 = 2,
        K3 = 4,
        K4 = 8,
        K5 = 16,
        K6 = 32,
        K7 = 64,
        K8 = 128,
        K9 = 256,
    }
    public enum ManiaSpecialStyle
    {
        /// <summary>
        /// No Special key
        /// </summary>
        None,
        /// <summary>
        /// Special key on left side
        /// </summary>
        Left,
        /// <summary>
        /// Special key on right side
        /// </summary>
        Right
    }

    public enum NoteBodyStyle
    {
        Stretch,
        RepeatTop,
        RepeatBottom,
        RepeatTopAndBottom,
    }

    public enum NoteType
    {
        Normal,
        H, //H
        L, //L
        T //T
    }

}