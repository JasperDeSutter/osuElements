using System.Collections.Generic;

namespace osuElements.Beatmaps.Curves
{
    public class LinearCurve : CurveBase
    {
        public LinearCurve(Position[] points, double length) : base(points, length) { }
        protected override void Init() {
            TotalLength = Points[0].Distance(Points[1]);
        }

        protected override void Precalc() {
            if (DesiredLength < 0 || DesiredLength > TotalLength) DesiredLength = TotalLength;
            EndPosition = CalculatePoint(ModT);
            NeedsUpdate = false;
        }

        protected override Position CalculatePoint(double t) {
            return Position.Lerp(Points[0], Points[1], (float)t);
        }

        public override List<CurveSegment> GetPointsBeforeTOnCurve(double t) {
            if (NeedsUpdate) Precalc();
            return new List<CurveSegment> { new CurveSegment(Points[0], GetPointOnCurve(t)) };
        }
    }
}
