using osuElements.Helpers;
using System;
namespace osuElements
{
    public struct ComboColor
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }

        public ComboColor(int r, int g, int b) {
            Red = r;
            Green = g;
            Blue = b;
        }
        public ComboColor(ComboColor c) {
            Red = c.Red;
            Blue = c.Blue;
            Green = c.Green;
        }
        public static ComboColor Parse(string s) {
            s = s.Trim(Splitter.Space);
            var parts = s.Split(Splitter.Comma, StringSplitOptions.RemoveEmptyEntries);
            return new ComboColor(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
        }
        public override string ToString() => $"{Red},{Green},{Blue}";
    }

}
