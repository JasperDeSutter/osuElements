using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using osuElements.Helpers;
using static osuElements.GameMode;
using static osuElements.Mods;
using static osuElements.Helpers.ScoreRank;

namespace osuElements.Api
{
    /// <summary>
    /// The API-driven approach to a user's score on a beatmap
    /// Not all API-functions return all properties, check at https://github.com/ppy/osu-api/wiki
    /// </summary>
    [DataContract]
    [Serializable]
    public class ApiScore
    {
        /// <summary>
        /// The total score gained by this play
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "score", Order = 4)]
        public int Score { get; set; }

        /// <summary>
        /// The biggest combo of this play
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "maxcombo", Order = 6)]
        public ushort MaxCombo { get; set; }

        /// <summary>
        /// The amount of 50 hits
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "count50", Order = 7)]
        public ushort Count50 { get; set; }

        /// <summary>
        /// The amount of 300 hits
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "count100", Order = 8)]
        public ushort Count100 { get; set; }

        /// <summary>
        /// The amount of misses
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "count300", Order = 9)]
        public ushort Count300 { get; set; }

        /// <summary>
        /// The amount of 100 hits
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "countmiss", Order = 10)]
        public ushort CountMiss { get; set; }

        /// <summary>
        /// The amount of katu hits
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "countkatu", Order = 11)]
        public ushort CountKatu { get; set; }

        /// <summary>
        /// The amount of geki hits
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "countgeki", Order = 12)]
        public ushort CountGeki { get; set; }

        /// <summary>
        /// Whether or not the user missed a note
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "perfect", Order = 13)]
        [JsonConverter(typeof (BoolConverter))]
        public bool Perfect { get; set; }

        /// <summary>
        /// Id of the player who made this play
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "user_id", Order = 15)]
        public int UserId { get; set; }

        /// <summary>
        /// The date and time from when this play was completed
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "date", Order = 16)]
        public DateTime Date { get; set; }

        /// <summary>
        /// The recieved score rank
        /// </summary>
        [JsonConverter(typeof (StringEnumConverter))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "rank", Order = 17)]
        public ScoreRank Rank { get; set; }

        /// <summary>
        /// The beatmap this play was set on
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "beatmap_id", Order = 2)]
        public int BeatmapId { get; set; }

        /// <summary>
        /// The username of the player who set this play.
        /// Only for beatmap topscores
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "username", Order = 5)]
        public string Username { get; set; }

        /// <summary>
        /// A unique Id for this score.
        /// Only for beatmap topscores
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "score_id", Order = 3)]
        public string ScoreId { get; set; }

        /// <summary>
        /// The enabled mods.
        /// This doesn't include individual mods for multigames
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = false, Name = "enabled_mods", Order = 14)]
        public Mods EnabledMods { get; set; }

        /// <summary>
        /// The raw performance points gained by this play.
        /// Only for beatmap and player topscores
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = false, Name = "pp", Order = 18)]
        public float Pp { get; set; }

        #region non-api

        /// <summary>
        /// The gamemode this play was set on
        /// </summary>
        public GameMode GameMode { get; set; }

        public int MaxHitCount {
            get {
                switch (GameMode) {
                    case Mania:
                        return Count300 + Count100 + Count50 + CountMiss + CountGeki + CountKatu;
                    case CatchTheBeat:
                        return Count300 + Count100 + Count50 + CountMiss + CountKatu;
                    default:
                        return Count300 + Count100 + Count50 + CountMiss;
                }
            }
        }

        public double CalculateAccuracy() {
            switch (GameMode) {
                case Standard:
                    return (Count300*300 + Count100*100 + Count50*50.0)/MaxHitCount;
                case Taiko:
                    return (Count100*150.0 + Count300*300)/(MaxHitCount*300);
                case Mania:
                    return (Count50*50.0 + Count100*100 + CountKatu*200 + (Count300 + CountGeki)*300)/(MaxHitCount*300);
                case CatchTheBeat:
                    return (Count300 + Count100 + Count50*1.0)/MaxHitCount;
            }
            return 1;
        }

        public ScoreRank CalculateScoreRank() {
            var accuracy = CalculateAccuracy();
            if (accuracy == 0) return D;
            switch (GameMode) {
                default:
                    var count300 = 1f*Count300/MaxHitCount;
                    var count50 = 1f*Count50/MaxHitCount;
                    if (count300 == 1)
                        return EnabledMods.IsType(Hidden | Flashlight) ? XH : X;
                    if (Perfect && count300 > 0.9 && count50 < 0.01)
                        return EnabledMods.IsType(Hidden | Flashlight) ? SH : S;
                    if (count300 > 0.9 || count300 > 0.8 && Perfect)
                        return A;
                    if (count300 > 0.8 || count300 > 0.7 && Perfect)
                        return B;
                    if (count300 > 0.6)
                        return C;
                    break;
                case Mania:
                    if (accuracy == 1)
                        return EnabledMods.IsType(Hidden | Flashlight | FadeIn) ? XH : X;
                    if (accuracy < 0.95)
                        return EnabledMods.IsType(Hidden | Flashlight | FadeIn) ? SH : S;
                    if (accuracy > 0.9)
                        return A;
                    if (accuracy > 0.8)
                        return B;
                    if (accuracy > 0.7)
                        return C;
                    break;
                case CatchTheBeat:
                    if (accuracy == 1)
                        return EnabledMods.IsType(Hidden | Flashlight) ? XH : X;
                    if (accuracy < 0.98)
                        return EnabledMods.IsType(Hidden | Flashlight) ? SH : S;
                    if (accuracy > 0.94)
                        return A;
                    if (accuracy > 0.9)
                        return B;
                    if (accuracy > 0.85)
                        return C;
                    break;
            }
            return D;
        }

        public void CloneTo(ApiScore result) {
            result.BeatmapId = BeatmapId;
            result.Score = Score;
            result.MaxCombo = MaxCombo;
            result.Count300 = Count300;
            result.Count100 = Count100;
            result.Count50 = Count50;
            result.CountGeki = CountGeki;
            result.CountKatu = CountKatu;
            result.CountMiss = CountMiss;
            result.UserId = UserId;
            result.Rank = Rank;
            result.Username = Username;
            result.EnabledMods = EnabledMods;
            result.Date = Date;
            result.Pp = Pp;
            result.GameMode = GameMode;
        }

        #endregion
    }
}