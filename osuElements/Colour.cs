using osuElements.Helpers;
using System;

namespace osuElements
{
    public struct Colour : IEquatable<Colour>
    {
        public static Colour Red = new Colour(255, 0, 0);
        public static Colour Green = new Colour(0, 255, 0);
        public static Colour Blue = new Colour(0, 0, 255);
        public static Colour White = new Colour(255, 255, 255);
        public static Colour Black = new Colour(0, 0, 0);

        public byte RedValue { get; set; }
        public byte GreenValue { get; set; }
        public byte BlueValue { get; set; }
        public byte Alpha { get; set; }

        public static Colour FromHsb(double h, double s, double b) {
            var result = new Colour();
            var hf = h / 60.0;
            var i = (int)Math.Floor(hf);
            var f = hf - i;
            var pv = (byte)(int)(b * (1.0 - s));
            var qv = (byte)(int)(b * (1.0 - s * f));
            var tv = (byte)(int)(b * (1.0 - s * (1 - f)));
            var V = (byte)(int)b;
            switch (i) {
                case 0:
                    result.RedValue = V;
                    result.GreenValue = tv;
                    result.BlueValue = pv;
                    break;
                case 1:
                    result.RedValue = qv;
                    result.GreenValue = V;
                    result.BlueValue = pv;
                    break;
                case 2:
                    result.RedValue = pv;
                    result.GreenValue = V;
                    result.BlueValue = tv;
                    break;
                case 3:
                    result.RedValue = pv;
                    result.GreenValue = qv;
                    result.BlueValue = V;
                    break;
                case 4:
                    result.RedValue = tv;
                    result.GreenValue = pv;
                    result.BlueValue = V;
                    break;
                case 5:
                    result.RedValue = V;
                    result.GreenValue = pv;
                    result.BlueValue = qv;
                    break;

                case 6:
                    result.RedValue = V;
                    result.GreenValue = tv;
                    result.BlueValue = pv;
                    break;
                case -1:
                    result.RedValue = V;
                    result.GreenValue = pv;
                    result.BlueValue = qv;
                    break;
                default:
                    result.RedValue = V;
                    result.GreenValue = V;
                    result.BlueValue = V;
                    break;
            }
            return result;
        }

        public Colour(byte r, byte g, byte b, byte a = 255) {
            RedValue = r;
            GreenValue = g;
            BlueValue = b;
            Alpha = a;
        }
        public Colour(Colour c) : this(c.RedValue, c.GreenValue, c.BlueValue, c.Alpha) { }
        public static Colour Parse(string s) {
            var parts = s.Split(','.AsArray(), StringSplitOptions.RemoveEmptyEntries);
            return new Colour(
                parts.Length < 1 ? (byte)0 : byte.Parse(parts[0].Trim()),
                parts.Length < 2 ? (byte)0 : byte.Parse(parts[1].Trim()),
                parts.Length < 3 ? (byte)0 : byte.Parse(parts[2].Trim()),
                parts.Length < 4 ? byte.MaxValue : byte.Parse(parts[3].Trim()));
        }

        public bool Equals(Colour other) {
            return (RedValue == other.RedValue && GreenValue == other.GreenValue && BlueValue == other.BlueValue && Alpha == other.Alpha);
        }

        public override string ToString() => $"{RedValue},{GreenValue},{BlueValue}" + (Alpha == 255 ? "" : $",{Alpha}");
    }

}
