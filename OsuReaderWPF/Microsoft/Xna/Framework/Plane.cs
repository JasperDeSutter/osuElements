// Decompiled with JetBrains decompiler
// Type: Microsoft.Xna.Framework.Plane
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
  public struct Plane : IEquatable<Plane>
  {
    public Vector3 Normal;
    public float float_0;

    public Plane(float float_1, float float_2, float float_3, float float_4)
    {
      this.Normal.float_0 = float_1;
      this.Normal.float_1 = float_2;
      this.Normal.float_2 = float_3;
      this.float_0 = float_4;
    }

    public Plane(Vector3 vector3_0, float float_1)
    {
      this.Normal = vector3_0;
      this.float_0 = float_1;
    }

    public Plane(Vector4 vector4_0)
    {
      this.Normal.float_0 = vector4_0.float_0;
      this.Normal.float_1 = vector4_0.float_1;
      this.Normal.float_2 = vector4_0.float_2;
      this.float_0 = vector4_0.float_3;
    }

    public Plane(Vector3 vector3_0, Vector3 vector3_1, Vector3 vector3_2)
    {
      float num1 = vector3_1.float_0 - vector3_0.float_0;
      float num2 = vector3_1.float_1 - vector3_0.float_1;
      float num3 = vector3_1.float_2 - vector3_0.float_2;
      float num4 = vector3_2.float_0 - vector3_0.float_0;
      float num5 = vector3_2.float_1 - vector3_0.float_1;
      float num6 = vector3_2.float_2 - vector3_0.float_2;
      float num7 = (float) ((double) num2 * (double) num6 - (double) num3 * (double) num5);
      float num8 = (float) ((double) num3 * (double) num4 - (double) num1 * (double) num6);
      float num9 = (float) ((double) num1 * (double) num5 - (double) num2 * (double) num4);
      float num10 = 1f / (float) Math.Sqrt((double) num7 * (double) num7 + (double) num8 * (double) num8 + (double) num9 * (double) num9);
      this.Normal.float_0 = num7 * num10;
      this.Normal.float_1 = num8 * num10;
      this.Normal.float_2 = num9 * num10;
      this.float_0 = (float) -((double) this.Normal.float_0 * (double) vector3_0.float_0 + (double) this.Normal.float_1 * (double) vector3_0.float_1 + (double) this.Normal.float_2 * (double) vector3_0.float_2);
    }

    public static bool operator ==(Plane plane_0, Plane plane_1)
    {
      return plane_0.Equals(plane_1);
    }

    public static bool operator !=(Plane plane_0, Plane plane_1)
    {
      if ((double) plane_0.Normal.float_0 == (double) plane_1.Normal.float_0 && (double) plane_0.Normal.float_1 == (double) plane_1.Normal.float_1 && (double) plane_0.Normal.float_2 == (double) plane_1.Normal.float_2)
        return (double) plane_0.float_0 != (double) plane_1.float_0;
      return true;
    }

    public bool Equals(Plane other)
    {
      if ((double) this.Normal.float_0 == (double) other.Normal.float_0 && (double) this.Normal.float_1 == (double) other.Normal.float_1 && (double) this.Normal.float_2 == (double) other.Normal.float_2)
        return (double) this.float_0 == (double) other.float_0;
      return false;
    }

    public override bool Equals(object obj)
    {
      bool flag = false;
      if (obj is Plane)
        flag = this.Equals((Plane) obj);
      return flag;
    }

    public override int GetHashCode()
    {
      return this.Normal.GetHashCode() + this.float_0.GetHashCode();
    }

    public override string ToString()
    {
      CultureInfo currentCulture = CultureInfo.CurrentCulture;
      return string.Format((IFormatProvider) currentCulture, "{{Normal:{0} D:{1}}}", new object[2]
      {
        (object) this.Normal.ToString(),
        (object) this.float_0.ToString((IFormatProvider) currentCulture)
      });
    }

    public void method_0()
    {
      float num1 = (float) ((double) this.Normal.float_0 * (double) this.Normal.float_0 + (double) this.Normal.float_1 * (double) this.Normal.float_1 + (double) this.Normal.float_2 * (double) this.Normal.float_2);
      if ((double) Math.Abs(num1 - 1f) < 1.19209289550781E-07)
        return;
      float num2 = 1f / (float) Math.Sqrt((double) num1);
      this.Normal.float_0 = this.Normal.float_0 * num2;
      this.Normal.float_1 = this.Normal.float_1 * num2;
      this.Normal.float_2 = this.Normal.float_2 * num2;
      this.float_0 *= num2;
    }

    public static Plane smethod_0(Plane plane_0)
    {
      float num1 = (float) ((double) plane_0.Normal.float_0 * (double) plane_0.Normal.float_0 + (double) plane_0.Normal.float_1 * (double) plane_0.Normal.float_1 + (double) plane_0.Normal.float_2 * (double) plane_0.Normal.float_2);
      if ((double) Math.Abs(num1 - 1f) < 1.19209289550781E-07)
      {
        Plane plane;
        plane.Normal = plane_0.Normal;
        plane.float_0 = plane_0.float_0;
        return plane;
      }
      float num2 = 1f / (float) Math.Sqrt((double) num1);
      Plane plane1;
      plane1.Normal.float_0 = plane_0.Normal.float_0 * num2;
      plane1.Normal.float_1 = plane_0.Normal.float_1 * num2;
      plane1.Normal.float_2 = plane_0.Normal.float_2 * num2;
      plane1.float_0 = plane_0.float_0 * num2;
      return plane1;
    }

    public static void smethod_1(ref Plane plane_0, out Plane plane_1)
    {
      float num1 = (float) ((double) plane_0.Normal.float_0 * (double) plane_0.Normal.float_0 + (double) plane_0.Normal.float_1 * (double) plane_0.Normal.float_1 + (double) plane_0.Normal.float_2 * (double) plane_0.Normal.float_2);
      if ((double) Math.Abs(num1 - 1f) < 1.19209289550781E-07)
      {
        plane_1.Normal = plane_0.Normal;
        plane_1.float_0 = plane_0.float_0;
      }
      else
      {
        float num2 = 1f / (float) Math.Sqrt((double) num1);
        plane_1.Normal.float_0 = plane_0.Normal.float_0 * num2;
        plane_1.Normal.float_1 = plane_0.Normal.float_1 * num2;
        plane_1.Normal.float_2 = plane_0.Normal.float_2 * num2;
        plane_1.float_0 = plane_0.float_0 * num2;
      }
    }

    public static Plane smethod_2(Plane plane_0, Matrix matrix_0)
    {
      Matrix matrix_2;
      Matrix.smethod_42(ref matrix_0, out matrix_2);
      float num1 = plane_0.Normal.float_0;
      float num2 = plane_0.Normal.float_1;
      float num3 = plane_0.Normal.float_2;
      float num4 = plane_0.float_0;
      Plane plane;
      plane.Normal.float_0 = (float) ((double) num1 * (double) matrix_2.M11 + (double) num2 * (double) matrix_2.M12 + (double) num3 * (double) matrix_2.M13 + (double) num4 * (double) matrix_2.M14);
      plane.Normal.float_1 = (float) ((double) num1 * (double) matrix_2.M21 + (double) num2 * (double) matrix_2.M22 + (double) num3 * (double) matrix_2.M23 + (double) num4 * (double) matrix_2.M24);
      plane.Normal.float_2 = (float) ((double) num1 * (double) matrix_2.M31 + (double) num2 * (double) matrix_2.M32 + (double) num3 * (double) matrix_2.M33 + (double) num4 * (double) matrix_2.M34);
      plane.float_0 = (float) ((double) num1 * (double) matrix_2.M41 + (double) num2 * (double) matrix_2.M42 + (double) num3 * (double) matrix_2.M43 + (double) num4 * (double) matrix_2.M44);
      return plane;
    }

    public static void smethod_3(ref Plane plane_0, ref Matrix matrix_0, out Plane plane_1)
    {
      Matrix matrix_2;
      Matrix.smethod_42(ref matrix_0, out matrix_2);
      float num1 = plane_0.Normal.float_0;
      float num2 = plane_0.Normal.float_1;
      float num3 = plane_0.Normal.float_2;
      float num4 = plane_0.float_0;
      plane_1.Normal.float_0 = (float) ((double) num1 * (double) matrix_2.M11 + (double) num2 * (double) matrix_2.M12 + (double) num3 * (double) matrix_2.M13 + (double) num4 * (double) matrix_2.M14);
      plane_1.Normal.float_1 = (float) ((double) num1 * (double) matrix_2.M21 + (double) num2 * (double) matrix_2.M22 + (double) num3 * (double) matrix_2.M23 + (double) num4 * (double) matrix_2.M24);
      plane_1.Normal.float_2 = (float) ((double) num1 * (double) matrix_2.M31 + (double) num2 * (double) matrix_2.M32 + (double) num3 * (double) matrix_2.M33 + (double) num4 * (double) matrix_2.M34);
      plane_1.float_0 = (float) ((double) num1 * (double) matrix_2.M41 + (double) num2 * (double) matrix_2.M42 + (double) num3 * (double) matrix_2.M43 + (double) num4 * (double) matrix_2.M44);
    }

    public float method_1(Vector4 vector4_0)
    {
      return (float) ((double) this.Normal.float_0 * (double) vector4_0.float_0 + (double) this.Normal.float_1 * (double) vector4_0.float_1 + (double) this.Normal.float_2 * (double) vector4_0.float_2 + (double) this.float_0 * (double) vector4_0.float_3);
    }

    public void method_2(ref Vector4 vector4_0, out float float_1)
    {
      float_1 = (float) ((double) this.Normal.float_0 * (double) vector4_0.float_0 + (double) this.Normal.float_1 * (double) vector4_0.float_1 + (double) this.Normal.float_2 * (double) vector4_0.float_2 + (double) this.float_0 * (double) vector4_0.float_3);
    }

    public float method_3(Vector3 vector3_0)
    {
      return (float) ((double) this.Normal.float_0 * (double) vector3_0.float_0 + (double) this.Normal.float_1 * (double) vector3_0.float_1 + (double) this.Normal.float_2 * (double) vector3_0.float_2) + this.float_0;
    }

    public void method_4(ref Vector3 vector3_0, out float float_1)
    {
      float_1 = (float) ((double) this.Normal.float_0 * (double) vector3_0.float_0 + (double) this.Normal.float_1 * (double) vector3_0.float_1 + (double) this.Normal.float_2 * (double) vector3_0.float_2) + this.float_0;
    }

    public float method_5(Vector3 vector3_0)
    {
      return (float) ((double) this.Normal.float_0 * (double) vector3_0.float_0 + (double) this.Normal.float_1 * (double) vector3_0.float_1 + (double) this.Normal.float_2 * (double) vector3_0.float_2);
    }

    public void method_6(ref Vector3 vector3_0, out float float_1)
    {
      float_1 = (float) ((double) this.Normal.float_0 * (double) vector3_0.float_0 + (double) this.Normal.float_1 * (double) vector3_0.float_1 + (double) this.Normal.float_2 * (double) vector3_0.float_2);
    }

    public GEnum97 method_7(BoundingBox boundingBox_0)
    {
      Vector3 vector3_1;
      vector3_1.float_0 = (double) this.Normal.float_0 >= 0.0 ? boundingBox_0.Min.float_0 : boundingBox_0.Max.float_0;
      vector3_1.float_1 = (double) this.Normal.float_1 >= 0.0 ? boundingBox_0.Min.float_1 : boundingBox_0.Max.float_1;
      vector3_1.float_2 = (double) this.Normal.float_2 >= 0.0 ? boundingBox_0.Min.float_2 : boundingBox_0.Max.float_2;
      Vector3 vector3_2;
      vector3_2.float_0 = (double) this.Normal.float_0 >= 0.0 ? boundingBox_0.Max.float_0 : boundingBox_0.Min.float_0;
      vector3_2.float_1 = (double) this.Normal.float_1 >= 0.0 ? boundingBox_0.Max.float_1 : boundingBox_0.Min.float_1;
      vector3_2.float_2 = (double) this.Normal.float_2 >= 0.0 ? boundingBox_0.Max.float_2 : boundingBox_0.Min.float_2;
      if ((double) this.Normal.float_0 * (double) vector3_1.float_0 + (double) this.Normal.float_1 * (double) vector3_1.float_1 + (double) this.Normal.float_2 * (double) vector3_1.float_2 + (double) this.float_0 > 0.0)
        return (GEnum97) 0;
      return (double) this.Normal.float_0 * (double) vector3_2.float_0 + (double) this.Normal.float_1 * (double) vector3_2.float_1 + (double) this.Normal.float_2 * (double) vector3_2.float_2 + (double) this.float_0 < 0.0 ? (GEnum97) 1 : (GEnum97) 2;
    }

    public void method_8(ref BoundingBox boundingBox_0, out GEnum97 genum97_0)
    {
      Vector3 vector3_1;
      vector3_1.float_0 = (double) this.Normal.float_0 >= 0.0 ? boundingBox_0.Min.float_0 : boundingBox_0.Max.float_0;
      vector3_1.float_1 = (double) this.Normal.float_1 >= 0.0 ? boundingBox_0.Min.float_1 : boundingBox_0.Max.float_1;
      vector3_1.float_2 = (double) this.Normal.float_2 >= 0.0 ? boundingBox_0.Min.float_2 : boundingBox_0.Max.float_2;
      Vector3 vector3_2;
      vector3_2.float_0 = (double) this.Normal.float_0 >= 0.0 ? boundingBox_0.Max.float_0 : boundingBox_0.Min.float_0;
      vector3_2.float_1 = (double) this.Normal.float_1 >= 0.0 ? boundingBox_0.Max.float_1 : boundingBox_0.Min.float_1;
      vector3_2.float_2 = (double) this.Normal.float_2 >= 0.0 ? boundingBox_0.Max.float_2 : boundingBox_0.Min.float_2;
      if ((double) this.Normal.float_0 * (double) vector3_1.float_0 + (double) this.Normal.float_1 * (double) vector3_1.float_1 + (double) this.Normal.float_2 * (double) vector3_1.float_2 + (double) this.float_0 > 0.0)
        genum97_0 = (GEnum97) 0;
      else if ((double) this.Normal.float_0 * (double) vector3_2.float_0 + (double) this.Normal.float_1 * (double) vector3_2.float_1 + (double) this.Normal.float_2 * (double) vector3_2.float_2 + (double) this.float_0 < 0.0)
        genum97_0 = (GEnum97) 1;
      else
        genum97_0 = (GEnum97) 2;
    }
  }
}
