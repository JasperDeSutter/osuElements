using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using osuElements;

namespace osuElements.Api
{
    /// <summary>
    /// Gamemode-specific data of a user retrieved by the API
    /// </summary>
    [DataContract]
    [Serializable]
    public class ApiUser
    {
        /// <summary>
        /// The gamemode of this user data
        /// </summary>
        public GameMode GameMode { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "user_id", Order = 0)]
        public int UserId { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "username", Order = 1)]
        public string Username { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "count300", Order = 2)]
        public int Count300 { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "count100", Order = 3)]
        public int Count100 { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "count50", Order = 4)]
        public int Count50 { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "playcount", Order = 5)]
        public int Playcount { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "ranked_score", Order = 6)]
        public long RankedScore { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "total_score", Order = 7)]
        public long TotalScore { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "pp_rank", Order = 8)]
        public int PpRank { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "level", Order = 9)]
        public float Level { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "pp_raw", Order = 10)]
        public float PpRaw { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "accuracy", Order = 12)]
        public float Accuracy { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "count_rank_ss", Order = 13)]
        public int SSCount { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "count_rank_s", Order = 14)]
        public int SCount { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "count_rank_a", Order = 15)]
        public int ACount { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "country", Order = 16)]
        public string Country { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "pp_country_rank", Order = 17)]
        public int PpCountryRank { get; set; }

        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "events", Order = 18)]
        public List<ApiEvent> Events { get; set; }
    }

    /// <summary>
    /// Describes a recent event for a user, such as a new score or beatmap upload
    /// </summary>
    [DataContract]
    [Serializable]
    public class ApiEvent
    {
        /// <summary>
        /// The beatmap for which the event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "beatmap_id", Order = 1)]
        public int BeatmapId { get; set; }

        /// <summary>
        /// The set of the beatmap for this event
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "beatmapset_id", Order = 2)]
        public int BeatmapSetId { get; set; }

        /// <summary>
        /// The date this event took place
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "date", Order = 3)]
        public DateTime Date { get; set; }

        /// <summary>
        /// String containing HTML code to show on website
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "display_html", Order = 0)]
        [JsonConverter(typeof(EventConverter))]
        public ApiEventInformation DisplayHtml { get; set; }

        /// <summary>
        /// Describes the epicness of the event a scale of 1 to 32
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "epicfactor", Order = 4)]
        public int Epicfactor { get; set; }
    }

    public class ApiEventInformation
    {
        public enum Type
        {
            Unknown,
            RankAchieved,
            RankLost,
            MapSetDelete,
            MapSetRevive,
            MapSetUpdate,
            MapSetUpload,
            Achievement,
            UsernameChange,
            SupportedAgain,
            SupportedFirst,
            SupportedGift,
        }

        public string Html { get; set; }
        public GameMode? GameMode { get; set; }
        public int? Rank { get; set; }
        public Type EventType { get; set; }

        public ApiEventInformation(string html)
        {
            Html = html;
            if (html.StartsWith("<b>")) { }
            else if (html.StartsWith("<img"))
            {
                EventType = Type.RankAchieved;
                var i = html.IndexOf("#", StringComparison.InvariantCulture);
                var intstring = Regex.Match(html.Substring(i + 1, 4), @"\d+").Value;
                Rank = int.Parse(intstring);
                var mode = html[html.Length - 2];
                switch (mode)
                {
                    case '!':
                        GameMode = global::osuElements.GameMode.Standard;
                        break;
                    case 'a':
                        GameMode = global::osuElements.GameMode.Mania;
                        break;
                    case 'o':
                        GameMode = global::osuElements.GameMode.Taiko;
                        break;
                    default:
                        GameMode = global::osuElements.GameMode.CatchTheBeat;
                        break;
                }
            }
        }
    }
}