using System;

namespace osuElements.Helpers
{
    public enum ScoreRank
    {
        D,
        C,
        B,
        A,
        S,
        SH,
        X,
        XH,
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
        None = 0,
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
    [Flags]
    public enum FileParameterOptions
    {
        None = 0,
        StartsWith = 1, //Uses string.startswith(name) instead of equals
        Multiple = 2, //Means that there can be multiple lines with this parameter
        DontSplit = 4, //TODO NYI

    }

}
