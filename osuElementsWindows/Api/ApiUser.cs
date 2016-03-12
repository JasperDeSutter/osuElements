using System;
using System.Collections.Generic;
using osuElements.Helpers;

namespace osuElements.Api
{
    public class ApiUser
    {
        public GameMode GameMode { get; set; }
        public int User_Id { get; set; }
        public string UserName { get; set; }
        public int Count300 { get; set; }
        public int Count100 { get; set; }
        public int Count50 { get; set; }
        public int PlayCount { get; set; }
        public long Ranked_Score { get; set; }
        public long Total_Score { get; set; }
        public int Pp_Rank { get; set; }
        public float Level { get; set; }
        public float Pp_Raw { get; set; }
        public float Accuracy { get; set; }
        public int Count_Rank_SS { get; set; }
        public int Count_Rank_S { get; set; }
        public int Count_Rank_A { get; set; }
        public string Country { get; set; }
        public int pp_Country_Rank { get; set; }
        public List<ApiEvent> Events { get; set; }
    }
    public class ApiEvent
    {
        public string Display_Html { get; set; }
        public int Beatmap_Id { get; set; }
        public int BeatmapSet_Id { get; set; }
        public DateTime Date { get; set; }
        public int Epicfactor { get; set; }
    }
}