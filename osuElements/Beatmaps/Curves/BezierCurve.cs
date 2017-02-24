using System;
using System.Collections.Generic;
using System.Linq;

namespace osuElements.Beatmaps.Curves
{
    public class BezierCurve : CurveBase
    {
        private readonly List<CurveBase> _segments = new List<CurveBase>();

        public BezierCurve(Position[] points, double length) : base(points, length) { }

        protected override void Precalc()
        {
            if (DesiredLength > TotalLength || DesiredLength < 0) DesiredLength = TotalLength;
            NeedsUpdate = false;
        }

        protected override void Init()
        {
            TotalLength = 0;
            if (Points.Length == 2)
            {
                _segments.Add(new LinearCurve(Points, DesiredLength));
                TotalLength = _segments[0].TotalLength;
                return;
            }
            var seglength = 1;
            for (int i = 1, n = Points.Length; i < n; i++)
            {
                if (Points[i] == Points[i - 1] || i == n - 1)
                {
                    double length = -1; //desiredlength of segment
                    if (i == n - 1)
                    { //last point -> take one extra
                        i++;
                        seglength++;
                        length = DesiredLength - TotalLength;
                        if (DesiredLength > 0 && TotalLength > DesiredLength)
                        {
                            length = 0; //complete segments are invisible
                        }
                    }
                    var points = new Position[seglength];
                    Array.Copy(Points, i - seglength, points, 0, seglength);
                    if (seglength > 2)
                    {
                        var bezierSegment = new BezierSegment(points, length);
                        TotalLength += bezierSegment.TotalLength;
                        _segments.Add(bezierSegment);
                    }
                    else if (seglength == 2)
                    {
                        var linearCurve = new LinearCurve(points, length);
                        TotalLength += linearCurve.TotalLength;
                        _segments.Add(linearCurve);
                    }
                    seglength = 0;  //_segments are always at least 2 points in size -> can skip one
                }

                seglength++;
            }
            if (DesiredLength < 0 || DesiredLength > TotalLength) DesiredLength = TotalLength;
            if (ModT == 1 && DesiredLength != TotalLength) ModT = DesiredLength / TotalLength;
            EndPosition = GetPointOnCurve(1);
        }

        private CurveBase GetSegmentOn(ref double t)
        { //Get the specific segment for the current point
            var seglength = 0.0;
            var currentlength = t * TotalLength;
            foreach (var segment in _segments)
            {
                var l = segment.TotalLength;
                seglength += l;
                if (seglength < currentlength) continue;

                t = (l - seglength + currentlength) / l; //scale t to segment
                return segment;
            }
            return _segments.Last();
        }

        protected override Position CalculatePoint(double t)
        {
            return GetSegmentOn(ref t).GetPointOnCurve(t);
        }
        public override List<CurveSegment> GetPointsBeforeTOnCurve(double t)
        {
            Precalc();
            t *= ModT;
            var last = _segments.IndexOf(GetSegmentOn(ref t));
            var result = new List<CurveSegment>();
            for (var i = 0; i < last; i++)
            {
                result.AddRange(_segments[i].GetPointsBeforeTOnCurve(1)); //get all points of previous _segments
                result.Last().IsCorner = true;
            }
            result.AddRange(_segments[last].GetPointsBeforeTOnCurve(t)); //get only correct points of this segment
            return result;
        }

        public class BezierSegment : CurveBase
        {
            private double[] _multiplier;
            public BezierSegment(Position[] points, double length) : base(points, length) { }
            protected override void Init()
            {
                TotalLength = 0;
                _multiplier = null;
                var pointcount = Listcount;
                var perfect = false;
                if (DesiredLength < 0)
                {
                    var distances = Points.Skip(1).Select((p, i) => p.Distance(Points[i])).ToArray(); //distances between all curves
                    perfect = distances.Max() - distances.Min() < double.Epsilon;
                    pointcount = (int)distances.Sum();
                }

                var multiplier = new double[pointcount - 1];
                var pointd = pointcount - 1d;
                var prev = Points[0];
                //get points and distances between them

                for (var i = 1; i < pointcount; i++)
                {
                    var t = i / pointd;
                    var pos = GetBezierPoint(t);
                    if (i == 0) continue;
                    var current = pos.Distance(prev);
                    TotalLength += current;
                    multiplier[i - 1] = TotalLength;
                    prev = pos;
                }
                if (!perfect)
                    _multiplier = multiplier;
            }

            protected override Position CalculatePoint(double t)
            {
                return GetBezierPoint(Normalize(t));
            }

            private double Normalize(double t)
            {
                if (_multiplier == null || t == 1) return t;
                var arr = _multiplier;
                var count = arr.Length;

                var start = Math.Min(count - 1, (int)(count * t));

                t *= _multiplier[count - 1];

                if (_multiplier[start] > t)
                {
                    for (int i = start - 1; i >= 0; i--)
                    {
                        var prev = _multiplier[i];
                        if (prev > t) continue;
                        var next = _multiplier[i + 1];
                        return (i + (t - prev) / (next - prev)) / (count - 1);
                    }
                    return 0;
                }

                for (int i = start + 1; i < count; i++)
                {
                    var next = _multiplier[i];
                    if (next < t) continue;
                    var prev = _multiplier[--i];
                    return (i + (t - prev) / (next - prev)) / (count - 1);
                }
                return 1;
            }

            public double GetTangent(double t)
            {
                int count = Points.Length;
                var ii = Math.Pow(1d - t, count - 2);
                var tt = 1d;
                var tangent = Position.Zero;
                var prev = Points[0];
                for (int j = 1; j < count; j++)
                {
                    var a = Points[j];
                    tangent += (a - prev) * (float)(ii * tt);
                    ii /= (1d - t);
                    tt *= t;
                    prev = a;
                }
                return tangent.GetAngle();
            }

            private Position GetBezierPoint(double t)
            {
                var result = new Position();
                var length = Points.Length - 1;
                for (var i = 0; i <= length; i++)
                {
                    result += Points[i] * (float)Bernstein(i, length, t);
                }
                return result;
            }

            private static double Bernstein(int i, int n, double t)
            {
                var powers = Math.Pow(t, i) * Math.Pow(1 - t, n - i);
                long r = 1;
                long d;
                if (i > n) return 0;
                for (d = 1; d <= i; d++)
                {
                    r *= n--;
                    r /= d;
                }
                return r * powers;
            }
        }

    }
}
