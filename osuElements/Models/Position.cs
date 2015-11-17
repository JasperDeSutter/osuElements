using System;
using osuElements.Helpers;
namespace osuElements
{
    public struct Position
    {
        #region props
        public static readonly double CANVAS_PROPORTION = 4.0 / 3;
        public static readonly int OSU_RESOLUTION_HEIGHT = 480;
        public static readonly int OSU_RESOLUTION_WIDTH = 640;
        public static readonly int HITOBJECTS_RESOLUTION_HEIGHT = 376;
        public static readonly int HITOBJECTS_RESOLUTION_WIDTH = 512;
        public static readonly int HITOBJECTS_LEFT_OFFSET = 64;
        public static readonly int HITOBJECTS_TOP_OFFSET = 56;
        public float X { get; set; }
        public float Y { get; set; }
        //public bool IsSliderPoint { get; set; }
        public static Position Zero => new Position(0, 0);

        #endregion

        public Position(float x, float y) {
            //IsSliderPoint = false;
            X = x;
            Y = y;
        }
        public Position(Position copy) : this(copy.X, copy.Y) {
            //IsSliderPoint = copy.IsSliderPoint;
        }
        public static Position FromHitobject(int x, int y, bool isSliderPoint = false) {
            var result = new Position{
                XForHitobject = x,
                YForHitobject = y
            };
            //result.IsSliderPoint = isSliderPoint;
            return result;
        }
        public int XForHitobject {
            get {
                return (int)X - HITOBJECTS_LEFT_OFFSET;
            }
            set {
                X = value + HITOBJECTS_LEFT_OFFSET;
            }
        }
        public int YForHitobject {
            get {
                return (int)Y - HITOBJECTS_TOP_OFFSET;
            }
            set {
                Y = value + HITOBJECTS_TOP_OFFSET;
            }
        }
        public override string ToString() => $"X:{X} Y:{Y}";

        public override bool Equals(object o) {
            return o is Position && this == (Position)o;
        }
        public static bool operator ==(Position a, Position b) {
            return (a.X == b.X && a.Y == b.Y);
        }
        public static bool operator !=(Position a, Position b) {
            return !(a == b);
        }
        public override int GetHashCode() {
            return X.GetHashCode() * 10000 + Y.GetHashCode() * 100;// + (IsSliderPoint ? 1 : 0);
        }

        #region Methods
        public float Distance(Position b) {
            double dx = b.X - X;
            double dy = b.Y - Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
        public static float Distance(Position a, Position b) {
            return a.Distance(b);
        }
        public float GetAngle(bool normalize = true) {
            if (normalize) return ((float)Math.Atan2(Y, X)).NormalizeAngle();
            return ((float)Math.Atan2(Y, X));
        }
        public static float GetAngle(Position a, bool normalize = true) {
            return a.GetAngle(normalize);
        }
        public static Position SecondaryPoint(Position from, float length, float angle) {
            return from.SecondaryPoint(length, angle);
        }
        public Position SecondaryPoint(float length, float angle) {
            var result = new Position(this);
            result.X += (float)(length * Math.Sin(angle));
            result.Y += (float)(length * Math.Cos(angle));
            return result;
        }

        public static Position operator -(Position p1, Position p2) {
            Position result = Zero;
            result.X = p1.X - p2.X;
            result.Y = p1.Y - p2.Y;
            return result;
        }
        public static Position operator +(Position p1, Position p2) {
            Position result = Zero;
            result.X = p1.X + p2.X;
            result.Y = p1.Y + p2.Y;
            return result;
        }
        public static Position operator *(Position p1, Position p2) {
            Position result = Zero;
            result.X = p1.X * p2.X;
            result.Y = p1.Y * p2.Y;
            return result;
        }
        public static Position operator *(Position p, float f) {
            Position result = Zero;
            result.X = p.X * f;
            result.Y = p.Y * f;
            return result;
        }
        public static Position operator /(Position p1, Position p2) {
            Position result = Zero;
            result.X = p1.X / p2.X;
            result.Y = p1.Y / p2.Y;
            return result;
        }
        public static Position operator /(Position p, float f) {
            Position result = Zero;
            result.X = p.X / f;
            result.Y = p.Y / f;
            return result;
        }
        #endregion

    }
}
