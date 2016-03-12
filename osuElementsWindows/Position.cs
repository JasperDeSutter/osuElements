using osuElements.Helpers;
using static System.Math;
namespace osuElements
{
    public struct Position
    {
        public static readonly double CANVAS_PROPORTION = 4.0 / 3;
        public static readonly int OSU_RESOLUTION_HEIGHT = 480;
        public static readonly int OSU_RESOLUTION_WIDTH = 640;
        public static readonly int HITOBJECTS_RESOLUTION_HEIGHT = 376;
        public static readonly int HITOBJECTS_RESOLUTION_WIDTH = 512;
        public static readonly int HITOBJECTS_LEFT_OFFSET = 64;
        public static readonly int HITOBJECTS_TOP_OFFSET = 56;

        #region properties
        public float X { get; set; }
        public float Y { get; set; }
        public static Position Zero { get; } = new Position(0, 0);
        public static Position Unit { get; } = new Position(1, 1);
        public static Position UnitX { get; } = new Position(1, 0);
        public static Position UnitY { get; } = new Position(0, 1);
        #endregion

        public Position(float xy) : this(xy, xy) { }

        public Position(float x, float y) {
            X = x;
            Y = y;
        }
        public Position(Position copy) : this(copy.X, copy.Y) { }
        public static Position FromHitobject(float x, float y) {
            var result = new Position {
                XForHitobject = x,
                YForHitobject = y
            };
            return result;
        }
        public float XForHitobject
        {
            get { return X - HITOBJECTS_LEFT_OFFSET; }
            set { X = value + HITOBJECTS_LEFT_OFFSET; }
        }
        public float YForHitobject
        {
            get { return Y - HITOBJECTS_TOP_OFFSET; }
            set { Y = value + HITOBJECTS_TOP_OFFSET; }
        }
        public override string ToString() =>
            $"X:{X} Y:{Y}";

        public string ToHitObjectString() =>
            $"{XForHitobject},{YForHitobject}";

        public override bool Equals(object o) =>
            o is Position && this == (Position)o;

        public override int GetHashCode() =>
            X.GetHashCode() * 1000 + Y.GetHashCode();
        public static bool operator ==(Position a, Position b) =>
            a.X == b.X && a.Y == b.Y;

        public static bool operator !=(Position a, Position b) =>
            !(a == b);

        #region Methods
        public float Distance() =>
            (float)Sqrt(X * X + Y * Y);

        public float Length =>
            (float)Sqrt(X * X + Y * Y);

        public float Distance(Position b) =>
            (this - b).Length;

        public static float Distance(Position a, Position b) =>
            (b - a).Length;

        public float GetAngle(bool normalize = true) {
            if (normalize) return ((float)Atan2(Y, X)).NormalizeAngle();
            return ((float)Atan2(Y, X));
        }
        public static float GetAngle(Position a, bool normalize = true) =>
            a.GetAngle(normalize);

        public static Position SecondaryPoint(Position from, float length, float angle) =>
            from.SecondaryPoint(length, angle);


        public Position SecondaryPoint(float length, float angle) {
            var result = new Position(this);
            result.X += (float)(length * Sin(angle));
            result.Y += (float)(length * Cos(angle));
            return result;
        }
        public static Position operator -(Position p1) {
            p1.X = -p1.X;
            p1.Y = -p1.Y;
            return p1;
        }
        public static Position operator -(Position p1, Position p2) {
            p1.X -= p2.X;
            p1.Y -= p2.Y;
            return p1;
        }
        public static Position operator +(Position p1, Position p2) {
            p1.X += p2.X;
            p1.Y += p2.Y;
            return p1;
        }
        public static Position operator *(Position p1, Position p2) {
            p1.X *= p2.X;
            p1.Y *= p2.Y;
            return p1;
        }
        public static Position operator *(Position p, float f) {
            p.X *= f;
            p.Y *= f;
            return p;
        }
        public static Position operator /(Position p1, Position p2) {
            p1.X /= p2.X;
            p1.Y /= p2.Y;
            return p1;
        }
        public static Position operator /(Position p, float f) {
            p.X /= f;
            p.Y /= f;
            return p;
        }
        public Position Normalize() =>
            new Position(this / Length);

        #endregion

        public static Position Lerp(Position a, Position b, float t) {
            return a + (b - a) * t;
        }

    }
}
