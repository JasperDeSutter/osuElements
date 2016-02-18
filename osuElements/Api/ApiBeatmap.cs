using System;
using osuElements.Helpers;

namespace osuElements.Api
{
    public class ApiBeatmap
    {
        public int BeatmapSet_Id { get; set; }
        public int Beatmap_Id { get; set; }
        public BeatmapState Approved { get; set; }
        public int Total_Length { get; set; }
        public int Hit_Length { get; set; }
        public string Version { get; set; }
        public string File_MD5 { get; set; }
        public float Diff_Size { get; set; }
        public float Diff_Overall { get; set; }
        public float Diff_Approach { get; set; }
        public float Diff_Drain { get; set; }
        public GameMode Mode { get; set; }
        public DateTime? Approved_Date { get; set; }
        public DateTime Last_Update { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public float Bpm { get; set; }
        public string Source { get; set; }
        public string Tags { get; set; }
        public int Genre_Id { get; set; }
        public int Language_Id { get; set; }
        public int Favourite_Count { get; set; }
        public int PlayCount { get; set; }
        public int PassCount { get; set; }
        public int? Max_Combo { get; set; }
        public double DifficultyRating { get; set; }
    }
}