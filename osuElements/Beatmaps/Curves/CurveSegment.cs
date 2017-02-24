namespace osuElements.Beatmaps.Curves
{
    public class CurveSegment
    {
        private Position _startPosition;
        private Position _endPosition;
        public Position Between { get; private set; }
        public Position StartPosition
        {
            get { return _startPosition; }
            set
            {
                _startPosition = value;
                SetBetween(_endPosition - value);
            }
        }

        public Position EndPosition
        {
            get { return _endPosition; }
            set
            {
                _endPosition = value;
                SetBetween(value - _startPosition);
            }
        }

        public float StartAngle { get; set; }
        public float EndAngle { get; set; }
        public CurveSegment(Position start, Position end) {
            _startPosition = start;
            EndPosition = end;
        }
        public static explicit operator Position(CurveSegment a) {
            return a.Between;
        }

        public bool IsCorner { get; set; }
        public double Angle => Between.GetAngle();
        public double Length => Between.Length;
        private void SetBetween(Position between) {
            Between = between;
        }

        public override string ToString() {
            return $"{StartPosition} L:{Length} A:{Angle}";
        }
    }
}