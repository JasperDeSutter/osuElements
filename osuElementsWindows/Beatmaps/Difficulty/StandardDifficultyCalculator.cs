using System;
using System.Collections.Generic;
using System.Linq;
using osuElements.Api;
using static System.Math;

namespace osuElements.Beatmaps.Difficulty
{
    public class StandardDifficultyCalculator : DifficultyCalculatorBase
    {
        private BeatmapManager _manager;
        private List<StandardDifficultyHitObject> _tpHitObjects;
        private const double STAR_SCALING_FACTOR = 0.0675;
        private const double EXTREME_SCALING_FACTOR = 0.5;
        private const double STRAIN_STEP = 400;
        private const double DECAY_WEIGHT = 0.9;

        public StandardDifficultyCalculator(BeatmapManager manager) {
            SetManager(manager);
        }
        public override GameMode GameMode => GameMode.Standard;
        protected override Mods DifficultyChangers => Mods.Easy | Mods.HardRock | Mods.DoubleTime | Mods.HalfTime;
        public override double StarDifficulty { get; set; }
        public double AimDifficulty { get; set; }
        public double SpeedDifficulty { get; set; }
        public static bool UseScoreV2 { get; set; }

        public void SetManager(BeatmapManager manager) {
            _manager = manager;
            RedoHitObjects();
        }

        private void RedoHitObjects() {
            var radius = (float)(54.4 - _manager.AdjustDifficulty(_manager.GetBeatmap().DifficultyCircleSize) * 4.48);
            _tpHitObjects = _manager.GetHitObjects().Select(ho => new StandardDifficultyHitObject(ho, radius)).ToList();
            CurrentMods = _manager.Mods;
        }

        public bool CalculateStrainValues() {
            var hitObjectsEnumerator = _tpHitObjects.GetEnumerator();
            if (hitObjectsEnumerator.MoveNext() == false) {
                return false;
            }

            var currentHitObject = hitObjectsEnumerator.Current;

            while (hitObjectsEnumerator.MoveNext()) {
                var nextHitObject = hitObjectsEnumerator.Current;
                nextHitObject.CalculateStrains(currentHitObject, ModSpeed);
                currentHitObject = nextHitObject;
            }

            return true;
        }

        public double CalculateDifficulty(DifficultyType type) {
            var highestStrains = new List<double>();
            var intervalEndTime = STRAIN_STEP * ModSpeed;

            var maximumStrain = 0.0;
            StandardDifficultyHitObject previousHitObject = null;
            foreach (var hitObject in _tpHitObjects) {
                while (hitObject.BaseHitObject.StartTime > intervalEndTime) {
                    highestStrains.Add(maximumStrain);

                    if (previousHitObject == null) {
                        maximumStrain = 0.0;
                    }
                    else {
                        var decay = Pow(StandardDifficultyHitObject.DECAY_BASE[(int)type],
                            (intervalEndTime - previousHitObject.BaseHitObject.StartTime) / 1000.0);
                        maximumStrain = previousHitObject.Strains[(int)type] * decay;
                    }

                    intervalEndTime += STRAIN_STEP;
                }

                if (hitObject.Strains[(int)type] > maximumStrain) {
                    maximumStrain = hitObject.Strains[(int)type];
                }

                previousHitObject = hitObject;
            }

            var difficulty = 0.0;
            var weight = 1.0;
            highestStrains.Sort((a, b) => b.CompareTo(a));

            foreach (var strain in highestStrains) {
                difficulty += weight * strain;
                weight *= DECAY_WEIGHT;
            }

            return difficulty;
        }

        public override void Calculate(Mods mods) {
            if ((mods & Mods.HardRock) != (CurrentMods & Mods.HardRock) ||
                (mods & Mods.Easy) != (CurrentMods & Mods.Easy))
                RedoHitObjects();
            StarDifficulty = 0;
            AimDifficulty = 0;
            SpeedDifficulty = 0;
            base.Calculate(mods);
            if (!CalculateStrainValues()) return;
            var speedDifficulty = CalculateDifficulty(DifficultyType.Speed);
            var aimDifficulty = CalculateDifficulty(DifficultyType.Aim);
            AimDifficulty = Sqrt(speedDifficulty) * STAR_SCALING_FACTOR;
            SpeedDifficulty = Sqrt(aimDifficulty) * STAR_SCALING_FACTOR;
            StarDifficulty = SpeedDifficulty + AimDifficulty +
                             Abs(SpeedDifficulty - AimDifficulty) * EXTREME_SCALING_FACTOR;
        }

        public static double PerformancePoints(Mods mods, double aimdifficulty, double speeddifficulty, double hit300, double preempt,
             int maxCombo, int count300, int count100, int count50, int countMiss, int hitcirlcecount, bool scorev2) {
            if (mods.HasFlag(Mods.Relax | Mods.Relax2 | Mods.Autoplay)) return 0;
            var total = count300 + count100 + count50 + countMiss;
            var acc = (count300 * 6 + count100 * 2 + count50) / (total * 6d);
            var modspeed = mods.SpeedMultiplier();
            var od = (80d - hit300 / modspeed) / 6d;
            var ar = preempt / modspeed;
            if (ar > 1200) ar = -(ar - 1800d) / 120d;
            else ar = -(ar - 1200) / 150 + 5;

            //aim
            var aimvalue = Pow(5.0 * Max(1.0, aimdifficulty / STAR_SCALING_FACTOR) - 4.0, 3.0) * 0.00001;
            var lengthbonus = 0.95 + 0.4 * Min(1d, total * 0.0005) + (total > 2000d ? Log10(total * 0.0005) / 2d : 0d);
            aimvalue *= lengthbonus;
            var arfactor = 1.0;
            if (ar > 10.33) arfactor += 0.45 * (ar - 10.33);
            else if (ar < 8.0) {
                if (mods.HasFlag(Mods.Hidden)) arfactor += 0.02 * (8.0 - ar);
                else arfactor += 0.01 * (8 - ar);
            }
            aimvalue *= arfactor;
            //speed
            var speedvalue = Pow(5d * Max(1.0, speeddifficulty / STAR_SCALING_FACTOR) - 4d, 3d) * 0.00001;
            speedvalue *= lengthbonus;
            if (maxCombo > 0d) {
                var pow = Pow(maxCombo, 0.8);
                var m = Min(pow / pow, 1d);
                aimvalue *= m;
                speedvalue *= m;
            }
            //acc
            var betteraccpercent = acc;
            var amountobjectsacc = total;
            if (!scorev2) {
                amountobjectsacc = hitcirlcecount;
                if (amountobjectsacc > 0d) {
                    betteraccpercent = ((count300 - (total - amountobjectsacc)) * 6 + count100 * 2 +
                                        count50) / (amountobjectsacc * 6d);
                    if (betteraccpercent < 0d) betteraccpercent = 0d;
                }
                else betteraccpercent = 0d;
            }
            var accvalue = Pow(1.52163, od) * Pow(betteraccpercent, 24d) * 2.83;
            accvalue *= Min(1.15, Pow(amountobjectsacc * 0.001, 0.3));
            //mods
            var multiplier = 1.12;
            if ((mods & Mods.NoFail) > 0) multiplier *= 0.9;
            if ((mods & Mods.SpunOut) > 0) multiplier *= 0.95;
            if (mods.HasFlag(Mods.Hidden)) {
                accvalue *= 1.02;
                aimvalue *= 1.18;
            }
            if (mods.HasFlag(Mods.Flashlight)) {
                accvalue *= 1.02;
                aimvalue *= 1.45 * lengthbonus;
            }
            var accmod = (0.5 + acc / 2d) * (0.98 + Pow(od, 2) * 0.0004) * Pow(0.97, countMiss);
            aimvalue *= accmod;
            speedvalue *= accmod;

            return Pow(Pow(aimvalue, 1.1) + Pow(speedvalue, 1.1) + Pow(accvalue, 1.1), 1d / 1.1) * multiplier;
        }
        

        /// <summary>
        /// Make sure to Calculate(Mods) before this
        /// </summary>
        public override double PerformancePoints(ApiScore score) {
            return PerformancePoints(_manager.Mods, AimDifficulty, SpeedDifficulty, _manager.HitWindow300,
                _manager.PreEmpt, _manager.GetHitObjects().Sum(h => h.MaxCombo), score.Count300, score.Count100, score.Count50,
                score.CountMiss, _manager.GetHitObjects().OfType<HitCircle>().Count(), UseScoreV2);
        }
    }
}