using System;
using System.Collections.Generic;
using System.Linq;

namespace osuElements.Beatmaps.Difficulty
{
    internal class StandardDifficultyCalculator : DifficultyCalculatorBase
    {
        public StandardDifficultyCalculator(BeatmapManager manager) {
            SetManager(manager);
        }
        public void SetManager(BeatmapManager manager) {
            var radius = (float)(54.4 - manager.AdjustDifficulty(manager.GetBeatmap().DifficultyCircleSize) * 4.48);
            TpHitObjects = manager.GetHitObjects().Select(ho => new StandardDifficultyHitObject(ho, radius)).ToList();
        }

        public IEnumerable<StandardDifficultyHitObject> TpHitObjects { get; set; }


        public const double STAR_SCALING_FACTOR = 0.0675;
        public const double EXTREME_SCALING_FACTOR = 0.5;

        public bool CalculateStrainValues() {
            var hitObjectsEnumerator = TpHitObjects.GetEnumerator();
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

        private const double STRAIN_STEP = 400;

        private const double DECAY_WEIGHT = 0.9;

        public double CalculateDifficulty(DifficultyType type) {
            var highestStrains = new List<double>();
            var intervalEndTime = STRAIN_STEP * ModSpeed;

            var maximumStrain = 0.0;
            StandardDifficultyHitObject previousHitObject = null;
            foreach (var hitObject in TpHitObjects) {
                while (hitObject.BaseHitObject.StartTime > intervalEndTime) {
                    highestStrains.Add(maximumStrain);

                    if (previousHitObject == null) {
                        maximumStrain = 0.0;
                    }
                    else {
                        var decay = Math.Pow(StandardDifficultyHitObject.DECAY_BASE[(int)type], (intervalEndTime - previousHitObject.BaseHitObject.StartTime) / 1000.0);
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
        public double CalculateDifficulty() {
            if (!CalculateStrainValues()) return 0;
            var speedDifficulty = CalculateDifficulty(DifficultyType.Speed);
            var aimDifficulty = CalculateDifficulty(DifficultyType.Aim);
            AimDifficulty = Math.Sqrt(speedDifficulty) * STAR_SCALING_FACTOR;
            SpeedDifficulty = Math.Sqrt(aimDifficulty) * STAR_SCALING_FACTOR;
            return SpeedDifficulty + AimDifficulty + Math.Abs(SpeedDifficulty - AimDifficulty) * EXTREME_SCALING_FACTOR;
        }


        public override GameMode GameMode => GameMode.Standard;
        public override double StarDifficulty { get; protected set; }
        public double AimDifficulty { get; private set; }
        public double SpeedDifficulty { get; private set; }
        public override void Calculate(Mods mods) {
            base.Calculate(mods);
            StarDifficulty = CalculateDifficulty();
        }
    }
}
