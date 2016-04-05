using System;
using System.Collections.Generic;
using System.Linq;

namespace osuElements.Beatmaps.Base
{
    public enum DifficultyType
    {
        Speed = 0,
        Aim =1,
    }
    
    internal class TpDifficulty
    {
        public TpDifficulty(BeatmapManager manager) {
            SetManager(manager);
        }
        public void SetManager(BeatmapManager manager) {
            _modSpeed = manager.ModSpeedMultiplier;
            var radius = (float)(54.4 - manager.AdjustDifficulty(manager.GetBeatmap().DifficultyCircleSize) * 4.48);
            TpHitObjects = manager.GetHitObjects().Select(ho => new TpHitObject(ho, radius)).ToList();
        }

        private float _modSpeed;
        public IEnumerable<TpHitObject> TpHitObjects { get; set; }


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
                nextHitObject.CalculateStrains(currentHitObject, _modSpeed);
                currentHitObject = nextHitObject;
            }

            return true;
        }
        
        private const double STRAIN_STEP = 400;
        
        private const double DECAY_WEIGHT = 0.9;

        public double CalculateDifficulty(DifficultyType type) {
            var highestStrains = new List<double>();
            var intervalEndTime = STRAIN_STEP * _modSpeed;

            double maximumStrain = 0;
            TpHitObject previousHitObject = null;
            foreach (var hitObject in TpHitObjects) {
                while (hitObject.BaseHitObject.StartTime > intervalEndTime) {
                    highestStrains.Add(maximumStrain);
                    
                    if (previousHitObject == null) {
                        maximumStrain = 0;
                    }
                    else {
                        var decay = Math.Pow(TpHitObject.DECAY_BASE[(int)type], (intervalEndTime - previousHitObject.BaseHitObject.StartTime) / 1000);
                        maximumStrain = previousHitObject.Strains[(int)type] * decay;
                    }
                    
                    intervalEndTime += STRAIN_STEP;
                }
                
                if (hitObject.Strains[(int)type] > maximumStrain) {
                    maximumStrain = hitObject.Strains[(int)type];
                }

                previousHitObject = hitObject;
            }
            
            double difficulty = 0;
            double weight = 1;
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
            var speedStars = Math.Sqrt(speedDifficulty) * STAR_SCALING_FACTOR;
            var aimStars = Math.Sqrt(aimDifficulty) * STAR_SCALING_FACTOR;
            return speedStars + aimStars + Math.Abs(speedStars - aimStars) * EXTREME_SCALING_FACTOR;
        }


    }
}
