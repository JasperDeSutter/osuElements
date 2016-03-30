using System;
using System.Collections.Generic;

namespace osuElements.Beatmaps.Curves
{
    public abstract class CurveBase
    {
        #region Fields
        public static double Resolution = 0.5;//how many points per osu-pixel

        private double _desiredLength;
        private Tuple<double, CurveSegment>[] _precalculated;
        private Position[] _points;
        protected bool NeedsUpdate;
        protected double ModT = 1;

        #endregion

        protected CurveBase(Position[] points, double length) {
            _desiredLength = length;
            _points = points;
            NeedsUpdate = true; //first time always calculate
            Init();
            Precalc();
        }

        #region Properties

        public Position EndPosition { get; protected set; }
        public Position[] Points
        {
            get { return _points; }
            set
            {
                if (_points == value) return;
                _points = value;
                NeedsUpdate = true;
            }
        }

        protected int Listcount => (int)(Resolution * DesiredLength);

        public virtual double TotalLength { get; protected set; }

        public double DesiredLength
        {
            get { return _desiredLength; }
            set
            {
                if (_desiredLength == value) return;
                _desiredLength = value;
                NeedsUpdate = true;
                ModT = DesiredLength / TotalLength;
            }
        }

        #endregion

        #region Methods

        public static CurveBase CreateCurve(Position[] points, SliderType st, double length) {
            CurveBase curve;
            switch (st) {
                case SliderType.Linear:
                    curve = new LinearCurve(points, length);
                    break;
                case SliderType.Bezier:
                    curve = new BezierCurve(points, length);
                    break;
                case SliderType.PerfectCurve:
                    curve = new PerfectCurve(points, length);
                    break;
                case SliderType.Catmull:
                    curve = new CatmullCurve(points, length);
                    break;
                default:
                    curve = null;
                    break;
            }
            return curve;
        }

        /// <summary>
        /// Returns the corresponding point and Angle
        /// </summary>
        /// <param name="t">value Between 0 and 1 representing percentage of the length of the curve</param>
        /// <returns></returns>
        public Position GetPointOnCurve(double t) {
            if (t > 1 || t < 0)
                throw new Exception("You are trying to get a point out of the range(0-1) of the _curve");
            if (Math.Abs(t - 1) < double.Epsilon) {
                return EndPosition;
            }
            if (DesiredLength < 1 || DesiredLength > TotalLength) DesiredLength = TotalLength;
            t *= ModT;
            return t <= 0 ? Points[0] : CalculatePoint(t);
        }

        public virtual List<CurveSegment> GetPointsBeforeTOnCurve(double t) {
            if (t > 1 || t < 0)
                throw new Exception("You are trying to get a point out of the range(0-1) of the _curve");
            Precalc();
            t *= ModT;

            var result = new List<CurveSegment>();

            for (var i = 0; i < Listcount; i++) {
                if (_precalculated[i].Item1 < t) result.Add(_precalculated[i].Item2);
                else {
                    if (Math.Abs(_precalculated[i].Item1 - t) < double.Epsilon) {
                        result.Add(_precalculated[i].Item2);
                        break;
                    }
                    var start = i > 0 ? _precalculated[i - 1].Item2.EndPosition : Points[0];
                    result.Add(new CurveSegment(start, GetPointOnCurve(t)));
                    break;
                }
            }
            return result;
        }

        public void Recalculate() {
            NeedsUpdate = true;
        }

        protected abstract Position CalculatePoint(double t);

        protected abstract void Init();

        protected virtual void Precalc() {
            if (DesiredLength < 1 || DesiredLength > TotalLength) DesiredLength = TotalLength;
            else if (!NeedsUpdate) return;
            var res = Listcount;
            _precalculated = new Tuple<double, CurveSegment>[res];
            var previous = Points[0];
            for (var i = 1; i <= res; i++) {
                var t = ModT * i / res;
                var pos = CalculatePoint(t);
                _precalculated[i - 1] = new Tuple<double, CurveSegment>(t,
                    new CurveSegment(previous, pos));
                previous = pos;
            }
            EndPosition = previous;
            NeedsUpdate = false;
        }
        #endregion
    }
}