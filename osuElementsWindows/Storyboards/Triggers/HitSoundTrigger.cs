using osuElements.Helpers;

namespace osuElements.Storyboards.Triggers
{
    public class HitSoundTrigger : TriggerBase
    {
        private SampleSet _sampleSet;
        private SampleSet _additionSampleSet;
        private HitObjectSoundType _soundType;
        private Custom _custom;
        private bool _triggerOnSampleSet;
        private bool _triggerOnAditionSampleSet;
        private bool _triggerOnSoundType;
        private bool _triggerOnCustom;

        public HitSoundTrigger(HitObjectSoundType soundType) {
            SoundType = soundType;
        }

        internal HitSoundTrigger() { }

        public HitSoundTrigger(IHitsound hitsound) : this(hitsound.SoundType) {
            if (hitsound.SampleSet != SampleSet.None)
                SampleSet = hitsound.SampleSet;
            if (hitsound.AdditionSampleSet != SampleSet.None)
                AdditionSampleSet = hitsound.AdditionSampleSet;
            if (hitsound.Custom != Custom.Default)
                Custom = hitsound.Custom;
        }


        public override TriggerTypes TriggerType { get; } = TriggerTypes.HitSound;

        public SampleSet SampleSet
        {
            get { return _sampleSet; }
            set
            {
                _sampleSet = value;
                _triggerOnSampleSet = value != SampleSet.None;
            }
        }

        public SampleSet AdditionSampleSet
        {
            get { return _additionSampleSet; }
            set
            {
                _additionSampleSet = value;
                _triggerOnAditionSampleSet = value != SampleSet.None;
            }
        }

        public HitObjectSoundType SoundType
        {
            get { return _soundType; }
            set
            {
                _soundType = value;
                _triggerOnSoundType = value != HitObjectSoundType.Normal;
            }
        }

        public Custom Custom
        {
            get { return _custom; }
            set
            {
                _custom = value;
                _triggerOnCustom = true;
            }
        }

        public override string ToString() {
            var result = TriggerType.ToString();
            if (_triggerOnSampleSet) result += SampleSet;
            if (_triggerOnAditionSampleSet) result += AdditionSampleSet;
            if (_triggerOnSoundType) result += SoundType;
            if (_triggerOnCustom) result += (int)Custom;
            return result;
        }
    }
}