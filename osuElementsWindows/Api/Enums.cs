namespace osuElements.Api
{
    #region ApiBeatmap
    public enum Genre
    {
        Any,
        Unspecified,
        Video_Game,
        Anime,
        Rock,
        Pop,
        Other,
        Novelty,
        //8 is missing
        Hip_Hop=9,
        Electronic=10,
    }
    public enum Language
    {
        Any,
        Other,
        English,
        Japanese,
        Chinese,
        Instrumental,
        Korean,
        French,
        German,
        Swedish,
        Spanish,
        Italian,
    }
    public enum BeatmapDifficulty
    {
        Easy,
        Normal,
        Hard,
        Insane,
        Expert
    }
    public enum ApiBeatmapState
    {
        Graveyard = -2,
        WorkInProgress,
        Pending,
        Ranked,
        Approved,
        Qualified,
    } 
    #endregion

    public enum TeamType
    {
        HeadToHead,
        TagCoOp,
        TeamVs,
        TagTeamVs,
    }
    public enum ScoringType
    {
        Score,
        Accuracy,
        Combo,
        ScoreV2,
    }
}