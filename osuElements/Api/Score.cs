using System;
using osuElements.Helpers;

namespace osuElements.Api
{
    public class Score
    {
        public int Beatmap_Id { get; set; }
        public long score { get; set; }
        public string UserName { get; set; }
        public int MaxCombo { get; set; }
        public int Count300 { get; set; }
        public int Count100 { get; set; }
        public int Count50 { get; set; }
        public int CountMiss { get; set; }
        public int CountKatu { get; set; }
        public int CountGeki { get; set; }
        public int Perfect { get; set; }
        public bool IsPerfect => Perfect == 1;
        public Mod Enabled_Mods { get; set; }
        public int User_Id { get; set; }
        public DateTime Date { get; set; }
        public string Rank { get; set; }
        public float pp { get; set; }
    }
}