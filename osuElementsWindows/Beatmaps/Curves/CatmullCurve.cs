using System;

namespace osuElements.Beatmaps.Curves
{
    //TODO check if it works
    public class CatmullCurve : CurveBase
    {
        public CatmullCurve(Position[] points, double length) : base(points, length) { }

        private static Position CatmullRom(Position a, Position b, Position c, Position d, double t) {
            return (b * 2 + (-a + c) * (float)t +
                (a * 2 - b * 5 + c * 4 - d) * (float)(t * t) +
                (-a + b * 3 - c * 3 + d) * (float)(t * t * t)
                ) / 2;
        }


        protected override void Init() {
            //set length
        }

        protected override Position CalculatePoint(double t) {
            var length = Points.Length;
            var d = t * length;
            var i = (int)Math.Round(d);
            var posA = i - 1 >= 0 ? Points[i - 1] : Points[i];
            var posB = Points[i];
            var posC = i + 1 < length ? Points[i + 1] : posB + posB - posA;
            var posD = i + 2 < length ? Points[i + 2] : posC + posC - posB;

            return CatmullRom(posA, posB, posC, posD, d % 1);
        }
    }
}