using osuElements.Api;

namespace osuElements.Beatmaps.Difficulty
{
    public class TaikoDifficultyCalculator : DifficultyCalculatorBase
    {
        public override GameMode GameMode => GameMode.Taiko;
        protected override Mods DifficultyChangers => Mods.Easy | Mods.HardRock | Mods.DoubleTime | Mods.HalfTime;
        public override double StarDifficulty { get; set; }
        public override void Calculate(Mods mods) {
            base.Calculate(mods);
            throw new System.NotImplementedException();
        }

        public override double PerformancePoints(ApiScore score) {
            throw new System.NotImplementedException();
        }
    }
}