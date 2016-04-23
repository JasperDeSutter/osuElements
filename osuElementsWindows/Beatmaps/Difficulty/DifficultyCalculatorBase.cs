namespace osuElements.Beatmaps.Difficulty
{
    public abstract class DifficultyCalculatorBase
    {
        public abstract GameMode GameMode { get; }
        public abstract double StarDifficulty { get; set; }
        public virtual void Calculate(Mods mods) {
            ModSpeed = mods.SpeedMultiplier();
        }
        protected double ModSpeed;

        public static DifficultyCalculatorBase GetForMode(GameMode mode, BeatmapManager manager) {
            switch (mode) {
                case GameMode.Standard:
                    return new StandardDifficultyCalculator(manager);
                case GameMode.Mania:
                    return new ManiaDifficultyCalculator();
                case GameMode.CatchTheBeat:
                    return new CtbDifficultyCalculator();
                case GameMode.Taiko:
                    return new TaikoDifficultyCalculator();
                default:
                    return null;
            }
        }

        #region mods

        public double ScoreMultiplier(Mods mods) => ScoreMultiplier(mods, GameMode);

        public static double ScoreMultiplier(Mods mods, GameMode gameMode) {
            var result = 1.0;
            if ((mods & Mods.Easy) > 0) result *= 0.5;
            if ((mods & Mods.NoFail) > 0) result *= 0.5;
            switch (gameMode) {
                case GameMode.Standard:
                    if ((mods & Mods.HalfTime) > 0) result *= 0.3;
                    if ((mods & Mods.HardRock) > 0) result *= 1.06;
                    if ((mods & Mods.DoubleTime) > 0) result *= 1.12;
                    if ((mods & Mods.Hidden) > 0) result *= 1.06;
                    if ((mods & Mods.Flashlight) > 0) result *= 1.12;
                    if ((mods & Mods.SpunOut) > 0) result *= 0.9;
                    break;
                case GameMode.Mania:
                    if ((mods & Mods.HalfTime) > 0) result *= 0.5;
                    break;
                case GameMode.Taiko:
                    if ((mods & Mods.HalfTime) > 0) result *= 0.3;
                    if ((mods & Mods.DoubleTime) > 0) result *= 1.12;
                    if ((mods & Mods.HardRock) > 0) result *= 1.06;
                    if ((mods & Mods.Hidden) > 0) result *= 1.06;
                    if ((mods & Mods.Flashlight) > 0) result *= 1.12;
                    break;
                case GameMode.CatchTheBeat:
                    if ((mods & Mods.HalfTime) > 0) result *= 0.3;
                    if ((mods & Mods.DoubleTime) > 0) result *= 1.06;
                    if ((mods & Mods.HardRock) > 0) result *= 1.12;
                    if ((mods & Mods.Hidden) > 0) result *= 1.06;
                    if ((mods & Mods.Flashlight) > 0) result *= 1.12;
                    break;
            }
            return result;
        }
        #endregion

        public abstract double PerformancePoints(ushort count300, ushort count100, ushort count50, ushort countMiss, bool scorev2);
    }
}