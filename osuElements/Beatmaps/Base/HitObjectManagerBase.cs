using System.Collections.Generic;

namespace osuElements.Beatmaps.Base
{
    public abstract class HitObjectManagerBase //: MarshalByRefObject
    {
        public abstract Beatmap GetBeatmap();

        public abstract List<HitObject> GetHitObjects();


        /// <summary>
        /// Adjusts a difficulty value depending on the chosen mods. This is used for adjusting DifficultyCircleSize.
        /// </summary>
        public abstract double AdjustDifficulty(double difficulty);

        /// <summary>
        /// Map a difficulty value to a range, taking mods into account. This is used for mapping DifficultyApproachRate, DifficultyOverall and DifficultyHpDrainRate to their respective timing windows.
        /// </summary>
        public abstract double MapDifficultyRange(double difficulty, double min, double mid, double max);

        /// <summary>
        /// Radius of a HitObject.
        /// </summary>
        public float HitObjectRadius { get; set; }

        /// <summary>
        /// Time HitObjects get displayed before they need to be clicked. Depends on DifficultyApproachRate;
        /// </summary>
        public int PreEmpt { get; set; }

        /// <summary>
        /// Time window in milliseconds for acquiring 300/100/50 when hitting HitObjects. Depend on DifficultyOverall.
        /// </summary>
        public int HitWindow50 { get; set; }
        public int HitWindow100 { get; set; }
        public int HitWindow300 { get; set; }

        /// <summary>
        /// Distance Between slider scoring points.
        /// </summary>
        public double SliderScoringPointDistance { get; set; }

        /// <summary>
        /// Returns the slider velocity at a given point in time.
        /// </summary>
        public abstract double SliderVelocityAt(int time);

        /// <summary>
        /// Number of rotations per second required for full score.
        /// </summary>
        public double SpinnerRotationRatio { get; set; }

        /// <summary>
        /// Pixels to offset on stacked notes.
        /// </summary>
        public float StackOffset { get; set; }
    }
}
