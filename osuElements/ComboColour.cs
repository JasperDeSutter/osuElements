using osuElements.Helpers;
using System;
namespace osuElements
{
    public struct ComboColour : IEquatable<ComboColour>
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public int Alpha { get; set; }

        public ComboColour(int r, int g, int b, int a = 255) {
            Red = Math.Max(0, Math.Min(255, r));
            Green = Math.Max(0, Math.Min(255, g));
            Blue = Math.Max(0, Math.Min(255, b));
            Alpha = Math.Max(0, Math.Min(255, a));
        }
        public ComboColour(ComboColour c) : this(c.Red, c.Green, c.Blue, c.Alpha) { }
        public static ComboColour Parse(string s) {
            var parts = s.Split(Constants.Splitter.Comma, StringSplitOptions.RemoveEmptyEntries);
            return new ComboColour(
                parts.Length < 1 ? 0 : int.Parse(parts[0].Trim()),
                parts.Length < 2 ? 0 : int.Parse(parts[1].Trim()),
                parts.Length < 3 ? 0 : int.Parse(parts[2].Trim()),
                parts.Length < 4 ? 255 : int.Parse(parts[3].Trim()));
        }

        public bool Equals(ComboColour other) {
            return (Red == other.Red && Green == other.Green && Blue == other.Blue && Alpha == other.Alpha);
        }

        public override string ToString() => $"{Red},{Green},{Blue}" + (Alpha == 255 ? "" : $",{Alpha}");
    }

}
