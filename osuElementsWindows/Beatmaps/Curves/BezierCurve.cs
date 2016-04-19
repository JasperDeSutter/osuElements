using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using osuElements.Helpers;

namespace osuElements.Beatmaps.Curves
{
    public class BezierCurve : CurveBase
    {
        private readonly List<CurveBase> _segments = new List<CurveBase>();

        public BezierCurve(Position[] points, double length) : base(points, length) { }

        protected override void Precalc() {
            if (DesiredLength > TotalLength || DesiredLength < 0) DesiredLength = TotalLength;
            NeedsUpdate = false;
        }

        protected override void Init() {
            TotalLength = 0;
            if (Points.Length == 2) {
                _segments.Add(new LinearCurve(Points, DesiredLength));
                TotalLength = _segments[0].TotalLength;
                return;
            }
            var seglength = 1;
            for (int i = 1, n = Points.Length; i < n; i++) {
                if (Points[i] == Points[i - 1] || i == n - 1) {
                    double length = -1; //desiredlength of segment
                    if (i == n - 1) { //last point -> take one extra
                        i++;
                        seglength++;
                        length = DesiredLength - TotalLength;
                        if (DesiredLength > 0 && TotalLength > DesiredLength) {
                            length = 0; //complete segments are invisible
                        }
                    }
                    var points = new Position[seglength];
                    Array.Copy(Points, i - seglength, points, 0, seglength);
                    if (seglength > 2) {
                        var bezierSegment = new BezierSegment(points, length);
                        TotalLength += bezierSegment.TotalLength;
                        _segments.Add(bezierSegment);
                    }
                    else if (seglength == 2) {
                        var linearCurve = new LinearCurve(points, length);
                        TotalLength += linearCurve.TotalLength;
                        _segments.Add(linearCurve);
                    }
                    seglength = 0;  //_segments are always at least 2 points in size -> can skip one
                }

                seglength++;
            }
            if (DesiredLength < 0 || DesiredLength > TotalLength) DesiredLength = TotalLength;
            EndPosition = GetPointOnCurve(1);
        }

        private CurveBase GetSegmentOn(ref double t) { //Get the specific segment for the current point
            var seglength = 0.0;
            var currentlength = t * TotalLength;
            foreach (var segment in _segments) {
                var l = segment.TotalLength;
                seglength += l;
                if (seglength < currentlength) continue;

                t = (l - seglength + currentlength) / l; //scale t to segment
                return segment;
            }
            return _segments.Last();
        }

        protected override Position CalculatePoint(double t) {
            var segmentt = GetSegmentOn(ref t);
            return segmentt.GetPointOnCurve(t);
        }
        public override List<CurveSegment> GetPointsBeforeTOnCurve(double t) {
            Precalc();
            t *= ModT;
            var last = _segments.IndexOf(GetSegmentOn(ref t));
            var result = new List<CurveSegment>();
            for (var i = 0; i < last; i++) {
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
            protected override void Init() {
                TotalLength = 0;
                _multiplier = null;
                var pointList = new List<Position>();
                var pointcount = Listcount;
                var perfect = false;
                if (DesiredLength < 0) {
                    var distances = Points.Skip(1).Select((p, i) => p.Distance(Points[i])).ToArray(); //distances between all curves
                    perfect = distances.Max() - distances.Min() < double.Epsilon;
                    pointcount = (int)distances.Sum();
                }

                var multiplier = new double[pointcount - 1];
                double totalmultiplier = 0;
                //get points and distances between them
                for (var i = 0; i < pointcount; i++) {
                    var t = 1.0 * i / (pointcount - 1);
                    var pos = GetBezierPoint(t);
                    pointList.Add(pos);
                    if (i == 0) continue;
                    var current = pos.Distance(pointList[i - 1]);
                    TotalLength += current;
                    if (perfect) continue;
                    current = 1 / current;
                    multiplier[i - 1] = current;
                    totalmultiplier += current;
                }
                if (perfect) {
                    return;
                }

                double previous = 0;
                pointcount -= 2;
                //correct multiplier for totalmultiplier
                for (var i = 0; i < pointcount; i++) {
                    previous += multiplier[i] / totalmultiplier;
                    multiplier[i] = previous;
                }
                multiplier[pointcount] = 1;
                _multiplier = multiplier;
            }

            protected override Position CalculatePoint(double t) {
                if (_multiplier == null || t == 1) return GetBezierPoint(t);
                //t modification because the scale of bezier is not normalized
                var f = (_multiplier.Length - 1) * t;
                var p = (int)f;
                var rest = f % 1;
                var below = _multiplier[p];
                var above = _multiplier[p + 1];

                return GetBezierPoint(MathHelper.Lerp(rest, below, above));
            }

            private Position GetBezierPoint(double t) {
                var result = new Position();
                var length = Points.Length - 1;
                for (var i = 0; i <= length; i++) {
                    result += Points[i] * (float)Bernstein(i, length, t);
                }
                return result;
            }

            private static double Bernstein(int i, int n, double t) {
                var powers = Math.Pow(t, i) * Math.Pow(1 - t, n - i);
                long r = 1;
                long d;
                if (i > n) return 0;
                for (d = 1; d <= i; d++) {
                    r *= n--;
                    r /= d;
                }
                return r * powers;
            }
        }

    }
}
