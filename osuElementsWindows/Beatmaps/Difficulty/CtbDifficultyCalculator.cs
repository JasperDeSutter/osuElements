using System.Linq;
using osuElements.Api;
using static System.Math;

namespace osuElements.Beatmaps.Difficulty
{
    public class CtbDifficultyCalculator : DifficultyCalculatorBase
    {
        public CtbDifficultyCalculator(BeatmapManager manager) : base(manager) { }
        public override GameMode GameMode => GameMode.CatchTheBeat;
        protected override Mods DifficultyChangers => Mods.Easy | Mods.HardRock | Mods.DoubleTime | Mods.HalfTime;
        public override double StarDifficulty { get; set; }
        public override void Calculate(Mods mods) {
            base.Calculate(mods);
            throw new System.NotImplementedException("Catch the beat difficulty calculation is not yet supported");
        }

        public double AimDifficulty { get; set; }
        public override double PerformancePoints(ApiScore score) {
            return PerformancePoints(Manager.Mods, AimDifficulty, score.MaxCombo, Manager.PreEmpt, score.Count300, score.Count100, score.Count50, score.CountKatu, score.CountMiss);
        }

        public static double PerformancePoints(Mods mods, double aimdifficulty, int maxcombo, double preempt, int count300, int count100
            , int count50, int countKatu, int countMiss) {
            if ((mods & (Mods.Relax | Mods.Relax2 | Mods.Autoplay)) > 0) return 0;

            var combo = count300 + count100 + countMiss;
            var total = combo + count50 + countKatu;
            var succesful = count50 + count100 + count300;
            var acc = 1.0 * succesful / total;

            var value = Pow(5d * Max(1d, aimdifficulty / 0.0049) - 4d, 2d) * 0.00001;
            var lengthbonus = 0.95 + 0.4 * Min(1, total / 3000d) + (total > 3000 ? Log10(total / 3000d) / 2d : 0d);
            value *= lengthbonus;
            value *= Pow(0.97, countMiss);
            if (maxcombo > 0) {
                var pow = Pow(maxcombo, 0.8);
                value *= Min(pow / pow, 1d);
            }

            var ar = preempt / mods.SpeedMultiplier();
            if (ar > 1200) ar = -(ar - 1800d) / 120d;
            else ar = -(ar - 1200) / 150 + 5;
            var arfactor = 1d;
            if (ar > 9d)
                arfactor += 0.1 * (ar - 9d);
            else if (ar < 8d)
                arfactor += 0.025 * (8d - ar);
            value *= arfactor;

            if (mods.HasFlag(Mods.Hidden))
                value *= 1.05 + 0.075 * (10d - Min(10d, ar));
            if (mods.HasFlag(Mods.Flashlight))
                value *= 1.35 * lengthbonus;
            value *= Pow(acc, 5.5);
            if (mods.HasFlag(Mods.NoFail))
                value *= 0.9;
            if (mods.HasFlag(Mods.SpunOut))
                value *= 0.95;

            return value;
        }

    }
}