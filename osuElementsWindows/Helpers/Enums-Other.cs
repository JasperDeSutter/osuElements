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
    public enum ReplayKeys
    {
        None = 0,
        M1 = 1,
        M2 = 2,
        K1 = 4 ,
        K2 = 8 ,
        Smoke = 16,
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
