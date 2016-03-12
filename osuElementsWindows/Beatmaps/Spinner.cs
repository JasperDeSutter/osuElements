using osuElements.Helpers;

namespace osuElements.Beatmaps
{
    public class Spinner : HitObject
    {
        public Spinner(Position position, int startTime, int endTime, bool isNewCombo = false, HitObjectSoundType soundType = HitObjectSoundType.Normal)
            : base(startTime, position, isNewCombo, HitObjectType.Spinner | HitObjectType.NewCombo, soundType) {
            EndTime = endTime;
        }
        public override string ToString() => $"{base.ToString()},{EndTime},{AdditionsForString}:";
    }
}
