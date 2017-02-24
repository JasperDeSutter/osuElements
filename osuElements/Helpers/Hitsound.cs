namespace osuElements.Helpers
{
    /// <summary>
    /// A container for a single hitsound (one clap, or one hitnormal...) from a sampleset
    /// </summary>
    public struct HitSound
    {
        public HitSound(SampleSet set, HitObjectSoundType sound, int custom) {
            SampleSet = set;
            HitObjectSoundType = sound;
            CustomSet = custom;
        }
        public SampleSet SampleSet { get; }
        public HitObjectSoundType HitObjectSoundType { get; }
        public int CustomSet { get; }

        //basically the filename (without extension) of the sound to be played 
        public override string ToString() {
            return DefaultString() + (CustomSet > 0 ? "" + CustomSet : "");
        }
        /// <summary>
        /// The filename for the file from skin/osu default samples
        /// </summary>
        public string DefaultString() {
            return $"{SampleSet}-hit{HitObjectSoundType}".ToLower();
        }
    }

}