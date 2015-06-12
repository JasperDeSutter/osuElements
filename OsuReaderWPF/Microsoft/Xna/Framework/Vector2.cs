// Decompiled with JetBrains decompiler
// Type: Microsoft.Xna.Framework.Vector2
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
  public struct Vector2 : IEquatable<Vector2>
  {
    private static Vector2 vector2_0 = new Vector2();
    private static Vector2 vector2_1 = new Vector2(1f, 1f);
    private static Vector2 vector2_2 = new Vector2(1f, 0.0f);
    private static Vector2 vector2_3 = new Vector2(0.0f, 1f);
    public float X;
    public float Y;

    public Vector2(float float_2, float float_3)
    {
      this.X = float_2;
      this.Y = float_3;
    }

    public Vector2(float float_2)
    {
      this.Y = float_2;
      this.X = float_2;
    }

    public static Vector2 operator -(Vector2 vector2_4)
    {
      Vector2 vector2;
      vector2.X = -vector2_4.X;
      vector2.Y = -vector2_4.Y;
      return vector2;
    }

    public static bool operator ==(Vector2 vector2_4, Vector2 vector2_5)
    {
      if ((double) vector2_4.X == (double) vector2_5.X)
        return (double) vector2_4.Y == (double) vector2_5.Y;
      return false;
    }

    public static bool operator !=(Vector2 vector2_4, Vector2 vector2_5)
    {
      if ((double) vector2_4.X == (double) vector2_5.X)
        return (double) vector2_4.Y != (double) vector2_5.Y;
      return true;
    }

    public static Vector2 operator +(Vector2 vector2_4, Vector2 vector2_5)
    {
      Vector2 vector2;
      vector2.X = vector2_4.X + vector2_5.X;
      vector2.Y = vector2_4.Y + vector2_5.Y;
      return vector2;
    }

    public static Vector2 operator -(Vector2 vector2_4, Vector2 vector2_5)
    {
      Vector2 vector2;
      vector2.X = vector2_4.X - vector2_5.X;
      vector2.Y = vector2_4.Y - vector2_5.Y;
      return vector2;
    }

    public static Vector2 operator *(Vector2 vector2_4, Vector2 vector2_5)
    {
      Vector2 vector2;
      vector2.X = vector2_4.X * vector2_5.X;
      vector2.Y = vector2_4.Y * vector2_5.Y;
      return vector2;
    }

    public static Vector2 operator *(Vector2 vector2_4, float float_2)
    {
      Vector2 vector2;
      vector2.X = vector2_4.X * float_2;
      vector2.Y = vector2_4.Y * float_2;
      return vector2;
    }

    public static Vector2 operator *(float float_2, Vector2 vector2_4)
    {
      Vector2 vector2;
      vector2.X = vector2_4.X * float_2;
      vector2.Y = vector2_4.Y * float_2;
      return vector2;
    }

    public static Vector2 operator /(Vector2 vector2_4, Vector2 vector2_5)
    {
      Vector2 vector2;
      vector2.X = vector2_4.X / vector2_5.X;
      vector2.Y = vector2_4.Y / vector2_5.Y;
      return vector2;
    }

    public static Vector2 operator /(Vector2 vector2_4, float float_2)
    {
      float num = 1f / float_2;
      Vector2 vector2;
      vector2.X = vector2_4.X * num;
      vector2.Y = vector2_4.Y * num;
      return vector2;
    }

    public static Vector2 smethod_0()
    {
      return Vector2.vector2_0;
    }

    public static Vector2 smethod_1()
    {
      return Vector2.vector2_1;
    }

    public static Vector2 smethod_2()
    {
      return Vector2.vector2_2;
    }

    public static Vector2 smethod_3()
    {
      return Vector2.vector2_3;
    }

    public override string ToString()
    {
      CultureInfo currentCulture = CultureInfo.CurrentCulture;
      return string.Format((IFormatProvider) currentCulture, "{{X:{0} Y:{1}}}", new object[2]
      {
        (object) this.X.ToString((IFormatProvider) currentCulture),
        (object) this.Y.ToString((IFormatProvider) currentCulture)
      });
    }

    public bool Equals(Vector2 other)
    {
      if ((double) this.X == (double) other.X)
        return (double) this.Y == (double) other.Y;
      return false;
    }

    public override bool Equals(object obj)
    {
      bool flag = false;
      if (obj is Vector2)
        flag = this.Equals((Vector2) obj);
      return flag;
    }

    public override int GetHashCode()
    {
      return this.X.GetHashCode() + this.Y.GetHashCode();
    }

    public float method_0()
    {
      return (float) Math.Sqrt((double) this.X * (double) this.X + (double) this.Y * (double) this.Y);
    }

    public float method_1()
    {
      return (float) ((double) this.X * (double) this.X + (double) this.Y * (double) this.Y);
    }

    public static float smethod_4(Vector2 vector2_4, Vector2 vector2_5)
    {
      float num1 = vector2_4.X - vector2_5.X;
      float num2 = vector2_4.Y - vector2_5.Y;
      return (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2);
    }

    public static void smethod_5(ref Vector2 vector2_4, ref Vector2 vector2_5, out float float_2)
    {
      float num1 = vector2_4.X - vector2_5.X;
      float num2 = vector2_4.Y - vector2_5.Y;
      float num3 = (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2);
      float_2 = (float) Math.Sqrt((double) num3);
    }

    public static float smethod_6(Vector2 vector2_4, Vector2 vector2_5)
    {
      float num1 = vector2_4.X - vector2_5.X;
      float num2 = vector2_4.Y - vector2_5.Y;
      return (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2);
    }

    public static void smethod_7(ref Vector2 vector2_4, ref Vector2 vector2_5, out float float_2)
    {
      float num1 = vector2_4.X - vector2_5.X;
      float num2 = vector2_4.Y - vector2_5.Y;
      float_2 = (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2);
    }

    public static float smethod_8(Vector2 vector2_4, Vector2 vector2_5)
    {
      return (float) ((double) vector2_4.X * (double) vector2_5.X + (double) vector2_4.Y * (double) vector2_5.Y);
    }

    public static void smethod_9(ref Vector2 vector2_4, ref Vector2 vector2_5, out float float_2)
    {
      float_2 = (float) ((double) vector2_4.X * (double) vector2_5.X + (double) vector2_4.Y * (double) vector2_5.Y);
    }

    public void method_2()
    {
      float num = 1f / (float) Math.Sqrt((double) this.X * (double) this.X + (double) this.Y * (double) this.Y);
      this.X *= num;
      this.Y *= num;
    }

    public static Vector2 smethod_10(Vector2 vector2_4)
    {
      float num = 1f / (float) Math.Sqrt((double) vector2_4.X * (double) vector2_4.X + (double) vector2_4.Y * (double) vector2_4.Y);
      Vector2 vector2;
      vector2.X = vector2_4.X * num;
      vector2.Y = vector2_4.Y * num;
      return vector2;
    }

    public static void smethod_11(ref Vector2 vector2_4, out Vector2 vector2_5)
    {
      float num = 1f / (float) Math.Sqrt((double) vector2_4.X * (double) vector2_4.X + (double) vector2_4.Y * (double) vector2_4.Y);
      vector2_5.X = vector2_4.X * num;
      vector2_5.Y = vector2_4.Y * num;
    }

    public static Vector2 smethod_12(Vector2 vector2_4, Vector2 vector2_5)
    {
      Vector2 vector2;
      vector2.X = (double) vector2_4.X < (double) vector2_5.X ? vector2_4.X : vector2_5.X;
      vector2.Y = (double) vector2_4.Y < (double) vector2_5.Y ? vector2_4.Y : vector2_5.Y;
      return vector2;
    }

    public static void smethod_13(ref Vector2 vector2_4, ref Vector2 vector2_5, out Vector2 vector2_6)
    {
      vector2_6.X = (double) vector2_4.X < (double) vector2_5.X ? vector2_4.X : vector2_5.X;
      vector2_6.Y = (double) vector2_4.Y < (double) vector2_5.Y ? vector2_4.Y : vector2_5.Y;
    }

    public static Vector2 smethod_14(Vector2 vector2_4, Vector2 vector2_5)
    {
      Vector2 vector2;
      vector2.X = (double) vector2_4.X > (double) vector2_5.X ? vector2_4.X : vector2_5.X;
      vector2.Y = (double) vector2_4.Y > (double) vector2_5.Y ? vector2_4.Y : vector2_5.Y;
      return vector2;
    }

    public static void smethod_15(ref Vector2 vector2_4, ref Vector2 vector2_5, out Vector2 vector2_6)
    {
      vector2_6.X = (double) vector2_4.X > (double) vector2_5.X ? vector2_4.X : vector2_5.X;
      vector2_6.Y = (double) vector2_4.Y > (double) vector2_5.Y ? vector2_4.Y : vector2_5.Y;
    }

    public static Vector2 smethod_16(Vector2 vector2_4, Vector2 vector2_5, Vector2 vector2_6)
    {
      float num1 = vector2_4.X;
      float num2 = (double) num1 > (double) vector2_6.X ? vector2_6.X : num1;
      float num3 = (double) num2 < (double) vector2_5.X ? vector2_5.X : num2;
      float num4 = vector2_4.Y;
      float num5 = (double) num4 > (double) vector2_6.Y ? vector2_6.Y : num4;
      float num6 = (double) num5 < (double) vector2_5.Y ? vector2_5.Y : num5;
      Vector2 vector2;
      vector2.X = num3;
      vector2.Y = num6;
      return vector2;
    }

    public static void smethod_17(ref Vector2 vector2_4, ref Vector2 vector2_5, ref Vector2 vector2_6, out Vector2 vector2_7)
    {
      float num1 = vector2_4.X;
      float num2 = (double) num1 > (double) vector2_6.X ? vector2_6.X : num1;
      float num3 = (double) num2 < (double) vector2_5.X ? vector2_5.X : num2;
      float num4 = vector2_4.Y;
      float num5 = (double) num4 > (double) vector2_6.Y ? vector2_6.Y : num4;
      float num6 = (double) num5 < (double) vector2_5.Y ? vector2_5.Y : num5;
      vector2_7.X = num3;
      vector2_7.Y = num6;
    }

    public static Vector2 smethod_18(Vector2 vector2_4, Vector2 vector2_5, float float_2)
    {
      Vector2 vector2;
      vector2.X = vector2_4.X + (vector2_5.X - vector2_4.X) * float_2;
      vector2.Y = vector2_4.Y + (vector2_5.Y - vector2_4.Y) * float_2;
      return vector2;
    }

    public static void smethod_19(ref Vector2 vector2_4, ref Vector2 vector2_5, float float_2, out Vector2 vector2_6)
    {
      vector2_6.X = vector2_4.X + (vector2_5.X - vector2_4.X) * float_2;
      vector2_6.Y = vector2_4.Y + (vector2_5.Y - vector2_4.Y) * float_2;
    }

    public static Vector2 smethod_20(Vector2 vector2_4, Vector2 vector2_5, Vector2 vector2_6, float float_2, float float_3)
    {
      Vector2 vector2;
      vector2.X = (float) ((double) vector2_4.X + (double) float_2 * ((double) vector2_5.X - (double) vector2_4.X) + (double) float_3 * ((double) vector2_6.X - (double) vector2_4.X));
      vector2.Y = (float) ((double) vector2_4.Y + (double) float_2 * ((double) vector2_5.Y - (double) vector2_4.Y) + (double) float_3 * ((double) vector2_6.Y - (double) vector2_4.Y));
      return vector2;
    }

    public static void smethod_21(ref Vector2 vector2_4, ref Vector2 vector2_5, ref Vector2 vector2_6, float float_2, float float_3, out Vector2 vector2_7)
    {
      vector2_7.X = (float) ((double) vector2_4.X + (double) float_2 * ((double) vector2_5.X - (double) vector2_4.X) + (double) float_3 * ((double) vector2_6.X - (double) vector2_4.X));
      vector2_7.Y = (float) ((double) vector2_4.Y + (double) float_2 * ((double) vector2_5.Y - (double) vector2_4.Y) + (double) float_3 * ((double) vector2_6.Y - (double) vector2_4.Y));
    }

    public static Vector2 smethod_22(Vector2 vector2_4, Vector2 vector2_5, float float_2)
    {
      float_2 = (double) float_2 > 1.0 ? 1f : ((double) float_2 < 0.0 ? 0.0f : float_2);
      float_2 = (float) ((double) float_2 * (double) float_2 * (3.0 - 2.0 * (double) float_2));
      Vector2 vector2;
      vector2.X = vector2_4.X + (vector2_5.X - vector2_4.X) * float_2;
      vector2.Y = vector2_4.Y + (vector2_5.Y - vector2_4.Y) * float_2;
      return vector2;
    }

    public static void smethod_23(ref Vector2 vector2_4, ref Vector2 vector2_5, float float_2, out Vector2 vector2_6)
    {
      float_2 = (double) float_2 > 1.0 ? 1f : ((double) float_2 < 0.0 ? 0.0f : float_2);
      float_2 = (float) ((double) float_2 * (double) float_2 * (3.0 - 2.0 * (double) float_2));
      vector2_6.X = vector2_4.X + (vector2_5.X - vector2_4.X) * float_2;
      vector2_6.Y = vector2_4.Y + (vector2_5.Y - vector2_4.Y) * float_2;
    }

    public static Vector2 smethod_24(Vector2 vector2_4, Vector2 vector2_5, Vector2 vector2_6, Vector2 vector2_7, float float_2)
    {
      float num1 = float_2 * float_2;
      float num2 = float_2 * num1;
      Vector2 vector2;
      vector2.X = (float) (0.5 * (2.0 * (double) vector2_5.X + (-(double) vector2_4.X + (double) vector2_6.X) * (double) float_2 + (2.0 * (double) vector2_4.X - 5.0 * (double) vector2_5.X + 4.0 * (double) vector2_6.X - (double) vector2_7.X) * (double) num1 + (-(double) vector2_4.X + 3.0 * (double) vector2_5.X - 3.0 * (double) vector2_6.X + (double) vector2_7.X) * (double) num2));
      vector2.Y = (float) (0.5 * (2.0 * (double) vector2_5.Y + (-(double) vector2_4.Y + (double) vector2_6.Y) * (double) float_2 + (2.0 * (double) vector2_4.Y - 5.0 * (double) vector2_5.Y + 4.0 * (double) vector2_6.Y - (double) vector2_7.Y) * (double) num1 + (-(double) vector2_4.Y + 3.0 * (double) vector2_5.Y - 3.0 * (double) vector2_6.Y + (double) vector2_7.Y) * (double) num2));
      return vector2;
    }

    public static void smethod_25(ref Vector2 vector2_4, ref Vector2 vector2_5, ref Vector2 vector2_6, ref Vector2 vector2_7, float float_2, out Vector2 vector2_8)
    {
      float num1 = float_2 * float_2;
      float num2 = float_2 * num1;
      vector2_8.X = (float) (0.5 * (2.0 * (double) vector2_5.X + (-(double) vector2_4.X + (double) vector2_6.X) * (double) float_2 + (2.0 * (double) vector2_4.X - 5.0 * (double) vector2_5.X + 4.0 * (double) vector2_6.X - (double) vector2_7.X) * (double) num1 + (-(double) vector2_4.X + 3.0 * (double) vector2_5.X - 3.0 * (double) vector2_6.X + (double) vector2_7.X) * (double) num2));
      vector2_8.Y = (float) (0.5 * (2.0 * (double) vector2_5.Y + (-(double) vector2_4.Y + (double) vector2_6.Y) * (double) float_2 + (2.0 * (double) vector2_4.Y - 5.0 * (double) vector2_5.Y + 4.0 * (double) vector2_6.Y - (double) vector2_7.Y) * (double) num1 + (-(double) vector2_4.Y + 3.0 * (double) vector2_5.Y - 3.0 * (double) vector2_6.Y + (double) vector2_7.Y) * (double) num2));
    }

    public static Vector2 smethod_26(Vector2 vector2_4, Vector2 vector2_5, Vector2 vector2_6, Vector2 vector2_7, float float_2)
    {
      float num1 = float_2 * float_2;
      float num2 = float_2 * num1;
      float num3 = (float) (2.0 * (double) num2 - 3.0 * (double) num1 + 1.0);
      float num4 = (float) (-2.0 * (double) num2 + 3.0 * (double) num1);
      float num5 = num2 - 2f * num1 + float_2;
      float num6 = num2 - num1;
      Vector2 vector2;
      vector2.X = (float) ((double) vector2_4.X * (double) num3 + (double) vector2_6.X * (double) num4 + (double) vector2_5.X * (double) num5 + (double) vector2_7.X * (double) num6);
      vector2.Y = (float) ((double) vector2_4.Y * (double) num3 + (double) vector2_6.Y * (double) num4 + (double) vector2_5.Y * (double) num5 + (double) vector2_7.Y * (double) num6);
      return vector2;
    }

    public static void smethod_27(ref Vector2 vector2_4, ref Vector2 vector2_5, ref Vector2 vector2_6, ref Vector2 vector2_7, float float_2, out Vector2 vector2_8)
    {
      float num1 = float_2 * float_2;
      float num2 = float_2 * num1;
      float num3 = (float) (2.0 * (double) num2 - 3.0 * (double) num1 + 1.0);
      float num4 = (float) (-2.0 * (double) num2 + 3.0 * (double) num1);
      float num5 = num2 - 2f * num1 + float_2;
      float num6 = num2 - num1;
      vector2_8.X = (float) ((double) vector2_4.X * (double) num3 + (double) vector2_6.X * (double) num4 + (double) vector2_5.X * (double) num5 + (double) vector2_7.X * (double) num6);
      vector2_8.Y = (float) ((double) vector2_4.Y * (double) num3 + (double) vector2_6.Y * (double) num4 + (double) vector2_5.Y * (double) num5 + (double) vector2_7.Y * (double) num6);
    }

    public static Vector2 smethod_28(Vector2 vector2_4, Matrix matrix_0)
    {
      float num1 = (float) ((double) vector2_4.X * (double) matrix_0.M11 + (double) vector2_4.Y * (double) matrix_0.M21) + matrix_0.M41;
      float num2 = (float) ((double) vector2_4.X * (double) matrix_0.M12 + (double) vector2_4.Y * (double) matrix_0.M22) + matrix_0.M42;
      Vector2 vector2;
      vector2.X = num1;
      vector2.Y = num2;
      return vector2;
    }

    public static void smethod_29(ref Vector2 vector2_4, ref Matrix matrix_0, out Vector2 vector2_5)
    {
      float num1 = (float) ((double) vector2_4.X * (double) matrix_0.M11 + (double) vector2_4.Y * (double) matrix_0.M21) + matrix_0.M41;
      float num2 = (float) ((double) vector2_4.X * (double) matrix_0.M12 + (double) vector2_4.Y * (double) matrix_0.M22) + matrix_0.M42;
      vector2_5.X = num1;
      vector2_5.Y = num2;
    }

    public static Vector2 smethod_30(Vector2 vector2_4, Matrix matrix_0)
    {
      float num1 = (float) ((double) vector2_4.X * (double) matrix_0.M11 + (double) vector2_4.Y * (double) matrix_0.M21);
      float num2 = (float) ((double) vector2_4.X * (double) matrix_0.M12 + (double) vector2_4.Y * (double) matrix_0.M22);
      Vector2 vector2;
      vector2.X = num1;
      vector2.Y = num2;
      return vector2;
    }

    public static void smethod_31(ref Vector2 vector2_4, ref Matrix matrix_0, out Vector2 vector2_5)
    {
      float num1 = (float) ((double) vector2_4.X * (double) matrix_0.M11 + (double) vector2_4.Y * (double) matrix_0.M21);
      float num2 = (float) ((double) vector2_4.X * (double) matrix_0.M12 + (double) vector2_4.Y * (double) matrix_0.M22);
      vector2_5.X = num1;
      vector2_5.Y = num2;
    }

    public static void smethod_32(Vector2[] vector2_4, ref Matrix matrix_0, Vector2[] vector2_5)
    {
      if (vector2_4 == null)
        throw new ArgumentNullException("values");
      if (vector2_5 == null)
        throw new ArgumentNullException("results");
      if (vector2_5.Length < vector2_4.Length)
        throw new IndexOutOfRangeException(Class1070.smethod_10());
      for (int index = 0; index < vector2_4.Length; ++index)
      {
        float num1 = vector2_4[index].X;
        float num2 = vector2_4[index].Y;
        vector2_5[index].X = (float) ((double) num1 * (double) matrix_0.M11 + (double) num2 * (double) matrix_0.M21) + matrix_0.M41;
        vector2_5[index].Y = (float) ((double) num1 * (double) matrix_0.M12 + (double) num2 * (double) matrix_0.M22) + matrix_0.M42;
      }
    }

    public static void smethod_33(Vector2[] vector2_4, int int_0, ref Matrix matrix_0, Vector2[] vector2_5, int int_1, int int_2)
    {
      if (vector2_4 == null)
        throw new ArgumentNullException("values");
      if (vector2_5 == null)
        throw new ArgumentNullException("results");
      if ((long) vector2_5.Length < (long) int_1 + (long) int_2)
        throw new IndexOutOfRangeException(Class1070.smethod_10());
      for (; int_2 > 0; --int_2)
      {
        float num1 = vector2_4[int_0].X;
        float num2 = vector2_4[int_0].Y;
        vector2_5[int_1].X = (float) ((double) num1 * (double) matrix_0.M11 + (double) num2 * (double) matrix_0.M21) + matrix_0.M41;
        vector2_5[int_1].Y = (float) ((double) num1 * (double) matrix_0.M12 + (double) num2 * (double) matrix_0.M22) + matrix_0.M42;
        ++int_0;
        ++int_1;
      }
    }

    public static void smethod_34(Vector2[] vector2_4, ref Matrix matrix_0, Vector2[] vector2_5)
    {
      if (vector2_4 == null)
        throw new ArgumentNullException("values");
      if (vector2_5 == null)
        throw new ArgumentNullException("results");
      if (vector2_5.Length < vector2_4.Length)
        throw new IndexOutOfRangeException(Class1070.smethod_10());
      for (int index = 0; index < vector2_4.Length; ++index)
      {
        float num1 = vector2_4[index].X;
        float num2 = vector2_4[index].Y;
        vector2_5[index].X = (float) ((double) num1 * (double) matrix_0.M11 + (double) num2 * (double) matrix_0.M21);
        vector2_5[index].Y = (float) ((double) num1 * (double) matrix_0.M12 + (double) num2 * (double) matrix_0.M22);
      }
    }

    public static void smethod_35(Vector2[] vector2_4, int int_0, ref Matrix matrix_0, Vector2[] vector2_5, int int_1, int int_2)
    {
      if (vector2_4 == null)
        throw new ArgumentNullException("values");
      if (vector2_5 == null)
        throw new ArgumentNullException("results");
      if ((long) vector2_5.Length < (long) int_1 + (long) int_2)
        throw new IndexOutOfRangeException(Class1070.smethod_10());
      for (; int_2 > 0; --int_2)
      {
        float num1 = vector2_4[int_0].X;
        float num2 = vector2_4[int_0].Y;
        vector2_5[int_1].X = (float) ((double) num1 * (double) matrix_0.M11 + (double) num2 * (double) matrix_0.M21);
        vector2_5[int_1].Y = (float) ((double) num1 * (double) matrix_0.M12 + (double) num2 * (double) matrix_0.M22);
        ++int_0;
        ++int_1;
      }
    }

    public static Vector2 smethod_36(Vector2 vector2_4)
    {
      Vector2 vector2;
      vector2.X = -vector2_4.X;
      vector2.Y = -vector2_4.Y;
      return vector2;
    }

    public static void smethod_37(ref Vector2 vector2_4, out Vector2 vector2_5)
    {
      vector2_5.X = -vector2_4.X;
      vector2_5.Y = -vector2_4.Y;
    }

    public static Vector2 smethod_38(Vector2 vector2_4, Vector2 vector2_5)
    {
      Vector2 vector2;
      vector2.X = vector2_4.X + vector2_5.X;
      vector2.Y = vector2_4.Y + vector2_5.Y;
      return vector2;
    }

    public static void smethod_39(ref Vector2 vector2_4, ref Vector2 vector2_5, out Vector2 vector2_6)
    {
      vector2_6.X = vector2_4.X + vector2_5.X;
      vector2_6.Y = vector2_4.Y + vector2_5.Y;
    }

    public static Vector2 smethod_40(Vector2 vector2_4, Vector2 vector2_5)
    {
      Vector2 vector2;
      vector2.X = vector2_4.X - vector2_5.X;
      vector2.Y = vector2_4.Y - vector2_5.Y;
      return vector2;
    }

    public static void smethod_41(ref Vector2 vector2_4, ref Vector2 vector2_5, out Vector2 vector2_6)
    {
      vector2_6.X = vector2_4.X - vector2_5.X;
      vector2_6.Y = vector2_4.Y - vector2_5.Y;
    }

    public static Vector2 smethod_42(Vector2 vector2_4, Vector2 vector2_5)
    {
      Vector2 vector2;
      vector2.X = vector2_4.X * vector2_5.X;
      vector2.Y = vector2_4.Y * vector2_5.Y;
      return vector2;
    }

    public static void smethod_43(ref Vector2 vector2_4, ref Vector2 vector2_5, out Vector2 vector2_6)
    {
      vector2_6.X = vector2_4.X * vector2_5.X;
      vector2_6.Y = vector2_4.Y * vector2_5.Y;
    }

    public static Vector2 smethod_44(Vector2 vector2_4, float float_2)
    {
      Vector2 vector2;
      vector2.X = vector2_4.X * float_2;
      vector2.Y = vector2_4.Y * float_2;
      return vector2;
    }

    public static void smethod_45(ref Vector2 vector2_4, float float_2, out Vector2 vector2_5)
    {
      vector2_5.X = vector2_4.X * float_2;
      vector2_5.Y = vector2_4.Y * float_2;
    }

    public static Vector2 smethod_46(Vector2 vector2_4, Vector2 vector2_5)
    {
      Vector2 vector2;
      vector2.X = vector2_4.X / vector2_5.X;
      vector2.Y = vector2_4.Y / vector2_5.Y;
      return vector2;
    }

    public static void smethod_47(ref Vector2 vector2_4, ref Vector2 vector2_5, out Vector2 vector2_6)
    {
      vector2_6.X = vector2_4.X / vector2_5.X;
      vector2_6.Y = vector2_4.Y / vector2_5.Y;
    }

    public static Vector2 smethod_48(Vector2 vector2_4, float float_2)
    {
      float num = 1f / float_2;
      Vector2 vector2;
      vector2.X = vector2_4.X * num;
      vector2.Y = vector2_4.Y * num;
      return vector2;
    }

    public static void smethod_49(ref Vector2 vector2_4, float float_2, out Vector2 vector2_5)
    {
      float num = 1f / float_2;
      vector2_5.X = vector2_4.X * num;
      vector2_5.Y = vector2_4.Y * num;
    }
  }
}
