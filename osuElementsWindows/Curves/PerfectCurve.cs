using System;
using osuElements.Helpers;

namespace osuElements.Curves
{
    public class PerfectCurve : CurveBase
    {
        public Position Center { get; set; }
        private double _startingangle; //Where the _curve starts on the circle
        private double _curveangle; //the _length of the _curve on the circle in radians
        public float Radius { get; set; }

        public double Circumference => MathHelper.TAU * Radius;

        public PerfectCurve(Position[] points) : base(points) { }
        protected override void Init() {
            Center = GetCenterFrom3Vectors(Points[0], Points[1], Points[2]);
            CalculateAngles();
            Radius = Position.Distance(Center, Points[0]);
            _length = Circumference * Math.Abs(_curveangle) / MathHelper.TAU;
        }

        public double Gradient(Position a, Position b) {
            var ax = a.X; //to not change the values in vector a
            var ay = a.Y;
            if (a.X == b.X) ax += float.Epsilon;
            if (a.Y == b.Y) ay += float.Epsilon;
            return ((double)b.Y - ay) / (b.X - ax);
        }

        private Position GetCenterFrom3Vectors(Position a, Position b, Position c) {
            var ma = Gradient(a, b);
            var mb = Gradient(b, c);
            // if (ma-mb < 0.01) -> not a _curve
            var x0 = (ma * mb * (a.Y - c.Y) + mb * (a.X + b.X) - ma * (b.X + c.X)) / (2 * (mb - ma));
            var y0 = (-2 * x0 + a.X + b.X) / (2 * ma) + (a.Y + b.Y) / 2.0;
            return new Position((float)x0, (float)y0);

        }
        private void CalculateAngles() //used for calculating points
        {
            _startingangle = Position.GetAngle(Points[0] - Center);
            var angle1 = (Position.GetAngle(Points[1] - Center) - _startingangle).NormalizeAngle();
            var angle2 = (Position.GetAngle(Points[2] - Center) - _startingangle).NormalizeAngle();
            _curveangle = angle2;
            if (angle1 > angle2) {
                _curveangle -= MathHelper.TAU;
            }
        }
        public override Tuple<Position, float> GetPointOnCurve(float t) {
            var currentangle = ((float)(_startingangle + t * _curveangle)).NormalizeAngle();
            Position free;
            if (GetFreePoints(t, out free)) {
                return new Tuple<Position, float>(free, currentangle + (_curveangle < 0 ? MathHelper.PI : 0));
            }
            var x = (float)(Center.X + Radius * Math.Cos(currentangle));
            var y = (float)(Center.Y + Radius * Math.Sin(currentangle));
            return new Tuple<Position, float>(new Position(x, y), currentangle + (_curveangle < 0 ? MathHelper.PI : 0));

        }

    }
}
