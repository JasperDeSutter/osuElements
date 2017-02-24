using osuElements.Beatmaps;

namespace osuElements.Helpers
{
    public static class BitFunctions
    {
        public static bool IsType(this HitObjectSoundType a, HitObjectSoundType b) {
            return (a & b) > 0;
        }
        public static bool IsType(this HitObjectType a, HitObjectType b)
        {
            return (a & b) > 0; //adding in binary results in 0 if both are equal
        }
        public static bool IsType(this Mods a, Mods b)
        {
            return (a & b) > 0; //adding in binary results in 0 if both are equal
        }
    }
}
