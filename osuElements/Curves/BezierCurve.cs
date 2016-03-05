using System;
using System.Collections.Generic;
using System.Linq;

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
            int seglength = 2;
            for (int i = 2; i < Points.Length; i++) {
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
            int last = _segments.IndexOf(GetSegmentOn(ref t));
            var result = new List<Tuple<Position, float>>();
            for (int i = 0; i < last; i++) {
                result.AddRange(_segments[i].GetPointsBeforeTOnCurve(1)); //get all points of previous _segments
            }
            result.AddRange(_segments[last].GetPointsBeforeTOnCurve(t)); //get only correct points of this segment

            return result.ToArray<Tuple<Position, float>>();
        }
    }
}
