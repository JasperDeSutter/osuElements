// Decompiled with JetBrains decompiler
// Type: Microsoft.Xna.Framework.Point
// Assembly: osu!, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01B8D71D-E69E-4E8A-76A7-28C15896CF26
// Assembly location: D:\Downloads\Decompiled osu\osu!-cleaned.exe

using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Xna.Framework
{
  [ComVisible(false)]
  [Serializable]
  public struct Point : IEquatable<Point>
  {
    private static Point point_0 = new Point();
    public int int_0;
    public int int_1;

    public Point(int int_2, int int_3)
    {
      this.int_0 = int_2;
      this.int_1 = int_3;
    }

    public static bool operator ==(Point point_1, Point point_2)
    {
      return point_1.Equals(point_2);
    }

    public static bool operator !=(Point point_1, Point point_2)
    {
      if (point_1.int_0 == point_2.int_0)
        return point_1.int_1 != point_2.int_1;
      return true;
    }

    public static Point smethod_0()
    {
      return Point.point_0;
    }

    public bool Equals(Point other)
    {
      if (this.int_0 == other.int_0)
        return this.int_1 == other.int_1;
      return false;
    }

    public override bool Equals(object obj)
    {
      bool flag = false;
      if (obj is Point)
        flag = this.Equals((Point) obj);
      return flag;
    }

    public override int GetHashCode()
    {
      return this.int_0.GetHashCode() + this.int_1.GetHashCode();
    }

    public override string ToString()
    {
      CultureInfo currentCulture = CultureInfo.CurrentCulture;
      return string.Format((IFormatProvider) currentCulture, "{{X:{0} Y:{1}}}", new object[2]
      {
        (object) this.int_0.ToString((IFormatProvider) currentCulture),
        (object) this.int_1.ToString((IFormatProvider) currentCulture)
      });
    }
  }
}
