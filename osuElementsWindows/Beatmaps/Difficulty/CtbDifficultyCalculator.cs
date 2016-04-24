using osuElements.Api;

namespace osuElements.Beatmaps.Difficulty
{
    public class CtbDifficultyCalculator : DifficultyCalculatorBase
    {
        public override GameMode GameMode => GameMode.CatchTheBeat;
        protected override Mods DifficultyChangers => Mods.Easy | Mods.HardRock | Mods.DoubleTime | Mods.HalfTime;
        public override double StarDifficulty { get; set; }
        public override void Calculate(Mods mods) {
            base.Calculate(mods);
            throw new System.NotImplementedException();
        }

        public override double PerformancePoints(ApiScore score) {
            return PerformancePoints(Mods.None, 0, 0, 0, score.Count300, score.Count100, score.Count50, score.CountKatu, score.CountMiss);
        }

        public static double PerformancePoints(Mods mods, double aimdifficulty, int maxcombo, double preempt, int count300, int count100
            , int count50, int countKatu, int count) {
            return 0;
        }
    }
}