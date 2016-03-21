using System;
using osuElements.Helpers;

namespace osuElements.Curves
{
    public class CatmullCurve : CurveBase
    {
        public CatmullCurve(Position[] points) : base(points) { }

        private static Position CatmullRom(Position a, Position b, Position c, Position d, float t) {
            return (b * 2 + (-a + c) * t +
                (a * 2 - b * 5 + c * 4 - d) * (t * t) +
                (-a + b * 3 - c * 3 + d) * (t * t * t)
                ) / 2;
        }


        protected override void Init() {

        }

        public override Tuple<Position, float> GetPointOnCurve(float t) {
            var length = Points.Length;
            var d = t * length;
            var i = (int)Math.Round(d);
            var posA = i - 1 >= 0 ? Points[i - 1] : Points[i];
            var posB = Points[i];
            var posC = i + 1 < length ? Points[i + 1] : posB + posB - posA;
            var posD = i + 2 < length ? Points[i + 2] : posC + posC - posB;

            var pointa = CatmullRom(posA, posB, posC, posD, d %= 1);
            var pointb = CatmullRom(posA, posB, posC, posD, d + float.MinValue);

            var angle = (float)(Position.GetAngle(pointa - pointb) + MathHelper.PI).NormalizeAngle();
            return new Tuple<Position, float>(pointa, angle);

        }
    }
}