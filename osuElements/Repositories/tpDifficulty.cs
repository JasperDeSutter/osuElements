using System;
using System.Collections.Generic;

namespace osuElements.Repositories
{// Those values are used as array indices. Be careful when changing them!
    public enum DifficultyType
    {
        Speed = 0,
        Aim
    }

    /// <summary>
    /// osu!tp's difficulty calculator ported to oRA.
    /// </summary>
    internal class TpDifficulty
    {

        public TpDifficulty(Beatmap beatmap) {
            ModSpeed = beatmap.ModSpeed;
            TpHitObjects = new List<TpHitObject>();
            foreach (var ho in beatmap.HitObjects) {
                TpHitObjects.Add(new TpHitObject(ho, beatmap.CircleDiameter));
            }
        }

        float ModSpeed;
        // We will store the HitObjects as a member variable.
        public List<TpHitObject> TpHitObjects { get; set; }


        public const double STAR_SCALING_FACTOR = 0.0625;
        public const double EXTREME_SCALING_FACTOR = 0.5;

        // Exceptions would be nicer to handle errors, but for this small project it shall be ignored.
        public bool CalculateStrainValues() {
            // Traverse hitObjects in pairs to calculate the strain value of NextHitObject from the strain value of CurrentHitObject and environment.
            var hitObjectsEnumerator = TpHitObjects.GetEnumerator();
            if (hitObjectsEnumerator.MoveNext() == false) {
                return false;
            }

            TpHitObject currentHitObject = hitObjectsEnumerator.Current;

            // First hitObject starts at strain 1. 1 is the default for strain values, so we don't need to set it here. See tpHitObject.

            while (hitObjectsEnumerator.MoveNext()) {
                TpHitObject nextHitObject = hitObjectsEnumerator.Current;
                nextHitObject.CalculateStrains(currentHitObject, ModSpeed);
                currentHitObject = nextHitObject;
            }

            return true;
        }


        // In milliseconds. For difficulty calculation we will only look at the highest strain value in each time interval of size STRAIN_STEP.
        // This is to eliminate higher influence of stream over aim by simply having more HitObjects with high strain.
        // The higher this value, the less strains there will be, indirectly giving long beatmaps an advantage.
        private const double STRAIN_STEP = 400;

        // The weighting of each strain value decays to 0.9 * it's previous value
        private const double DECAY_WEIGHT = 0.9;

        public double CalculateDifficulty(DifficultyType type) {
            // Find the highest strain value within each strain step
            var highestStrains = new List<double>();
            double intervalEndTime = STRAIN_STEP * ModSpeed;
            double maximumStrain = 0; // We need to keep track of the maximum strain in the current interval

            TpHitObject previousHitObject = null;
            foreach (TpHitObject hitObject in TpHitObjects) {
                // While we are beyond the current interval push the currently available maximum to our strain list
                while (hitObject.BaseHitObject.StartTime > intervalEndTime) {
                    highestStrains.Add(maximumStrain);

                    // The maximum strain of the next interval is not zero by default! We need to take the last hitObject we encountered, take its strain and apply the decay
                    // until the beginning of the next interval.
                    if (previousHitObject == null) {
                        maximumStrain = 0;
                    }
                    else {
                        double decay = Math.Pow(TpHitObject.DECAY_BASE[(int)type], (intervalEndTime - previousHitObject.BaseHitObject.StartTime) / 1000);
                        maximumStrain = previousHitObject.Strains[(int)type] * decay;
                    }

                    // Go to the next time interval
                    intervalEndTime += STRAIN_STEP;
                }

                // Obtain maximum strain
                if (hitObject.Strains[(int)type] > maximumStrain) {
                    maximumStrain = hitObject.Strains[(int)type];
                }

                previousHitObject = hitObject;
            }

            // Build the weighted sum over the highest strains for each interval
            double difficulty = 0;
            double weight = 1;
            highestStrains.Sort((a, b) => b.CompareTo(a)); // Sort from highest to lowest strain.

            foreach (double strain in highestStrains) {
                difficulty += weight * strain;
                weight *= DECAY_WEIGHT;
            }

            return difficulty;
        }
        public double CalculateDifficulty() {
            if (!CalculateStrainValues()) return 0;
            var speedDifficulty = CalculateDifficulty(DifficultyType.Speed);
            var aimDifficulty = CalculateDifficulty(DifficultyType.Aim);
            var speedStars = Math.Sqrt(speedDifficulty) * STAR_SCALING_FACTOR;
            var aimStars = Math.Sqrt(aimDifficulty) * STAR_SCALING_FACTOR;
            return speedStars + aimStars + Math.Abs(speedStars - aimStars) * EXTREME_SCALING_FACTOR;
        }


    }
}
