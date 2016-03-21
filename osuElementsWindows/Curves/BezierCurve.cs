using System;
using System.Collections.Generic;
using System.Linq;
using osuElements.Helpers;

namespace osuElements.Curves
{
    public class BezierCurve : CurveBase
    {
        private readonly List<CurveBase> _segments = new List<CurveBase>();

        public BezierCurve(Position[] points) : base(points) { }

        protected override void Precalc() { }
        public override int Resolution
        {
            get { return _segments[0].Resolution; }
            set
            {
                foreach (var segment in _segments.Where(segment => !(segment is LinearCurve))) {
                    segment.Resolution = value;
                }
            }
        }

        protected override void Init() {
            if (Points.Length == 2) {
                _segments.Add(new LinearCurve(Points));
                return;
            }
            var seglength = 2;
            for (var i = 2; i < Points.Length; i++) {
                if ((Points[i] == Points[i - 1]) || i == Points.Length - 1) {
                    if (i == Points.Length - 1) { i++; seglength++; }
                    var points = new Position[seglength];
                    Array.Copy(Points, i - seglength, points, 0, seglength);
                    if (seglength > 2) _segments.Add(new BezierSegment(points));
                    else if (seglength == 2) _segments.Add(new LinearCurve(points));
                    seglength = 0;  //_segments are always at least 2 points in size -> can skip one
                }

                seglength++;
            }
            _length = 0;
            foreach (var seg in _segments) {
                _length += seg.Length;
            }
        }

        private CurveBase GetSegmentOn(ref float t) { //Get the specific segment for the current point, also returns specific t for that segment
            var seglength = 0.0;
            var currentlength = t * Length;
            foreach (var segment in _segments) {
                var l = segment.Length;
                seglength += l;
                if (seglength < currentlength) continue;

                t = (float)((l - seglength + currentlength) / l);
                return segment;
            }
            return _segments.Last();
        }

        public override Tuple<Position, float> GetPointOnCurve(float t) {
            if (t > 1 || t < 0) throw new Exception("You are trying to get a point out of the range(0-1) of the curve");
            var segmentt = GetSegmentOn(ref t);
            return segmentt.GetPointOnCurve(t);
        }
        public override Tuple<Position, float>[] GetPointsBeforeTOnCurve(float t) {
            var last = _segments.IndexOf(GetSegmentOn(ref t));
            var result = new List<Tuple<Position, float>>();
            for (var i = 0; i < last; i++) {
                result.AddRange(_segments[i].GetPointsBeforeTOnCurve(1)); //get all points of previous _segments
            }
            result.AddRange(_segments[last].GetPointsBeforeTOnCurve(t)); //get only correct points of this segment

            return result.ToArray<Tuple<Position, float>>();
        }

        public class BezierSegment : CurveBase
        {
            private double[] _multiplier;
            public BezierSegment(Position[] points) : base(points) { }
            protected override void Init() {
                var pointList = new List<Tuple<Position, float>>();
                for (var i = 0; i < Listcount; i++) {
                    var t = 1f * i / (Listcount - 1);
                    pointList.Add(GetPointOnCurve(t));
                }
                _multiplier = new double[Listcount];
                _length = 0;

                double totalmultiplier = 0;
                for (var i = 1; i < Listcount; i++) {
                    var current = Position.Distance(pointList[i].Item1, pointList[i - 1].Item1);
                    _length += current;
                    _multiplier[i - 1] = 1 / (current);
                    totalmultiplier += _multiplier[i - 1];
                }
                double previous = 0;
                for (var i = 0; i < Listcount - 1; i++) {
                    previous += _multiplier[i] / totalmultiplier;
                    _multiplier[i] = previous;
                }
                _multiplier[_multiplier.Length - 1] = 1;
            }
            public override Tuple<Position, float> GetPointOnCurve(float t) {
                if (_multiplier != null && t != 1 && t != 0) {
                    //t modification because the scale of bezier is not normalized
                    var f = (_multiplier.Length - 1) * t;
                    var p = (int)f;
                    var rest = f % 1;
                    var below = _multiplier[p];
                    var between = _multiplier[p + 1] - below;
                    below += rest * between;
                    t = (float)below;
                }
                Position result;
                if (!GetFreePoints(t, out result)) {
                    result = GetBezierPointRecursive(t, Points, 0, Points.Length);
                }
                Position result2;
                if (t < 1) {
                    result2 = GetBezierPointRecursive(t + float.Epsilon, Points, 0, Points.Length);
                    return new Tuple<Position, float>(result, (float)(Position.GetAngle(result - result2) + MathHelper.PI2).NormalizeAngle());
                }
                result2 = GetBezierPointRecursive(t - float.Epsilon, Points, 0, Points.Length);
                return new Tuple<Position, float>(result, (float)(Position.GetAngle(result2 - result) + MathHelper.PI2).NormalizeAngle());
            }
            private static Position GetBezierPointRecursive(double t, IList<Position> controlPoints, int index, int count) {//recursive way of calculating n-point beziers based on quadratic bezier
                if (count == 1) return controlPoints[index];
                var p0 = GetBezierPointRecursive(t, controlPoints, index, count - 1);
                var p1 = GetBezierPointRecursive(t, controlPoints, index + 1, count - 1);
                //return new Position((float)((1 - t) * p0.X + t * p1.X), (float)((1 - t) * p0.Y + t * p1.Y));
                return Position.Lerp(p0, p1, (float)t);
            }
        }

    }
}
