// Decompiled with JetBrains decompiler
// Type: Microsoft.Xna.Framework.Vector3
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
  public struct Vector3 : IEquatable<Vector3>
  {
    private static Vector3 vector3_0 = new Vector3();
    private static Vector3 vector3_1 = new Vector3(1f, 1f, 1f);
    private static Vector3 vector3_2 = new Vector3(1f, 0.0f, 0.0f);
    private static Vector3 vector3_3 = new Vector3(0.0f, 1f, 0.0f);
    private static Vector3 vector3_4 = new Vector3(0.0f, 0.0f, 1f);
    private static Vector3 vector3_5 = new Vector3(0.0f, 1f, 0.0f);
    private static Vector3 vector3_6 = new Vector3(0.0f, -1f, 0.0f);
    private static Vector3 vector3_7 = new Vector3(1f, 0.0f, 0.0f);
    private static Vector3 vector3_8 = new Vector3(-1f, 0.0f, 0.0f);
    private static Vector3 vector3_9 = new Vector3(0.0f, 0.0f, -1f);
    private static Vector3 vector3_10 = new Vector3(0.0f, 0.0f, 1f);
    public float float_0;
    public float float_1;
    public float float_2;

    public Vector3(float float_3, float float_4, float float_5)
    {
      this.float_0 = float_3;
      this.float_1 = float_4;
      this.float_2 = float_5;
    }

    public Vector3(float float_3)
    {
      this.float_2 = float_3;
      this.float_1 = float_3;
      this.float_0 = float_3;
    }

    public Vector3(Vector2 vector2_0, float float_3)
    {
      this.float_0 = vector2_0.X;
      this.float_1 = vector2_0.Y;
      this.float_2 = float_3;
    }

    public static Vector3 operator -(Vector3 vector3_11)
    {
      Vector3 vector3;
      vector3.float_0 = -vector3_11.float_0;
      vector3.float_1 = -vector3_11.float_1;
      vector3.float_2 = -vector3_11.float_2;
      return vector3;
    }

    public static bool operator ==(Vector3 vector3_11, Vector3 vector3_12)
    {
      if ((double) vector3_11.float_0 == (double) vector3_12.float_0 && (double) vector3_11.float_1 == (double) vector3_12.float_1)
        return (double) vector3_11.float_2 == (double) vector3_12.float_2;
      return false;
    }

    public static bool operator !=(Vector3 vector3_11, Vector3 vector3_12)
    {
      if ((double) vector3_11.float_0 == (double) vector3_12.float_0 && (double) vector3_11.float_1 == (double) vector3_12.float_1)
        return (double) vector3_11.float_2 != (double) vector3_12.float_2;
      return true;
    }

    public static Vector3 operator +(Vector3 vector3_11, Vector3 vector3_12)
    {
      Vector3 vector3;
      vector3.float_0 = vector3_11.float_0 + vector3_12.float_0;
      vector3.float_1 = vector3_11.float_1 + vector3_12.float_1;
      vector3.float_2 = vector3_11.float_2 + vector3_12.float_2;
      return vector3;
    }

    public static Vector3 operator -(Vector3 vector3_11, Vector3 vector3_12)
    {
      Vector3 vector3;
      vector3.float_0 = vector3_11.float_0 - vector3_12.float_0;
      vector3.float_1 = vector3_11.float_1 - vector3_12.float_1;
      vector3.float_2 = vector3_11.float_2 - vector3_12.float_2;
      return vector3;
    }

    public static Vector3 operator *(Vector3 vector3_11, Vector3 vector3_12)
    {
      Vector3 vector3;
      vector3.float_0 = vector3_11.float_0 * vector3_12.float_0;
      vector3.float_1 = vector3_11.float_1 * vector3_12.float_1;
      vector3.float_2 = vector3_11.float_2 * vector3_12.float_2;
      return vector3;
    }

    public static Vector3 operator *(Vector3 vector3_11, float float_3)
    {
      Vector3 vector3;
      vector3.float_0 = vector3_11.float_0 * float_3;
      vector3.float_1 = vector3_11.float_1 * float_3;
      vector3.float_2 = vector3_11.float_2 * float_3;
      return vector3;
    }

    public static Vector3 operator *(float float_3, Vector3 vector3_11)
    {
      Vector3 vector3;
      vector3.float_0 = vector3_11.float_0 * float_3;
      vector3.float_1 = vector3_11.float_1 * float_3;
      vector3.float_2 = vector3_11.float_2 * float_3;
      return vector3;
    }

    public static Vector3 operator /(Vector3 vector3_11, Vector3 vector3_12)
    {
      Vector3 vector3;
      vector3.float_0 = vector3_11.float_0 / vector3_12.float_0;
      vector3.float_1 = vector3_11.float_1 / vector3_12.float_1;
      vector3.float_2 = vector3_11.float_2 / vector3_12.float_2;
      return vector3;
    }

    public static Vector3 operator /(Vector3 vector3_11, float float_3)
    {
      float num = 1f / float_3;
      Vector3 vector3;
      vector3.float_0 = vector3_11.float_0 * num;
      vector3.float_1 = vector3_11.float_1 * num;
      vector3.float_2 = vector3_11.float_2 * num;
      return vector3;
    }

    public static Vector3 smethod_0()
    {
      return Vector3.vector3_0;
    }

    public static Vector3 smethod_1()
    {
      return Vector3.vector3_1;
    }

    public static Vector3 smethod_2()
    {
      return Vector3.vector3_2;
    }

    public static Vector3 smethod_3()
    {
      return Vector3.vector3_3;
    }

    public static Vector3 smethod_4()
    {
      return Vector3.vector3_4;
    }

    public static Vector3 smethod_5()
    {
      return Vector3.vector3_5;
    }

    public static Vector3 smethod_6()
    {
      return Vector3.vector3_6;
    }

    public static Vector3 smethod_7()
    {
      return Vector3.vector3_7;
    }

    public static Vector3 smethod_8()
    {
      return Vector3.vector3_8;
    }

    public static Vector3 smethod_9()
    {
      return Vector3.vector3_9;
    }

    public static Vector3 smethod_10()
    {
      return Vector3.vector3_10;
    }

    public override string ToString()
    {
      CultureInfo currentCulture = CultureInfo.CurrentCulture;
      return string.Format((IFormatProvider) currentCulture, "{{X:{0} Y:{1} Z:{2}}}", (object) this.float_0.ToString((IFormatProvider) currentCulture), (object) this.float_1.ToString((IFormatProvider) currentCulture), (object) this.float_2.ToString((IFormatProvider) currentCulture));
    }

    public bool Equals(Vector3 other)
    {
      if ((double) this.float_0 == (double) other.float_0 && (double) this.float_1 == (double) other.float_1)
        return (double) this.float_2 == (double) other.float_2;
      return false;
    }

    public override bool Equals(object obj)
    {
      bool flag = false;
      if (obj is Vector3)
        flag = this.Equals((Vector3) obj);
      return flag;
    }

    public override int GetHashCode()
    {
      return this.float_0.GetHashCode() + this.float_1.GetHashCode() + this.float_2.GetHashCode();
    }

    public float method_0()
    {
      return (float) Math.Sqrt((double) this.float_0 * (double) this.float_0 + (double) this.float_1 * (double) this.float_1 + (double) this.float_2 * (double) this.float_2);
    }

    public float method_1()
    {
      return (float) ((double) this.float_0 * (double) this.float_0 + (double) this.float_1 * (double) this.float_1 + (double) this.float_2 * (double) this.float_2);
    }

    public static float smethod_11(Vector3 vector3_11, Vector3 vector3_12)
    {
      float num1 = vector3_11.float_0 - vector3_12.float_0;
      float num2 = vector3_11.float_1 - vector3_12.float_1;
      float num3 = vector3_11.float_2 - vector3_12.float_2;
      return (float) Math.Sqrt((double) num1 * (double) num1 + (double) num2 * (double) num2 + (double) num3 * (double) num3);
    }

    public static void smethod_12(ref Vector3 vector3_11, ref Vector3 vector3_12, out float float_3)
    {
      float num1 = vector3_11.float_0 - vector3_12.float_0;
      float num2 = vector3_11.float_1 - vector3_12.float_1;
      float num3 = vector3_11.float_2 - vector3_12.float_2;
      float num4 = (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2 + (double) num3 * (double) num3);
      float_3 = (float) Math.Sqrt((double) num4);
    }

    public static float smethod_13(Vector3 vector3_11, Vector3 vector3_12)
    {
      float num1 = vector3_11.float_0 - vector3_12.float_0;
      float num2 = vector3_11.float_1 - vector3_12.float_1;
      float num3 = vector3_11.float_2 - vector3_12.float_2;
      return (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2 + (double) num3 * (double) num3);
    }

    public static void smethod_14(ref Vector3 vector3_11, ref Vector3 vector3_12, out float float_3)
    {
      float num1 = vector3_11.float_0 - vector3_12.float_0;
      float num2 = vector3_11.float_1 - vector3_12.float_1;
      float num3 = vector3_11.float_2 - vector3_12.float_2;
      float_3 = (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2 + (double) num3 * (double) num3);
    }

    public static float smethod_15(Vector3 vector3_11, Vector3 vector3_12)
    {
      return (float) ((double) vector3_11.float_0 * (double) vector3_12.float_0 + (double) vector3_11.float_1 * (double) vector3_12.float_1 + (double) vector3_11.float_2 * (double) vector3_12.float_2);
    }

    public static void smethod_16(ref Vector3 vector3_11, ref Vector3 vector3_12, out float float_3)
    {
      float_3 = (float) ((double) vector3_11.float_0 * (double) vector3_12.float_0 + (double) vector3_11.float_1 * (double) vector3_12.float_1 + (double) vector3_11.float_2 * (double) vector3_12.float_2);
    }

    public void method_2()
    {
      float num = 1f / (float) Math.Sqrt((double) this.float_0 * (double) this.float_0 + (double) this.float_1 * (double) this.float_1 + (double) this.float_2 * (double) this.float_2);
      this.float_0 *= num;
      this.float_1 *= num;
      this.float_2 *= num;
    }

    public static Vector3 smethod_17(Vector3 vector3_11)
    {
      float num = 1f / (float) Math.Sqrt((double) vector3_11.float_0 * (double) vector3_11.float_0 + (double) vector3_11.float_1 * (double) vector3_11.float_1 + (double) vector3_11.float_2 * (double) vector3_11.float_2);
      Vector3 vector3;
      vector3.float_0 = vector3_11.float_0 * num;
      vector3.float_1 = vector3_11.float_1 * num;
      vector3.float_2 = vector3_11.float_2 * num;
      return vector3;
    }

    public static void smethod_18(ref Vector3 vector3_11, out Vector3 vector3_12)
    {
      float num = 1f / (float) Math.Sqrt((double) vector3_11.float_0 * (double) vector3_11.float_0 + (double) vector3_11.float_1 * (double) vector3_11.float_1 + (double) vector3_11.float_2 * (double) vector3_11.float_2);
      vector3_12.float_0 = vector3_11.float_0 * num;
      vector3_12.float_1 = vector3_11.float_1 * num;
      vector3_12.float_2 = vector3_11.float_2 * num;
    }

    public static Vector3 smethod_19(Vector3 vector3_11, Vector3 vector3_12)
    {
      Vector3 vector3;
      vector3.float_0 = (float) ((double) vector3_11.float_1 * (double) vector3_12.float_2 - (double) vector3_11.float_2 * (double) vector3_12.float_1);
      vector3.float_1 = (float) ((double) vector3_11.float_2 * (double) vector3_12.float_0 - (double) vector3_11.float_0 * (double) vector3_12.float_2);
      vector3.float_2 = (float) ((double) vector3_11.float_0 * (double) vector3_12.float_1 - (double) vector3_11.float_1 * (double) vector3_12.float_0);
      return vector3;
    }

    public static void smethod_20(ref Vector3 vector3_11, ref Vector3 vector3_12, out Vector3 vector3_13)
    {
      float num1 = (float) ((double) vector3_11.float_1 * (double) vector3_12.float_2 - (double) vector3_11.float_2 * (double) vector3_12.float_1);
      float num2 = (float) ((double) vector3_11.float_2 * (double) vector3_12.float_0 - (double) vector3_11.float_0 * (double) vector3_12.float_2);
      float num3 = (float) ((double) vector3_11.float_0 * (double) vector3_12.float_1 - (double) vector3_11.float_1 * (double) vector3_12.float_0);
      vector3_13.float_0 = num1;
      vector3_13.float_1 = num2;
      vector3_13.float_2 = num3;
    }

    public static Vector3 smethod_21(Vector3 vector3_11, Vector3 vector3_12)
    {
      float num = (float) ((double) vector3_11.float_0 * (double) vector3_12.float_0 + (double) vector3_11.float_1 * (double) vector3_12.float_1 + (double) vector3_11.float_2 * (double) vector3_12.float_2);
      Vector3 vector3;
      vector3.float_0 = vector3_11.float_0 - 2f * num * vector3_12.float_0;
      vector3.float_1 = vector3_11.float_1 - 2f * num * vector3_12.float_1;
      vector3.float_2 = vector3_11.float_2 - 2f * num * vector3_12.float_2;
      return vector3;
    }

    public static void smethod_22(ref Vector3 vector3_11, ref Vector3 vector3_12, out Vector3 vector3_13)
    {
      float num = (float) ((double) vector3_11.float_0 * (double) vector3_12.float_0 + (double) vector3_11.float_1 * (double) vector3_12.float_1 + (double) vector3_11.float_2 * (double) vector3_12.float_2);
      vector3_13.float_0 = vector3_11.float_0 - 2f * num * vector3_12.float_0;
      vector3_13.float_1 = vector3_11.float_1 - 2f * num * vector3_12.float_1;
      vector3_13.float_2 = vector3_11.float_2 - 2f * num * vector3_12.float_2;
    }

    public static Vector3 smethod_23(Vector3 vector3_11, Vector3 vector3_12)
    {
      Vector3 vector3;
      vector3.float_0 = (double) vector3_11.float_0 < (double) vector3_12.float_0 ? vector3_11.float_0 : vector3_12.float_0;
      vector3.float_1 = (double) vector3_11.float_1 < (double) vector3_12.float_1 ? vector3_11.float_1 : vector3_12.float_1;
      vector3.float_2 = (double) vector3_11.float_2 < (double) vector3_12.float_2 ? vector3_11.float_2 : vector3_12.float_2;
      return vector3;
    }

    public static void smethod_24(ref Vector3 vector3_11, ref Vector3 vector3_12, out Vector3 vector3_13)
    {
      vector3_13.float_0 = (double) vector3_11.float_0 < (double) vector3_12.float_0 ? vector3_11.float_0 : vector3_12.float_0;
      vector3_13.float_1 = (double) vector3_11.float_1 < (double) vector3_12.float_1 ? vector3_11.float_1 : vector3_12.float_1;
      vector3_13.float_2 = (double) vector3_11.float_2 < (double) vector3_12.float_2 ? vector3_11.float_2 : vector3_12.float_2;
    }

    public static Vector3 smethod_25(Vector3 vector3_11, Vector3 vector3_12)
    {
      Vector3 vector3;
      vector3.float_0 = (double) vector3_11.float_0 > (double) vector3_12.float_0 ? vector3_11.float_0 : vector3_12.float_0;
      vector3.float_1 = (double) vector3_11.float_1 > (double) vector3_12.float_1 ? vector3_11.float_1 : vector3_12.float_1;
      vector3.float_2 = (double) vector3_11.float_2 > (double) vector3_12.float_2 ? vector3_11.float_2 : vector3_12.float_2;
      return vector3;
    }

    public static void smethod_26(ref Vector3 vector3_11, ref Vector3 vector3_12, out Vector3 vector3_13)
    {
      vector3_13.float_0 = (double) vector3_11.float_0 > (double) vector3_12.float_0 ? vector3_11.float_0 : vector3_12.float_0;
      vector3_13.float_1 = (double) vector3_11.float_1 > (double) vector3_12.float_1 ? vector3_11.float_1 : vector3_12.float_1;
      vector3_13.float_2 = (double) vector3_11.float_2 > (double) vector3_12.float_2 ? vector3_11.float_2 : vector3_12.float_2;
    }

    public static Vector3 smethod_27(Vector3 vector3_11, Vector3 vector3_12, Vector3 vector3_13)
    {
      float num1 = vector3_11.float_0;
      float num2 = (double) num1 > (double) vector3_13.float_0 ? vector3_13.float_0 : num1;
      float num3 = (double) num2 < (double) vector3_12.float_0 ? vector3_12.float_0 : num2;
      float num4 = vector3_11.float_1;
      float num5 = (double) num4 > (double) vector3_13.float_1 ? vector3_13.float_1 : num4;
      float num6 = (double) num5 < (double) vector3_12.float_1 ? vector3_12.float_1 : num5;
      float num7 = vector3_11.float_2;
      float num8 = (double) num7 > (double) vector3_13.float_2 ? vector3_13.float_2 : num7;
      float num9 = (double) num8 < (double) vector3_12.float_2 ? vector3_12.float_2 : num8;
      Vector3 vector3;
      vector3.float_0 = num3;
      vector3.float_1 = num6;
      vector3.float_2 = num9;
      return vector3;
    }

    public static void smethod_28(ref Vector3 vector3_11, ref Vector3 vector3_12, ref Vector3 vector3_13, out Vector3 vector3_14)
    {
      float num1 = vector3_11.float_0;
      float num2 = (double) num1 > (double) vector3_13.float_0 ? vector3_13.float_0 : num1;
      float num3 = (double) num2 < (double) vector3_12.float_0 ? vector3_12.float_0 : num2;
      float num4 = vector3_11.float_1;
      float num5 = (double) num4 > (double) vector3_13.float_1 ? vector3_13.float_1 : num4;
      float num6 = (double) num5 < (double) vector3_12.float_1 ? vector3_12.float_1 : num5;
      float num7 = vector3_11.float_2;
      float num8 = (double) num7 > (double) vector3_13.float_2 ? vector3_13.float_2 : num7;
      float num9 = (double) num8 < (double) vector3_12.float_2 ? vector3_12.float_2 : num8;
      vector3_14.float_0 = num3;
      vector3_14.float_1 = num6;
      vector3_14.float_2 = num9;
    }

    public static Vector3 smethod_29(Vector3 vector3_11, Vector3 vector3_12, float float_3)
    {
      Vector3 vector3;
      vector3.float_0 = vector3_11.float_0 + (vector3_12.float_0 - vector3_11.float_0) * float_3;
      vector3.float_1 = vector3_11.float_1 + (vector3_12.float_1 - vector3_11.float_1) * float_3;
      vector3.float_2 = vector3_11.float_2 + (vector3_12.float_2 - vector3_11.float_2) * float_3;
      return vector3;
    }

    public static void smethod_30(ref Vector3 vector3_11, ref Vector3 vector3_12, float float_3, out Vector3 vector3_13)
    {
      vector3_13.float_0 = vector3_11.float_0 + (vector3_12.float_0 - vector3_11.float_0) * float_3;
      vector3_13.float_1 = vector3_11.float_1 + (vector3_12.float_1 - vector3_11.float_1) * float_3;
      vector3_13.float_2 = vector3_11.float_2 + (vector3_12.float_2 - vector3_11.float_2) * float_3;
    }

    public static Vector3 smethod_31(Vector3 vector3_11, Vector3 vector3_12, Vector3 vector3_13, float float_3, float float_4)
    {
      Vector3 vector3;
      vector3.float_0 = (float) ((double) vector3_11.float_0 + (double) float_3 * ((double) vector3_12.float_0 - (double) vector3_11.float_0) + (double) float_4 * ((double) vector3_13.float_0 - (double) vector3_11.float_0));
      vector3.float_1 = (float) ((double) vector3_11.float_1 + (double) float_3 * ((double) vector3_12.float_1 - (double) vector3_11.float_1) + (double) float_4 * ((double) vector3_13.float_1 - (double) vector3_11.float_1));
      vector3.float_2 = (float) ((double) vector3_11.float_2 + (double) float_3 * ((double) vector3_12.float_2 - (double) vector3_11.float_2) + (double) float_4 * ((double) vector3_13.float_2 - (double) vector3_11.float_2));
      return vector3;
    }

    public static void smethod_32(ref Vector3 vector3_11, ref Vector3 vector3_12, ref Vector3 vector3_13, float float_3, float float_4, out Vector3 vector3_14)
    {
      vector3_14.float_0 = (float) ((double) vector3_11.float_0 + (double) float_3 * ((double) vector3_12.float_0 - (double) vector3_11.float_0) + (double) float_4 * ((double) vector3_13.float_0 - (double) vector3_11.float_0));
      vector3_14.float_1 = (float) ((double) vector3_11.float_1 + (double) float_3 * ((double) vector3_12.float_1 - (double) vector3_11.float_1) + (double) float_4 * ((double) vector3_13.float_1 - (double) vector3_11.float_1));
      vector3_14.float_2 = (float) ((double) vector3_11.float_2 + (double) float_3 * ((double) vector3_12.float_2 - (double) vector3_11.float_2) + (double) float_4 * ((double) vector3_13.float_2 - (double) vector3_11.float_2));
    }

    public static Vector3 smethod_33(Vector3 vector3_11, Vector3 vector3_12, float float_3)
    {
      float_3 = (double) float_3 > 1.0 ? 1f : ((double) float_3 < 0.0 ? 0.0f : float_3);
      float_3 = (float) ((double) float_3 * (double) float_3 * (3.0 - 2.0 * (double) float_3));
      Vector3 vector3;
      vector3.float_0 = vector3_11.float_0 + (vector3_12.float_0 - vector3_11.float_0) * float_3;
      vector3.float_1 = vector3_11.float_1 + (vector3_12.float_1 - vector3_11.float_1) * float_3;
      vector3.float_2 = vector3_11.float_2 + (vector3_12.float_2 - vector3_11.float_2) * float_3;
      return vector3;
    }

    public static void smethod_34(ref Vector3 vector3_11, ref Vector3 vector3_12, float float_3, out Vector3 vector3_13)
    {
      float_3 = (double) float_3 > 1.0 ? 1f : ((double) float_3 < 0.0 ? 0.0f : float_3);
      float_3 = (float) ((double) float_3 * (double) float_3 * (3.0 - 2.0 * (double) float_3));
      vector3_13.float_0 = vector3_11.float_0 + (vector3_12.float_0 - vector3_11.float_0) * float_3;
      vector3_13.float_1 = vector3_11.float_1 + (vector3_12.float_1 - vector3_11.float_1) * float_3;
      vector3_13.float_2 = vector3_11.float_2 + (vector3_12.float_2 - vector3_11.float_2) * float_3;
    }

    public static Vector3 smethod_35(Vector3 vector3_11, Vector3 vector3_12, Vector3 vector3_13, Vector3 vector3_14, float float_3)
    {
      float num1 = float_3 * float_3;
      float num2 = float_3 * num1;
      Vector3 vector3;
      vector3.float_0 = (float) (0.5 * (2.0 * (double) vector3_12.float_0 + (-(double) vector3_11.float_0 + (double) vector3_13.float_0) * (double) float_3 + (2.0 * (double) vector3_11.float_0 - 5.0 * (double) vector3_12.float_0 + 4.0 * (double) vector3_13.float_0 - (double) vector3_14.float_0) * (double) num1 + (-(double) vector3_11.float_0 + 3.0 * (double) vector3_12.float_0 - 3.0 * (double) vector3_13.float_0 + (double) vector3_14.float_0) * (double) num2));
      vector3.float_1 = (float) (0.5 * (2.0 * (double) vector3_12.float_1 + (-(double) vector3_11.float_1 + (double) vector3_13.float_1) * (double) float_3 + (2.0 * (double) vector3_11.float_1 - 5.0 * (double) vector3_12.float_1 + 4.0 * (double) vector3_13.float_1 - (double) vector3_14.float_1) * (double) num1 + (-(double) vector3_11.float_1 + 3.0 * (double) vector3_12.float_1 - 3.0 * (double) vector3_13.float_1 + (double) vector3_14.float_1) * (double) num2));
      vector3.float_2 = (float) (0.5 * (2.0 * (double) vector3_12.float_2 + (-(double) vector3_11.float_2 + (double) vector3_13.float_2) * (double) float_3 + (2.0 * (double) vector3_11.float_2 - 5.0 * (double) vector3_12.float_2 + 4.0 * (double) vector3_13.float_2 - (double) vector3_14.float_2) * (double) num1 + (-(double) vector3_11.float_2 + 3.0 * (double) vector3_12.float_2 - 3.0 * (double) vector3_13.float_2 + (double) vector3_14.float_2) * (double) num2));
      return vector3;
    }

    public static void smethod_36(ref Vector3 vector3_11, ref Vector3 vector3_12, ref Vector3 vector3_13, ref Vector3 vector3_14, float float_3, out Vector3 vector3_15)
    {
      float num1 = float_3 * float_3;
      float num2 = float_3 * num1;
      vector3_15.float_0 = (float) (0.5 * (2.0 * (double) vector3_12.float_0 + (-(double) vector3_11.float_0 + (double) vector3_13.float_0) * (double) float_3 + (2.0 * (double) vector3_11.float_0 - 5.0 * (double) vector3_12.float_0 + 4.0 * (double) vector3_13.float_0 - (double) vector3_14.float_0) * (double) num1 + (-(double) vector3_11.float_0 + 3.0 * (double) vector3_12.float_0 - 3.0 * (double) vector3_13.float_0 + (double) vector3_14.float_0) * (double) num2));
      vector3_15.float_1 = (float) (0.5 * (2.0 * (double) vector3_12.float_1 + (-(double) vector3_11.float_1 + (double) vector3_13.float_1) * (double) float_3 + (2.0 * (double) vector3_11.float_1 - 5.0 * (double) vector3_12.float_1 + 4.0 * (double) vector3_13.float_1 - (double) vector3_14.float_1) * (double) num1 + (-(double) vector3_11.float_1 + 3.0 * (double) vector3_12.float_1 - 3.0 * (double) vector3_13.float_1 + (double) vector3_14.float_1) * (double) num2));
      vector3_15.float_2 = (float) (0.5 * (2.0 * (double) vector3_12.float_2 + (-(double) vector3_11.float_2 + (double) vector3_13.float_2) * (double) float_3 + (2.0 * (double) vector3_11.float_2 - 5.0 * (double) vector3_12.float_2 + 4.0 * (double) vector3_13.float_2 - (double) vector3_14.float_2) * (double) num1 + (-(double) vector3_11.float_2 + 3.0 * (double) vector3_12.float_2 - 3.0 * (double) vector3_13.float_2 + (double) vector3_14.float_2) * (double) num2));
    }

    public static Vector3 smethod_37(Vector3 vector3_11, Vector3 vector3_12, Vector3 vector3_13, Vector3 vector3_14, float float_3)
    {
      float num1 = float_3 * float_3;
      float num2 = float_3 * num1;
      float num3 = (float) (2.0 * (double) num2 - 3.0 * (double) num1 + 1.0);
      float num4 = (float) (-2.0 * (double) num2 + 3.0 * (double) num1);
      float num5 = num2 - 2f * num1 + float_3;
      float num6 = num2 - num1;
      Vector3 vector3;
      vector3.float_0 = (float) ((double) vector3_11.float_0 * (double) num3 + (double) vector3_13.float_0 * (double) num4 + (double) vector3_12.float_0 * (double) num5 + (double) vector3_14.float_0 * (double) num6);
      vector3.float_1 = (float) ((double) vector3_11.float_1 * (double) num3 + (double) vector3_13.float_1 * (double) num4 + (double) vector3_12.float_1 * (double) num5 + (double) vector3_14.float_1 * (double) num6);
      vector3.float_2 = (float) ((double) vector3_11.float_2 * (double) num3 + (double) vector3_13.float_2 * (double) num4 + (double) vector3_12.float_2 * (double) num5 + (double) vector3_14.float_2 * (double) num6);
      return vector3;
    }

    public static void smethod_38(ref Vector3 vector3_11, ref Vector3 vector3_12, ref Vector3 vector3_13, ref Vector3 vector3_14, float float_3, out Vector3 vector3_15)
    {
      float num1 = float_3 * float_3;
      float num2 = float_3 * num1;
      float num3 = (float) (2.0 * (double) num2 - 3.0 * (double) num1 + 1.0);
      float num4 = (float) (-2.0 * (double) num2 + 3.0 * (double) num1);
      float num5 = num2 - 2f * num1 + float_3;
      float num6 = num2 - num1;
      vector3_15.float_0 = (float) ((double) vector3_11.float_0 * (double) num3 + (double) vector3_13.float_0 * (double) num4 + (double) vector3_12.float_0 * (double) num5 + (double) vector3_14.float_0 * (double) num6);
      vector3_15.float_1 = (float) ((double) vector3_11.float_1 * (double) num3 + (double) vector3_13.float_1 * (double) num4 + (double) vector3_12.float_1 * (double) num5 + (double) vector3_14.float_1 * (double) num6);
      vector3_15.float_2 = (float) ((double) vector3_11.float_2 * (double) num3 + (double) vector3_13.float_2 * (double) num4 + (double) vector3_12.float_2 * (double) num5 + (double) vector3_14.float_2 * (double) num6);
    }

    public static Vector3 smethod_39(Vector3 vector3_11, Matrix matrix_0)
    {
      float num1 = (float) ((double) vector3_11.float_0 * (double) matrix_0.M11 + (double) vector3_11.float_1 * (double) matrix_0.M21 + (double) vector3_11.float_2 * (double) matrix_0.M31) + matrix_0.M41;
      float num2 = (float) ((double) vector3_11.float_0 * (double) matrix_0.M12 + (double) vector3_11.float_1 * (double) matrix_0.M22 + (double) vector3_11.float_2 * (double) matrix_0.M32) + matrix_0.M42;
      float num3 = (float) ((double) vector3_11.float_0 * (double) matrix_0.M13 + (double) vector3_11.float_1 * (double) matrix_0.M23 + (double) vector3_11.float_2 * (double) matrix_0.M33) + matrix_0.M43;
      Vector3 vector3;
      vector3.float_0 = num1;
      vector3.float_1 = num2;
      vector3.float_2 = num3;
      return vector3;
    }

    public static void smethod_40(ref Vector3 vector3_11, ref Matrix matrix_0, out Vector3 vector3_12)
    {
      float num1 = (float) ((double) vector3_11.float_0 * (double) matrix_0.M11 + (double) vector3_11.float_1 * (double) matrix_0.M21 + (double) vector3_11.float_2 * (double) matrix_0.M31) + matrix_0.M41;
      float num2 = (float) ((double) vector3_11.float_0 * (double) matrix_0.M12 + (double) vector3_11.float_1 * (double) matrix_0.M22 + (double) vector3_11.float_2 * (double) matrix_0.M32) + matrix_0.M42;
      float num3 = (float) ((double) vector3_11.float_0 * (double) matrix_0.M13 + (double) vector3_11.float_1 * (double) matrix_0.M23 + (double) vector3_11.float_2 * (double) matrix_0.M33) + matrix_0.M43;
      vector3_12.float_0 = num1;
      vector3_12.float_1 = num2;
      vector3_12.float_2 = num3;
    }

    public static Vector3 smethod_41(Vector3 vector3_11, Matrix matrix_0)
    {
      float num1 = (float) ((double) vector3_11.float_0 * (double) matrix_0.M11 + (double) vector3_11.float_1 * (double) matrix_0.M21 + (double) vector3_11.float_2 * (double) matrix_0.M31);
      float num2 = (float) ((double) vector3_11.float_0 * (double) matrix_0.M12 + (double) vector3_11.float_1 * (double) matrix_0.M22 + (double) vector3_11.float_2 * (double) matrix_0.M32);
      float num3 = (float) ((double) vector3_11.float_0 * (double) matrix_0.M13 + (double) vector3_11.float_1 * (double) matrix_0.M23 + (double) vector3_11.float_2 * (double) matrix_0.M33);
      Vector3 vector3;
      vector3.float_0 = num1;
      vector3.float_1 = num2;
      vector3.float_2 = num3;
      return vector3;
    }

    public static void smethod_42(ref Vector3 vector3_11, ref Matrix matrix_0, out Vector3 vector3_12)
    {
      float num1 = (float) ((double) vector3_11.float_0 * (double) matrix_0.M11 + (double) vector3_11.float_1 * (double) matrix_0.M21 + (double) vector3_11.float_2 * (double) matrix_0.M31);
      float num2 = (float) ((double) vector3_11.float_0 * (double) matrix_0.M12 + (double) vector3_11.float_1 * (double) matrix_0.M22 + (double) vector3_11.float_2 * (double) matrix_0.M32);
      float num3 = (float) ((double) vector3_11.float_0 * (double) matrix_0.M13 + (double) vector3_11.float_1 * (double) matrix_0.M23 + (double) vector3_11.float_2 * (double) matrix_0.M33);
      vector3_12.float_0 = num1;
      vector3_12.float_1 = num2;
      vector3_12.float_2 = num3;
    }

    public static void smethod_43(Vector3[] vector3_11, ref Matrix matrix_0, Vector3[] vector3_12)
    {
      if (vector3_11 == null)
        throw new ArgumentNullException("values");
      if (vector3_12 == null)
        throw new ArgumentNullException("results");
      if (vector3_12.Length < vector3_11.Length)
        throw new IndexOutOfRangeException(Class1070.smethod_10());
      for (int index = 0; index < vector3_11.Length; ++index)
      {
        float num1 = vector3_11[index].float_0;
        float num2 = vector3_11[index].float_1;
        float num3 = vector3_11[index].float_2;
        vector3_12[index].float_0 = (float) ((double) num1 * (double) matrix_0.M11 + (double) num2 * (double) matrix_0.M21 + (double) num3 * (double) matrix_0.M31) + matrix_0.M41;
        vector3_12[index].float_1 = (float) ((double) num1 * (double) matrix_0.M12 + (double) num2 * (double) matrix_0.M22 + (double) num3 * (double) matrix_0.M32) + matrix_0.M42;
        vector3_12[index].float_2 = (float) ((double) num1 * (double) matrix_0.M13 + (double) num2 * (double) matrix_0.M23 + (double) num3 * (double) matrix_0.M33) + matrix_0.M43;
      }
    }

    public static void smethod_44(Vector3[] vector3_11, int int_0, ref Matrix matrix_0, Vector3[] vector3_12, int int_1, int int_2)
    {
      if (vector3_11 == null)
        throw new ArgumentNullException("values");
      if (vector3_12 == null)
        throw new ArgumentNullException("results");
      if ((long) vector3_11.Length < (long) int_0 + (long) int_2)
        throw new IndexOutOfRangeException(Class1070.smethod_9());
      if ((long) vector3_12.Length < (long) int_1 + (long) int_2)
        throw new IndexOutOfRangeException(Class1070.smethod_10());
      for (; int_2 > 0; --int_2)
      {
        float num1 = vector3_11[int_0].float_0;
        float num2 = vector3_11[int_0].float_1;
        float num3 = vector3_11[int_0].float_2;
        vector3_12[int_1].float_0 = (float) ((double) num1 * (double) matrix_0.M11 + (double) num2 * (double) matrix_0.M21 + (double) num3 * (double) matrix_0.M31) + matrix_0.M41;
        vector3_12[int_1].float_1 = (float) ((double) num1 * (double) matrix_0.M12 + (double) num2 * (double) matrix_0.M22 + (double) num3 * (double) matrix_0.M32) + matrix_0.M42;
        vector3_12[int_1].float_2 = (float) ((double) num1 * (double) matrix_0.M13 + (double) num2 * (double) matrix_0.M23 + (double) num3 * (double) matrix_0.M33) + matrix_0.M43;
        ++int_0;
        ++int_1;
      }
    }

    public static void smethod_45(Vector3[] vector3_11, ref Matrix matrix_0, Vector3[] vector3_12)
    {
      if (vector3_11 == null)
        throw new ArgumentNullException("values");
      if (vector3_12 == null)
        throw new ArgumentNullException("results");
      if (vector3_12.Length < vector3_11.Length)
        throw new IndexOutOfRangeException(Class1070.smethod_10());
      for (int index = 0; index < vector3_11.Length; ++index)
      {
        float num1 = vector3_11[index].float_0;
        float num2 = vector3_11[index].float_1;
        float num3 = vector3_11[index].float_2;
        vector3_12[index].float_0 = (float) ((double) num1 * (double) matrix_0.M11 + (double) num2 * (double) matrix_0.M21 + (double) num3 * (double) matrix_0.M31);
        vector3_12[index].float_1 = (float) ((double) num1 * (double) matrix_0.M12 + (double) num2 * (double) matrix_0.M22 + (double) num3 * (double) matrix_0.M32);
        vector3_12[index].float_2 = (float) ((double) num1 * (double) matrix_0.M13 + (double) num2 * (double) matrix_0.M23 + (double) num3 * (double) matrix_0.M33);
      }
    }

    public static void smethod_46(Vector3[] vector3_11, int int_0, ref Matrix matrix_0, Vector3[] vector3_12, int int_1, int int_2)
    {
      if (vector3_11 == null)
        throw new ArgumentNullException("values");
      if (vector3_12 == null)
        throw new ArgumentNullException("results");
      if ((long) vector3_11.Length < (long) int_0 + (long) int_2)
        throw new IndexOutOfRangeException(Class1070.smethod_9());
      if ((long) vector3_12.Length < (long) int_1 + (long) int_2)
        throw new IndexOutOfRangeException(Class1070.smethod_10());
      for (; int_2 > 0; --int_2)
      {
        float num1 = vector3_11[int_0].float_0;
        float num2 = vector3_11[int_0].float_1;
        float num3 = vector3_11[int_0].float_2;
        vector3_12[int_1].float_0 = (float) ((double) num1 * (double) matrix_0.M11 + (double) num2 * (double) matrix_0.M21 + (double) num3 * (double) matrix_0.M31);
        vector3_12[int_1].float_1 = (float) ((double) num1 * (double) matrix_0.M12 + (double) num2 * (double) matrix_0.M22 + (double) num3 * (double) matrix_0.M32);
        vector3_12[int_1].float_2 = (float) ((double) num1 * (double) matrix_0.M13 + (double) num2 * (double) matrix_0.M23 + (double) num3 * (double) matrix_0.M33);
        ++int_0;
        ++int_1;
      }
    }

    public static Vector3 smethod_47(Vector3 vector3_11)
    {
      Vector3 vector3;
      vector3.float_0 = -vector3_11.float_0;
      vector3.float_1 = -vector3_11.float_1;
      vector3.float_2 = -vector3_11.float_2;
      return vector3;
    }

    public static void smethod_48(ref Vector3 vector3_11, out Vector3 vector3_12)
    {
      vector3_12.float_0 = -vector3_11.float_0;
      vector3_12.float_1 = -vector3_11.float_1;
      vector3_12.float_2 = -vector3_11.float_2;
    }

    public static Vector3 smethod_49(Vector3 vector3_11, Vector3 vector3_12)
    {
      Vector3 vector3;
      vector3.float_0 = vector3_11.float_0 + vector3_12.float_0;
      vector3.float_1 = vector3_11.float_1 + vector3_12.float_1;
      vector3.float_2 = vector3_11.float_2 + vector3_12.float_2;
      return vector3;
    }

    public static void smethod_50(ref Vector3 vector3_11, ref Vector3 vector3_12, out Vector3 vector3_13)
    {
      vector3_13.float_0 = vector3_11.float_0 + vector3_12.float_0;
      vector3_13.float_1 = vector3_11.float_1 + vector3_12.float_1;
      vector3_13.float_2 = vector3_11.float_2 + vector3_12.float_2;
    }

    public static Vector3 smethod_51(Vector3 vector3_11, Vector3 vector3_12)
    {
      Vector3 vector3;
      vector3.float_0 = vector3_11.float_0 - vector3_12.float_0;
      vector3.float_1 = vector3_11.float_1 - vector3_12.float_1;
      vector3.float_2 = vector3_11.float_2 - vector3_12.float_2;
      return vector3;
    }

    public static void smethod_52(ref Vector3 vector3_11, ref Vector3 vector3_12, out Vector3 vector3_13)
    {
      vector3_13.float_0 = vector3_11.float_0 - vector3_12.float_0;
      vector3_13.float_1 = vector3_11.float_1 - vector3_12.float_1;
      vector3_13.float_2 = vector3_11.float_2 - vector3_12.float_2;
    }

    public static Vector3 smethod_53(Vector3 vector3_11, Vector3 vector3_12)
    {
      Vector3 vector3;
      vector3.float_0 = vector3_11.float_0 * vector3_12.float_0;
      vector3.float_1 = vector3_11.float_1 * vector3_12.float_1;
      vector3.float_2 = vector3_11.float_2 * vector3_12.float_2;
      return vector3;
    }

    public static void smethod_54(ref Vector3 vector3_11, ref Vector3 vector3_12, out Vector3 vector3_13)
    {
      vector3_13.float_0 = vector3_11.float_0 * vector3_12.float_0;
      vector3_13.float_1 = vector3_11.float_1 * vector3_12.float_1;
      vector3_13.float_2 = vector3_11.float_2 * vector3_12.float_2;
    }

    public static Vector3 smethod_55(Vector3 vector3_11, float float_3)
    {
      Vector3 vector3;
      vector3.float_0 = vector3_11.float_0 * float_3;
      vector3.float_1 = vector3_11.float_1 * float_3;
      vector3.float_2 = vector3_11.float_2 * float_3;
      return vector3;
    }

    public static void smethod_56(ref Vector3 vector3_11, float float_3, out Vector3 vector3_12)
    {
      vector3_12.float_0 = vector3_11.float_0 * float_3;
      vector3_12.float_1 = vector3_11.float_1 * float_3;
      vector3_12.float_2 = vector3_11.float_2 * float_3;
    }

    public static Vector3 smethod_57(Vector3 vector3_11, Vector3 vector3_12)
    {
      Vector3 vector3;
      vector3.float_0 = vector3_11.float_0 / vector3_12.float_0;
      vector3.float_1 = vector3_11.float_1 / vector3_12.float_1;
      vector3.float_2 = vector3_11.float_2 / vector3_12.float_2;
      return vector3;
    }

    public static void smethod_58(ref Vector3 vector3_11, ref Vector3 vector3_12, out Vector3 vector3_13)
    {
      vector3_13.float_0 = vector3_11.float_0 / vector3_12.float_0;
      vector3_13.float_1 = vector3_11.float_1 / vector3_12.float_1;
      vector3_13.float_2 = vector3_11.float_2 / vector3_12.float_2;
    }

    public static Vector3 smethod_59(Vector3 vector3_11, float float_3)
    {
      float num = 1f / float_3;
      Vector3 vector3;
      vector3.float_0 = vector3_11.float_0 * num;
      vector3.float_1 = vector3_11.float_1 * num;
      vector3.float_2 = vector3_11.float_2 * num;
      return vector3;
    }

    public static void smethod_60(ref Vector3 vector3_11, float float_3, out Vector3 vector3_12)
    {
      float num = 1f / float_3;
      vector3_12.float_0 = vector3_11.float_0 * num;
      vector3_12.float_1 = vector3_11.float_1 * num;
      vector3_12.float_2 = vector3_11.float_2 * num;
    }
  }
}
