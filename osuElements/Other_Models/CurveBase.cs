using System;
using System.Collections.Generic;
using System.Linq;
using osuElements.Helpers;

namespace osuElements.Other_Models
{
    public abstract class CurveBase
    {
        #region precalculation
        private int _resolution = 100;
        /// <summary>
        /// How many values get calcualted per given point. Higher value means smoother _curve.
        /// </summary>
        public int Resolution {
            get {
                return _resolution;
            }
            set {
                _resolution = value;
                _needsUpdate = true;
            }
        }
        protected int Listcount => _resolution * (Points.Length - 1);
        bool _needsUpdate;
        List<Tuple<float, Tuple<Position, float>>> _precalculated;
        protected virtual void Precalc() {
            if (!_needsUpdate) return;
            int res = Listcount;
            _precalculated = new List<Tuple<float, Tuple<Position, float>>>();
            for (int i = 0; i < res; i++) {
                float t = 1f * i / (res - 1);
                _precalculated.Add(new Tuple<float, Tuple<Position, float>>(t, GetPointOnCurve(t)));
            }
            _needsUpdate = false;
        }
        private List<Tuple<Position, float>> Getprecalcbefore(float t) {
            return _precalculated.TakeWhile(p => !(p.Item1 > t)).Select(p => p.Item2).ToList();
        }
        #endregion

        public Position[] Points;
        protected CurveBase(Position[] points) {
            _precalculated = new List<Tuple<float, Tuple<Position, float>>>();
            Points = points;
            Init();
            _needsUpdate = true; //first time always calculate
            Precalc();
        }

        protected double _length;
        public virtual double Length => _length;
        protected abstract void Init();
        /// <summary>
        /// Returns the corresponding point and angle 
        /// </summary>
        /// <param name="t">value between 0 and 1 representing percentage of the _length of the _curve</param>
        /// <returns></returns>
        public abstract Tuple<Position, float> GetPointOnCurve(float t);

        protected bool GetFreePoints(float t, out Position result) {
            if (t == 1) result = Points.Last();
            else if (t == 0) result = Points[0];
            else {
                result = new Position(0, 0);
                return false;
            }
            return true;
        }

        public virtual Tuple<Position, float>[] GetPointsBeforeTOnCurve(float t) //for value between 0 and 1, returns corresponding points before value on _curve
        {
            Precalc();
            var result = Getprecalcbefore(t);
            if (t != 1)
                result.Add(GetPointOnCurve(t));
            return result.ToArray();
        }
        public static CurveBase CreateCurve(Position[] points, SliderType st) {
            CurveBase curve;
            switch ((int)st) {
                case (int)SliderType.Linear:
                    curve = new LinearCurve(points);
                    break;
                case (int)SliderType.Bezier:
                    curve = new BezierCurve(points);
                    break;
                case (int)SliderType.PerfectCurve:
                    curve = new PerfectCurve(points);
                    break;
                default:
                    curve = null;
                    break;
            }
            return curve;
        }
    }
}
