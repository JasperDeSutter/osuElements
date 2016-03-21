using System;
using osuElements.Helpers;

namespace osuElements.Api
{
    /// <summary>
    /// the API-driven approach to the beatmap object
    /// </summary>
    public class ApiBeatmap
    {
        /// <summary>
        /// the ID of grouped difficulties in a set
        /// </summary>
        public int BeatmapSet_Id { get; set; }
        /// <summary>
        /// A unique ID per difficulty of every mapset
        /// </summary>
        public int Beatmap_Id { get; set; }
        public ApiBeatmapState Approved { get; set; }
        /// <summary>
        /// seconds from first note to last note including breaks
        /// </summary>
        public int Total_Length { get; set; }
        /// <summary>
        /// seconds from first note to last note not including breaks
        /// </summary>
        public int Hit_Length { get; set; }
        /// <summary>
        /// the name of the beatmap's difficulty.
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// an MD5 Hash of the file
        /// </summary>
        public string File_MD5 { get; set; }
        /// <summary>
        /// Circle Size before mod calculations
        /// </summary>
        public float Diff_Size { get; set; }
        /// <summary>
        /// Overal Difficulty before mod calculations
        /// </summary>
        public float Diff_Overall { get; set; }
        /// <summary>
        /// Approach Rate before mod calculations
        /// </summary>
        public float Diff_Approach { get; set; }
        /// <summary>
        /// HP Drain before mod calculations
        /// </summary>
        public float Diff_Drain { get; set; }

        /// <summary>
        /// Date on which beatmap got ranked, can be null for unranked
        /// </summary>
        public DateTime? Approved_Date { get; set; }
        /// <summary>
        /// Last update the creator uploaded
        /// </summary>
        public DateTime Last_Update { get; set; }
        /// <summary>
        /// The tempo in Beats Per Minute of the song
        /// </summary>
        public float Bpm { get; set; }
        public int Genre_Id { get; set; }
        public int Language_Id { get; set; }
        public int Favourite_Count { get; set; }
        public int PlayCount { get; set; }
        public int PassCount { get; set; }
        public int? Max_Combo { get; set; }
        /// <summary>
        /// The difficulty returned by the API
        /// </summary>
        public double DifficultyRating { get; set; }


        public string Artist { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public GameMode Mode { get; set; }
        /// <summary>
        /// describes the origin of the song.
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// a collection of words describing the song. Tags are searchable in both the online listings and in the song selection menu.
        /// </summary>
        public string Tags { get; set; }


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
        /// <param name="includeBasic">shared properties across ApiBeatmap, Beatmap and DbBeatmap</param>
        public void CopyTo(ApiBeatmap result, bool includeBasic = true) {
            result.Approved = Approved;
            result.Approved_Date = Approved_Date;
            result.Bpm = Bpm;
            result.DifficultyRating = DifficultyRating;
            result.Favourite_Count = Favourite_Count;
            result.Genre_Id = Genre_Id;
            result.Hit_Length = Hit_Length;
            result.Language_Id = Language_Id;
            result.Last_Update = Last_Update;
            result.Max_Combo = Max_Combo;
            result.PassCount = PassCount;
            result.PlayCount = PlayCount;
            result.Total_Length = Total_Length;
            if (!includeBasic) return;
            result.Artist = Artist;
            result.Beatmap_Id = Beatmap_Id;
            result.BeatmapSet_Id = BeatmapSet_Id;
            result.Creator = Creator;
            result.Diff_Approach = Diff_Approach;
            result.Diff_Drain = Diff_Drain;
            result.Diff_Overall = Diff_Overall;
            result.Diff_Size = Diff_Size;
            result.File_MD5 = File_MD5;
            result.Mode = Mode;
            result.Source = Source;
            result.Tags = Tags;
            result.Title = Title;
            result.Version = Version;
        }
    }
}