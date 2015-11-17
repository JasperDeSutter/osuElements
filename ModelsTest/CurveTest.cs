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
        private readonly Position[] _points;
        private readonly CurveBase _curve;

        public LinearCurveTest() {
            _points = new[]
            {
                new Position(10,10),
                new Position(20,20)
            };
            _curve = new LinearCurve(_points);
        }

        [TestMethod]
        public void PerfectCurveLength() {

            Assert.AreEqual(_points[0].Distance(_points[1]), _curve.Length);
        }
        [TestMethod]
        public void PerfectCurvePointCount() {

            Assert.AreEqual(2, _curve.GetPointsBeforeTOnCurve(1).Length);
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

    }
    [TestClass]
    public class PerfectCurveTest
    {
        private readonly Position[] _points;
        private readonly CurveBase _curve;

        public PerfectCurveTest() {
            _points = new[]
            {
                new Position(10,10),
                new Position(20,20),
                new Position(30,10), 
            };
            _curve = new PerfectCurve(_points);
        }

        [TestMethod]
        public void PerfectCurveLength() {

            Assert.AreEqual((float)Math.PI * 10, _curve.Length);
        }
        

        [TestMethod]
        public void PerfectCurveCenter() {
            Assert.AreEqual(_points[1], _curve.GetPointOnCurve(0.5f).Item1);
        }

    }
}
