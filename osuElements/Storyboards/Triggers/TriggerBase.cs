using System;
using osuElements.Helpers;

namespace osuElements.Storyboards.Triggers
{
    public abstract class TriggerBase
    {
        public override string ToString() {
            return TriggerType.ToString();
        }

        public abstract TriggerTypes TriggerType { get; }

        public static bool TryParse(string part, out TriggerBase trigger) {
            TriggerTypes type;
            trigger = null;
            if (!part.TrimStart().TryParseStartsWithEnum(out type)) return false;
            switch (type) {
                default:
                    return false;
                case TriggerTypes.Failing:
                    trigger = new FailingTrigger();
                    return true;
                case TriggerTypes.Passing:
                    trigger = new PassingTrigger();
                    return true;
                case TriggerTypes.HitSound:
                    trigger = new HitSoundTrigger();
                    break;
            }
            var hitsoundTrigger = (HitSoundTrigger)trigger;
            part = part.Remove(0, TriggerTypes.HitSound.ToString().Length);
            SampleSet sample;
            if (part.TryParseStartsWithEnum(out sample)) {
                hitsoundTrigger.SampleSet = sample;
                hitsoundTrigger.TriggerOnSampleSet = true;
                part = part.Remove(0, sample.ToString().Length);
                if (part.TryParseStartsWithEnum(out sample)) {
                    hitsoundTrigger.AdditionSampleSet = sample;
                    hitsoundTrigger.TriggerOnAditionSampleSet = true;
                    part = part.Remove(0, sample.ToString().Length);
                }
            }
            HitObjectSoundType hitsound;
            if (part.TryParseStartsWithEnum(out hitsound)) {
                hitsoundTrigger.SoundType = hitsound;
                hitsoundTrigger.TriggerOnHitObjectSoundType = true;
                part = part.Remove(0, hitsound.ToString().Length);
            }
            int custom;
            if (int.TryParse(part, out custom)) {
                hitsoundTrigger.Custom = (Custom)custom;
                hitsoundTrigger.TriggerOnCustom = true;
            }
            return true;
        }
    }
}