// Decompiled with JetBrains decompiler
// Type: Microsoft.Xna.Framework.Rectangle
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
  public struct Rectangle : IEquatable<Rectangle>
  {
    private static Rectangle rectangle_0 = new Rectangle();
    public int int_0;
    public int int_1;
    public int Width;
    public int Height;

    public Rectangle(int int_2, int int_3, int int_4, int int_5)
    {
      this.int_0 = int_2;
      this.int_1 = int_3;
      this.Width = int_4;
      this.Height = int_5;
    }

    public static bool operator ==(Rectangle rectangle_1, Rectangle rectangle_2)
    {
      if (rectangle_1.int_0 == rectangle_2.int_0 && rectangle_1.int_1 == rectangle_2.int_1 && rectangle_1.Width == rectangle_2.Width)
        return rectangle_1.Height == rectangle_2.Height;
      return false;
    }

    public static bool operator !=(Rectangle rectangle_1, Rectangle rectangle_2)
    {
      if (rectangle_1.int_0 == rectangle_2.int_0 && rectangle_1.int_1 == rectangle_2.int_1 && rectangle_1.Width == rectangle_2.Width)
        return rectangle_1.Height != rectangle_2.Height;
      return true;
    }

    public int method_0()
    {
      return this.int_0;
    }

    public int method_1()
    {
      return this.int_0 + this.Width;
    }

    public int method_2()
    {
      return this.int_1;
    }

    public int method_3()
    {
      return this.int_1 + this.Height;
    }

    public static Rectangle smethod_0()
    {
      return Rectangle.rectangle_0;
    }

    public void method_4(Point point_0)
    {
      this.int_0 += point_0.int_0;
      this.int_1 += point_0.int_1;
    }

    public void method_5(int int_2, int int_3)
    {
      this.int_0 += int_2;
      this.int_1 += int_3;
    }

    public void method_6(int int_2, int int_3)
    {
      this.int_0 -= int_2;
      this.int_1 -= int_3;
      this.Width += int_2 * 2;
      this.Height += int_3 * 2;
    }

    public bool method_7(int int_2, int int_3)
    {
      if (this.int_0 <= int_2 && int_2 < this.int_0 + this.Width && this.int_1 <= int_3)
        return int_3 < this.int_1 + this.Height;
      return false;
    }

    public bool method_8(Point point_0)
    {
      if (this.int_0 <= point_0.int_0 && point_0.int_0 < this.int_0 + this.Width && this.int_1 <= point_0.int_1)
        return point_0.int_1 < this.int_1 + this.Height;
      return false;
    }

    public void method_9(ref Point point_0, out bool bool_0)
    {
      bool_0 = this.int_0 <= point_0.int_0 && point_0.int_0 < this.int_0 + this.Width && this.int_1 <= point_0.int_1 && point_0.int_1 < this.int_1 + this.Height;
    }

    public bool method_10(Rectangle rectangle_1)
    {
      if (this.int_0 <= rectangle_1.int_0 && rectangle_1.int_0 + rectangle_1.Width <= this.int_0 + this.Width && this.int_1 <= rectangle_1.int_1)
        return rectangle_1.int_1 + rectangle_1.Height <= this.int_1 + this.Height;
      return false;
    }

    public void method_11(ref Rectangle rectangle_1, out bool bool_0)
    {
      bool_0 = this.int_0 <= rectangle_1.int_0 && rectangle_1.int_0 + rectangle_1.Width <= this.int_0 + this.Width && this.int_1 <= rectangle_1.int_1 && rectangle_1.int_1 + rectangle_1.Height <= this.int_1 + this.Height;
    }

    public bool method_12(Rectangle rectangle_1)
    {
      if (rectangle_1.int_0 < this.int_0 + this.Width && this.int_0 < rectangle_1.int_0 + rectangle_1.Width && rectangle_1.int_1 < this.int_1 + this.Height)
        return this.int_1 < rectangle_1.int_1 + rectangle_1.Height;
      return false;
    }

    public void method_13(ref Rectangle rectangle_1, out bool bool_0)
    {
      bool_0 = rectangle_1.int_0 < this.int_0 + this.Width && this.int_0 < rectangle_1.int_0 + rectangle_1.Width && rectangle_1.int_1 < this.int_1 + this.Height && this.int_1 < rectangle_1.int_1 + rectangle_1.Height;
    }

    public bool Equals(Rectangle other)
    {
      if (this.int_0 == other.int_0 && this.int_1 == other.int_1 && this.Width == other.Width)
        return this.Height == other.Height;
      return false;
    }

    public override bool Equals(object obj)
    {
      bool flag = false;
      if (obj is Rectangle)
        flag = this.Equals((Rectangle) obj);
      return flag;
    }

    public override string ToString()
    {
      CultureInfo currentCulture = CultureInfo.CurrentCulture;
      return string.Format((IFormatProvider) currentCulture, "{{X:{0} Y:{1} Width:{2} Height:{3}}}", (object) this.int_0.ToString((IFormatProvider) currentCulture), (object) this.int_1.ToString((IFormatProvider) currentCulture), (object) this.Width.ToString((IFormatProvider) currentCulture), (object) this.Height.ToString((IFormatProvider) currentCulture));
    }

    public override int GetHashCode()
    {
      return this.int_0.GetHashCode() + this.int_1.GetHashCode() + this.Width.GetHashCode() + this.Height.GetHashCode();
    }
  }
}
