using osuElements.Helpers;
using System;

namespace osuElements
{
    public struct Colour : IEquatable<Colour>
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public int Alpha { get; set; }

        public static Colour FromHsb(double h, double s, double b) {
            var result = new Colour();
            var hf = h / 60.0;
            var i = (int)Math.Floor(hf);
            var f = hf - i;
            var pv = (int)(b * (1.0 - s));
            var qv = (int)(b * (1.0 - s * f));
            var tv = (int)(b * (1.0 - s * (1 - f)));
            var V = (int)b;
            switch (i) {
                case 0:
                    result.Red = V;
                    result.Green = tv;
                    result.Blue = pv;
                    break;
                case 1:
                    result.Red = qv;
                    result.Green = V;
                    result.Blue = pv;
                    break;
                case 2:
                    result.Red = pv;
                    result.Green = V;
                    result.Blue = tv;
                    break;
                case 3:
                    result.Red = pv;
                    result.Green = qv;
                    result.Blue = V;
                    break;
                case 4:
                    result.Red = tv;
                    result.Green = pv;
                    result.Blue = V;
                    break;
                case 5:
                    result.Red = V;
                    result.Green = pv;
                    result.Blue = qv;
                    break;

                case 6:
                    result.Red = V;
                    result.Green = tv;
                    result.Blue = pv;
                    break;
                case -1:
                    result.Red = V;
                    result.Green = pv;
                    result.Blue = qv;
                    break;
                default:
                    result.Red = V;
                    result.Green = V;
                    result.Blue = V;
                    break;
            }
            return result;
        }

        public Colour(int r, int g, int b, int a = 255) {
            Red = Math.Max(0, Math.Min(255, r));
            Green = Math.Max(0, Math.Min(255, g));
            Blue = Math.Max(0, Math.Min(255, b));
            Alpha = Math.Max(0, Math.Min(255, a));
        }
        public Colour(Colour c) : this(c.Red, c.Green, c.Blue, c.Alpha) { }
        public static Colour Parse(string s) {
            var parts = s.Split(','.AsArray(), StringSplitOptions.RemoveEmptyEntries);
            return new Colour(
                parts.Length < 1 ? 0 : int.Parse(parts[0].Trim()),
                parts.Length < 2 ? 0 : int.Parse(parts[1].Trim()),
                parts.Length < 3 ? 0 : int.Parse(parts[2].Trim()),
                parts.Length < 4 ? 255 : int.Parse(parts[3].Trim()));
        }

        public bool Equals(Colour other) {
            return (Red == other.Red && Green == other.Green && Blue == other.Blue && Alpha == other.Alpha);
        }

        public override string ToString() => $"{Red},{Green},{Blue}" + (Alpha == 255 ? "" : $",{Alpha}");
    }

}
