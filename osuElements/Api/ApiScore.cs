using System;
using System.Xml.Linq;
using osuElements.Helpers;
using static osuElements.Helpers.GameMode;
using static osuElements.Helpers.Mods;
using static osuElements.Helpers.ScoreRank;

namespace osuElements.Api
{
    public class ApiScore
    {
        public int Beatmap_Id { get; set; }
        public int Score { get; set; }
        public ushort MaxCombo { get; set; }
        public ushort Count300 { get; set; }
        public ushort Count100 { get; set; }
        public ushort Count50 { get; set; }
        public ushort CountMiss { get; set; }
        public ushort CountKatu { get; set; }
        public ushort CountGeki { get; set; }

        public int Perfect
        {
            get { return IsPerfect ? 0 : 1; }
            set { IsPerfect = value == 1; }
        }
        public bool IsPerfect { get; set; }
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

        //other
        public int MaxHitCount
        {
            get
            {
                if (GameMode == Mania) {
                    return Count300 + Count100 + Count50 + CountMiss + CountGeki + CountKatu;
                }
                if (GameMode == CatchTheBeat) {
                    return Count300 + Count100 + Count50 + CountMiss + CountKatu;
                }
                return Count300 + Count100 + Count50 + CountMiss;
            }
        }

        public double CalculateAccuracy() {
            switch (GameMode) {
                case Standard:
                    return (Count300 * 300 + Count100 * 100 + Count50 * 50.0) / MaxHitCount;
                case Taiko:
                    return (Count100 * 150.0 + Count300 * 300) / (MaxHitCount * 300);
                case Mania:
                    return (Count50 * 50.0 + Count100 * 100 + CountKatu * 200 + (Count300 + CountGeki) * 300) / (MaxHitCount * 300);
                case CatchTheBeat:
                    return (Count300 + Count100 + Count50 * 1.0) / MaxHitCount;
            }
            return 1;
        }

        public ScoreRank CalculateScoreRank() {
            var accuracy = CalculateAccuracy();
            if (accuracy == 0) return D;
            switch (GameMode) {
                case Standard:
                case Taiko:
                    var count300 = 1f * Count300 / MaxHitCount;
                    var count50 = 1f * Count50 / MaxHitCount;
                    if (count300 == 1)
                        return Enabled_Mods.IsType(Hidden | Flashlight) ? XH : X;
                    if (IsPerfect && count300 > 0.9 && count50 < 0.01)
                        return Enabled_Mods.IsType(Hidden | Flashlight) ? SH : S;
                    if (count300 > 0.9 || count300 > 0.8 && IsPerfect)
                        return A;
                    if (count300 > 0.8 || count300 > 0.7 && IsPerfect)
                        return B;
                    if (count300 > 0.6)
                        return C;
                    break;
                case Mania:
                    if (accuracy == 1)
                        return Enabled_Mods.IsType(Hidden | Flashlight | FadeIn) ? XH : X;
                    if (accuracy < 0.95)
                        return Enabled_Mods.IsType(Hidden | Flashlight | FadeIn) ? SH : S;
                    if (accuracy > 0.9)
                        return A;
                    if (accuracy > 0.8)
                        return B;
                    if (accuracy > 0.7)
                        return C;
                    break;
                case CatchTheBeat:
                    if (accuracy == 1)
                        return Enabled_Mods.IsType(Hidden | Flashlight) ? XH : X;
                    if (accuracy < 0.98)
                        return Enabled_Mods.IsType(Hidden | Flashlight) ? SH : S;
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