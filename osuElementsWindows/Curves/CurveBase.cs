using System;
using System.Collections.Generic;
using System.Linq;
using osuElements.Helpers;

namespace osuElements.Curves
{
    public abstract class CurveBase
    {
        protected double _length;

        public Position[] Points;
        protected CurveBase(Position[] points) {
            Points = points;
            Init();
            _needsUpdate = true; //first time always calculate
            Precalc();
        }

        public virtual double Length => _length;
        protected abstract void Init();

        /// <summary>
        /// Returns the corresponding point and angle
        /// </summary>
        /// <param name="t">value Between 0 and 1 representing percentage of the length of the curve</param>
        /// <returns></returns>
        public abstract Tuple<Position, float> GetPointOnCurve(float t);

        protected bool GetFreePoints(float t, out Position result) {
            if (t == 1) result = Points.Last();
            else if (t == 0) result = Points[0];
            else {
                result = new Position(0);
                return false;
            }
            return true;
        }

        public virtual Tuple<Position, float>[] GetPointsBeforeTOnCurve(float t)
        {
            Precalc();
            var result = Getprecalcbefore(t);
            if (Math.Abs(t - 1) > float.Epsilon)
                result.Add(GetPointOnCurve(t));
            return result.ToArray();
        }

        public static CurveBase CreateCurve(Position[] points, SliderType st) {
            CurveBase curve;
            switch (st) {
                case SliderType.Linear:
                    curve = new LinearCurve(points);
                    break;
                case SliderType.Bezier:
                    curve = new BezierCurve(points);
                    break;
                case SliderType.PerfectCurve:
                    curve = new PerfectCurve(points);
                    break;
                    //case SliderType.Catmull:
                    //curve = new CatmullCurve(points);
                    //break;
                default:
                    curve = null;
                    break;
            }
            return curve;
        }

        #region precalculation
        private int _resolution = 100;

        /// <summary>
        /// How many pointvalues get calcualted per given controlpoint. Higher value means a smoother curve.
        /// </summary>
        public virtual int Resolution
        {
            get { return _resolution; }
            set
            {
                _resolution = value;
                _needsUpdate = true;
            }
        }

        protected int Listcount => _resolution * (Points.Length - 1);
        private bool _needsUpdate;
        private Tuple<float, Tuple<Position, float>>[] _precalculated;

        protected virtual void Precalc() {
            if (!_needsUpdate) return;
            var res = Listcount;
            _precalculated = new Tuple<float, Tuple<Position, float>>[res];
            for (var i = 0; i < res; i++) {
                var t = 1f * i / (res - 1);
                _precalculated[i] = new Tuple<float, Tuple<Position, float>>(t, GetPointOnCurve(t));
            }
            _needsUpdate = false;
        }

        private List<Tuple<Position, float>> Getprecalcbefore(float t) {
            return _precalculated.TakeWhile(p => !(p.Item1 > t)).Select(p => p.Item2).ToList();
        }

        #endregion
    }
}