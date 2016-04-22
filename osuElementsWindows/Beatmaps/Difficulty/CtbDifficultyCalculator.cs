namespace osuElements.Beatmaps.Difficulty
{
    public class CtbDifficultyCalculator : DifficultyCalculatorBase
    {
        public override GameMode GameMode => GameMode.CatchTheBeat;
        public override double StarDifficulty { get; protected set; }
        public override void Calculate(Mods mods) {
            base.Calculate(mods);
            throw new System.NotImplementedException();
        }
    }
}