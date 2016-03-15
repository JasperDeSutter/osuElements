using System;
using System.Collections.Generic;
using osuElements.Helpers;

namespace osuElements.Api
{
    public class ApiMatchResult
    {
        /// <summary>
        /// The Multimatch-wide properties
        /// </summary>
        public ApiMulti Match { get; set; }
        /// <summary>
        /// A list of all played games
        /// </summary>
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
        /// <summary>
        /// The played beatmap's ID
        /// </summary>
        public int Beatmap_Id { get; set; }
        /// <summary>
        /// The played Game Mode
        /// </summary>
        public GameMode Play_Mode { get; set; }
        /// <summary>
        /// Unknown property
        /// </summary>
        public int Match_Type { get; set; } //?
        /// <summary>
        /// Win conditions of the game
        /// </summary>
        public MatchScoringTypes Scoring_Type { get; set; }
        /// <summary>
        /// The way users are grouped into teams
        /// </summary>
        public MatchTeamTypes Team_Type { get; set; }
        /// <summary>
        /// the room-shared mods of the multi (such as DT or HT)
        /// </summary>
        public Mods Mods { get; set; }
        /// <summary>
        /// a list of scores per user
        /// </summary>
        public List<ApiScore> Scores { get; set; }
    }
}