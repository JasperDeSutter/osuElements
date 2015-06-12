using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuReaderWPF.Models
{
    public class Position
    {
        public Position(int x, int y, bool isSliderPoint=false)
        {
            Set(x, y);
            _isSliderPoint = isSliderPoint;
        }
        public double X { get; set; }
        public double Y { get; set; }
        private bool _isSliderPoint =false;
        private const int DEFAULTX = 512;
        private const int DEFAULTY = 384;

        public bool IsSliderPoint
        {
            get { return _isSliderPoint; }
            set { _isSliderPoint = value; }
        }

        public void Set(int x, int y, int screenX = DEFAULTX, int screenY = DEFAULTY)
        {
            X = 1.0 * x / screenX;
            Y = 1.0 * y / screenY;
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
    }
}
