using osuElements.Helpers;

namespace osuElements.Storyboards.Triggers
{
    public class HitSoundTrigger : TriggerBase, IHitsound
    {
        public override TriggerTypes TriggerType { get; } = TriggerTypes.HitSound;
        public SampleSet SampleSet { get; set; }
        public SampleSet AdditionSampleSet { get; set; }
        public HitObjectSoundType SoundType { get; set; }
        public Custom Custom { get; set; }
        public bool TriggerOnSampleSet { get; set; }
        public bool TriggerOnAditionSampleSet { get; set; }
        public bool TriggerOnHitObjectSoundType { get; set; }
        public bool TriggerOnCustom { get; set; }
        public override string ToString() {
            var result = TriggerType.ToString();
            if (TriggerOnSampleSet) result += SampleSet;
            if (TriggerOnAditionSampleSet) result += AdditionSampleSet;
            if (TriggerOnHitObjectSoundType) result += SoundType;
            if (TriggerOnCustom) result += (int)Custom;
            return result;
        }
    }
}