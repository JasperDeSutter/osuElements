using osuElements.Helpers;

namespace osuElements.Beatmaps
{
    public class HitCircle : HitObject
    {
        public HitCircle(Position position, int startTime, bool isNewCombo = false, HitObjectType type = HitObjectType.HitCircle, HitObjectSoundType soundType = HitObjectSoundType.Normal)
            : base(startTime, position, isNewCombo, type, soundType) {
        }

        public override string ToString() => HitobjectToString() + "," + AdditionsForString;
    }
}
