using System.Security.Cryptography;
using osuElements.Api;
using static System.Math;

namespace osuElements.Beatmaps.Difficulty
{
    public class ManiaDifficultyCalculator : DifficultyCalculatorBase
    {
        public ManiaDifficultyCalculator(BeatmapManager manager) : base(manager) { }
        public override GameMode GameMode => GameMode.Mania;
        protected override Mods DifficultyChangers => Mods.Easy | Mods.HardRock | Mods.DoubleTime | Mods.HalfTime | Mods.KeyMod;
        public override double StarDifficulty { get; set; }
        public double Strain { get; set; }
        public override void Calculate(Mods mods) {
            base.Calculate(mods);
            throw new System.NotImplementedException("Mania difficulty calculation is not yet supported");
        }

        public override double PerformancePoints(ApiScore score) {
            return PerformancePoints(Manager.Mods, Strain, Manager.HitWindow300, score.Count300, score.Count100,
                score.Count50, score.CountKatu, score.CountGeki, score.CountMiss, score.Score);
        }

        public static double PerformancePoints(Mods mods, double strain, double hit300, int count300, int count100,
            int count50, int countKatu, int countGeki, int countMiss, int score) {
            if ((mods & (Mods.Relax | Mods.Relax2 | Mods.Autoplay)) > 0) return 0;

            var succesful = count300 + count100 + count50 + countKatu + countGeki;
            double total = succesful + countMiss;
            var acc = (count50 + count100 * 2 + countKatu * 4 + (count300 + countGeki) * 6) / (total * 6.0);

            var multiplier = 1d;
            if ((mods & Mods.NoFail) > 0)
                multiplier *= 0.90;
            if ((mods & Mods.SpunOut) > 0)
                multiplier *= 0.95;
            if ((mods & Mods.Easy) > 0)
                multiplier *= 0.50;

            var scoremultiplier = ScoreMultiplier(mods, GameMode.Mania);
            score = (int)(score / scoremultiplier);

            var strainvalue = Pow(5d * Max(1d, strain / 0.0825) - 4d, 3d) / 110000.0;
            strainvalue *= 1d + 0.1 * Min(1d, total / 1500d);

            if (score <= 500000)
                strainvalue *= score / 500000.0 * 0.1f;
            else if (score <= 600000)
                strainvalue *= 0.1 + (score - 500000) / 100000.0 * 0.2;
            else if (score <= 700000)
                strainvalue *= 0.3 + (score - 600000) / 100000.0 * 0.35;
            else if (score <= 800000)
                strainvalue *= 0.65 + (score - 700000) / 100000.0f * 0.20;
            else if (score <= 900000)
                strainvalue *= 0.85 + (score - 800000) / 100000.0f * 0.1;
            else
                strainvalue *= 0.95 + (score - 900000) / 100000.0 * 0.05;

            var accvalue = Pow(150d / hit300 * Pow(acc, 16d), 1.8) * 2.5;
            accvalue *= Min(1.15, Pow(total / 1500d, 0.3));

            return Pow(Pow(strainvalue, 1.1) + Pow(accvalue, 1.1), 1d / 1.1) * multiplier;
        }

    }
}