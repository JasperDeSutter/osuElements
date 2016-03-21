using System.Collections.Generic;
using System.ComponentModel;
using static osuElements.Helpers.HitObjectSoundType;

namespace osuElements.Helpers
{
    public interface IHitsound
    {
        SampleSet SampleSet { get; set; }
        SampleSet AdditionSampleSet { get; set; }
        HitObjectSoundType SoundType { get; set; }
        Custom Custom { get; set; }
    }
    /// <summary>
    /// A container for a single hitsound (one clap, or one hitnormal...) from a sampleset
    /// </summary>
    public class HitSound
    {
        public HitSound(SampleSet set, HitObjectSoundType sound, int custom) {
            SampleSet = set;
            HitObjectSoundType = sound;
            CustomSet = custom;
        }
        public SampleSet SampleSet { get; }
        public HitObjectSoundType HitObjectSoundType { get; }
        public int CustomSet { get; }

        //basically the name of the file of the sound to be played without extension
        public override string ToString() {
            return (SampleSet + "-hit" + HitObjectSoundType + (CustomSet > 0 ? "" + CustomSet : "")).ToLower();
        }
    }

    public static class HitsoundExtensions
    {
        /// <summary>
        /// inherit values from parent to child which aren't set on child
        /// </summary>
        /// <param name="child">hitobject (or sliderendpoint)</param>
        /// <param name="parent">timingpoint (or slider)</param>
        /// <param name="includeSoundType">if hitobjectsoundtype should be set too</param>
        public static IHitsound InheritFrom(this IHitsound child, IHitsound parent, bool includeSoundType = false) {
            if (child.SampleSet == SampleSet.None) {
                child.SampleSet = parent.SampleSet;
                child.Custom = parent.Custom;
            }
            if (child.AdditionSampleSet == SampleSet.None) child.AdditionSampleSet = parent.AdditionSampleSet;
            if (includeSoundType && child.SoundType == Normal) child.SoundType = parent.SoundType;
            return child;
        }
        /// <summary>
        /// get all hitsounds that play when this IHitsound plays
        /// </summary>
        /// <returns>an array of 1 to 4 HitSounds</returns>
        public static HitSound[] GetHitSounds(this IHitsound hitsound) {
            //a sampleset needs to be supplied
            if (hitsound.SampleSet == SampleSet.None)
                throw new InvalidEnumArgumentException(nameof(hitsound), (int)SampleSet.None, typeof(SampleSet));

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