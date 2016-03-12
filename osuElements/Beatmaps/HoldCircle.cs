using osuElements.Helpers;

namespace osuElements.Beatmaps
{
    public class HoldCircle : HitCircle
    {
        public HoldCircle(Position position, int starttime, int endtime, bool isNewCombo = false,
            HitObjectType type = HitObjectType.HoldCircle, HitObjectSoundType soundType = HitObjectSoundType.Normal)
            : base(position, starttime, isNewCombo, type, soundType) {
            EndTime = endtime;
        }

        public override string ToString() => $"{base.ToString()},{EndTime},{AdditionsForString}";
    }
}