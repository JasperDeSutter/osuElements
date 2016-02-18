using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using osuElements;

namespace ModelsTest
{
    [TestClass]
    public class PositionTest
    {
        private Position _positionA;
        private readonly Position _positionB;
        private readonly Position _positionC;

        public PositionTest() {
            _positionA = new Position(0, 0);
            _positionB = new Position(10, 0);
            _positionC = new Position(20, 10);
        }

        [TestMethod]
        public void Operators() {
            Assert.AreEqual(new Position(30, 10), _positionC + _positionB);
            Assert.AreEqual(new Position(10, 10), _positionC - _positionB);
            Assert.AreEqual(new Position(200, 0), _positionC * _positionB);
            Assert.AreEqual(new Position(2, 10), _positionC / new Position(10,1));
            Assert.AreEqual(new Position(30, 15), _positionC * 1.5f);
            Assert.AreEqual(new Position(10, 5), _positionC / 2);
        }

        [TestMethod]
        public void Equals() {
            Assert.AreEqual(Position.Zero, _positionA);
        }
        [TestMethod]
        public void DistanceTest() {
            var distanceAb = _positionA.Distance(_positionB);
            var distanceAc = _positionA.Distance(_positionC);
            Assert.AreEqual(distanceAb, 10);
            Assert.AreEqual(distanceAc, (float)Math.Sqrt(500)); //10 * 10 + 20 * 20
        }
        [TestMethod]
        public void AngleTest() {
            var angleAb = Position.GetAngle(_positionB - _positionA);
            var angleBc = Position.GetAngle(_positionC - _positionB, false);
            Assert.AreEqual(angleAb, 0);
            Assert.AreEqual(angleBc, (float)Math.PI / 4); //45
        }

    }
}
