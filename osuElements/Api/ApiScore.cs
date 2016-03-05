using System;
using osuElements.Helpers;

namespace osuElements.Api
{
    public class ApiScore
    {
        public int Beatmap_Id { get; set; }
        public long Score { get; set; }
        public int MaxCombo { get; set; }
        public int Count300 { get; set; }
        public int Count100 { get; set; }
        public int Count50 { get; set; }
        public int CountMiss { get; set; }
        public int CountKatu { get; set; }
        public int CountGeki { get; set; }

        public int Perfect
        {
            get { return IsPerfect ? 0 : 1; }
            set { IsPerfect = value != 0; }
        }
        public bool IsPerfect;
        public int User_Id { get; set; }
        public string Rank { get; set; }

        //Beatmap scores
        public string UserName { get; set; }
        public Mods Enabled_Mods { get; set; }
        public DateTime Date { get; set; }
        public float Pp { get; set; }

        //Multiplayer scores
        public int Slot { get; set; }
        public int Team { get; set; }
        public bool Pass { get; set; }

        //replay
        public GameMode GameMode { get; set; }

        public double CalculateAccuracy() {
            var total = Count300 + Count100 + Count50 + CountMiss + CountGeki + CountKatu;
            return (Count300*300 + Count100*100 + Count50*50.0)/total;
        }

        public void CloneTo(ApiScore result) {
            result.Beatmap_Id = Beatmap_Id;
            result.Score = Score;
            result.MaxCombo = MaxCombo;
            result.Count300 = Count300;
            result.Count100 = Count100;
            result.Count50 = Count50;
            result.CountGeki = CountGeki;
            result.CountKatu = CountKatu;
            result.CountMiss = CountMiss;
            result.Perfect = Perfect;
            result.User_Id = User_Id;
            result.Rank = Rank;
            result.UserName = UserName;
            result.Enabled_Mods = Enabled_Mods;
            result.Date = Date;
            result.Pp = Pp;
            result.Slot = Slot;
            result.Team = Team;
            result.Pass = Pass;
            result.GameMode = GameMode;
        }
    }
}