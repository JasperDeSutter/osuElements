using System;
using osuElements.Helpers;
using static System.Math;
namespace osuElements
{
    public struct Position
    {
        public const double CANVAS_PROPORTION = 4.0 / 3;
        public const int OSU_RESOLUTION_HEIGHT = 480;
        public const int OSU_RESOLUTION_WIDTH = 640;
        public const int HITOBJECTS_RESOLUTION_HEIGHT = 376;
        public const int HITOBJECTS_RESOLUTION_WIDTH = 512;
        public const int HITOBJECTS_LEFT_OFFSET = 64;
        public const int HITOBJECTS_RIGHT_OFFSET = 64;
        public const int HITOBJECTS_TOP_OFFSET = 56;
        public const int HITOBJECTS_BOTTOM_OFFSET = 48;

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
        public static Position FromHitobject(float x, float y, bool clamp = true) {
            if (!clamp) return new Position { XForHitobject = x, YForHitobject = y };
            return new Position {
                XForHitobject = MathHelper.Clamp(x, 0, 512),
                YForHitobject = MathHelper.Clamp(y, 0, 384),
            };
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
        public double Length =>
            Sqrt(1.0 * X * X + 1.0 * Y * Y);

        public double LengthSquared =>
           1.0 * X * X + 1.0 * Y * Y;


        public double Distance(Position b) {
            return (this - b).Length;
        }

        public double DistanceSquared(Position b) {
            return (this - b).LengthSquared;
        }

        public Position SecondaryPoint(double length, double angle) {
            var result = new Position(this);
            result.X += (float)(length * Sin(angle));
            result.Y += (float)(length * Cos(angle));
            return result;
        }

        public double GetAngle(bool normalize = true) {
            return normalize ? Atan2(Y, X).NormalizeAngle() : Atan2(Y, X);
        }

        public static double GetAngle(Position a, bool normalize = true) =>
            a.GetAngle(normalize);

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
        public static Position operator *(Position p, double d) {
            return p * (float)d;
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
            new Position(this / (float)Length);

        #endregion

        public static Position Lerp(Position a, Position b, float t) {
            return a + (b - a) * t;
        }

        public static Position Flip(Position pos) {
            pos.YForHitobject = HITOBJECTS_RESOLUTION_HEIGHT - pos.YForHitobject;
            return pos;
        }
    }
}
