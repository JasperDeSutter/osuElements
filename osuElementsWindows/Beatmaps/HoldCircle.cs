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

        public override string ToString() => 
            $"{HitobjectToString()},{EndTime}:{AdditionsForString}"; //theres a : between endtime and additions. Thanks peppy!
    }
}