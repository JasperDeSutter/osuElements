namespace osuElements.Beatmaps.Difficulty
{
    public class ManiaDifficultyCalculator : DifficultyCalculatorBase
    {
        public override GameMode GameMode => GameMode.Mania;
        public override double StarDifficulty { get; protected set; }
        public override void Calculate(Mods mods) {
            base.Calculate(mods);
            throw new System.NotImplementedException();
        }
    }
}