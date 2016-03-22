using osuElements.Helpers;

namespace osuElements.Beatmaps
{
    public class Spinner : HitObject
    {
        public Spinner(Position position, int startTime, int endTime, HitObjectType type = HitObjectType.Spinner, HitObjectSoundType soundType = HitObjectSoundType.Normal)
            : base(startTime, position, true, type | HitObjectType.Spinner | HitObjectType.NewCombo, soundType) {
            EndTime = endTime;
        }
        public override string ToString() => $"{HitobjectToString},{EndTime},{AdditionsForString}:";
    }
}
