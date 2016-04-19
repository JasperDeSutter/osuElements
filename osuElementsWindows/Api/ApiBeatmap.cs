using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace osuElements.Api
{
    /// <summary>
    /// the API-driven approach to this beatmap object.
    /// </summary>
    [DataContract]
    [Serializable]
    public class ApiBeatmap
    {
        /// <summary>
        /// The online state of this beatmap
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "approved", Order = 0)]
        public ApiBeatmapState ApprovedState { get; set; }

        /// <summary>
        /// Date on which beatmap got ranked, can be null for unranked
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "approved_date", Order = 1)]
        public DateTime? ApprovedDate { get; set; }

        /// <summary>
        /// The song's artist
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "artist", Order = 3)]
        public string Artist { get; set; }

        /// <summary>
        /// an MD5 Hash of the file
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "file_md5", Order = 20)]
        public string BeatmapHash { get; set; }

        /// <summary>
        /// A unique ID per difficulty of every mapset
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "beatmap_id", Order = 4)]
        public int BeatmapId { get; set; }

        /// <summary>
        /// the ID of grouped difficulties in a set
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "beatmapset_id", Order = 5)]
        public int BeatmapSetId { get; set; }

        /// <summary>
        /// The tempo in Beats Per Minute of the song
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "bpm", Order = 6)]
        public double Bpm { get; set; } //could be a float, not sure

        /// <summary>
        /// Username of this beatmap's creator
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "creator", Order = 7)]
        public string Creator { get; set; }

        /// <summary>
        /// Approach Rate before mod calculations
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "diff_approach", Order = 11)]
        public float DifficultyApproachRate { get; set; }

        /// <summary>
        /// Circle Size before mod calculations
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "diff_size", Order = 9)]
        public float DifficultyCircleSize { get; set; }

        /// <summary>
        /// HP Drain before mod calculations
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "diff_drain", Order = 12)]
        public float DifficultyHpDrainRate { get; set; }

        /// <summary>
        /// Overal Difficulty before mod calculations
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "diff_overall", Order = 10)]
        public float DifficultyOverall { get; set; }

        /// <summary>
        /// The difficulty returned by the API
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "difficultyrating", Order = 8)]
        public double DifficultyRating { get; set; }

        /// <summary>
        /// The amount of favourites this beatmap has received
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "favourite_count", Order = 23)]
        public int FavouriteCount { get; set; }

        /// <summary>
        /// The genre returned by the API
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "genre_id", Order = 15)]
        public Genre Genre { get; set; }

        /// <summary>
        /// seconds from first note to last note not including breaks
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "hit_length", Order = 13)]
        public int HitLength { get; set; }

        /// <summary>
        /// The Language returned by the API
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "language_id", Order = 16)]
        public Language Language { get; set; }

        /// <summary>
        /// Last update the creator uploaded
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "last_update", Order = 2)]
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// The maximum combo a user can reach playing this beatmap
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "max_combo", Order = 26)]
        public int? MaxCombo { get; set; }

        /// <summary>
        /// The Gamemode of this beatmap
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "mode", Order = 21)]
        public GameMode Mode { get; set; }

        /// <summary>
        /// The amount of times this beatmap has been passed (without failing or retrying)
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "passcount", Order = 25)]
        public int PassCount { get; set; }

        /// <summary>
        /// The amount of times this beatmap has been played
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "playcount", Order = 24)]
        public int PlayCount { get; set; }

        /// <summary>
        /// Describes the origin of the song
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "source", Order = 14)]
        public string Source { get; set; }

        /// <summary>
        /// A collection of words describing the song. Tags are searchable in both the online listings and in the song selection menu.
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "tags", Order = 22)]
        public string Tags { get; set; }

        /// <summary>
        /// The title of the song
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "title", Order = 17)]
        public string Title { get; set; }

        /// <summary>
        /// seconds from first note to last note including breaks
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "total_length", Order = 18)]
        public int TotalLength { get; set; }

        /// <summary>
        /// the name of this beatmap's difficulty.
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "version", Order = 19)]
        public string Version { get; set; }

        /// <summary>
        /// Returns an identifier for the difficulty based on DifficltyRating
        /// </summary>
        public BeatmapDifficulty BeatmapDifficulty
        {
            get
            {
                if (DifficultyRating > 5.25) return BeatmapDifficulty.Expert;
                if (DifficultyRating > 3.75) return BeatmapDifficulty.Insane;
                if (DifficultyRating > 2.25) return BeatmapDifficulty.Hard;
                return DifficultyRating < 1.5 ? BeatmapDifficulty.Easy : BeatmapDifficulty.Normal;
            }
        }
        /// <summary>
        /// Copies properties from this to another ApiBeatmap instance
        /// </summary>
        /// <param name="result">the destination of the copy</param>
        /// <param name="includeBasic">Common shared properties across ApiBeatmap, Beatmap and DbBeatmap</param>
        public void CopyTo(ApiBeatmap result, bool includeBasic = true) {
            result.ApprovedState = ApprovedState;
            result.ApprovedDate = ApprovedDate;
            result.Bpm = Bpm;
            result.DifficultyRating = DifficultyRating;
            result.FavouriteCount = FavouriteCount;
            result.Genre = Genre;
            result.HitLength = HitLength;
            result.Language = Language;
            result.LastUpdate = LastUpdate;
            result.MaxCombo = MaxCombo;
            result.PassCount = PassCount;
            result.PlayCount = PlayCount;
            result.TotalLength = TotalLength;
            if (!includeBasic) return;
            result.Artist = Artist;
            result.BeatmapId = BeatmapId;
            result.BeatmapSetId = BeatmapSetId;
            result.Creator = Creator;
            result.DifficultyApproachRate = DifficultyApproachRate;
            result.DifficultyHpDrainRate = DifficultyHpDrainRate;
            result.DifficultyOverall = DifficultyOverall;
            result.DifficultyCircleSize = DifficultyCircleSize;
            result.BeatmapHash = BeatmapHash;
            result.Mode = Mode;
            result.Source = Source;
            result.Tags = Tags;
            result.Title = Title;
            result.Version = Version;
        }
    }
}