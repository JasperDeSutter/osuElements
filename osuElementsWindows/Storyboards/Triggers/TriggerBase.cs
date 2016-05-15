using osuElements.Helpers;

namespace osuElements.Storyboards.Triggers
{
    public abstract class TriggerBase
    {
        public override string ToString()
        {
            return TriggerType.ToString();
        }

        public abstract TriggerTypes TriggerType { get; }

        public static bool TryParse(string part, out TriggerBase trigger)
        {
            TriggerTypes type;
            trigger = null;
            if (!part.TrimStart().TryParseStartsWithEnum(out type)) return false;
            trigger = FromType(type);
            if (type != TriggerTypes.HitSound) return trigger != null;

            var hitsoundTrigger = (HitSoundTrigger)trigger;
            part = part.Remove(0, TriggerTypes.HitSound.ToString().Length);
            SampleSet sample;
            if (part.TryParseStartsWithEnum(out sample))
            {
                hitsoundTrigger.SampleSet = sample;
                part = part.Remove(0, sample.ToString().Length);
                if (part.TryParseStartsWithEnum(out sample))
                {
                    hitsoundTrigger.AdditionSampleSet = sample;
                    part = part.Remove(0, sample.ToString().Length);
                }
            }
            HitObjectSoundType hitsound;
            if (part.TryParseStartsWithEnum(out hitsound))
            {
                hitsoundTrigger.SoundType = hitsound;
                part = part.Remove(0, hitsound.ToString().Length);
            }
            int custom;
            if (int.TryParse(part, out custom))
            {
                hitsoundTrigger.Custom = (Custom)custom;
            }
            return true;
        }

        public static TriggerBase FromType(TriggerTypes trigger)
        {
            switch (trigger)
            {
                default:
                    return null;
                case TriggerTypes.Failing:
                    return new FailingTrigger();
                case TriggerTypes.Passing:
                    return new PassingTrigger();
                case TriggerTypes.HitSound:
                    return new HitSoundTrigger();
                case TriggerTypes.HitObjectHit:
                    return new HitObjectHitTrigger();
            }
        }
    }

    public class HitObjectHitTrigger : TriggerBase
    {
        public override TriggerTypes TriggerType { get; } = TriggerTypes.HitObjectHit;

    }
}