using System;
using System.Collections.Generic;
using osuElements.Helpers;

namespace osuElements.Api
{
    public class ApiMatchResult
    {
        public ApiMulti Match { get; set; }
        public List<ApiMultiGame> Games { get; set; }
    }
    public class ApiMulti
    {
        public int Match_Id { get; set; }
        public string Name { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
    }

    public class ApiMultiGame
    {
        public int Game_Id { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public int Beatmap_Id { get; set; }
        public GameMode Play_Mode { get; set; }
        public int Match_Type { get; set; } //?
        public MatchScoringTypes Scoring_Type { get; set; }
        public MatchTeamTypes Team_Type { get; set; }
        public Mods Mods { get; set; }
        public List<ApiScore> Scores { get; set; }
    }
}