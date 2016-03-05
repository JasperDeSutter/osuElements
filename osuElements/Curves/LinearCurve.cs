using System;
using osuElements.Helpers;

namespace osuElements.Curves
{
    public class LinearCurve : CurveBase
    {
        private float _positionangle;
        public LinearCurve(Position[] points) : base(points) { }
        protected override void Init() {
            var angle = Position.GetAngle(Points[1] - Points[0]);
            _positionangle = (angle - Constants.Math.PI2).NormalizeAngle();
            _length = Position.Distance(Points[0], Points[1]);
            Resolution = 2;
        }

        public override Tuple<Position, float> GetPointOnCurve(float t) {
            Position free;
            if (GetFreePoints(t, out free)) {
                return new Tuple<Position, float>(free, _positionangle);
            }
            if (t > 1 || t < 0) throw new Exception("You are trying to get a point out of the range(0-1) of the _curve");
            var result = Position.Lerp(Points[0], Points[1], t);
            return new Tuple<Position, float>(result, _positionangle);
        }
    }
}
