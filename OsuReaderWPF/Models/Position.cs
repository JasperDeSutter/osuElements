using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuElements
{
    public class Position
    {
        public static double CanvasProportion = 4.0f / 3;
        public Position(int x, int y, bool isSliderPoint=false)
        {
            Set(x, y);
            _isSliderPoint = isSliderPoint;
        }
        public Position(Position @base)
        {
            this.X = @base.X;
            this.Y = @base.Y;
            this.IsSliderPoint = @base.IsSliderPoint;
        }

        public float X { get; set; }
        public float Y { get; set; }
        private bool _isSliderPoint =false;
        private const int DEFAULTX = Statics.OsuResolutionWidth;
        private const int DEFAULTY = Statics.OsuResolutionHeight;

        public bool IsSliderPoint
        {
            get { return _isSliderPoint; }
            set { _isSliderPoint = value; }
        }
        
        public void Set(int x, int y, int screenX = DEFAULTX, int screenY = DEFAULTY)
        {
            X = 1.0f * x / screenX;
            Y = 1.0f * y / screenY;
        }
        public int GetX(int screenX = DEFAULTX)
        {
            return (int)(screenX * X);
        }
        public int GetY(int screenY = DEFAULTY)
        {
            return (int)(screenY * Y);
        }
        public override string ToString()
        {
            if (IsSliderPoint) return GetX() + ":" + GetY();
            return GetX() + "," + GetY();
        }
        public override bool Equals(object o)
        {
            Position pos = o as Position;
            return (X == pos.X && Y == pos.Y);
        }
        public override int GetHashCode()
        {
            return GetX()<<4 + GetY()<<2 + (IsSliderPoint?1:0);
        }
        public static bool TryParse(string s, out Position pos)
        {
            s.Trim();
            s.Trim(Splitter.Comma);

            string[] parts = s.Split(Splitter.Comma);
            pos = null;
            if (parts.Length != 2) return false;
            int a;
            if (!int.TryParse(parts[0], out a) || !int.TryParse(parts[1], out a)) return false; //are both numbers integers?
            pos = Parse(parts[0],parts[1]);
            return true;
        }
        public static Position Parse(string s)
        {
            string[] parts = s.Split(Splitter.Comma);
            return Parse(parts[0], parts[1]);
        }
        public static Position Parse(string a, string b)
        {
            return new Position(int.Parse(a), int.Parse(b));
        }
    }
}
