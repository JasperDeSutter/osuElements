// Decompiled with JetBrains decompiler
// Type: Microsoft.Xna.Framework.Vector4
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
  public struct Vector4 : IEquatable<Vector4>
  {
    private static Vector4 vector4_0 = new Vector4();
    private static Vector4 vector4_1 = new Vector4(1f, 1f, 1f, 1f);
    private static Vector4 vector4_2 = new Vector4(1f, 0.0f, 0.0f, 0.0f);
    private static Vector4 vector4_3 = new Vector4(0.0f, 1f, 0.0f, 0.0f);
    private static Vector4 vector4_4 = new Vector4(0.0f, 0.0f, 1f, 0.0f);
    private static Vector4 vector4_5 = new Vector4(0.0f, 0.0f, 0.0f, 1f);
    public float float_0;
    public float float_1;
    public float float_2;
    public float float_3;

    public Vector4(float float_4, float float_5, float float_6, float float_7)
    {
      this.float_0 = float_4;
      this.float_1 = float_5;
      this.float_2 = float_6;
      this.float_3 = float_7;
    }

    public Vector4(Vector2 vector2_0, float float_4, float float_5)
    {
      this.float_0 = vector2_0.X;
      this.float_1 = vector2_0.Y;
      this.float_2 = float_4;
      this.float_3 = float_5;
    }

    public Vector4(Vector3 vector3_0, float float_4)
    {
      this.float_0 = vector3_0.float_0;
      this.float_1 = vector3_0.float_1;
      this.float_2 = vector3_0.float_2;
      this.float_3 = float_4;
    }

    public Vector4(float float_4)
    {
      this.float_3 = float_4;
      this.float_2 = float_4;
      this.float_1 = float_4;
      this.float_0 = float_4;
    }

    public static Vector4 operator -(Vector4 vector4_6)
    {
      Vector4 vector4;
      vector4.float_0 = -vector4_6.float_0;
      vector4.float_1 = -vector4_6.float_1;
      vector4.float_2 = -vector4_6.float_2;
      vector4.float_3 = -vector4_6.float_3;
      return vector4;
    }

    public static bool operator ==(Vector4 vector4_6, Vector4 vector4_7)
    {
      if ((double) vector4_6.float_0 == (double) vector4_7.float_0 && (double) vector4_6.float_1 == (double) vector4_7.float_1 && (double) vector4_6.float_2 == (double) vector4_7.float_2)
        return (double) vector4_6.float_3 == (double) vector4_7.float_3;
      return false;
    }

    public static bool operator !=(Vector4 vector4_6, Vector4 vector4_7)
    {
      if ((double) vector4_6.float_0 == (double) vector4_7.float_0 && (double) vector4_6.float_1 == (double) vector4_7.float_1 && (double) vector4_6.float_2 == (double) vector4_7.float_2)
        return (double) vector4_6.float_3 != (double) vector4_7.float_3;
      return true;
    }

    public static Vector4 operator +(Vector4 vector4_6, Vector4 vector4_7)
    {
      Vector4 vector4;
      vector4.float_0 = vector4_6.float_0 + vector4_7.float_0;
      vector4.float_1 = vector4_6.float_1 + vector4_7.float_1;
      vector4.float_2 = vector4_6.float_2 + vector4_7.float_2;
      vector4.float_3 = vector4_6.float_3 + vector4_7.float_3;
      return vector4;
    }

    public static Vector4 operator -(Vector4 vector4_6, Vector4 vector4_7)
    {
      Vector4 vector4;
      vector4.float_0 = vector4_6.float_0 - vector4_7.float_0;
      vector4.float_1 = vector4_6.float_1 - vector4_7.float_1;
      vector4.float_2 = vector4_6.float_2 - vector4_7.float_2;
      vector4.float_3 = vector4_6.float_3 - vector4_7.float_3;
      return vector4;
    }

    public static Vector4 operator *(Vector4 vector4_6, Vector4 vector4_7)
    {
      Vector4 vector4;
      vector4.float_0 = vector4_6.float_0 * vector4_7.float_0;
      vector4.float_1 = vector4_6.float_1 * vector4_7.float_1;
      vector4.float_2 = vector4_6.float_2 * vector4_7.float_2;
      vector4.float_3 = vector4_6.float_3 * vector4_7.float_3;
      return vector4;
    }

    public static Vector4 operator *(Vector4 vector4_6, float float_4)
    {
      Vector4 vector4;
      vector4.float_0 = vector4_6.float_0 * float_4;
      vector4.float_1 = vector4_6.float_1 * float_4;
      vector4.float_2 = vector4_6.float_2 * float_4;
      vector4.float_3 = vector4_6.float_3 * float_4;
      return vector4;
    }

    public static Vector4 operator *(float float_4, Vector4 vector4_6)
    {
      Vector4 vector4;
      vector4.float_0 = vector4_6.float_0 * float_4;
      vector4.float_1 = vector4_6.float_1 * float_4;
      vector4.float_2 = vector4_6.float_2 * float_4;
      vector4.float_3 = vector4_6.float_3 * float_4;
      return vector4;
    }

    public static Vector4 operator /(Vector4 vector4_6, Vector4 vector4_7)
    {
      Vector4 vector4;
      vector4.float_0 = vector4_6.float_0 / vector4_7.float_0;
      vector4.float_1 = vector4_6.float_1 / vector4_7.float_1;
      vector4.float_2 = vector4_6.float_2 / vector4_7.float_2;
      vector4.float_3 = vector4_6.float_3 / vector4_7.float_3;
      return vector4;
    }

    public static Vector4 operator /(Vector4 vector4_6, float float_4)
    {
      float num = 1f / float_4;
      Vector4 vector4;
      vector4.float_0 = vector4_6.float_0 * num;
      vector4.float_1 = vector4_6.float_1 * num;
      vector4.float_2 = vector4_6.float_2 * num;
      vector4.float_3 = vector4_6.float_3 * num;
      return vector4;
    }

    public static Vector4 smethod_0()
    {
      return Vector4.vector4_0;
    }

    public static Vector4 smethod_1()
    {
      return Vector4.vector4_1;
    }

    public static Vector4 smethod_2()
    {
      return Vector4.vector4_2;
    }

    public static Vector4 smethod_3()
    {
      return Vector4.vector4_3;
    }

    public static Vector4 smethod_4()
    {
      return Vector4.vector4_4;
    }

    public static Vector4 smethod_5()
    {
      return Vector4.vector4_5;
    }

    public override string ToString()
    {
      CultureInfo currentCulture = CultureInfo.CurrentCulture;
      return string.Format((IFormatProvider) currentCulture, "{{X:{0} Y:{1} Z:{2} W:{3}}}", (object) this.float_0.ToString((IFormatProvider) currentCulture), (object) this.float_1.ToString((IFormatProvider) currentCulture), (object) this.float_2.ToString((IFormatProvider) currentCulture), (object) this.float_3.ToString((IFormatProvider) currentCulture));
    }

    public bool Equals(Vector4 other)
    {
      if ((double) this.float_0 == (double) other.float_0 && (double) this.float_1 == (double) other.float_1 && (double) this.float_2 == (double) other.float_2)
        return (double) this.float_3 == (double) other.float_3;
      return false;
    }

    public override bool Equals(object obj)
    {
      bool flag = false;
      if (obj is Vector4)
        flag = this.Equals((Vector4) obj);
      return flag;
    }

    public override int GetHashCode()
    {
      return this.float_0.GetHashCode() + this.float_1.GetHashCode() + this.float_2.GetHashCode() + this.float_3.GetHashCode();
    }

    public float method_0()
    {
      return (float) Math.Sqrt((double) this.float_0 * (double) this.float_0 + (double) this.float_1 * (double) this.float_1 + (double) this.float_2 * (double) this.float_2 + (double) this.float_3 * (double) this.float_3);
    }

    public float method_1()
    {
      return (float) ((double) this.float_0 * (double) this.float_0 + (double) this.float_1 * (double) this.float_1 + (double) this.float_2 * (double) this.float_2 + (double) this.float_3 * (double) this.float_3);
    }

    public static float smethod_6(Vector4 vector4_6, Vector4 vector4_7)
    {
      float num1 = vector4_6.float_0 - vector4_7.float_0;
      float num2 = vector4_6.float_1 - vector4_7.float_1;
      float num3 = vector4_6.float_2 - vector4_7.float_2;
      float num4 = vector4_6.float_3 - vector4_7.float_3;
      return (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2 + (double) num3 * (double) num3 + (double) num4 * (double) num4);
    }

    public static void smethod_7(ref Vector4 vector4_6, ref Vector4 vector4_7, out float float_4)
    {
      float num1 = vector4_6.float_0 - vector4_7.float_0;
      float num2 = vector4_6.float_1 - vector4_7.float_1;
      float num3 = vector4_6.float_2 - vector4_7.float_2;
      float num4 = vector4_6.float_3 - vector4_7.float_3;
      float num5 = (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2 + (double) num3 * (double) num3 + (double) num4 * (double) num4);
      float_4 = (float) Math.Sqrt((double) num5);
    }

    public static float smethod_8(Vector4 vector4_6, Vector4 vector4_7)
    {
      float num1 = vector4_6.float_0 - vector4_7.float_0;
      float num2 = vector4_6.float_1 - vector4_7.float_1;
      float num3 = vector4_6.float_2 - vector4_7.float_2;
      float num4 = vector4_6.float_3 - vector4_7.float_3;
      return (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2 + (double) num3 * (double) num3 + (double) num4 * (double) num4);
    }

    public static void smethod_9(ref Vector4 vector4_6, ref Vector4 vector4_7, out float float_4)
    {
      float num1 = vector4_6.float_0 - vector4_7.float_0;
      float num2 = vector4_6.float_1 - vector4_7.float_1;
      float num3 = vector4_6.float_2 - vector4_7.float_2;
      float num4 = vector4_6.float_3 - vector4_7.float_3;
      float_4 = (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2 + (double) num3 * (double) num3 + (double) num4 * (double) num4);
    }

    public static float smethod_10(Vector4 vector4_6, Vector4 vector4_7)
    {
      return (float) ((double) vector4_6.float_0 * (double) vector4_7.float_0 + (double) vector4_6.float_1 * (double) vector4_7.float_1 + (double) vector4_6.float_2 * (double) vector4_7.float_2 + (double) vector4_6.float_3 * (double) vector4_7.float_3);
    }

    public static void smethod_11(ref Vector4 vector4_6, ref Vector4 vector4_7, out float float_4)
    {
      float_4 = (float) ((double) vector4_6.float_0 * (double) vector4_7.float_0 + (double) vector4_6.float_1 * (double) vector4_7.float_1 + (double) vector4_6.float_2 * (double) vector4_7.float_2 + (double) vector4_6.float_3 * (double) vector4_7.float_3);
    }

    public void method_2()
    {
      float num = 1f / (float) Math.Sqrt((double) this.float_0 * (double) this.float_0 + (double) this.float_1 * (double) this.float_1 + (double) this.float_2 * (double) this.float_2 + (double) this.float_3 * (double) this.float_3);
      this.float_0 *= num;
      this.float_1 *= num;
      this.float_2 *= num;
      this.float_3 *= num;
    }

    public static Vector4 smethod_12(Vector4 vector4_6)
    {
      float num = 1f / (float) Math.Sqrt((double) vector4_6.float_0 * (double) vector4_6.float_0 + (double) vector4_6.float_1 * (double) vector4_6.float_1 + (double) vector4_6.float_2 * (double) vector4_6.float_2 + (double) vector4_6.float_3 * (double) vector4_6.float_3);
      Vector4 vector4;
      vector4.float_0 = vector4_6.float_0 * num;
      vector4.float_1 = vector4_6.float_1 * num;
      vector4.float_2 = vector4_6.float_2 * num;
      vector4.float_3 = vector4_6.float_3 * num;
      return vector4;
    }

    public static void smethod_13(ref Vector4 vector4_6, out Vector4 vector4_7)
    {
      float num = 1f / (float) Math.Sqrt((double) vector4_6.float_0 * (double) vector4_6.float_0 + (double) vector4_6.float_1 * (double) vector4_6.float_1 + (double) vector4_6.float_2 * (double) vector4_6.float_2 + (double) vector4_6.float_3 * (double) vector4_6.float_3);
      vector4_7.float_0 = vector4_6.float_0 * num;
      vector4_7.float_1 = vector4_6.float_1 * num;
      vector4_7.float_2 = vector4_6.float_2 * num;
      vector4_7.float_3 = vector4_6.float_3 * num;
    }

    public static Vector4 smethod_14(Vector4 vector4_6, Vector4 vector4_7)
    {
      Vector4 vector4;
      vector4.float_0 = (double) vector4_6.float_0 < (double) vector4_7.float_0 ? vector4_6.float_0 : vector4_7.float_0;
      vector4.float_1 = (double) vector4_6.float_1 < (double) vector4_7.float_1 ? vector4_6.float_1 : vector4_7.float_1;
      vector4.float_2 = (double) vector4_6.float_2 < (double) vector4_7.float_2 ? vector4_6.float_2 : vector4_7.float_2;
      vector4.float_3 = (double) vector4_6.float_3 < (double) vector4_7.float_3 ? vector4_6.float_3 : vector4_7.float_3;
      return vector4;
    }

    public static void smethod_15(ref Vector4 vector4_6, ref Vector4 vector4_7, out Vector4 vector4_8)
    {
      vector4_8.float_0 = (double) vector4_6.float_0 < (double) vector4_7.float_0 ? vector4_6.float_0 : vector4_7.float_0;
      vector4_8.float_1 = (double) vector4_6.float_1 < (double) vector4_7.float_1 ? vector4_6.float_1 : vector4_7.float_1;
      vector4_8.float_2 = (double) vector4_6.float_2 < (double) vector4_7.float_2 ? vector4_6.float_2 : vector4_7.float_2;
      vector4_8.float_3 = (double) vector4_6.float_3 < (double) vector4_7.float_3 ? vector4_6.float_3 : vector4_7.float_3;
    }

    public static Vector4 smethod_16(Vector4 vector4_6, Vector4 vector4_7)
    {
      Vector4 vector4;
      vector4.float_0 = (double) vector4_6.float_0 > (double) vector4_7.float_0 ? vector4_6.float_0 : vector4_7.float_0;
      vector4.float_1 = (double) vector4_6.float_1 > (double) vector4_7.float_1 ? vector4_6.float_1 : vector4_7.float_1;
      vector4.float_2 = (double) vector4_6.float_2 > (double) vector4_7.float_2 ? vector4_6.float_2 : vector4_7.float_2;
      vector4.float_3 = (double) vector4_6.float_3 > (double) vector4_7.float_3 ? vector4_6.float_3 : vector4_7.float_3;
      return vector4;
    }

    public static void smethod_17(ref Vector4 vector4_6, ref Vector4 vector4_7, out Vector4 vector4_8)
    {
      vector4_8.float_0 = (double) vector4_6.float_0 > (double) vector4_7.float_0 ? vector4_6.float_0 : vector4_7.float_0;
      vector4_8.float_1 = (double) vector4_6.float_1 > (double) vector4_7.float_1 ? vector4_6.float_1 : vector4_7.float_1;
      vector4_8.float_2 = (double) vector4_6.float_2 > (double) vector4_7.float_2 ? vector4_6.float_2 : vector4_7.float_2;
      vector4_8.float_3 = (double) vector4_6.float_3 > (double) vector4_7.float_3 ? vector4_6.float_3 : vector4_7.float_3;
    }

    public static Vector4 smethod_18(Vector4 vector4_6, Vector4 vector4_7, Vector4 vector4_8)
    {
      float num1 = vector4_6.float_0;
      float num2 = (double) num1 > (double) vector4_8.float_0 ? vector4_8.float_0 : num1;
      float num3 = (double) num2 < (double) vector4_7.float_0 ? vector4_7.float_0 : num2;
      float num4 = vector4_6.float_1;
      float num5 = (double) num4 > (double) vector4_8.float_1 ? vector4_8.float_1 : num4;
      float num6 = (double) num5 < (double) vector4_7.float_1 ? vector4_7.float_1 : num5;
      float num7 = vector4_6.float_2;
      float num8 = (double) num7 > (double) vector4_8.float_2 ? vector4_8.float_2 : num7;
      float num9 = (double) num8 < (double) vector4_7.float_2 ? vector4_7.float_2 : num8;
      float num10 = vector4_6.float_3;
      float num11 = (double) num10 > (double) vector4_8.float_3 ? vector4_8.float_3 : num10;
      float num12 = (double) num11 < (double) vector4_7.float_3 ? vector4_7.float_3 : num11;
      Vector4 vector4;
      vector4.float_0 = num3;
      vector4.float_1 = num6;
      vector4.float_2 = num9;
      vector4.float_3 = num12;
      return vector4;
    }

    public static void smethod_19(ref Vector4 vector4_6, ref Vector4 vector4_7, ref Vector4 vector4_8, out Vector4 vector4_9)
    {
      float num1 = vector4_6.float_0;
      float num2 = (double) num1 > (double) vector4_8.float_0 ? vector4_8.float_0 : num1;
      float num3 = (double) num2 < (double) vector4_7.float_0 ? vector4_7.float_0 : num2;
      float num4 = vector4_6.float_1;
      float num5 = (double) num4 > (double) vector4_8.float_1 ? vector4_8.float_1 : num4;
      float num6 = (double) num5 < (double) vector4_7.float_1 ? vector4_7.float_1 : num5;
      float num7 = vector4_6.float_2;
      float num8 = (double) num7 > (double) vector4_8.float_2 ? vector4_8.float_2 : num7;
      float num9 = (double) num8 < (double) vector4_7.float_2 ? vector4_7.float_2 : num8;
      float num10 = vector4_6.float_3;
      float num11 = (double) num10 > (double) vector4_8.float_3 ? vector4_8.float_3 : num10;
      float num12 = (double) num11 < (double) vector4_7.float_3 ? vector4_7.float_3 : num11;
      vector4_9.float_0 = num3;
      vector4_9.float_1 = num6;
      vector4_9.float_2 = num9;
      vector4_9.float_3 = num12;
    }

    public static Vector4 smethod_20(Vector4 vector4_6, Vector4 vector4_7, float float_4)
    {
      Vector4 vector4;
      vector4.float_0 = vector4_6.float_0 + (vector4_7.float_0 - vector4_6.float_0) * float_4;
      vector4.float_1 = vector4_6.float_1 + (vector4_7.float_1 - vector4_6.float_1) * float_4;
      vector4.float_2 = vector4_6.float_2 + (vector4_7.float_2 - vector4_6.float_2) * float_4;
      vector4.float_3 = vector4_6.float_3 + (vector4_7.float_3 - vector4_6.float_3) * float_4;
      return vector4;
    }

    public static void smethod_21(ref Vector4 vector4_6, ref Vector4 vector4_7, float float_4, out Vector4 vector4_8)
    {
      vector4_8.float_0 = vector4_6.float_0 + (vector4_7.float_0 - vector4_6.float_0) * float_4;
      vector4_8.float_1 = vector4_6.float_1 + (vector4_7.float_1 - vector4_6.float_1) * float_4;
      vector4_8.float_2 = vector4_6.float_2 + (vector4_7.float_2 - vector4_6.float_2) * float_4;
      vector4_8.float_3 = vector4_6.float_3 + (vector4_7.float_3 - vector4_6.float_3) * float_4;
    }

    public static Vector4 smethod_22(Vector4 vector4_6, Vector4 vector4_7, Vector4 vector4_8, float float_4, float float_5)
    {
      Vector4 vector4;
      vector4.float_0 = (float) ((double) vector4_6.float_0 + (double) float_4 * ((double) vector4_7.float_0 - (double) vector4_6.float_0) + (double) float_5 * ((double) vector4_8.float_0 - (double) vector4_6.float_0));
      vector4.float_1 = (float) ((double) vector4_6.float_1 + (double) float_4 * ((double) vector4_7.float_1 - (double) vector4_6.float_1) + (double) float_5 * ((double) vector4_8.float_1 - (double) vector4_6.float_1));
      vector4.float_2 = (float) ((double) vector4_6.float_2 + (double) float_4 * ((double) vector4_7.float_2 - (double) vector4_6.float_2) + (double) float_5 * ((double) vector4_8.float_2 - (double) vector4_6.float_2));
      vector4.float_3 = (float) ((double) vector4_6.float_3 + (double) float_4 * ((double) vector4_7.float_3 - (double) vector4_6.float_3) + (double) float_5 * ((double) vector4_8.float_3 - (double) vector4_6.float_3));
      return vector4;
    }

    public static void smethod_23(ref Vector4 vector4_6, ref Vector4 vector4_7, ref Vector4 vector4_8, float float_4, float float_5, out Vector4 vector4_9)
    {
      vector4_9.float_0 = (float) ((double) vector4_6.float_0 + (double) float_4 * ((double) vector4_7.float_0 - (double) vector4_6.float_0) + (double) float_5 * ((double) vector4_8.float_0 - (double) vector4_6.float_0));
      vector4_9.float_1 = (float) ((double) vector4_6.float_1 + (double) float_4 * ((double) vector4_7.float_1 - (double) vector4_6.float_1) + (double) float_5 * ((double) vector4_8.float_1 - (double) vector4_6.float_1));
      vector4_9.float_2 = (float) ((double) vector4_6.float_2 + (double) float_4 * ((double) vector4_7.float_2 - (double) vector4_6.float_2) + (double) float_5 * ((double) vector4_8.float_2 - (double) vector4_6.float_2));
      vector4_9.float_3 = (float) ((double) vector4_6.float_3 + (double) float_4 * ((double) vector4_7.float_3 - (double) vector4_6.float_3) + (double) float_5 * ((double) vector4_8.float_3 - (double) vector4_6.float_3));
    }

    public static Vector4 smethod_24(Vector4 vector4_6, Vector4 vector4_7, float float_4)
    {
      float_4 = (double) float_4 > 1.0 ? 1f : ((double) float_4 < 0.0 ? 0.0f : float_4);
      float_4 = (float) ((double) float_4 * (double) float_4 * (3.0 - 2.0 * (double) float_4));
      Vector4 vector4;
      vector4.float_0 = vector4_6.float_0 + (vector4_7.float_0 - vector4_6.float_0) * float_4;
      vector4.float_1 = vector4_6.float_1 + (vector4_7.float_1 - vector4_6.float_1) * float_4;
      vector4.float_2 = vector4_6.float_2 + (vector4_7.float_2 - vector4_6.float_2) * float_4;
      vector4.float_3 = vector4_6.float_3 + (vector4_7.float_3 - vector4_6.float_3) * float_4;
      return vector4;
    }

    public static void smethod_25(ref Vector4 vector4_6, ref Vector4 vector4_7, float float_4, out Vector4 vector4_8)
    {
      float_4 = (double) float_4 > 1.0 ? 1f : ((double) float_4 < 0.0 ? 0.0f : float_4);
      float_4 = (float) ((double) float_4 * (double) float_4 * (3.0 - 2.0 * (double) float_4));
      vector4_8.float_0 = vector4_6.float_0 + (vector4_7.float_0 - vector4_6.float_0) * float_4;
      vector4_8.float_1 = vector4_6.float_1 + (vector4_7.float_1 - vector4_6.float_1) * float_4;
      vector4_8.float_2 = vector4_6.float_2 + (vector4_7.float_2 - vector4_6.float_2) * float_4;
      vector4_8.float_3 = vector4_6.float_3 + (vector4_7.float_3 - vector4_6.float_3) * float_4;
    }

    public static Vector4 smethod_26(Vector4 vector4_6, Vector4 vector4_7, Vector4 vector4_8, Vector4 vector4_9, float float_4)
    {
      float num1 = float_4 * float_4;
      float num2 = float_4 * num1;
      Vector4 vector4;
      vector4.float_0 = (float) (0.5 * (2.0 * (double) vector4_7.float_0 + (-(double) vector4_6.float_0 + (double) vector4_8.float_0) * (double) float_4 + (2.0 * (double) vector4_6.float_0 - 5.0 * (double) vector4_7.float_0 + 4.0 * (double) vector4_8.float_0 - (double) vector4_9.float_0) * (double) num1 + (-(double) vector4_6.float_0 + 3.0 * (double) vector4_7.float_0 - 3.0 * (double) vector4_8.float_0 + (double) vector4_9.float_0) * (double) num2));
      vector4.float_1 = (float) (0.5 * (2.0 * (double) vector4_7.float_1 + (-(double) vector4_6.float_1 + (double) vector4_8.float_1) * (double) float_4 + (2.0 * (double) vector4_6.float_1 - 5.0 * (double) vector4_7.float_1 + 4.0 * (double) vector4_8.float_1 - (double) vector4_9.float_1) * (double) num1 + (-(double) vector4_6.float_1 + 3.0 * (double) vector4_7.float_1 - 3.0 * (double) vector4_8.float_1 + (double) vector4_9.float_1) * (double) num2));
      vector4.float_2 = (float) (0.5 * (2.0 * (double) vector4_7.float_2 + (-(double) vector4_6.float_2 + (double) vector4_8.float_2) * (double) float_4 + (2.0 * (double) vector4_6.float_2 - 5.0 * (double) vector4_7.float_2 + 4.0 * (double) vector4_8.float_2 - (double) vector4_9.float_2) * (double) num1 + (-(double) vector4_6.float_2 + 3.0 * (double) vector4_7.float_2 - 3.0 * (double) vector4_8.float_2 + (double) vector4_9.float_2) * (double) num2));
      vector4.float_3 = (float) (0.5 * (2.0 * (double) vector4_7.float_3 + (-(double) vector4_6.float_3 + (double) vector4_8.float_3) * (double) float_4 + (2.0 * (double) vector4_6.float_3 - 5.0 * (double) vector4_7.float_3 + 4.0 * (double) vector4_8.float_3 - (double) vector4_9.float_3) * (double) num1 + (-(double) vector4_6.float_3 + 3.0 * (double) vector4_7.float_3 - 3.0 * (double) vector4_8.float_3 + (double) vector4_9.float_3) * (double) num2));
      return vector4;
    }

    public static void smethod_27(ref Vector4 vector4_6, ref Vector4 vector4_7, ref Vector4 vector4_8, ref Vector4 vector4_9, float float_4, out Vector4 vector4_10)
    {
      float num1 = float_4 * float_4;
      float num2 = float_4 * num1;
      vector4_10.float_0 = (float) (0.5 * (2.0 * (double) vector4_7.float_0 + (-(double) vector4_6.float_0 + (double) vector4_8.float_0) * (double) float_4 + (2.0 * (double) vector4_6.float_0 - 5.0 * (double) vector4_7.float_0 + 4.0 * (double) vector4_8.float_0 - (double) vector4_9.float_0) * (double) num1 + (-(double) vector4_6.float_0 + 3.0 * (double) vector4_7.float_0 - 3.0 * (double) vector4_8.float_0 + (double) vector4_9.float_0) * (double) num2));
      vector4_10.float_1 = (float) (0.5 * (2.0 * (double) vector4_7.float_1 + (-(double) vector4_6.float_1 + (double) vector4_8.float_1) * (double) float_4 + (2.0 * (double) vector4_6.float_1 - 5.0 * (double) vector4_7.float_1 + 4.0 * (double) vector4_8.float_1 - (double) vector4_9.float_1) * (double) num1 + (-(double) vector4_6.float_1 + 3.0 * (double) vector4_7.float_1 - 3.0 * (double) vector4_8.float_1 + (double) vector4_9.float_1) * (double) num2));
      vector4_10.float_2 = (float) (0.5 * (2.0 * (double) vector4_7.float_2 + (-(double) vector4_6.float_2 + (double) vector4_8.float_2) * (double) float_4 + (2.0 * (double) vector4_6.float_2 - 5.0 * (double) vector4_7.float_2 + 4.0 * (double) vector4_8.float_2 - (double) vector4_9.float_2) * (double) num1 + (-(double) vector4_6.float_2 + 3.0 * (double) vector4_7.float_2 - 3.0 * (double) vector4_8.float_2 + (double) vector4_9.float_2) * (double) num2));
      vector4_10.float_3 = (float) (0.5 * (2.0 * (double) vector4_7.float_3 + (-(double) vector4_6.float_3 + (double) vector4_8.float_3) * (double) float_4 + (2.0 * (double) vector4_6.float_3 - 5.0 * (double) vector4_7.float_3 + 4.0 * (double) vector4_8.float_3 - (double) vector4_9.float_3) * (double) num1 + (-(double) vector4_6.float_3 + 3.0 * (double) vector4_7.float_3 - 3.0 * (double) vector4_8.float_3 + (double) vector4_9.float_3) * (double) num2));
    }

    public static Vector4 smethod_28(Vector4 vector4_6, Vector4 vector4_7, Vector4 vector4_8, Vector4 vector4_9, float float_4)
    {
      float num1 = float_4 * float_4;
      float num2 = float_4 * num1;
      float num3 = (float) (2.0 * (double) num2 - 3.0 * (double) num1 + 1.0);
      float num4 = (float) (-2.0 * (double) num2 + 3.0 * (double) num1);
      float num5 = num2 - 2f * num1 + float_4;
      float num6 = num2 - num1;
      Vector4 vector4;
      vector4.float_0 = (float) ((double) vector4_6.float_0 * (double) num3 + (double) vector4_8.float_0 * (double) num4 + (double) vector4_7.float_0 * (double) num5 + (double) vector4_9.float_0 * (double) num6);
      vector4.float_1 = (float) ((double) vector4_6.float_1 * (double) num3 + (double) vector4_8.float_1 * (double) num4 + (double) vector4_7.float_1 * (double) num5 + (double) vector4_9.float_1 * (double) num6);
      vector4.float_2 = (float) ((double) vector4_6.float_2 * (double) num3 + (double) vector4_8.float_2 * (double) num4 + (double) vector4_7.float_2 * (double) num5 + (double) vector4_9.float_2 * (double) num6);
      vector4.float_3 = (float) ((double) vector4_6.float_3 * (double) num3 + (double) vector4_8.float_3 * (double) num4 + (double) vector4_7.float_3 * (double) num5 + (double) vector4_9.float_3 * (double) num6);
      return vector4;
    }

    public static void smethod_29(ref Vector4 vector4_6, ref Vector4 vector4_7, ref Vector4 vector4_8, ref Vector4 vector4_9, float float_4, out Vector4 vector4_10)
    {
      float num1 = float_4 * float_4;
      float num2 = float_4 * num1;
      float num3 = (float) (2.0 * (double) num2 - 3.0 * (double) num1 + 1.0);
      float num4 = (float) (-2.0 * (double) num2 + 3.0 * (double) num1);
      float num5 = num2 - 2f * num1 + float_4;
      float num6 = num2 - num1;
      vector4_10.float_0 = (float) ((double) vector4_6.float_0 * (double) num3 + (double) vector4_8.float_0 * (double) num4 + (double) vector4_7.float_0 * (double) num5 + (double) vector4_9.float_0 * (double) num6);
      vector4_10.float_1 = (float) ((double) vector4_6.float_1 * (double) num3 + (double) vector4_8.float_1 * (double) num4 + (double) vector4_7.float_1 * (double) num5 + (double) vector4_9.float_1 * (double) num6);
      vector4_10.float_2 = (float) ((double) vector4_6.float_2 * (double) num3 + (double) vector4_8.float_2 * (double) num4 + (double) vector4_7.float_2 * (double) num5 + (double) vector4_9.float_2 * (double) num6);
      vector4_10.float_3 = (float) ((double) vector4_6.float_3 * (double) num3 + (double) vector4_8.float_3 * (double) num4 + (double) vector4_7.float_3 * (double) num5 + (double) vector4_9.float_3 * (double) num6);
    }

    public static Vector4 smethod_30(Vector2 vector2_0, Matrix matrix_0)
    {
      float num1 = (float) ((double) vector2_0.X * (double) matrix_0.M11 + (double) vector2_0.Y * (double) matrix_0.M21) + matrix_0.M41;
      float num2 = (float) ((double) vector2_0.X * (double) matrix_0.M12 + (double) vector2_0.Y * (double) matrix_0.M22) + matrix_0.M42;
      float num3 = (float) ((double) vector2_0.X * (double) matrix_0.M13 + (double) vector2_0.Y * (double) matrix_0.M23) + matrix_0.M43;
      float num4 = (float) ((double) vector2_0.X * (double) matrix_0.M14 + (double) vector2_0.Y * (double) matrix_0.M24) + matrix_0.M44;
      Vector4 vector4;
      vector4.float_0 = num1;
      vector4.float_1 = num2;
      vector4.float_2 = num3;
      vector4.float_3 = num4;
      return vector4;
    }

    public static void smethod_31(ref Vector2 vector2_0, ref Matrix matrix_0, out Vector4 vector4_6)
    {
      float num1 = (float) ((double) vector2_0.X * (double) matrix_0.M11 + (double) vector2_0.Y * (double) matrix_0.M21) + matrix_0.M41;
      float num2 = (float) ((double) vector2_0.X * (double) matrix_0.M12 + (double) vector2_0.Y * (double) matrix_0.M22) + matrix_0.M42;
      float num3 = (float) ((double) vector2_0.X * (double) matrix_0.M13 + (double) vector2_0.Y * (double) matrix_0.M23) + matrix_0.M43;
      float num4 = (float) ((double) vector2_0.X * (double) matrix_0.M14 + (double) vector2_0.Y * (double) matrix_0.M24) + matrix_0.M44;
      vector4_6.float_0 = num1;
      vector4_6.float_1 = num2;
      vector4_6.float_2 = num3;
      vector4_6.float_3 = num4;
    }

    public static Vector4 smethod_32(Vector3 vector3_0, Matrix matrix_0)
    {
      float num1 = (float) ((double) vector3_0.float_0 * (double) matrix_0.M11 + (double) vector3_0.float_1 * (double) matrix_0.M21 + (double) vector3_0.float_2 * (double) matrix_0.M31) + matrix_0.M41;
      float num2 = (float) ((double) vector3_0.float_0 * (double) matrix_0.M12 + (double) vector3_0.float_1 * (double) matrix_0.M22 + (double) vector3_0.float_2 * (double) matrix_0.M32) + matrix_0.M42;
      float num3 = (float) ((double) vector3_0.float_0 * (double) matrix_0.M13 + (double) vector3_0.float_1 * (double) matrix_0.M23 + (double) vector3_0.float_2 * (double) matrix_0.M33) + matrix_0.M43;
      float num4 = (float) ((double) vector3_0.float_0 * (double) matrix_0.M14 + (double) vector3_0.float_1 * (double) matrix_0.M24 + (double) vector3_0.float_2 * (double) matrix_0.M34) + matrix_0.M44;
      Vector4 vector4;
      vector4.float_0 = num1;
      vector4.float_1 = num2;
      vector4.float_2 = num3;
      vector4.float_3 = num4;
      return vector4;
    }

    public static void smethod_33(ref Vector3 vector3_0, ref Matrix matrix_0, out Vector4 vector4_6)
    {
      float num1 = (float) ((double) vector3_0.float_0 * (double) matrix_0.M11 + (double) vector3_0.float_1 * (double) matrix_0.M21 + (double) vector3_0.float_2 * (double) matrix_0.M31) + matrix_0.M41;
      float num2 = (float) ((double) vector3_0.float_0 * (double) matrix_0.M12 + (double) vector3_0.float_1 * (double) matrix_0.M22 + (double) vector3_0.float_2 * (double) matrix_0.M32) + matrix_0.M42;
      float num3 = (float) ((double) vector3_0.float_0 * (double) matrix_0.M13 + (double) vector3_0.float_1 * (double) matrix_0.M23 + (double) vector3_0.float_2 * (double) matrix_0.M33) + matrix_0.M43;
      float num4 = (float) ((double) vector3_0.float_0 * (double) matrix_0.M14 + (double) vector3_0.float_1 * (double) matrix_0.M24 + (double) vector3_0.float_2 * (double) matrix_0.M34) + matrix_0.M44;
      vector4_6.float_0 = num1;
      vector4_6.float_1 = num2;
      vector4_6.float_2 = num3;
      vector4_6.float_3 = num4;
    }

    public static Vector4 smethod_34(Vector4 vector4_6, Matrix matrix_0)
    {
      float num1 = (float) ((double) vector4_6.float_0 * (double) matrix_0.M11 + (double) vector4_6.float_1 * (double) matrix_0.M21 + (double) vector4_6.float_2 * (double) matrix_0.M31 + (double) vector4_6.float_3 * (double) matrix_0.M41);
      float num2 = (float) ((double) vector4_6.float_0 * (double) matrix_0.M12 + (double) vector4_6.float_1 * (double) matrix_0.M22 + (double) vector4_6.float_2 * (double) matrix_0.M32 + (double) vector4_6.float_3 * (double) matrix_0.M42);
      float num3 = (float) ((double) vector4_6.float_0 * (double) matrix_0.M13 + (double) vector4_6.float_1 * (double) matrix_0.M23 + (double) vector4_6.float_2 * (double) matrix_0.M33 + (double) vector4_6.float_3 * (double) matrix_0.M43);
      float num4 = (float) ((double) vector4_6.float_0 * (double) matrix_0.M14 + (double) vector4_6.float_1 * (double) matrix_0.M24 + (double) vector4_6.float_2 * (double) matrix_0.M34 + (double) vector4_6.float_3 * (double) matrix_0.M44);
      Vector4 vector4;
      vector4.float_0 = num1;
      vector4.float_1 = num2;
      vector4.float_2 = num3;
      vector4.float_3 = num4;
      return vector4;
    }

    public static void smethod_35(ref Vector4 vector4_6, ref Matrix matrix_0, out Vector4 vector4_7)
    {
      float num1 = (float) ((double) vector4_6.float_0 * (double) matrix_0.M11 + (double) vector4_6.float_1 * (double) matrix_0.M21 + (double) vector4_6.float_2 * (double) matrix_0.M31 + (double) vector4_6.float_3 * (double) matrix_0.M41);
      float num2 = (float) ((double) vector4_6.float_0 * (double) matrix_0.M12 + (double) vector4_6.float_1 * (double) matrix_0.M22 + (double) vector4_6.float_2 * (double) matrix_0.M32 + (double) vector4_6.float_3 * (double) matrix_0.M42);
      float num3 = (float) ((double) vector4_6.float_0 * (double) matrix_0.M13 + (double) vector4_6.float_1 * (double) matrix_0.M23 + (double) vector4_6.float_2 * (double) matrix_0.M33 + (double) vector4_6.float_3 * (double) matrix_0.M43);
      float num4 = (float) ((double) vector4_6.float_0 * (double) matrix_0.M14 + (double) vector4_6.float_1 * (double) matrix_0.M24 + (double) vector4_6.float_2 * (double) matrix_0.M34 + (double) vector4_6.float_3 * (double) matrix_0.M44);
      vector4_7.float_0 = num1;
      vector4_7.float_1 = num2;
      vector4_7.float_2 = num3;
      vector4_7.float_3 = num4;
    }

    public static void smethod_36(Vector4[] vector4_6, ref Matrix matrix_0, Vector4[] vector4_7)
    {
      if (vector4_6 == null)
        throw new ArgumentNullException("values");
      if (vector4_7 == null)
        throw new ArgumentNullException("results");
      if (vector4_7.Length < vector4_6.Length)
        throw new IndexOutOfRangeException(Class1070.smethod_10());
      for (int index = 0; index < vector4_6.Length; ++index)
      {
        float num1 = vector4_6[index].float_0;
        float num2 = vector4_6[index].float_1;
        float num3 = vector4_6[index].float_2;
        float num4 = vector4_6[index].float_3;
        vector4_7[index].float_0 = (float) ((double) num1 * (double) matrix_0.M11 + (double) num2 * (double) matrix_0.M21 + (double) num3 * (double) matrix_0.M31 + (double) num4 * (double) matrix_0.M41);
        vector4_7[index].float_1 = (float) ((double) num1 * (double) matrix_0.M12 + (double) num2 * (double) matrix_0.M22 + (double) num3 * (double) matrix_0.M32 + (double) num4 * (double) matrix_0.M42);
        vector4_7[index].float_2 = (float) ((double) num1 * (double) matrix_0.M13 + (double) num2 * (double) matrix_0.M23 + (double) num3 * (double) matrix_0.M33 + (double) num4 * (double) matrix_0.M43);
        vector4_7[index].float_3 = (float) ((double) num1 * (double) matrix_0.M14 + (double) num2 * (double) matrix_0.M24 + (double) num3 * (double) matrix_0.M34 + (double) num4 * (double) matrix_0.M44);
      }
    }

    public static void smethod_37(Vector4[] vector4_6, int int_0, ref Matrix matrix_0, Vector4[] vector4_7, int int_1, int int_2)
    {
      if (vector4_6 == null)
        throw new ArgumentNullException("values");
      if (vector4_7 == null)
        throw new ArgumentNullException("results");
      if ((long) vector4_6.Length < (long) int_0 + (long) int_2)
        throw new IndexOutOfRangeException(Class1070.smethod_9());
      if ((long) vector4_7.Length < (long) int_1 + (long) int_2)
        throw new IndexOutOfRangeException(Class1070.smethod_10());
      for (; int_2 > 0; --int_2)
      {
        float num1 = vector4_6[int_0].float_0;
        float num2 = vector4_6[int_0].float_1;
        float num3 = vector4_6[int_0].float_2;
        float num4 = vector4_6[int_0].float_3;
        vector4_7[int_1].float_0 = (float) ((double) num1 * (double) matrix_0.M11 + (double) num2 * (double) matrix_0.M21 + (double) num3 * (double) matrix_0.M31 + (double) num4 * (double) matrix_0.M41);
        vector4_7[int_1].float_1 = (float) ((double) num1 * (double) matrix_0.M12 + (double) num2 * (double) matrix_0.M22 + (double) num3 * (double) matrix_0.M32 + (double) num4 * (double) matrix_0.M42);
        vector4_7[int_1].float_2 = (float) ((double) num1 * (double) matrix_0.M13 + (double) num2 * (double) matrix_0.M23 + (double) num3 * (double) matrix_0.M33 + (double) num4 * (double) matrix_0.M43);
        vector4_7[int_1].float_3 = (float) ((double) num1 * (double) matrix_0.M14 + (double) num2 * (double) matrix_0.M24 + (double) num3 * (double) matrix_0.M34 + (double) num4 * (double) matrix_0.M44);
        ++int_0;
        ++int_1;
      }
    }

    public static Vector4 smethod_38(Vector4 vector4_6)
    {
      Vector4 vector4;
      vector4.float_0 = -vector4_6.float_0;
      vector4.float_1 = -vector4_6.float_1;
      vector4.float_2 = -vector4_6.float_2;
      vector4.float_3 = -vector4_6.float_3;
      return vector4;
    }

    public static void smethod_39(ref Vector4 vector4_6, out Vector4 vector4_7)
    {
      vector4_7.float_0 = -vector4_6.float_0;
      vector4_7.float_1 = -vector4_6.float_1;
      vector4_7.float_2 = -vector4_6.float_2;
      vector4_7.float_3 = -vector4_6.float_3;
    }

    public static Vector4 smethod_40(Vector4 vector4_6, Vector4 vector4_7)
    {
      Vector4 vector4;
      vector4.float_0 = vector4_6.float_0 + vector4_7.float_0;
      vector4.float_1 = vector4_6.float_1 + vector4_7.float_1;
      vector4.float_2 = vector4_6.float_2 + vector4_7.float_2;
      vector4.float_3 = vector4_6.float_3 + vector4_7.float_3;
      return vector4;
    }

    public static void smethod_41(ref Vector4 vector4_6, ref Vector4 vector4_7, out Vector4 vector4_8)
    {
      vector4_8.float_0 = vector4_6.float_0 + vector4_7.float_0;
      vector4_8.float_1 = vector4_6.float_1 + vector4_7.float_1;
      vector4_8.float_2 = vector4_6.float_2 + vector4_7.float_2;
      vector4_8.float_3 = vector4_6.float_3 + vector4_7.float_3;
    }

    public static Vector4 smethod_42(Vector4 vector4_6, Vector4 vector4_7)
    {
      Vector4 vector4;
      vector4.float_0 = vector4_6.float_0 - vector4_7.float_0;
      vector4.float_1 = vector4_6.float_1 - vector4_7.float_1;
      vector4.float_2 = vector4_6.float_2 - vector4_7.float_2;
      vector4.float_3 = vector4_6.float_3 - vector4_7.float_3;
      return vector4;
    }

    public static void smethod_43(ref Vector4 vector4_6, ref Vector4 vector4_7, out Vector4 vector4_8)
    {
      vector4_8.float_0 = vector4_6.float_0 - vector4_7.float_0;
      vector4_8.float_1 = vector4_6.float_1 - vector4_7.float_1;
      vector4_8.float_2 = vector4_6.float_2 - vector4_7.float_2;
      vector4_8.float_3 = vector4_6.float_3 - vector4_7.float_3;
    }

    public static Vector4 smethod_44(Vector4 vector4_6, Vector4 vector4_7)
    {
      Vector4 vector4;
      vector4.float_0 = vector4_6.float_0 * vector4_7.float_0;
      vector4.float_1 = vector4_6.float_1 * vector4_7.float_1;
      vector4.float_2 = vector4_6.float_2 * vector4_7.float_2;
      vector4.float_3 = vector4_6.float_3 * vector4_7.float_3;
      return vector4;
    }

    public static void smethod_45(ref Vector4 vector4_6, ref Vector4 vector4_7, out Vector4 vector4_8)
    {
      vector4_8.float_0 = vector4_6.float_0 * vector4_7.float_0;
      vector4_8.float_1 = vector4_6.float_1 * vector4_7.float_1;
      vector4_8.float_2 = vector4_6.float_2 * vector4_7.float_2;
      vector4_8.float_3 = vector4_6.float_3 * vector4_7.float_3;
    }

    public static Vector4 smethod_46(Vector4 vector4_6, float float_4)
    {
      Vector4 vector4;
      vector4.float_0 = vector4_6.float_0 * float_4;
      vector4.float_1 = vector4_6.float_1 * float_4;
      vector4.float_2 = vector4_6.float_2 * float_4;
      vector4.float_3 = vector4_6.float_3 * float_4;
      return vector4;
    }

    public static void smethod_47(ref Vector4 vector4_6, float float_4, out Vector4 vector4_7)
    {
      vector4_7.float_0 = vector4_6.float_0 * float_4;
      vector4_7.float_1 = vector4_6.float_1 * float_4;
      vector4_7.float_2 = vector4_6.float_2 * float_4;
      vector4_7.float_3 = vector4_6.float_3 * float_4;
    }

    public static Vector4 smethod_48(Vector4 vector4_6, Vector4 vector4_7)
    {
      Vector4 vector4;
      vector4.float_0 = vector4_6.float_0 / vector4_7.float_0;
      vector4.float_1 = vector4_6.float_1 / vector4_7.float_1;
      vector4.float_2 = vector4_6.float_2 / vector4_7.float_2;
      vector4.float_3 = vector4_6.float_3 / vector4_7.float_3;
      return vector4;
    }

    public static void smethod_49(ref Vector4 vector4_6, ref Vector4 vector4_7, out Vector4 vector4_8)
    {
      vector4_8.float_0 = vector4_6.float_0 / vector4_7.float_0;
      vector4_8.float_1 = vector4_6.float_1 / vector4_7.float_1;
      vector4_8.float_2 = vector4_6.float_2 / vector4_7.float_2;
      vector4_8.float_3 = vector4_6.float_3 / vector4_7.float_3;
    }

    public static Vector4 smethod_50(Vector4 vector4_6, float float_4)
    {
      float num = 1f / float_4;
      Vector4 vector4;
      vector4.float_0 = vector4_6.float_0 * num;
      vector4.float_1 = vector4_6.float_1 * num;
      vector4.float_2 = vector4_6.float_2 * num;
      vector4.float_3 = vector4_6.float_3 * num;
      return vector4;
    }

    public static void smethod_51(ref Vector4 vector4_6, float float_4, out Vector4 vector4_7)
    {
      float num = 1f / float_4;
      vector4_7.float_0 = vector4_6.float_0 * num;
      vector4_7.float_1 = vector4_6.float_1 * num;
      vector4_7.float_2 = vector4_6.float_2 * num;
      vector4_7.float_3 = vector4_6.float_3 * num;
    }
  }
}
