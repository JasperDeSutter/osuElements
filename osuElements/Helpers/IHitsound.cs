using System.Collections.Generic;
using osuElements.Beatmaps;
using static osuElements.Helpers.HitObjectSoundType;
namespace osuElements.Helpers
{
    public interface IHitsound
    {
        /// <summary>
        /// The <see cref="SampleSet"/> for the normal hitsound
        /// </summary>
        SampleSet SampleSet { get; set; }

        /// <summary>
        /// The <see cref="SampleSet"/> for the additional hitsounds.
        /// (clap, whistle, finish)
        /// </summary>
        SampleSet AdditionSampleSet { get; set; }

        /// <summary>
        /// The sounds that the <see cref="HitObject"/> makes on hit.
        /// can be one or more soundtypes
        /// </summary>
        HitObjectSoundType SoundType { get; set; }

        /// <summary>
        /// The custom set from which the samples are taken.
        /// 0 is default, use (Custom)int for higher values.
        /// </summary>
        Custom Custom { get; set; }

        /// <summary>
        /// The loudness of the samples in percentage.
        /// 0 to 100
        /// </summary>
        int Volume { get; set; }
    }
    public static class HitsoundExtensions
    {
        /// <summary>
        /// inherit the values from parent to child which aren't set on child
        /// </summary>
        /// <param name="child">hitobject (or sliderendpoint)</param>
        /// <param name="parent">timingpoint (or slider)</param>
        /// <param name="includeSoundType">if hitobjectsoundtype should be set too</param>
        public static IHitsound InheritSoundsFrom(this IHitsound child, IHitsound parent, bool includeSoundType = false) {
            if (child.SampleSet == SampleSet.None) {
                child.SampleSet = parent.SampleSet;
                child.Custom = parent.Custom;
            }
            if (child.AdditionSampleSet == SampleSet.None) child.AdditionSampleSet = parent.AdditionSampleSet;
            if (includeSoundType && child.SoundType == Normal) child.SoundType = parent.SoundType;
            if (child.Volume == 0) child.Volume = parent.Volume;
            return child;
        }
        /// <summary>
        /// get all hitsounds that play when this IHitsound plays
        /// </summary>
        /// <returns>an array of 1 to 4 HitSounds</returns>
        public static HitSound[] GetHitSounds(this IHitsound hitsound) {
            //a sampleset needs to be supplied
            if (hitsound.SampleSet == SampleSet.None)
                hitsound.SampleSet = SampleSet.Normal;
            //throw new InvalidEnumArgumentException(nameof(hitsound), (int)SampleSet.None, typeof(SampleSet));

            var additionset = hitsound.AdditionSampleSet == SampleSet.None ? hitsound.SampleSet : hitsound.AdditionSampleSet;
            var custom = (int)hitsound.Custom;
            var result = new List<HitSound> { new HitSound(hitsound.SampleSet, Normal, custom) };
            if (hitsound.SoundType.HasFlag(Clap)) result.Add(new HitSound(additionset, Clap, custom));
            if (hitsound.SoundType.HasFlag(Finish)) result.Add(new HitSound(additionset, Finish, custom));
            if (hitsound.SoundType.HasFlag(Whistle)) result.Add(new HitSound(additionset, Whistle, custom));
            return result.ToArray();
        }

    }
}