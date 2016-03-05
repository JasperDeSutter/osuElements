using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using osuElements;
using osuElements.Curves;
using osuElements.Helpers;

namespace ModelsTest
{
    [TestClass]
    public class LinearCurveTest
    {
        #region Fields

        private readonly CurveBase _curve;
        private readonly Position[] _points;

        #endregion

        public LinearCurveTest() {
            _points = new[]{
                new Position(10, 10),
                new Position(20, 20)
            };
            _curve = new LinearCurve(_points);
        }

        #region Methods

        [TestMethod]
        public void PerfectCurveLength() {
            Assert.AreEqual(_points[0].Distance(_points[1]), _curve.Length);
        }

        [TestMethod]
        public void PerfectCurvePointCount() {
            var arr = _curve.GetPointsBeforeTOnCurve(1);
            Assert.AreEqual(2, arr.Length);
        }

        [TestMethod]
        public void PerfectCurveAngle() {
            var angle0 = _curve.GetPointOnCurve(0).Item2.NormalizeAngle();
            var angle1 = _curve.GetPointOnCurve(1).Item2.NormalizeAngle();
            Assert.AreEqual(angle0, angle1);
            Assert.AreEqual(angle1, (Position.GetAngle(_points[1] - _points[0]) - (float)Math.PI / 2).NormalizeAngle());
        }

        [TestMethod]
        public void PerfectCurveCenter() {
            var expected = new Position(15, 15);
            Assert.AreEqual(expected, _curve.GetPointOnCurve(0.5f).Item1);
        }

        #endregion
    }

    [TestClass]
    public class PerfectCurveTest
    {
        #region Fields

        private readonly CurveBase _curve;
        private readonly Position[] _points;

        #endregion

        public PerfectCurveTest() {
            _points = new[]{
                new Position(10, 10),
                new Position(20, 20),
                new Position(30, 10)
            };
            _curve = new PerfectCurve(_points);
        }

        #region Methods

        [TestMethod]
        public void PerfectCurveLength() {
            Assert.AreEqual((float)Math.PI * 10, _curve.Length);
        }


        [TestMethod]
        public void PerfectCurveCenter() {
            Assert.AreEqual(_points[1], _curve.GetPointOnCurve(0.5f).Item1);
        }

        #endregion
    }

    [TestClass]
    public class BezierTest
    {
        #region Fields

        private readonly CurveBase _curve;
        private readonly Position[] _points;
        private readonly BezierCurve _curve2;

        #endregion

        public BezierTest() {
            _points = new[]{
                new Position(10, 10),
                new Position(20, 20),
                new Position(20, 20),
                new Position(30, 10)
            };
            var _points2 = new[]{
                new Position(10, 10),
                new Position(20, 20),
                new Position(20, 20),
                new Position(27, 17),
                new Position(30, 10)
            };
            _curve = new BezierCurve(_points);
            _curve2 = new BezierCurve(_points2);
        }

        #region Methods

        [TestMethod]
        public void BezierLength() {
            Assert.AreEqual(Position.Distance(_points[0], _points[1]) * 2, _curve.Length);
        }

        [TestMethod]
        public void BezierPointsSpacing() {
            //_curve2.Resolution = 1000;
            var points = _curve2.GetPointsBeforeTOnCurve(0.5f);
            var distances = new float[points.Length - 1];
            for (var i = 0; i < distances.Length; i++) {
                distances[i] = Position.Distance(points[i].Item1, points[i + 1].Item1);
            }
        }

        [TestMethod]
        public void BezierCenter() {
            Assert.AreEqual(_points[1], _curve.GetPointOnCurve(0.5f).Item1);
        }

        [TestMethod]
        public void BezierPoints() {
            var points = _curve2.GetPointsBeforeTOnCurve(1f);
            var point = _curve2.GetPointOnCurve(1);
        }

        #endregion
    }
}