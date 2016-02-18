using System;

namespace osuElements.Helpers
{
    public enum SliderType
    {
        Catmull,
        Bezier,
        Linear,
        PerfectCurve,
    }
    [Flags]
    public enum HitsoundType  //Sounds are additive, so for multiple sounds just add the values (whistle + clap would be 10)
    {
        Normal = 0,
        Whistle = 2,
        Finish = 4,
        Clap = 8
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
    public enum GameMode
    {
        Standard,
        Taiko,
        Ctb,
        Mania,
    }
    [Flags]
    public enum TimingPointOption
    {
        None = 0,
        KiaiTime = 1,
        OmitFirstBarLine = 8
    }
    [Flags]
    public enum Mod 
    {
        None = 0,
        NoFail = 1,
        Easy = 2,
        Hidden = 8,
        HardRock = 16,
        SuddenDeath = 32,
        DoubleTime = 64,
        Relax = 128,
        HalfTime = 256,
        Nightcore = 512,
        Flashlight = 1024,
        Autoplay = 2048,
        SpunOut = 4096,
        Relax2 = 8192,
        Perfect = 16384,
        Key4 = 32768,
        Key5 = 65536,
        Key6 = 131072,
        Key7 = 262144,
        Key8 = 524288,
        FadeIn = 1048576,
        Random = 2097152,
        Cinema = 4194304,
        Target = 8388608,
        Key9 = 16777216,
        KeyCoop = 33554432,
        Key1 = 67108864,
        Key3 = 134217728,
        Key2 = 268435456,
        LastMod = 536870912,
        KeyMod = Key2 | Key3 | Key1 | KeyCoop | Key9 | Key8 | Key7 | Key6 | Key5 | Key4,
       // FreeModAllowed = KeyMod | FadeIn | Relax2 | SpunOut | Flashlight | Relax | SuddenDeath | HardRock | Hidden | Easy | NoFail,
        ScoreIncreaseMods = FadeIn | Flashlight | DoubleTime | HardRock | Hidden,
    }
    public enum OverlayPosition
    {
        NoChange,
        Below,
        Above,
    }
    [Flags]
    public enum ReplayKey
    {
        None =0,
        M1 = 1,
        M2 = 2,
        K1 = 4 | 1,
        K2 = 8 | 2,
    }
    public enum BeatmapState
    {
        Graveyard = -2,
        WorkInProgress,
        Pending,
        Ranked,
        Approved,
        Qualified,
    }
    public enum MatchTeamTypes
    {
        HeadToHead,
        TagCoOp,
        TeamVs,
        TagTeamVs,
    }
    public enum MatchScoringTypes
    {
        Score,
        Accuracy,
        Combo,
        ScoreV2,
    }

}
