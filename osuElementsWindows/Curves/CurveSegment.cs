namespace osuElements.Curves
{
    public class CurveSegment
    {
        private Position _startPosition;
        private Position _endPosition;
        private Position _between;
        public Position StartPosition
        {
            get { return _startPosition; }
            set
            {
                _startPosition = value;
                _between = _endPosition - value;
            }
        }

        public Position EndPosition
        {
            get { return _endPosition; }
            set
            {
                _endPosition = value;
                _between = value - _startPosition;
            }
        }
        public CurveSegment(Position start, Position end) {
            _startPosition = start;
            EndPosition = end;
        }

        public double Angle() => _between.GetAngle();
        public float LengthSquared() => _between.LengthSquared();
        public float Length() => _between.Length;

        public override string ToString() {
            return $"{StartPosition},{Length()},{Angle()}";
        }
    }
}