namespace osuElements.Helpers
{
    public static class FloatExtension
    {
        public static float NormalizeAngle(this float a)
        {
            while (a < 0) a += Constants.Math.TAU;
            return (a % Constants.Math.TAU);
        }
    }
}
