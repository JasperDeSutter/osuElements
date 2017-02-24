using System;
using osuElements.Helpers;

namespace osuElements.Beatmaps.Curves
{
    public class PerfectCurve : CurveBase
    {
        public static double Increment = 0.00001;

        public Position Center { get; set; }
        private double _startingangle; //Where the _curve starts on the circle
        private double _curveangle; //the Length of the _curve on the circle in radians
        public double Radius { get; set; }

        public double Circumference => MathHelper.TAU * Radius;

        public PerfectCurve(Position[] points, double length) : base(points, length) { }
        protected override void Init() {
            Center = GetCenterFrom3Vectors(Points[0], Points[1], Points[2]);
            CalculateAngles();
            Radius = Center.Distance(Points[0]);
            TotalLength = Radius * Math.Abs(_curveangle);
        }

        public static double Gradient(Position a, Position b) {
            double ax = a.X; //to not change the values in vector a
            double ay = a.Y;
            if (ax == b.X) ax += Increment;
            if (ay == b.Y) ay += Increment;
            return (b.Y - ay) / (b.X - ax);
        }

        private static Position GetCenterFrom3Vectors(Position a, Position b, Position c) {
            var ga = Gradient(a, b);
            var gb = Gradient(b, c);
            if (ga == gb) ga += Increment;
            var x = (ga * gb * (a.Y - c.Y) + gb * (a.X + b.X) - ga * (b.X + c.X)) / (2 * (gb - ga));
            var y = (-2 * x + a.X + b.X) / (2 * ga) + (a.Y + b.Y) / 2.0;
            //Todo check for very small gradient difference and make a special curve
            return new Position((float)x, (float)y);
        }

        private void CalculateAngles() { //used for calculating points
            _startingangle = Position.GetAngle(Points[0] - Center);
            var angle1 = (Position.GetAngle(Points[1] - Center, false) - _startingangle).NormalizeAngle();
            var angle2 = (Position.GetAngle(Points[2] - Center, false) - _startingangle).NormalizeAngle();
            _curveangle = angle2;
            if (angle1 > angle2) {
                _curveangle -= MathHelper.TAU;
            }
        }

        protected override Position CalculatePoint(double t) {
            return Center.SecondaryPoint(Radius, _startingangle + t * _curveangle);
        }

    }
}
