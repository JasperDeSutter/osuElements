using osuElements.Helpers;
using System;

namespace osuElements.Curves
{
    public class LinearCurve : CurveBase
    {
        private float _angle;
        private float _positionangle;
        public LinearCurve(Position[] points) : base(points) { }
        protected override void Init() {
            _angle = Position.GetAngle(Points[1] - Points[0]);
            _positionangle = (_angle - Constants.Math.Pi2).NormalizeAngle();
            _length = Position.Distance(Points[0], Points[1]);
            Resolution = 2;
        }

        public override Tuple<Position, float> GetPointOnCurve(float t) {
            Position free;
            if (GetFreePoints(t, out free)) {
                return new Tuple<Position, float>(free, _positionangle);
            }
            if (t > 1 || t < 0) throw new Exception("You are trying to get a point out of the range(0-1) of the _curve");
            var x = (float)(Points[0].X + t * _length * Math.Sin(_angle));
            var y = (float)(Points[0].Y + t * _length * Math.Cos(_angle));
            return new Tuple<Position, float>(new Position(x, y), _positionangle);
        }
    }
}
