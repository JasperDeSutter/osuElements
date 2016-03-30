using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace osuElements.Api
{
    /// <summary>
    /// The history of a multiplayer lobby
    /// </summary>
    [Serializable]
    [DataContract]
    public class ApiMatchResult
    {
        /// <summary>
        /// A list of all played games
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "games", Order = 1)]
        public List<ApiMultiGame> Games { get; set; }

        /// <summary>
        /// The multiplayer match-wide properties
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "match", Order = 0)]
        public ApiMulti Match { get; set; }
    }

    /// <summary>
    /// global properties of a multiplayer lobby
    /// </summary>
    [DataContract]
    [Serializable]
    public class ApiMulti
    {
        /// <summary>
        /// The endtime of this match, always null
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "end_time", Order = 3)]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// The unique ID of this match
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "match_id", Order = 0)]
        public int MatchId { get; set; }

        /// <summary>
        /// Current name of this match
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "name", Order = 1)]
        public string Name { get; set; }

        /// <summary>
        /// The starttime of this match
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "start_time", Order = 2)]
        public DateTime StartTime { get; set; }
    }

    /// <summary>
    /// One played game in a multiplayer match
    /// </summary>
    [Serializable] 
    [DataContract]
    public class ApiMultiGame
    {
        /// <summary>
        /// A unique ID for this multigame
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "game_id", Order = 0)]
        public int GameId { get; set; }

        /// <summary>
        /// The starttime of this multigame
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "start_time", Order = 1)]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The endttime of this multigame
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "end_time", Order = 2)]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// The played beatmap's ID
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "beatmap_id", Order = 3)]
        public int BeatmapId { get; set; }

        /// <summary>
        /// The played gamemode
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "play_mode", Order = 4)]
        public GameMode PlayMode { get; set; }

        /// <summary>
        /// Unknown property
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "match_type", Order = 5)]
        public int MatchType { get; set; } //?

        /// <summary>
        /// Win conditions of the game
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "scoring_type", Order = 6)]
        public ScoringType ScoringType { get; set; }

        /// <summary>
        /// The way users are grouped into teams
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "team_type", Order = 7)]
        public TeamType TeamType { get; set; }

        /// <summary>
        /// the room-shared mods of the multi (such as DT, NC or HT)
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "mods", Order = 8)]
        public Mods Mods { get; set; }

        /// <summary>
        /// a list of scores per user
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "scores", Order = 9)]
        public List<ApiMultiScore> Scores { get; set; }
    }

    /// <summary>
    /// A score set by a player in a multiplayer match
    /// </summary>
    [DataContract]
    [Serializable]
    public class ApiMultiScore : ApiScore
    {
        /// <summary>
        /// The slot of the room the player was in
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "slot", Order = 0)]
        public int Slot { get; set; }

        /// <summary>
        /// The team the player was in
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "team", Order = 1)]
        public int Team { get; set; }

        /// <summary>
        /// Whether or not the player passed (didn't fail)
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "pass", Order = 30)]
        public bool Pass { get; set; }
    }
}