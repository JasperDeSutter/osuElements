using System;
using System.Diagnostics.Contracts;

namespace osuElements.Curves
{
    public class CatmullCurve : CurveBase
    {
        public CatmullCurve(Position[] points) : base(points) { }

        private static Position CatmullRom(Position a, Position b, Position c, Position d, float amount)
        {
            return (b * 2 + (-a + c) * amount +
                (a * 2 - b * 5 + c * 4 - d) * (amount * amount) +
                (-a + b * 3 - c * 3 + d) * (amount * amount * amount)
                ) / 2;
        }

        protected override void Init()
        {
            //var vector2_1 = i - 1 >= 0 ? controlPoints[i - 1] : controlPoints[i];
            //var vector2_2 = controlPoints[i];
            //var vector2_3 = i + 1 < controlPoints.Count ? controlPoints[i + 1] : vector2_2 + vector2_2 - vector2_1;
            //var vector2_4 = i + 2 < controlPoints.Count ? controlPoints[i + 2] : vector2_3 + vector2_3 - vector2_2;
        }

        public override Tuple<Position, float> GetPointOnCurve(float t)
        {
            throw new NotImplementedException();
        }
    }
}