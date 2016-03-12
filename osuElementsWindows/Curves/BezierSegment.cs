using System;
using System.Collections.Generic;
using osuElements.Helpers;

namespace osuElements.Curves
{
    public class BezierSegment : CurveBase
    {
        private float[] _multiplier;
        public BezierSegment(Position[] points) : base(points) { }
        protected override void Init()
        {
            var pointList = new List<Tuple<Position, float>>();
            for (int i = 0; i < Listcount; i++)
            {
                float t = 1f * i / (Listcount - 1);
                pointList.Add(GetPointOnCurve(t));
            }
            _multiplier = new float[Listcount];
            _length = 0;

            float totalmultiplier = 0;
            for (int i = 1; i < Listcount; i++)
            {
                var current = Position.Distance(pointList[i].Item1, pointList[i - 1].Item1);
                _length += current;
                _multiplier[i - 1] = 1 / (current);
                totalmultiplier += _multiplier[i - 1];
            }
            float previous = 0;
            for (int i = 0; i < Listcount - 1; i++)
            {
                previous += _multiplier[i] / totalmultiplier;
                _multiplier[i] = previous;
            }
            _multiplier[_multiplier.Length - 1] = 1;
        }
        public override Tuple<Position, float> GetPointOnCurve(float t)
        {
            if (_multiplier != null && t != 1 && t != 0)
            {
                //t modification because the scale of bezier is not normalized
                float f = (_multiplier.Length - 1) * t;
                int p = (int)f;
                float rest = f % 1;
                float below = _multiplier[p];
                float between = _multiplier[p + 1] - below;
                below += rest * between;
                t = below;
            }
            Position result;
            if (!GetFreePoints(t, out result))
            {
                result = GetBezierPointRecursive(t, Points, 0, Points.Length);
            }
            Position result2;
            if (t < 1)
            {
                result2 = GetBezierPointRecursive(t + Single.Epsilon, Points, 0, Points.Length);
                return new Tuple<Position, float>(result, (Position.GetAngle(result - result2) + MathHelper.PI2).NormalizeAngle());
            }
            result2 = GetBezierPointRecursive(t - Single.Epsilon, Points, 0, Points.Length);
            return new Tuple<Position, float>(result, (Position.GetAngle(result2 - result) + MathHelper.PI2).NormalizeAngle());
        }
        private static Position GetBezierPointRecursive(double t, IList<Position> controlPoints, int index, int count)
        {//recursive way of calculating n-point beziers based on quadratic bezier
            if (count == 1) return controlPoints[index];
            var p0 = GetBezierPointRecursive(t, controlPoints, index, count - 1);
            var p1 = GetBezierPointRecursive(t, controlPoints, index + 1, count - 1);
            //return new Position((float)((1 - t) * p0.X + t * p1.X), (float)((1 - t) * p0.Y + t * p1.Y));
            return Position.Lerp(p0, p1, (float)t);
        }
    }
}