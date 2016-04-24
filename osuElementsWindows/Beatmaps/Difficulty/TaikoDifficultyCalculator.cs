using osuElements.Api;
using static System.Math;
namespace osuElements.Beatmaps.Difficulty
{
    public class TaikoDifficultyCalculator : DifficultyCalculatorBase
    {
        public TaikoDifficultyCalculator(BeatmapManager manager) : base(manager) { }
        public override GameMode GameMode => GameMode.Taiko;
        protected override Mods DifficultyChangers => Mods.Easy | Mods.HardRock | Mods.DoubleTime | Mods.HalfTime;
        public override double StarDifficulty { get; set; }
        public double Strain { get; set; }

        public override void Calculate(Mods mods) {
            base.Calculate(mods);
            throw new System.NotImplementedException("Taiko difficulty calculation is not yet supported");
        }

        public override double PerformancePoints(ApiScore score) {
            return PerformancePoints(Manager.Mods, Strain, Manager.HitWindow300, score.Count300, score.Count100,
                score.Count50, score.CountMiss, score.MaxCombo);
        }

        public static double PerformancePoints(Mods mods, double strain, double hit300, int count300, int count100,
            int count50, int countMiss, int maxCombo) {
            if ((mods & (Mods.Relax | Mods.Relax2 | Mods.Autoplay)) > 0) return 0;

            var succesful = count300 + count100 + count50;
            double total = succesful + countMiss;
            var acc = (count100 * 150 + count300 * 300) / (total * 300d);

            var strainvalue = Pow(5d * Max(1d, strain / 0.0075) - 4d, 2d) * 0.00001;
            var lengthbonus = 1D + 0.1 * Min(1d, total / 1500d);
            strainvalue *= lengthbonus;
            strainvalue *= Pow(0.985, countMiss);
            strainvalue *= acc;

            if (maxCombo > 0) {
                var pow = Pow(maxCombo, 0.5);
                strainvalue *= Min(pow / pow, 1d);
            }

            var accvalue = Pow(150d / hit300, 1.1d) * Pow(acc, 15) * 22d;
            accvalue *= Min(1.15, Pow(total / 1500d, 0.3));

            var multiplier = 1d;
            if ((mods & Mods.NoFail) > 0)
                multiplier *= 0.90;
            if ((mods & Mods.SpunOut) > 0)
                multiplier *= 0.95;
            if ((mods & Mods.Hidden) > 0) {
                multiplier *= 1.1;
                strainvalue *= 1.025;
            }
            if ((mods & Mods.Flashlight) > 0)
                multiplier *= 1.05 * lengthbonus;

            return Pow(Pow(strainvalue, 1.1) + Pow(accvalue, 1.1), 1d / 1.1) * multiplier;
        }

    }
}