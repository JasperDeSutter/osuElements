using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace osuElements.Events
{
    public enum EventTypes //print as string in osb, as int in osu
    {
        Background = 0,
        Video = 1,
        Break = 2,
        Backgroundcolor = 3,
        Sprite = 4,
        Sample = 5,
        Animation = 6,
    }
    public enum EventLayer//print as string
    {
        Background = 0,
        Fail = 1,
        Pass = 2,
        Foreground = 3,
    }
    public enum Origin//print as string
    {
        TopLeft = 0,
        TopCentre = 1,
        TopRight = 2,
        CentreLeft = 10,
        Centre = 11,
        CentreRight = 12,
        BottomLeft = 20,
        BottomCentre = 21,
        BottomRight = 22,
    }
    public enum Easing //print as int
    {
        None = 0,
        In = 1,
        Out = 2,
    }
    public enum Looptypes//print as string
    {
        LoopForever,
        LoopOnce,
    }
    public enum TransformTypes
    {
        F, //fade
        M, //move
        MX, //move x
        MY, //move y
        S, //scale
        V, //vector scale
        R, //rotate
        C, //color
        P, //parameter
        //last ones are special because they ignore all previous while active
        L, //loop
        T, //trigger
    }
    public enum ParamTypes
    {
        A, //Additive color blending
        H, //Horizontal flip
        V, //Vertical flip
    }
    public enum TriggerTypes
    {
        HitSoundClap,
        HitSoundFinish,
        HitSoundWhistle,
        Passing,
        Failing,
    }
}
