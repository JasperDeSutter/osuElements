// Decompiled with JetBrains decompiler
// Type: Microsoft.Xna.Framework.Matrix
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
  public struct Matrix : IEquatable<Matrix>
  {
    private static Matrix matrix_0 = new Matrix(1f, 0.0f, 0.0f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, 0.0f, 1f);
    public float M11;
    public float M12;
    public float M13;
    public float M14;
    public float M21;
    public float M22;
    public float M23;
    public float M24;
    public float M31;
    public float M32;
    public float M33;
    public float M34;
    public float M41;
    public float M42;
    public float M43;
    public float M44;

    public Matrix(float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, float float_6, float float_7, float float_8, float float_9, float float_10, float float_11, float float_12, float float_13, float float_14, float float_15)
    {
      this.M11 = float_0;
      this.M12 = float_1;
      this.M13 = float_2;
      this.M14 = float_3;
      this.M21 = float_4;
      this.M22 = float_5;
      this.M23 = float_6;
      this.M24 = float_7;
      this.M31 = float_8;
      this.M32 = float_9;
      this.M33 = float_10;
      this.M34 = float_11;
      this.M41 = float_12;
      this.M42 = float_13;
      this.M43 = float_14;
      this.M44 = float_15;
    }

    public static Matrix operator -(Matrix matrix_1)
    {
      Matrix matrix;
      matrix.M11 = -matrix_1.M11;
      matrix.M12 = -matrix_1.M12;
      matrix.M13 = -matrix_1.M13;
      matrix.M14 = -matrix_1.M14;
      matrix.M21 = -matrix_1.M21;
      matrix.M22 = -matrix_1.M22;
      matrix.M23 = -matrix_1.M23;
      matrix.M24 = -matrix_1.M24;
      matrix.M31 = -matrix_1.M31;
      matrix.M32 = -matrix_1.M32;
      matrix.M33 = -matrix_1.M33;
      matrix.M34 = -matrix_1.M34;
      matrix.M41 = -matrix_1.M41;
      matrix.M42 = -matrix_1.M42;
      matrix.M43 = -matrix_1.M43;
      matrix.M44 = -matrix_1.M44;
      return matrix;
    }

    public static bool operator ==(Matrix matrix_1, Matrix matrix_2)
    {
      if ((double) matrix_1.M11 == (double) matrix_2.M11 && (double) matrix_1.M22 == (double) matrix_2.M22 && ((double) matrix_1.M33 == (double) matrix_2.M33 && (double) matrix_1.M44 == (double) matrix_2.M44) && ((double) matrix_1.M12 == (double) matrix_2.M12 && (double) matrix_1.M13 == (double) matrix_2.M13 && ((double) matrix_1.M14 == (double) matrix_2.M14 && (double) matrix_1.M21 == (double) matrix_2.M21)) && ((double) matrix_1.M23 == (double) matrix_2.M23 && (double) matrix_1.M24 == (double) matrix_2.M24 && ((double) matrix_1.M31 == (double) matrix_2.M31 && (double) matrix_1.M32 == (double) matrix_2.M32) && ((double) matrix_1.M34 == (double) matrix_2.M34 && (double) matrix_1.M41 == (double) matrix_2.M41 && (double) matrix_1.M42 == (double) matrix_2.M42)))
        return (double) matrix_1.M43 == (double) matrix_2.M43;
      return false;
    }

    public static bool operator !=(Matrix matrix_1, Matrix matrix_2)
    {
      if ((double) matrix_1.M11 == (double) matrix_2.M11 && (double) matrix_1.M12 == (double) matrix_2.M12 && ((double) matrix_1.M13 == (double) matrix_2.M13 && (double) matrix_1.M14 == (double) matrix_2.M14) && ((double) matrix_1.M21 == (double) matrix_2.M21 && (double) matrix_1.M22 == (double) matrix_2.M22 && ((double) matrix_1.M23 == (double) matrix_2.M23 && (double) matrix_1.M24 == (double) matrix_2.M24)) && ((double) matrix_1.M31 == (double) matrix_2.M31 && (double) matrix_1.M32 == (double) matrix_2.M32 && ((double) matrix_1.M33 == (double) matrix_2.M33 && (double) matrix_1.M34 == (double) matrix_2.M34) && ((double) matrix_1.M41 == (double) matrix_2.M41 && (double) matrix_1.M42 == (double) matrix_2.M42 && (double) matrix_1.M43 == (double) matrix_2.M43)))
        return (double) matrix_1.M44 != (double) matrix_2.M44;
      return true;
    }

    public static Matrix operator +(Matrix matrix_1, Matrix matrix_2)
    {
      Matrix matrix;
      matrix.M11 = matrix_1.M11 + matrix_2.M11;
      matrix.M12 = matrix_1.M12 + matrix_2.M12;
      matrix.M13 = matrix_1.M13 + matrix_2.M13;
      matrix.M14 = matrix_1.M14 + matrix_2.M14;
      matrix.M21 = matrix_1.M21 + matrix_2.M21;
      matrix.M22 = matrix_1.M22 + matrix_2.M22;
      matrix.M23 = matrix_1.M23 + matrix_2.M23;
      matrix.M24 = matrix_1.M24 + matrix_2.M24;
      matrix.M31 = matrix_1.M31 + matrix_2.M31;
      matrix.M32 = matrix_1.M32 + matrix_2.M32;
      matrix.M33 = matrix_1.M33 + matrix_2.M33;
      matrix.M34 = matrix_1.M34 + matrix_2.M34;
      matrix.M41 = matrix_1.M41 + matrix_2.M41;
      matrix.M42 = matrix_1.M42 + matrix_2.M42;
      matrix.M43 = matrix_1.M43 + matrix_2.M43;
      matrix.M44 = matrix_1.M44 + matrix_2.M44;
      return matrix;
    }

    public static Matrix operator -(Matrix matrix_1, Matrix matrix_2)
    {
      Matrix matrix;
      matrix.M11 = matrix_1.M11 - matrix_2.M11;
      matrix.M12 = matrix_1.M12 - matrix_2.M12;
      matrix.M13 = matrix_1.M13 - matrix_2.M13;
      matrix.M14 = matrix_1.M14 - matrix_2.M14;
      matrix.M21 = matrix_1.M21 - matrix_2.M21;
      matrix.M22 = matrix_1.M22 - matrix_2.M22;
      matrix.M23 = matrix_1.M23 - matrix_2.M23;
      matrix.M24 = matrix_1.M24 - matrix_2.M24;
      matrix.M31 = matrix_1.M31 - matrix_2.M31;
      matrix.M32 = matrix_1.M32 - matrix_2.M32;
      matrix.M33 = matrix_1.M33 - matrix_2.M33;
      matrix.M34 = matrix_1.M34 - matrix_2.M34;
      matrix.M41 = matrix_1.M41 - matrix_2.M41;
      matrix.M42 = matrix_1.M42 - matrix_2.M42;
      matrix.M43 = matrix_1.M43 - matrix_2.M43;
      matrix.M44 = matrix_1.M44 - matrix_2.M44;
      return matrix;
    }

    public static Matrix operator *(Matrix matrix_1, Matrix matrix_2)
    {
      Matrix matrix;
      matrix.M11 = (float) ((double) matrix_1.M11 * (double) matrix_2.M11 + (double) matrix_1.M12 * (double) matrix_2.M21 + (double) matrix_1.M13 * (double) matrix_2.M31 + (double) matrix_1.M14 * (double) matrix_2.M41);
      matrix.M12 = (float) ((double) matrix_1.M11 * (double) matrix_2.M12 + (double) matrix_1.M12 * (double) matrix_2.M22 + (double) matrix_1.M13 * (double) matrix_2.M32 + (double) matrix_1.M14 * (double) matrix_2.M42);
      matrix.M13 = (float) ((double) matrix_1.M11 * (double) matrix_2.M13 + (double) matrix_1.M12 * (double) matrix_2.M23 + (double) matrix_1.M13 * (double) matrix_2.M33 + (double) matrix_1.M14 * (double) matrix_2.M43);
      matrix.M14 = (float) ((double) matrix_1.M11 * (double) matrix_2.M14 + (double) matrix_1.M12 * (double) matrix_2.M24 + (double) matrix_1.M13 * (double) matrix_2.M34 + (double) matrix_1.M14 * (double) matrix_2.M44);
      matrix.M21 = (float) ((double) matrix_1.M21 * (double) matrix_2.M11 + (double) matrix_1.M22 * (double) matrix_2.M21 + (double) matrix_1.M23 * (double) matrix_2.M31 + (double) matrix_1.M24 * (double) matrix_2.M41);
      matrix.M22 = (float) ((double) matrix_1.M21 * (double) matrix_2.M12 + (double) matrix_1.M22 * (double) matrix_2.M22 + (double) matrix_1.M23 * (double) matrix_2.M32 + (double) matrix_1.M24 * (double) matrix_2.M42);
      matrix.M23 = (float) ((double) matrix_1.M21 * (double) matrix_2.M13 + (double) matrix_1.M22 * (double) matrix_2.M23 + (double) matrix_1.M23 * (double) matrix_2.M33 + (double) matrix_1.M24 * (double) matrix_2.M43);
      matrix.M24 = (float) ((double) matrix_1.M21 * (double) matrix_2.M14 + (double) matrix_1.M22 * (double) matrix_2.M24 + (double) matrix_1.M23 * (double) matrix_2.M34 + (double) matrix_1.M24 * (double) matrix_2.M44);
      matrix.M31 = (float) ((double) matrix_1.M31 * (double) matrix_2.M11 + (double) matrix_1.M32 * (double) matrix_2.M21 + (double) matrix_1.M33 * (double) matrix_2.M31 + (double) matrix_1.M34 * (double) matrix_2.M41);
      matrix.M32 = (float) ((double) matrix_1.M31 * (double) matrix_2.M12 + (double) matrix_1.M32 * (double) matrix_2.M22 + (double) matrix_1.M33 * (double) matrix_2.M32 + (double) matrix_1.M34 * (double) matrix_2.M42);
      matrix.M33 = (float) ((double) matrix_1.M31 * (double) matrix_2.M13 + (double) matrix_1.M32 * (double) matrix_2.M23 + (double) matrix_1.M33 * (double) matrix_2.M33 + (double) matrix_1.M34 * (double) matrix_2.M43);
      matrix.M34 = (float) ((double) matrix_1.M31 * (double) matrix_2.M14 + (double) matrix_1.M32 * (double) matrix_2.M24 + (double) matrix_1.M33 * (double) matrix_2.M34 + (double) matrix_1.M34 * (double) matrix_2.M44);
      matrix.M41 = (float) ((double) matrix_1.M41 * (double) matrix_2.M11 + (double) matrix_1.M42 * (double) matrix_2.M21 + (double) matrix_1.M43 * (double) matrix_2.M31 + (double) matrix_1.M44 * (double) matrix_2.M41);
      matrix.M42 = (float) ((double) matrix_1.M41 * (double) matrix_2.M12 + (double) matrix_1.M42 * (double) matrix_2.M22 + (double) matrix_1.M43 * (double) matrix_2.M32 + (double) matrix_1.M44 * (double) matrix_2.M42);
      matrix.M43 = (float) ((double) matrix_1.M41 * (double) matrix_2.M13 + (double) matrix_1.M42 * (double) matrix_2.M23 + (double) matrix_1.M43 * (double) matrix_2.M33 + (double) matrix_1.M44 * (double) matrix_2.M43);
      matrix.M44 = (float) ((double) matrix_1.M41 * (double) matrix_2.M14 + (double) matrix_1.M42 * (double) matrix_2.M24 + (double) matrix_1.M43 * (double) matrix_2.M34 + (double) matrix_1.M44 * (double) matrix_2.M44);
      return matrix;
    }

    public static Matrix operator *(Matrix matrix_1, float float_0)
    {
      Matrix matrix;
      matrix.M11 = matrix_1.M11 * float_0;
      matrix.M12 = matrix_1.M12 * float_0;
      matrix.M13 = matrix_1.M13 * float_0;
      matrix.M14 = matrix_1.M14 * float_0;
      matrix.M21 = matrix_1.M21 * float_0;
      matrix.M22 = matrix_1.M22 * float_0;
      matrix.M23 = matrix_1.M23 * float_0;
      matrix.M24 = matrix_1.M24 * float_0;
      matrix.M31 = matrix_1.M31 * float_0;
      matrix.M32 = matrix_1.M32 * float_0;
      matrix.M33 = matrix_1.M33 * float_0;
      matrix.M34 = matrix_1.M34 * float_0;
      matrix.M41 = matrix_1.M41 * float_0;
      matrix.M42 = matrix_1.M42 * float_0;
      matrix.M43 = matrix_1.M43 * float_0;
      matrix.M44 = matrix_1.M44 * float_0;
      return matrix;
    }

    public static Matrix operator *(float float_0, Matrix matrix_1)
    {
      Matrix matrix;
      matrix.M11 = matrix_1.M11 * float_0;
      matrix.M12 = matrix_1.M12 * float_0;
      matrix.M13 = matrix_1.M13 * float_0;
      matrix.M14 = matrix_1.M14 * float_0;
      matrix.M21 = matrix_1.M21 * float_0;
      matrix.M22 = matrix_1.M22 * float_0;
      matrix.M23 = matrix_1.M23 * float_0;
      matrix.M24 = matrix_1.M24 * float_0;
      matrix.M31 = matrix_1.M31 * float_0;
      matrix.M32 = matrix_1.M32 * float_0;
      matrix.M33 = matrix_1.M33 * float_0;
      matrix.M34 = matrix_1.M34 * float_0;
      matrix.M41 = matrix_1.M41 * float_0;
      matrix.M42 = matrix_1.M42 * float_0;
      matrix.M43 = matrix_1.M43 * float_0;
      matrix.M44 = matrix_1.M44 * float_0;
      return matrix;
    }

    public static Matrix operator /(Matrix matrix_1, Matrix matrix_2)
    {
      Matrix matrix;
      matrix.M11 = matrix_1.M11 / matrix_2.M11;
      matrix.M12 = matrix_1.M12 / matrix_2.M12;
      matrix.M13 = matrix_1.M13 / matrix_2.M13;
      matrix.M14 = matrix_1.M14 / matrix_2.M14;
      matrix.M21 = matrix_1.M21 / matrix_2.M21;
      matrix.M22 = matrix_1.M22 / matrix_2.M22;
      matrix.M23 = matrix_1.M23 / matrix_2.M23;
      matrix.M24 = matrix_1.M24 / matrix_2.M24;
      matrix.M31 = matrix_1.M31 / matrix_2.M31;
      matrix.M32 = matrix_1.M32 / matrix_2.M32;
      matrix.M33 = matrix_1.M33 / matrix_2.M33;
      matrix.M34 = matrix_1.M34 / matrix_2.M34;
      matrix.M41 = matrix_1.M41 / matrix_2.M41;
      matrix.M42 = matrix_1.M42 / matrix_2.M42;
      matrix.M43 = matrix_1.M43 / matrix_2.M43;
      matrix.M44 = matrix_1.M44 / matrix_2.M44;
      return matrix;
    }

    public static Matrix operator /(Matrix matrix_1, float float_0)
    {
      float num = 1f / float_0;
      Matrix matrix;
      matrix.M11 = matrix_1.M11 * num;
      matrix.M12 = matrix_1.M12 * num;
      matrix.M13 = matrix_1.M13 * num;
      matrix.M14 = matrix_1.M14 * num;
      matrix.M21 = matrix_1.M21 * num;
      matrix.M22 = matrix_1.M22 * num;
      matrix.M23 = matrix_1.M23 * num;
      matrix.M24 = matrix_1.M24 * num;
      matrix.M31 = matrix_1.M31 * num;
      matrix.M32 = matrix_1.M32 * num;
      matrix.M33 = matrix_1.M33 * num;
      matrix.M34 = matrix_1.M34 * num;
      matrix.M41 = matrix_1.M41 * num;
      matrix.M42 = matrix_1.M42 * num;
      matrix.M43 = matrix_1.M43 * num;
      matrix.M44 = matrix_1.M44 * num;
      return matrix;
    }

    public static Matrix smethod_0()
    {
      return Matrix.matrix_0;
    }

    public Vector3 method_0()
    {
      Vector3 vector3;
      vector3.float_0 = this.M21;
      vector3.float_1 = this.M22;
      vector3.float_2 = this.M23;
      return vector3;
    }

    public void method_1(Vector3 vector3_0)
    {
      this.M21 = vector3_0.float_0;
      this.M22 = vector3_0.float_1;
      this.M23 = vector3_0.float_2;
    }

    public Vector3 method_2()
    {
      Vector3 vector3;
      vector3.float_0 = -this.M21;
      vector3.float_1 = -this.M22;
      vector3.float_2 = -this.M23;
      return vector3;
    }

    public void method_3(Vector3 vector3_0)
    {
      this.M21 = -vector3_0.float_0;
      this.M22 = -vector3_0.float_1;
      this.M23 = -vector3_0.float_2;
    }

    public Vector3 method_4()
    {
      Vector3 vector3;
      vector3.float_0 = this.M11;
      vector3.float_1 = this.M12;
      vector3.float_2 = this.M13;
      return vector3;
    }

    public void method_5(Vector3 vector3_0)
    {
      this.M11 = vector3_0.float_0;
      this.M12 = vector3_0.float_1;
      this.M13 = vector3_0.float_2;
    }

    public Vector3 method_6()
    {
      Vector3 vector3;
      vector3.float_0 = -this.M11;
      vector3.float_1 = -this.M12;
      vector3.float_2 = -this.M13;
      return vector3;
    }

    public void method_7(Vector3 vector3_0)
    {
      this.M11 = -vector3_0.float_0;
      this.M12 = -vector3_0.float_1;
      this.M13 = -vector3_0.float_2;
    }

    public Vector3 method_8()
    {
      Vector3 vector3;
      vector3.float_0 = -this.M31;
      vector3.float_1 = -this.M32;
      vector3.float_2 = -this.M33;
      return vector3;
    }

    public void method_9(Vector3 vector3_0)
    {
      this.M31 = -vector3_0.float_0;
      this.M32 = -vector3_0.float_1;
      this.M33 = -vector3_0.float_2;
    }

    public Vector3 method_10()
    {
      Vector3 vector3;
      vector3.float_0 = this.M31;
      vector3.float_1 = this.M32;
      vector3.float_2 = this.M33;
      return vector3;
    }

    public void method_11(Vector3 vector3_0)
    {
      this.M31 = vector3_0.float_0;
      this.M32 = vector3_0.float_1;
      this.M33 = vector3_0.float_2;
    }

    public Vector3 method_12()
    {
      Vector3 vector3;
      vector3.float_0 = this.M41;
      vector3.float_1 = this.M42;
      vector3.float_2 = this.M43;
      return vector3;
    }

    public void method_13(Vector3 vector3_0)
    {
      this.M41 = vector3_0.float_0;
      this.M42 = vector3_0.float_1;
      this.M43 = vector3_0.float_2;
    }

    public static Matrix smethod_1(Vector3 vector3_0, Vector3 vector3_1, Vector3 vector3_2, Vector3? nullable_0)
    {
      Vector3 vector3_12;
      vector3_12.float_0 = vector3_0.float_0 - vector3_1.float_0;
      vector3_12.float_1 = vector3_0.float_1 - vector3_1.float_1;
      vector3_12.float_2 = vector3_0.float_2 - vector3_1.float_2;
      float num = vector3_12.method_1();
      if ((double) num < 9.99999974737875E-05)
        vector3_12 = nullable_0.HasValue ? -nullable_0.Value : Vector3.smethod_9();
      else
        Vector3.smethod_56(ref vector3_12, 1f / (float) Math.Sqrt((double) num), out vector3_12);
      Vector3 vector3_13_1;
      Vector3.smethod_20(ref vector3_2, ref vector3_12, out vector3_13_1);
      vector3_13_1.method_2();
      Vector3 vector3_13_2;
      Vector3.smethod_20(ref vector3_12, ref vector3_13_1, out vector3_13_2);
      Matrix matrix;
      matrix.M11 = vector3_13_1.float_0;
      matrix.M12 = vector3_13_1.float_1;
      matrix.M13 = vector3_13_1.float_2;
      matrix.M14 = 0.0f;
      matrix.M21 = vector3_13_2.float_0;
      matrix.M22 = vector3_13_2.float_1;
      matrix.M23 = vector3_13_2.float_2;
      matrix.M24 = 0.0f;
      matrix.M31 = vector3_12.float_0;
      matrix.M32 = vector3_12.float_1;
      matrix.M33 = vector3_12.float_2;
      matrix.M34 = 0.0f;
      matrix.M41 = vector3_0.float_0;
      matrix.M42 = vector3_0.float_1;
      matrix.M43 = vector3_0.float_2;
      matrix.M44 = 1f;
      return matrix;
    }

    public static void smethod_2(ref Vector3 vector3_0, ref Vector3 vector3_1, ref Vector3 vector3_2, Vector3? nullable_0, out Matrix matrix_1)
    {
      Vector3 vector3_12;
      vector3_12.float_0 = vector3_0.float_0 - vector3_1.float_0;
      vector3_12.float_1 = vector3_0.float_1 - vector3_1.float_1;
      vector3_12.float_2 = vector3_0.float_2 - vector3_1.float_2;
      float num = vector3_12.method_1();
      if ((double) num < 9.99999974737875E-05)
        vector3_12 = nullable_0.HasValue ? -nullable_0.Value : Vector3.smethod_9();
      else
        Vector3.smethod_56(ref vector3_12, 1f / (float) Math.Sqrt((double) num), out vector3_12);
      Vector3 vector3_13_1;
      Vector3.smethod_20(ref vector3_2, ref vector3_12, out vector3_13_1);
      vector3_13_1.method_2();
      Vector3 vector3_13_2;
      Vector3.smethod_20(ref vector3_12, ref vector3_13_1, out vector3_13_2);
      matrix_1.M11 = vector3_13_1.float_0;
      matrix_1.M12 = vector3_13_1.float_1;
      matrix_1.M13 = vector3_13_1.float_2;
      matrix_1.M14 = 0.0f;
      matrix_1.M21 = vector3_13_2.float_0;
      matrix_1.M22 = vector3_13_2.float_1;
      matrix_1.M23 = vector3_13_2.float_2;
      matrix_1.M24 = 0.0f;
      matrix_1.M31 = vector3_12.float_0;
      matrix_1.M32 = vector3_12.float_1;
      matrix_1.M33 = vector3_12.float_2;
      matrix_1.M34 = 0.0f;
      matrix_1.M41 = vector3_0.float_0;
      matrix_1.M42 = vector3_0.float_1;
      matrix_1.M43 = vector3_0.float_2;
      matrix_1.M44 = 1f;
    }

    public static Matrix smethod_3(Vector3 vector3_0, Vector3 vector3_1, Vector3 vector3_2, Vector3? nullable_0, Vector3? nullable_1)
    {
      Vector3 vector3_12_1;
      vector3_12_1.float_0 = vector3_0.float_0 - vector3_1.float_0;
      vector3_12_1.float_1 = vector3_0.float_1 - vector3_1.float_1;
      vector3_12_1.float_2 = vector3_0.float_2 - vector3_1.float_2;
      float num = vector3_12_1.method_1();
      if ((double) num < 9.99999974737875E-05)
        vector3_12_1 = nullable_0.HasValue ? -nullable_0.Value : Vector3.smethod_9();
      else
        Vector3.smethod_56(ref vector3_12_1, 1f / (float) Math.Sqrt((double) num), out vector3_12_1);
      Vector3 vector3_12_2 = vector3_2;
      float float_3;
      Vector3.smethod_16(ref vector3_2, ref vector3_12_1, out float_3);
      Vector3 vector3_13_1;
      Vector3 vector3_13_2;
      if ((double) Math.Abs(float_3) > 0.998254656791687)
      {
        if (nullable_1.HasValue)
        {
          vector3_13_1 = nullable_1.Value;
          Vector3.smethod_16(ref vector3_2, ref vector3_13_1, out float_3);
          if ((double) Math.Abs(float_3) > 0.998254656791687)
            vector3_13_1 = (double) Math.Abs((float) ((double) vector3_2.float_0 * (double) Vector3.smethod_9().float_0 + (double) vector3_2.float_1 * (double) Vector3.smethod_9().float_1 + (double) vector3_2.float_2 * (double) Vector3.smethod_9().float_2)) > 0.998254656791687 ? Vector3.smethod_7() : Vector3.smethod_9();
        }
        else
          vector3_13_1 = (double) Math.Abs((float) ((double) vector3_2.float_0 * (double) Vector3.smethod_9().float_0 + (double) vector3_2.float_1 * (double) Vector3.smethod_9().float_1 + (double) vector3_2.float_2 * (double) Vector3.smethod_9().float_2)) > 0.998254656791687 ? Vector3.smethod_7() : Vector3.smethod_9();
        Vector3.smethod_20(ref vector3_2, ref vector3_13_1, out vector3_13_2);
        vector3_13_2.method_2();
        Vector3.smethod_20(ref vector3_13_2, ref vector3_2, out vector3_13_1);
        vector3_13_1.method_2();
      }
      else
      {
        Vector3.smethod_20(ref vector3_2, ref vector3_12_1, out vector3_13_2);
        vector3_13_2.method_2();
        Vector3.smethod_20(ref vector3_13_2, ref vector3_12_2, out vector3_13_1);
        vector3_13_1.method_2();
      }
      Matrix matrix;
      matrix.M11 = vector3_13_2.float_0;
      matrix.M12 = vector3_13_2.float_1;
      matrix.M13 = vector3_13_2.float_2;
      matrix.M14 = 0.0f;
      matrix.M21 = vector3_12_2.float_0;
      matrix.M22 = vector3_12_2.float_1;
      matrix.M23 = vector3_12_2.float_2;
      matrix.M24 = 0.0f;
      matrix.M31 = vector3_13_1.float_0;
      matrix.M32 = vector3_13_1.float_1;
      matrix.M33 = vector3_13_1.float_2;
      matrix.M34 = 0.0f;
      matrix.M41 = vector3_0.float_0;
      matrix.M42 = vector3_0.float_1;
      matrix.M43 = vector3_0.float_2;
      matrix.M44 = 1f;
      return matrix;
    }

    public static void smethod_4(ref Vector3 vector3_0, ref Vector3 vector3_1, ref Vector3 vector3_2, Vector3? nullable_0, Vector3? nullable_1, out Matrix matrix_1)
    {
      Vector3 vector3_12_1;
      vector3_12_1.float_0 = vector3_0.float_0 - vector3_1.float_0;
      vector3_12_1.float_1 = vector3_0.float_1 - vector3_1.float_1;
      vector3_12_1.float_2 = vector3_0.float_2 - vector3_1.float_2;
      float num = vector3_12_1.method_1();
      if ((double) num < 9.99999974737875E-05)
        vector3_12_1 = nullable_0.HasValue ? -nullable_0.Value : Vector3.smethod_9();
      else
        Vector3.smethod_56(ref vector3_12_1, 1f / (float) Math.Sqrt((double) num), out vector3_12_1);
      Vector3 vector3_12_2 = vector3_2;
      float float_3;
      Vector3.smethod_16(ref vector3_2, ref vector3_12_1, out float_3);
      Vector3 vector3_13_1;
      Vector3 vector3_13_2;
      if ((double) Math.Abs(float_3) > 0.998254656791687)
      {
        if (nullable_1.HasValue)
        {
          vector3_13_1 = nullable_1.Value;
          Vector3.smethod_16(ref vector3_2, ref vector3_13_1, out float_3);
          if ((double) Math.Abs(float_3) > 0.998254656791687)
            vector3_13_1 = (double) Math.Abs((float) ((double) vector3_2.float_0 * (double) Vector3.smethod_9().float_0 + (double) vector3_2.float_1 * (double) Vector3.smethod_9().float_1 + (double) vector3_2.float_2 * (double) Vector3.smethod_9().float_2)) > 0.998254656791687 ? Vector3.smethod_7() : Vector3.smethod_9();
        }
        else
          vector3_13_1 = (double) Math.Abs((float) ((double) vector3_2.float_0 * (double) Vector3.smethod_9().float_0 + (double) vector3_2.float_1 * (double) Vector3.smethod_9().float_1 + (double) vector3_2.float_2 * (double) Vector3.smethod_9().float_2)) > 0.998254656791687 ? Vector3.smethod_7() : Vector3.smethod_9();
        Vector3.smethod_20(ref vector3_2, ref vector3_13_1, out vector3_13_2);
        vector3_13_2.method_2();
        Vector3.smethod_20(ref vector3_13_2, ref vector3_2, out vector3_13_1);
        vector3_13_1.method_2();
      }
      else
      {
        Vector3.smethod_20(ref vector3_2, ref vector3_12_1, out vector3_13_2);
        vector3_13_2.method_2();
        Vector3.smethod_20(ref vector3_13_2, ref vector3_12_2, out vector3_13_1);
        vector3_13_1.method_2();
      }
      matrix_1.M11 = vector3_13_2.float_0;
      matrix_1.M12 = vector3_13_2.float_1;
      matrix_1.M13 = vector3_13_2.float_2;
      matrix_1.M14 = 0.0f;
      matrix_1.M21 = vector3_12_2.float_0;
      matrix_1.M22 = vector3_12_2.float_1;
      matrix_1.M23 = vector3_12_2.float_2;
      matrix_1.M24 = 0.0f;
      matrix_1.M31 = vector3_13_1.float_0;
      matrix_1.M32 = vector3_13_1.float_1;
      matrix_1.M33 = vector3_13_1.float_2;
      matrix_1.M34 = 0.0f;
      matrix_1.M41 = vector3_0.float_0;
      matrix_1.M42 = vector3_0.float_1;
      matrix_1.M43 = vector3_0.float_2;
      matrix_1.M44 = 1f;
    }

    public static Matrix smethod_5(Vector3 vector3_0)
    {
      Matrix matrix;
      matrix.M11 = 1f;
      matrix.M12 = 0.0f;
      matrix.M13 = 0.0f;
      matrix.M14 = 0.0f;
      matrix.M21 = 0.0f;
      matrix.M22 = 1f;
      matrix.M23 = 0.0f;
      matrix.M24 = 0.0f;
      matrix.M31 = 0.0f;
      matrix.M32 = 0.0f;
      matrix.M33 = 1f;
      matrix.M34 = 0.0f;
      matrix.M41 = vector3_0.float_0;
      matrix.M42 = vector3_0.float_1;
      matrix.M43 = vector3_0.float_2;
      matrix.M44 = 1f;
      return matrix;
    }

    public static void smethod_6(ref Vector3 vector3_0, out Matrix matrix_1)
    {
      matrix_1.M11 = 1f;
      matrix_1.M12 = 0.0f;
      matrix_1.M13 = 0.0f;
      matrix_1.M14 = 0.0f;
      matrix_1.M21 = 0.0f;
      matrix_1.M22 = 1f;
      matrix_1.M23 = 0.0f;
      matrix_1.M24 = 0.0f;
      matrix_1.M31 = 0.0f;
      matrix_1.M32 = 0.0f;
      matrix_1.M33 = 1f;
      matrix_1.M34 = 0.0f;
      matrix_1.M41 = vector3_0.float_0;
      matrix_1.M42 = vector3_0.float_1;
      matrix_1.M43 = vector3_0.float_2;
      matrix_1.M44 = 1f;
    }

    public static Matrix smethod_7(float float_0, float float_1, float float_2)
    {
      Matrix matrix;
      matrix.M11 = 1f;
      matrix.M12 = 0.0f;
      matrix.M13 = 0.0f;
      matrix.M14 = 0.0f;
      matrix.M21 = 0.0f;
      matrix.M22 = 1f;
      matrix.M23 = 0.0f;
      matrix.M24 = 0.0f;
      matrix.M31 = 0.0f;
      matrix.M32 = 0.0f;
      matrix.M33 = 1f;
      matrix.M34 = 0.0f;
      matrix.M41 = float_0;
      matrix.M42 = float_1;
      matrix.M43 = float_2;
      matrix.M44 = 1f;
      return matrix;
    }

    public static void smethod_8(float float_0, float float_1, float float_2, out Matrix matrix_1)
    {
      matrix_1.M11 = 1f;
      matrix_1.M12 = 0.0f;
      matrix_1.M13 = 0.0f;
      matrix_1.M14 = 0.0f;
      matrix_1.M21 = 0.0f;
      matrix_1.M22 = 1f;
      matrix_1.M23 = 0.0f;
      matrix_1.M24 = 0.0f;
      matrix_1.M31 = 0.0f;
      matrix_1.M32 = 0.0f;
      matrix_1.M33 = 1f;
      matrix_1.M34 = 0.0f;
      matrix_1.M41 = float_0;
      matrix_1.M42 = float_1;
      matrix_1.M43 = float_2;
      matrix_1.M44 = 1f;
    }

    public static Matrix smethod_9(float float_0, float float_1, float float_2)
    {
      Matrix matrix;
      matrix.M11 = float_0;
      matrix.M12 = 0.0f;
      matrix.M13 = 0.0f;
      matrix.M14 = 0.0f;
      matrix.M21 = 0.0f;
      matrix.M22 = float_1;
      matrix.M23 = 0.0f;
      matrix.M24 = 0.0f;
      matrix.M31 = 0.0f;
      matrix.M32 = 0.0f;
      matrix.M33 = float_2;
      matrix.M34 = 0.0f;
      matrix.M41 = 0.0f;
      matrix.M42 = 0.0f;
      matrix.M43 = 0.0f;
      matrix.M44 = 1f;
      return matrix;
    }

    public static void smethod_10(float float_0, float float_1, float float_2, out Matrix matrix_1)
    {
      matrix_1.M11 = float_0;
      matrix_1.M12 = 0.0f;
      matrix_1.M13 = 0.0f;
      matrix_1.M14 = 0.0f;
      matrix_1.M21 = 0.0f;
      matrix_1.M22 = float_1;
      matrix_1.M23 = 0.0f;
      matrix_1.M24 = 0.0f;
      matrix_1.M31 = 0.0f;
      matrix_1.M32 = 0.0f;
      matrix_1.M33 = float_2;
      matrix_1.M34 = 0.0f;
      matrix_1.M41 = 0.0f;
      matrix_1.M42 = 0.0f;
      matrix_1.M43 = 0.0f;
      matrix_1.M44 = 1f;
    }

    public static Matrix smethod_11(Vector3 vector3_0)
    {
      float num1 = vector3_0.float_0;
      float num2 = vector3_0.float_1;
      float num3 = vector3_0.float_2;
      Matrix matrix;
      matrix.M11 = num1;
      matrix.M12 = 0.0f;
      matrix.M13 = 0.0f;
      matrix.M14 = 0.0f;
      matrix.M21 = 0.0f;
      matrix.M22 = num2;
      matrix.M23 = 0.0f;
      matrix.M24 = 0.0f;
      matrix.M31 = 0.0f;
      matrix.M32 = 0.0f;
      matrix.M33 = num3;
      matrix.M34 = 0.0f;
      matrix.M41 = 0.0f;
      matrix.M42 = 0.0f;
      matrix.M43 = 0.0f;
      matrix.M44 = 1f;
      return matrix;
    }

    public static void smethod_12(ref Vector3 vector3_0, out Matrix matrix_1)
    {
      float num1 = vector3_0.float_0;
      float num2 = vector3_0.float_1;
      float num3 = vector3_0.float_2;
      matrix_1.M11 = num1;
      matrix_1.M12 = 0.0f;
      matrix_1.M13 = 0.0f;
      matrix_1.M14 = 0.0f;
      matrix_1.M21 = 0.0f;
      matrix_1.M22 = num2;
      matrix_1.M23 = 0.0f;
      matrix_1.M24 = 0.0f;
      matrix_1.M31 = 0.0f;
      matrix_1.M32 = 0.0f;
      matrix_1.M33 = num3;
      matrix_1.M34 = 0.0f;
      matrix_1.M41 = 0.0f;
      matrix_1.M42 = 0.0f;
      matrix_1.M43 = 0.0f;
      matrix_1.M44 = 1f;
    }

    public static Matrix smethod_13(float float_0)
    {
      Matrix matrix;
      matrix.M11 = float_0;
      matrix.M12 = 0.0f;
      matrix.M13 = 0.0f;
      matrix.M14 = 0.0f;
      matrix.M21 = 0.0f;
      matrix.M22 = float_0;
      matrix.M23 = 0.0f;
      matrix.M24 = 0.0f;
      matrix.M31 = 0.0f;
      matrix.M32 = 0.0f;
      matrix.M33 = float_0;
      matrix.M34 = 0.0f;
      matrix.M41 = 0.0f;
      matrix.M42 = 0.0f;
      matrix.M43 = 0.0f;
      matrix.M44 = 1f;
      return matrix;
    }

    public static void smethod_14(float float_0, out Matrix matrix_1)
    {
      matrix_1.M11 = float_0;
      matrix_1.M12 = 0.0f;
      matrix_1.M13 = 0.0f;
      matrix_1.M14 = 0.0f;
      matrix_1.M21 = 0.0f;
      matrix_1.M22 = float_0;
      matrix_1.M23 = 0.0f;
      matrix_1.M24 = 0.0f;
      matrix_1.M31 = 0.0f;
      matrix_1.M32 = 0.0f;
      matrix_1.M33 = float_0;
      matrix_1.M34 = 0.0f;
      matrix_1.M41 = 0.0f;
      matrix_1.M42 = 0.0f;
      matrix_1.M43 = 0.0f;
      matrix_1.M44 = 1f;
    }

    public static Matrix smethod_15(float float_0)
    {
      float num1 = (float) Math.Cos((double) float_0);
      float num2 = (float) Math.Sin((double) float_0);
      Matrix matrix;
      matrix.M11 = 1f;
      matrix.M12 = 0.0f;
      matrix.M13 = 0.0f;
      matrix.M14 = 0.0f;
      matrix.M21 = 0.0f;
      matrix.M22 = num1;
      matrix.M23 = num2;
      matrix.M24 = 0.0f;
      matrix.M31 = 0.0f;
      matrix.M32 = -num2;
      matrix.M33 = num1;
      matrix.M34 = 0.0f;
      matrix.M41 = 0.0f;
      matrix.M42 = 0.0f;
      matrix.M43 = 0.0f;
      matrix.M44 = 1f;
      return matrix;
    }

    public static void smethod_16(float float_0, out Matrix matrix_1)
    {
      float num1 = (float) Math.Cos((double) float_0);
      float num2 = (float) Math.Sin((double) float_0);
      matrix_1.M11 = 1f;
      matrix_1.M12 = 0.0f;
      matrix_1.M13 = 0.0f;
      matrix_1.M14 = 0.0f;
      matrix_1.M21 = 0.0f;
      matrix_1.M22 = num1;
      matrix_1.M23 = num2;
      matrix_1.M24 = 0.0f;
      matrix_1.M31 = 0.0f;
      matrix_1.M32 = -num2;
      matrix_1.M33 = num1;
      matrix_1.M34 = 0.0f;
      matrix_1.M41 = 0.0f;
      matrix_1.M42 = 0.0f;
      matrix_1.M43 = 0.0f;
      matrix_1.M44 = 1f;
    }

    public static Matrix smethod_17(float float_0)
    {
      float num1 = (float) Math.Cos((double) float_0);
      float num2 = (float) Math.Sin((double) float_0);
      Matrix matrix;
      matrix.M11 = num1;
      matrix.M12 = 0.0f;
      matrix.M13 = -num2;
      matrix.M14 = 0.0f;
      matrix.M21 = 0.0f;
      matrix.M22 = 1f;
      matrix.M23 = 0.0f;
      matrix.M24 = 0.0f;
      matrix.M31 = num2;
      matrix.M32 = 0.0f;
      matrix.M33 = num1;
      matrix.M34 = 0.0f;
      matrix.M41 = 0.0f;
      matrix.M42 = 0.0f;
      matrix.M43 = 0.0f;
      matrix.M44 = 1f;
      return matrix;
    }

    public static void smethod_18(float float_0, out Matrix matrix_1)
    {
      float num1 = (float) Math.Cos((double) float_0);
      float num2 = (float) Math.Sin((double) float_0);
      matrix_1.M11 = num1;
      matrix_1.M12 = 0.0f;
      matrix_1.M13 = -num2;
      matrix_1.M14 = 0.0f;
      matrix_1.M21 = 0.0f;
      matrix_1.M22 = 1f;
      matrix_1.M23 = 0.0f;
      matrix_1.M24 = 0.0f;
      matrix_1.M31 = num2;
      matrix_1.M32 = 0.0f;
      matrix_1.M33 = num1;
      matrix_1.M34 = 0.0f;
      matrix_1.M41 = 0.0f;
      matrix_1.M42 = 0.0f;
      matrix_1.M43 = 0.0f;
      matrix_1.M44 = 1f;
    }

    public static Matrix smethod_19(float float_0)
    {
      float num1 = (float) Math.Cos((double) float_0);
      float num2 = (float) Math.Sin((double) float_0);
      Matrix matrix;
      matrix.M11 = num1;
      matrix.M12 = num2;
      matrix.M13 = 0.0f;
      matrix.M14 = 0.0f;
      matrix.M21 = -num2;
      matrix.M22 = num1;
      matrix.M23 = 0.0f;
      matrix.M24 = 0.0f;
      matrix.M31 = 0.0f;
      matrix.M32 = 0.0f;
      matrix.M33 = 1f;
      matrix.M34 = 0.0f;
      matrix.M41 = 0.0f;
      matrix.M42 = 0.0f;
      matrix.M43 = 0.0f;
      matrix.M44 = 1f;
      return matrix;
    }

    public static void smethod_20(float float_0, out Matrix matrix_1)
    {
      float num1 = (float) Math.Cos((double) float_0);
      float num2 = (float) Math.Sin((double) float_0);
      matrix_1.M11 = num1;
      matrix_1.M12 = num2;
      matrix_1.M13 = 0.0f;
      matrix_1.M14 = 0.0f;
      matrix_1.M21 = -num2;
      matrix_1.M22 = num1;
      matrix_1.M23 = 0.0f;
      matrix_1.M24 = 0.0f;
      matrix_1.M31 = 0.0f;
      matrix_1.M32 = 0.0f;
      matrix_1.M33 = 1f;
      matrix_1.M34 = 0.0f;
      matrix_1.M41 = 0.0f;
      matrix_1.M42 = 0.0f;
      matrix_1.M43 = 0.0f;
      matrix_1.M44 = 1f;
    }

    public static Matrix smethod_21(Vector3 vector3_0, float float_0)
    {
      float num1 = vector3_0.float_0;
      float num2 = vector3_0.float_1;
      float num3 = vector3_0.float_2;
      float num4 = (float) Math.Sin((double) float_0);
      float num5 = (float) Math.Cos((double) float_0);
      float num6 = num1 * num1;
      float num7 = num2 * num2;
      float num8 = num3 * num3;
      float num9 = num1 * num2;
      float num10 = num1 * num3;
      float num11 = num2 * num3;
      Matrix matrix;
      matrix.M11 = num6 + num5 * (1f - num6);
      matrix.M12 = (float) ((double) num9 - (double) num5 * (double) num9 + (double) num4 * (double) num3);
      matrix.M13 = (float) ((double) num10 - (double) num5 * (double) num10 - (double) num4 * (double) num2);
      matrix.M14 = 0.0f;
      matrix.M21 = (float) ((double) num9 - (double) num5 * (double) num9 - (double) num4 * (double) num3);
      matrix.M22 = num7 + num5 * (1f - num7);
      matrix.M23 = (float) ((double) num11 - (double) num5 * (double) num11 + (double) num4 * (double) num1);
      matrix.M24 = 0.0f;
      matrix.M31 = (float) ((double) num10 - (double) num5 * (double) num10 + (double) num4 * (double) num2);
      matrix.M32 = (float) ((double) num11 - (double) num5 * (double) num11 - (double) num4 * (double) num1);
      matrix.M33 = num8 + num5 * (1f - num8);
      matrix.M34 = 0.0f;
      matrix.M41 = 0.0f;
      matrix.M42 = 0.0f;
      matrix.M43 = 0.0f;
      matrix.M44 = 1f;
      return matrix;
    }

    public static void smethod_22(ref Vector3 vector3_0, float float_0, out Matrix matrix_1)
    {
      float num1 = vector3_0.float_0;
      float num2 = vector3_0.float_1;
      float num3 = vector3_0.float_2;
      float num4 = (float) Math.Sin((double) float_0);
      float num5 = (float) Math.Cos((double) float_0);
      float num6 = num1 * num1;
      float num7 = num2 * num2;
      float num8 = num3 * num3;
      float num9 = num1 * num2;
      float num10 = num1 * num3;
      float num11 = num2 * num3;
      matrix_1.M11 = num6 + num5 * (1f - num6);
      matrix_1.M12 = (float) ((double) num9 - (double) num5 * (double) num9 + (double) num4 * (double) num3);
      matrix_1.M13 = (float) ((double) num10 - (double) num5 * (double) num10 - (double) num4 * (double) num2);
      matrix_1.M14 = 0.0f;
      matrix_1.M21 = (float) ((double) num9 - (double) num5 * (double) num9 - (double) num4 * (double) num3);
      matrix_1.M22 = num7 + num5 * (1f - num7);
      matrix_1.M23 = (float) ((double) num11 - (double) num5 * (double) num11 + (double) num4 * (double) num1);
      matrix_1.M24 = 0.0f;
      matrix_1.M31 = (float) ((double) num10 - (double) num5 * (double) num10 + (double) num4 * (double) num2);
      matrix_1.M32 = (float) ((double) num11 - (double) num5 * (double) num11 - (double) num4 * (double) num1);
      matrix_1.M33 = num8 + num5 * (1f - num8);
      matrix_1.M34 = 0.0f;
      matrix_1.M41 = 0.0f;
      matrix_1.M42 = 0.0f;
      matrix_1.M43 = 0.0f;
      matrix_1.M44 = 1f;
    }

    public static Matrix smethod_23(float float_0, float float_1, float float_2, float float_3)
    {
      if ((double) float_0 > 0.0 && (double) float_0 < 3.14159274101257)
      {
        if ((double) float_2 <= 0.0)
          throw new ArgumentOutOfRangeException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Class1070.smethod_6(), new object[1]
          {
            (object) "nearPlaneDistance"
          }));
        if ((double) float_3 <= 0.0)
          throw new ArgumentOutOfRangeException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Class1070.smethod_6(), new object[1]
          {
            (object) "farPlaneDistance"
          }));
        if ((double) float_2 >= (double) float_3)
          throw new ArgumentOutOfRangeException(Class1070.smethod_11());
        float num1 = 1f / (float) Math.Tan((double) float_0 * 0.5);
        float num2 = num1 / float_1;
        Matrix matrix;
        matrix.M11 = num2;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local1 = @matrix;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local2 = @matrix;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local3 = @matrix;
        double num3 = 0.0;
        float num4 = 0.0f;
        // ISSUE: explicit reference operation
        (^local3).M14 = (float) num3;
        double num5 = (double) num4;
        float num6 = 0.0f;
        // ISSUE: explicit reference operation
        (^local2).M13 = (float) num5;
        double num7 = (double) num6;
        // ISSUE: explicit reference operation
        (^local1).M12 = (float) num7;
        matrix.M22 = num1;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local4 = @matrix;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local5 = @matrix;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local6 = @matrix;
        double num8 = 0.0;
        float num9 = 0.0f;
        // ISSUE: explicit reference operation
        (^local6).M24 = (float) num8;
        double num10 = (double) num9;
        float num11 = 0.0f;
        // ISSUE: explicit reference operation
        (^local5).M23 = (float) num10;
        double num12 = (double) num11;
        // ISSUE: explicit reference operation
        (^local4).M21 = (float) num12;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local7 = @matrix;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local8 = @matrix;
        double num13 = 0.0;
        float num14 = 0.0f;
        // ISSUE: explicit reference operation
        (^local8).M32 = (float) num13;
        double num15 = (double) num14;
        // ISSUE: explicit reference operation
        (^local7).M31 = (float) num15;
        matrix.M33 = float_3 / (float_2 - float_3);
        matrix.M34 = -1f;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local9 = @matrix;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local10 = @matrix;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local11 = @matrix;
        double num16 = 0.0;
        float num17 = 0.0f;
        // ISSUE: explicit reference operation
        (^local11).M44 = (float) num16;
        double num18 = (double) num17;
        float num19 = 0.0f;
        // ISSUE: explicit reference operation
        (^local10).M42 = (float) num18;
        double num20 = (double) num19;
        // ISSUE: explicit reference operation
        (^local9).M41 = (float) num20;
        matrix.M43 = (float) ((double) float_2 * (double) float_3 / ((double) float_2 - (double) float_3));
        return matrix;
      }
      throw new ArgumentOutOfRangeException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Class1070.smethod_12(), new object[1]
      {
        (object) "fieldOfView"
      }));
    }

    public static void smethod_24(float float_0, float float_1, float float_2, float float_3, out Matrix matrix_1)
    {
      if ((double) float_0 > 0.0 && (double) float_0 < 3.14159274101257)
      {
        if ((double) float_2 <= 0.0)
          throw new ArgumentOutOfRangeException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Class1070.smethod_6(), new object[1]
          {
            (object) "nearPlaneDistance"
          }));
        if ((double) float_3 <= 0.0)
          throw new ArgumentOutOfRangeException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Class1070.smethod_6(), new object[1]
          {
            (object) "farPlaneDistance"
          }));
        if ((double) float_2 >= (double) float_3)
          throw new ArgumentOutOfRangeException(Class1070.smethod_11());
        float num1 = 1f / (float) Math.Tan((double) float_0 * 0.5);
        float num2 = num1 / float_1;
        matrix_1.M11 = num2;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local1 = @matrix_1;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local2 = @matrix_1;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local3 = @matrix_1;
        double num3 = 0.0;
        float num4 = 0.0f;
        // ISSUE: explicit reference operation
        (^local3).M14 = (float) num3;
        double num5 = (double) num4;
        float num6 = 0.0f;
        // ISSUE: explicit reference operation
        (^local2).M13 = (float) num5;
        double num7 = (double) num6;
        // ISSUE: explicit reference operation
        (^local1).M12 = (float) num7;
        matrix_1.M22 = num1;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local4 = @matrix_1;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local5 = @matrix_1;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local6 = @matrix_1;
        double num8 = 0.0;
        float num9 = 0.0f;
        // ISSUE: explicit reference operation
        (^local6).M24 = (float) num8;
        double num10 = (double) num9;
        float num11 = 0.0f;
        // ISSUE: explicit reference operation
        (^local5).M23 = (float) num10;
        double num12 = (double) num11;
        // ISSUE: explicit reference operation
        (^local4).M21 = (float) num12;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local7 = @matrix_1;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local8 = @matrix_1;
        double num13 = 0.0;
        float num14 = 0.0f;
        // ISSUE: explicit reference operation
        (^local8).M32 = (float) num13;
        double num15 = (double) num14;
        // ISSUE: explicit reference operation
        (^local7).M31 = (float) num15;
        matrix_1.M33 = float_3 / (float_2 - float_3);
        matrix_1.M34 = -1f;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local9 = @matrix_1;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local10 = @matrix_1;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Matrix& local11 = @matrix_1;
        double num16 = 0.0;
        float num17 = 0.0f;
        // ISSUE: explicit reference operation
        (^local11).M44 = (float) num16;
        double num18 = (double) num17;
        float num19 = 0.0f;
        // ISSUE: explicit reference operation
        (^local10).M42 = (float) num18;
        double num20 = (double) num19;
        // ISSUE: explicit reference operation
        (^local9).M41 = (float) num20;
        matrix_1.M43 = (float) ((double) float_2 * (double) float_3 / ((double) float_2 - (double) float_3));
      }
      else
        throw new ArgumentOutOfRangeException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Class1070.smethod_12(), new object[1]
        {
          (object) "fieldOfView"
        }));
    }

    public static Matrix smethod_25(float float_0, float float_1, float float_2, float float_3)
    {
      if ((double) float_2 <= 0.0)
        throw new ArgumentOutOfRangeException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Class1070.smethod_6(), new object[1]
        {
          (object) "nearPlaneDistance"
        }));
      if ((double) float_3 <= 0.0)
        throw new ArgumentOutOfRangeException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Class1070.smethod_6(), new object[1]
        {
          (object) "farPlaneDistance"
        }));
      if ((double) float_2 >= (double) float_3)
        throw new ArgumentOutOfRangeException(Class1070.smethod_11());
      Matrix matrix;
      matrix.M11 = 2f * float_2 / float_0;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local1 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local2 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local3 = @matrix;
      double num1 = 0.0;
      float num2 = 0.0f;
      // ISSUE: explicit reference operation
      (^local3).M14 = (float) num1;
      double num3 = (double) num2;
      float num4 = 0.0f;
      // ISSUE: explicit reference operation
      (^local2).M13 = (float) num3;
      double num5 = (double) num4;
      // ISSUE: explicit reference operation
      (^local1).M12 = (float) num5;
      matrix.M22 = 2f * float_2 / float_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local4 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local5 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local6 = @matrix;
      double num6 = 0.0;
      float num7 = 0.0f;
      // ISSUE: explicit reference operation
      (^local6).M24 = (float) num6;
      double num8 = (double) num7;
      float num9 = 0.0f;
      // ISSUE: explicit reference operation
      (^local5).M23 = (float) num8;
      double num10 = (double) num9;
      // ISSUE: explicit reference operation
      (^local4).M21 = (float) num10;
      matrix.M33 = float_3 / (float_2 - float_3);
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local7 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local8 = @matrix;
      double num11 = 0.0;
      float num12 = 0.0f;
      // ISSUE: explicit reference operation
      (^local8).M32 = (float) num11;
      double num13 = (double) num12;
      // ISSUE: explicit reference operation
      (^local7).M31 = (float) num13;
      matrix.M34 = -1f;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local9 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local10 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local11 = @matrix;
      double num14 = 0.0;
      float num15 = 0.0f;
      // ISSUE: explicit reference operation
      (^local11).M44 = (float) num14;
      double num16 = (double) num15;
      float num17 = 0.0f;
      // ISSUE: explicit reference operation
      (^local10).M42 = (float) num16;
      double num18 = (double) num17;
      // ISSUE: explicit reference operation
      (^local9).M41 = (float) num18;
      matrix.M43 = (float) ((double) float_2 * (double) float_3 / ((double) float_2 - (double) float_3));
      return matrix;
    }

    public static void smethod_26(float float_0, float float_1, float float_2, float float_3, out Matrix matrix_1)
    {
      if ((double) float_2 <= 0.0)
        throw new ArgumentOutOfRangeException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Class1070.smethod_6(), new object[1]
        {
          (object) "nearPlaneDistance"
        }));
      if ((double) float_3 <= 0.0)
        throw new ArgumentOutOfRangeException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Class1070.smethod_6(), new object[1]
        {
          (object) "farPlaneDistance"
        }));
      if ((double) float_2 >= (double) float_3)
        throw new ArgumentOutOfRangeException(Class1070.smethod_11());
      matrix_1.M11 = 2f * float_2 / float_0;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local1 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local2 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local3 = @matrix_1;
      double num1 = 0.0;
      float num2 = 0.0f;
      // ISSUE: explicit reference operation
      (^local3).M14 = (float) num1;
      double num3 = (double) num2;
      float num4 = 0.0f;
      // ISSUE: explicit reference operation
      (^local2).M13 = (float) num3;
      double num5 = (double) num4;
      // ISSUE: explicit reference operation
      (^local1).M12 = (float) num5;
      matrix_1.M22 = 2f * float_2 / float_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local4 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local5 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local6 = @matrix_1;
      double num6 = 0.0;
      float num7 = 0.0f;
      // ISSUE: explicit reference operation
      (^local6).M24 = (float) num6;
      double num8 = (double) num7;
      float num9 = 0.0f;
      // ISSUE: explicit reference operation
      (^local5).M23 = (float) num8;
      double num10 = (double) num9;
      // ISSUE: explicit reference operation
      (^local4).M21 = (float) num10;
      matrix_1.M33 = float_3 / (float_2 - float_3);
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local7 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local8 = @matrix_1;
      double num11 = 0.0;
      float num12 = 0.0f;
      // ISSUE: explicit reference operation
      (^local8).M32 = (float) num11;
      double num13 = (double) num12;
      // ISSUE: explicit reference operation
      (^local7).M31 = (float) num13;
      matrix_1.M34 = -1f;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local9 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local10 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local11 = @matrix_1;
      double num14 = 0.0;
      float num15 = 0.0f;
      // ISSUE: explicit reference operation
      (^local11).M44 = (float) num14;
      double num16 = (double) num15;
      float num17 = 0.0f;
      // ISSUE: explicit reference operation
      (^local10).M42 = (float) num16;
      double num18 = (double) num17;
      // ISSUE: explicit reference operation
      (^local9).M41 = (float) num18;
      matrix_1.M43 = (float) ((double) float_2 * (double) float_3 / ((double) float_2 - (double) float_3));
    }

    public static Matrix smethod_27(float float_0, float float_1, float float_2, float float_3, float float_4, float float_5)
    {
      if ((double) float_4 <= 0.0)
        throw new ArgumentOutOfRangeException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Class1070.smethod_6(), new object[1]
        {
          (object) "nearPlaneDistance"
        }));
      if ((double) float_5 <= 0.0)
        throw new ArgumentOutOfRangeException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Class1070.smethod_6(), new object[1]
        {
          (object) "farPlaneDistance"
        }));
      if ((double) float_4 >= (double) float_5)
        throw new ArgumentOutOfRangeException(Class1070.smethod_11());
      Matrix matrix;
      matrix.M11 = (float) (2.0 * (double) float_4 / ((double) float_1 - (double) float_0));
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local1 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local2 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local3 = @matrix;
      double num1 = 0.0;
      float num2 = 0.0f;
      // ISSUE: explicit reference operation
      (^local3).M14 = (float) num1;
      double num3 = (double) num2;
      float num4 = 0.0f;
      // ISSUE: explicit reference operation
      (^local2).M13 = (float) num3;
      double num5 = (double) num4;
      // ISSUE: explicit reference operation
      (^local1).M12 = (float) num5;
      matrix.M22 = (float) (2.0 * (double) float_4 / ((double) float_3 - (double) float_2));
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local4 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local5 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local6 = @matrix;
      double num6 = 0.0;
      float num7 = 0.0f;
      // ISSUE: explicit reference operation
      (^local6).M24 = (float) num6;
      double num8 = (double) num7;
      float num9 = 0.0f;
      // ISSUE: explicit reference operation
      (^local5).M23 = (float) num8;
      double num10 = (double) num9;
      // ISSUE: explicit reference operation
      (^local4).M21 = (float) num10;
      matrix.M31 = (float) (((double) float_0 + (double) float_1) / ((double) float_1 - (double) float_0));
      matrix.M32 = (float) (((double) float_3 + (double) float_2) / ((double) float_3 - (double) float_2));
      matrix.M33 = float_5 / (float_4 - float_5);
      matrix.M34 = -1f;
      matrix.M43 = (float) ((double) float_4 * (double) float_5 / ((double) float_4 - (double) float_5));
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local7 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local8 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local9 = @matrix;
      double num11 = 0.0;
      float num12 = 0.0f;
      // ISSUE: explicit reference operation
      (^local9).M44 = (float) num11;
      double num13 = (double) num12;
      float num14 = 0.0f;
      // ISSUE: explicit reference operation
      (^local8).M42 = (float) num13;
      double num15 = (double) num14;
      // ISSUE: explicit reference operation
      (^local7).M41 = (float) num15;
      return matrix;
    }

    public static void smethod_28(float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, out Matrix matrix_1)
    {
      if ((double) float_4 <= 0.0)
        throw new ArgumentOutOfRangeException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Class1070.smethod_6(), new object[1]
        {
          (object) "nearPlaneDistance"
        }));
      if ((double) float_5 <= 0.0)
        throw new ArgumentOutOfRangeException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, Class1070.smethod_6(), new object[1]
        {
          (object) "farPlaneDistance"
        }));
      if ((double) float_4 >= (double) float_5)
        throw new ArgumentOutOfRangeException(Class1070.smethod_11());
      matrix_1.M11 = (float) (2.0 * (double) float_4 / ((double) float_1 - (double) float_0));
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local1 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local2 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local3 = @matrix_1;
      double num1 = 0.0;
      float num2 = 0.0f;
      // ISSUE: explicit reference operation
      (^local3).M14 = (float) num1;
      double num3 = (double) num2;
      float num4 = 0.0f;
      // ISSUE: explicit reference operation
      (^local2).M13 = (float) num3;
      double num5 = (double) num4;
      // ISSUE: explicit reference operation
      (^local1).M12 = (float) num5;
      matrix_1.M22 = (float) (2.0 * (double) float_4 / ((double) float_3 - (double) float_2));
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local4 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local5 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local6 = @matrix_1;
      double num6 = 0.0;
      float num7 = 0.0f;
      // ISSUE: explicit reference operation
      (^local6).M24 = (float) num6;
      double num8 = (double) num7;
      float num9 = 0.0f;
      // ISSUE: explicit reference operation
      (^local5).M23 = (float) num8;
      double num10 = (double) num9;
      // ISSUE: explicit reference operation
      (^local4).M21 = (float) num10;
      matrix_1.M31 = (float) (((double) float_0 + (double) float_1) / ((double) float_1 - (double) float_0));
      matrix_1.M32 = (float) (((double) float_3 + (double) float_2) / ((double) float_3 - (double) float_2));
      matrix_1.M33 = float_5 / (float_4 - float_5);
      matrix_1.M34 = -1f;
      matrix_1.M43 = (float) ((double) float_4 * (double) float_5 / ((double) float_4 - (double) float_5));
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local7 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local8 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local9 = @matrix_1;
      double num11 = 0.0;
      float num12 = 0.0f;
      // ISSUE: explicit reference operation
      (^local9).M44 = (float) num11;
      double num13 = (double) num12;
      float num14 = 0.0f;
      // ISSUE: explicit reference operation
      (^local8).M42 = (float) num13;
      double num15 = (double) num14;
      // ISSUE: explicit reference operation
      (^local7).M41 = (float) num15;
    }

    public static Matrix smethod_29(float float_0, float float_1, float float_2, float float_3)
    {
      Matrix matrix;
      matrix.M11 = 2f / float_0;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local1 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local2 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local3 = @matrix;
      double num1 = 0.0;
      float num2 = 0.0f;
      // ISSUE: explicit reference operation
      (^local3).M14 = (float) num1;
      double num3 = (double) num2;
      float num4 = 0.0f;
      // ISSUE: explicit reference operation
      (^local2).M13 = (float) num3;
      double num5 = (double) num4;
      // ISSUE: explicit reference operation
      (^local1).M12 = (float) num5;
      matrix.M22 = 2f / float_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local4 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local5 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local6 = @matrix;
      double num6 = 0.0;
      float num7 = 0.0f;
      // ISSUE: explicit reference operation
      (^local6).M24 = (float) num6;
      double num8 = (double) num7;
      float num9 = 0.0f;
      // ISSUE: explicit reference operation
      (^local5).M23 = (float) num8;
      double num10 = (double) num9;
      // ISSUE: explicit reference operation
      (^local4).M21 = (float) num10;
      matrix.M33 = (float) (1.0 / ((double) float_2 - (double) float_3));
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local7 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local8 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local9 = @matrix;
      double num11 = 0.0;
      float num12 = 0.0f;
      // ISSUE: explicit reference operation
      (^local9).M34 = (float) num11;
      double num13 = (double) num12;
      float num14 = 0.0f;
      // ISSUE: explicit reference operation
      (^local8).M32 = (float) num13;
      double num15 = (double) num14;
      // ISSUE: explicit reference operation
      (^local7).M31 = (float) num15;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local10 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local11 = @matrix;
      double num16 = 0.0;
      float num17 = 0.0f;
      // ISSUE: explicit reference operation
      (^local11).M42 = (float) num16;
      double num18 = (double) num17;
      // ISSUE: explicit reference operation
      (^local10).M41 = (float) num18;
      matrix.M43 = float_2 / (float_2 - float_3);
      matrix.M44 = 1f;
      return matrix;
    }

    public static void smethod_30(float float_0, float float_1, float float_2, float float_3, out Matrix matrix_1)
    {
      matrix_1.M11 = 2f / float_0;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local1 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local2 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local3 = @matrix_1;
      double num1 = 0.0;
      float num2 = 0.0f;
      // ISSUE: explicit reference operation
      (^local3).M14 = (float) num1;
      double num3 = (double) num2;
      float num4 = 0.0f;
      // ISSUE: explicit reference operation
      (^local2).M13 = (float) num3;
      double num5 = (double) num4;
      // ISSUE: explicit reference operation
      (^local1).M12 = (float) num5;
      matrix_1.M22 = 2f / float_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local4 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local5 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local6 = @matrix_1;
      double num6 = 0.0;
      float num7 = 0.0f;
      // ISSUE: explicit reference operation
      (^local6).M24 = (float) num6;
      double num8 = (double) num7;
      float num9 = 0.0f;
      // ISSUE: explicit reference operation
      (^local5).M23 = (float) num8;
      double num10 = (double) num9;
      // ISSUE: explicit reference operation
      (^local4).M21 = (float) num10;
      matrix_1.M33 = (float) (1.0 / ((double) float_2 - (double) float_3));
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local7 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local8 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local9 = @matrix_1;
      double num11 = 0.0;
      float num12 = 0.0f;
      // ISSUE: explicit reference operation
      (^local9).M34 = (float) num11;
      double num13 = (double) num12;
      float num14 = 0.0f;
      // ISSUE: explicit reference operation
      (^local8).M32 = (float) num13;
      double num15 = (double) num14;
      // ISSUE: explicit reference operation
      (^local7).M31 = (float) num15;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local10 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local11 = @matrix_1;
      double num16 = 0.0;
      float num17 = 0.0f;
      // ISSUE: explicit reference operation
      (^local11).M42 = (float) num16;
      double num18 = (double) num17;
      // ISSUE: explicit reference operation
      (^local10).M41 = (float) num18;
      matrix_1.M43 = float_2 / (float_2 - float_3);
      matrix_1.M44 = 1f;
    }

    public static Matrix smethod_31(float float_0, float float_1, float float_2, float float_3, float float_4, float float_5)
    {
      Matrix matrix;
      matrix.M11 = (float) (2.0 / ((double) float_1 - (double) float_0));
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local1 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local2 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local3 = @matrix;
      double num1 = 0.0;
      float num2 = 0.0f;
      // ISSUE: explicit reference operation
      (^local3).M14 = (float) num1;
      double num3 = (double) num2;
      float num4 = 0.0f;
      // ISSUE: explicit reference operation
      (^local2).M13 = (float) num3;
      double num5 = (double) num4;
      // ISSUE: explicit reference operation
      (^local1).M12 = (float) num5;
      matrix.M22 = (float) (2.0 / ((double) float_3 - (double) float_2));
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local4 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local5 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local6 = @matrix;
      double num6 = 0.0;
      float num7 = 0.0f;
      // ISSUE: explicit reference operation
      (^local6).M24 = (float) num6;
      double num8 = (double) num7;
      float num9 = 0.0f;
      // ISSUE: explicit reference operation
      (^local5).M23 = (float) num8;
      double num10 = (double) num9;
      // ISSUE: explicit reference operation
      (^local4).M21 = (float) num10;
      matrix.M33 = (float) (1.0 / ((double) float_4 - (double) float_5));
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local7 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local8 = @matrix;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local9 = @matrix;
      double num11 = 0.0;
      float num12 = 0.0f;
      // ISSUE: explicit reference operation
      (^local9).M34 = (float) num11;
      double num13 = (double) num12;
      float num14 = 0.0f;
      // ISSUE: explicit reference operation
      (^local8).M32 = (float) num13;
      double num15 = (double) num14;
      // ISSUE: explicit reference operation
      (^local7).M31 = (float) num15;
      matrix.M41 = (float) (((double) float_0 + (double) float_1) / ((double) float_0 - (double) float_1));
      matrix.M42 = (float) (((double) float_3 + (double) float_2) / ((double) float_2 - (double) float_3));
      matrix.M43 = float_4 / (float_4 - float_5);
      matrix.M44 = 1f;
      return matrix;
    }

    public static void smethod_32(float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, out Matrix matrix_1)
    {
      matrix_1.M11 = (float) (2.0 / ((double) float_1 - (double) float_0));
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local1 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local2 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local3 = @matrix_1;
      double num1 = 0.0;
      float num2 = 0.0f;
      // ISSUE: explicit reference operation
      (^local3).M14 = (float) num1;
      double num3 = (double) num2;
      float num4 = 0.0f;
      // ISSUE: explicit reference operation
      (^local2).M13 = (float) num3;
      double num5 = (double) num4;
      // ISSUE: explicit reference operation
      (^local1).M12 = (float) num5;
      matrix_1.M22 = (float) (2.0 / ((double) float_3 - (double) float_2));
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local4 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local5 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local6 = @matrix_1;
      double num6 = 0.0;
      float num7 = 0.0f;
      // ISSUE: explicit reference operation
      (^local6).M24 = (float) num6;
      double num8 = (double) num7;
      float num9 = 0.0f;
      // ISSUE: explicit reference operation
      (^local5).M23 = (float) num8;
      double num10 = (double) num9;
      // ISSUE: explicit reference operation
      (^local4).M21 = (float) num10;
      matrix_1.M33 = (float) (1.0 / ((double) float_4 - (double) float_5));
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local7 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local8 = @matrix_1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Matrix& local9 = @matrix_1;
      double num11 = 0.0;
      float num12 = 0.0f;
      // ISSUE: explicit reference operation
      (^local9).M34 = (float) num11;
      double num13 = (double) num12;
      float num14 = 0.0f;
      // ISSUE: explicit reference operation
      (^local8).M32 = (float) num13;
      double num15 = (double) num14;
      // ISSUE: explicit reference operation
      (^local7).M31 = (float) num15;
      matrix_1.M41 = (float) (((double) float_0 + (double) float_1) / ((double) float_0 - (double) float_1));
      matrix_1.M42 = (float) (((double) float_3 + (double) float_2) / ((double) float_2 - (double) float_3));
      matrix_1.M43 = float_4 / (float_4 - float_5);
      matrix_1.M44 = 1f;
    }

    public static Matrix smethod_33(Vector3 vector3_0, Vector3 vector3_1, Vector3 vector3_2)
    {
      Vector3 vector3_3 = Vector3.smethod_17(vector3_0 - vector3_1);
      Vector3 vector3_4 = Vector3.smethod_17(Vector3.smethod_19(vector3_2, vector3_3));
      Vector3 vector3_11 = Vector3.smethod_19(vector3_3, vector3_4);
      Matrix matrix;
      matrix.M11 = vector3_4.float_0;
      matrix.M12 = vector3_11.float_0;
      matrix.M13 = vector3_3.float_0;
      matrix.M14 = 0.0f;
      matrix.M21 = vector3_4.float_1;
      matrix.M22 = vector3_11.float_1;
      matrix.M23 = vector3_3.float_1;
      matrix.M24 = 0.0f;
      matrix.M31 = vector3_4.float_2;
      matrix.M32 = vector3_11.float_2;
      matrix.M33 = vector3_3.float_2;
      matrix.M34 = 0.0f;
      matrix.M41 = -Vector3.smethod_15(vector3_4, vector3_0);
      matrix.M42 = -Vector3.smethod_15(vector3_11, vector3_0);
      matrix.M43 = -Vector3.smethod_15(vector3_3, vector3_0);
      matrix.M44 = 1f;
      return matrix;
    }

    public static void smethod_34(ref Vector3 vector3_0, ref Vector3 vector3_1, ref Vector3 vector3_2, out Matrix matrix_1)
    {
      Vector3 vector3_3 = Vector3.smethod_17(vector3_0 - vector3_1);
      Vector3 vector3_4 = Vector3.smethod_17(Vector3.smethod_19(vector3_2, vector3_3));
      Vector3 vector3_11 = Vector3.smethod_19(vector3_3, vector3_4);
      matrix_1.M11 = vector3_4.float_0;
      matrix_1.M12 = vector3_11.float_0;
      matrix_1.M13 = vector3_3.float_0;
      matrix_1.M14 = 0.0f;
      matrix_1.M21 = vector3_4.float_1;
      matrix_1.M22 = vector3_11.float_1;
      matrix_1.M23 = vector3_3.float_1;
      matrix_1.M24 = 0.0f;
      matrix_1.M31 = vector3_4.float_2;
      matrix_1.M32 = vector3_11.float_2;
      matrix_1.M33 = vector3_3.float_2;
      matrix_1.M34 = 0.0f;
      matrix_1.M41 = -Vector3.smethod_15(vector3_4, vector3_0);
      matrix_1.M42 = -Vector3.smethod_15(vector3_11, vector3_0);
      matrix_1.M43 = -Vector3.smethod_15(vector3_3, vector3_0);
      matrix_1.M44 = 1f;
    }

    public static Matrix smethod_35(Vector3 vector3_0, Plane plane_0)
    {
      Plane plane_1;
      Plane.smethod_1(ref plane_0, out plane_1);
      float num1 = (float) ((double) plane_1.Normal.float_0 * (double) vector3_0.float_0 + (double) plane_1.Normal.float_1 * (double) vector3_0.float_1 + (double) plane_1.Normal.float_2 * (double) vector3_0.float_2);
      float num2 = -plane_1.Normal.float_0;
      float num3 = -plane_1.Normal.float_1;
      float num4 = -plane_1.Normal.float_2;
      float num5 = -plane_1.float_0;
      Matrix matrix;
      matrix.M11 = num2 * vector3_0.float_0 + num1;
      matrix.M21 = num3 * vector3_0.float_0;
      matrix.M31 = num4 * vector3_0.float_0;
      matrix.M41 = num5 * vector3_0.float_0;
      matrix.M12 = num2 * vector3_0.float_1;
      matrix.M22 = num3 * vector3_0.float_1 + num1;
      matrix.M32 = num4 * vector3_0.float_1;
      matrix.M42 = num5 * vector3_0.float_1;
      matrix.M13 = num2 * vector3_0.float_2;
      matrix.M23 = num3 * vector3_0.float_2;
      matrix.M33 = num4 * vector3_0.float_2 + num1;
      matrix.M43 = num5 * vector3_0.float_2;
      matrix.M14 = 0.0f;
      matrix.M24 = 0.0f;
      matrix.M34 = 0.0f;
      matrix.M44 = num1;
      return matrix;
    }

    public static void smethod_36(ref Vector3 vector3_0, ref Plane plane_0, out Matrix matrix_1)
    {
      Plane plane_1;
      Plane.smethod_1(ref plane_0, out plane_1);
      float num1 = (float) ((double) plane_1.Normal.float_0 * (double) vector3_0.float_0 + (double) plane_1.Normal.float_1 * (double) vector3_0.float_1 + (double) plane_1.Normal.float_2 * (double) vector3_0.float_2);
      float num2 = -plane_1.Normal.float_0;
      float num3 = -plane_1.Normal.float_1;
      float num4 = -plane_1.Normal.float_2;
      float num5 = -plane_1.float_0;
      matrix_1.M11 = num2 * vector3_0.float_0 + num1;
      matrix_1.M21 = num3 * vector3_0.float_0;
      matrix_1.M31 = num4 * vector3_0.float_0;
      matrix_1.M41 = num5 * vector3_0.float_0;
      matrix_1.M12 = num2 * vector3_0.float_1;
      matrix_1.M22 = num3 * vector3_0.float_1 + num1;
      matrix_1.M32 = num4 * vector3_0.float_1;
      matrix_1.M42 = num5 * vector3_0.float_1;
      matrix_1.M13 = num2 * vector3_0.float_2;
      matrix_1.M23 = num3 * vector3_0.float_2;
      matrix_1.M33 = num4 * vector3_0.float_2 + num1;
      matrix_1.M43 = num5 * vector3_0.float_2;
      matrix_1.M14 = 0.0f;
      matrix_1.M24 = 0.0f;
      matrix_1.M34 = 0.0f;
      matrix_1.M44 = num1;
    }

    public static Matrix smethod_37(Plane plane_0)
    {
      plane_0.method_0();
      float num1 = plane_0.Normal.float_0;
      float num2 = plane_0.Normal.float_1;
      float num3 = plane_0.Normal.float_2;
      float num4 = -2f * num1;
      float num5 = -2f * num2;
      float num6 = -2f * num3;
      Matrix matrix;
      matrix.M11 = (float) ((double) num4 * (double) num1 + 1.0);
      matrix.M12 = num5 * num1;
      matrix.M13 = num6 * num1;
      matrix.M14 = 0.0f;
      matrix.M21 = num4 * num2;
      matrix.M22 = (float) ((double) num5 * (double) num2 + 1.0);
      matrix.M23 = num6 * num2;
      matrix.M24 = 0.0f;
      matrix.M31 = num4 * num3;
      matrix.M32 = num5 * num3;
      matrix.M33 = (float) ((double) num6 * (double) num3 + 1.0);
      matrix.M34 = 0.0f;
      matrix.M41 = num4 * plane_0.float_0;
      matrix.M42 = num5 * plane_0.float_0;
      matrix.M43 = num6 * plane_0.float_0;
      matrix.M44 = 1f;
      return matrix;
    }

    public static void smethod_38(ref Plane plane_0, out Matrix matrix_1)
    {
      Plane plane_1;
      Plane.smethod_1(ref plane_0, out plane_1);
      plane_0.method_0();
      float num1 = plane_1.Normal.float_0;
      float num2 = plane_1.Normal.float_1;
      float num3 = plane_1.Normal.float_2;
      float num4 = -2f * num1;
      float num5 = -2f * num2;
      float num6 = -2f * num3;
      matrix_1.M11 = (float) ((double) num4 * (double) num1 + 1.0);
      matrix_1.M12 = num5 * num1;
      matrix_1.M13 = num6 * num1;
      matrix_1.M14 = 0.0f;
      matrix_1.M21 = num4 * num2;
      matrix_1.M22 = (float) ((double) num5 * (double) num2 + 1.0);
      matrix_1.M23 = num6 * num2;
      matrix_1.M24 = 0.0f;
      matrix_1.M31 = num4 * num3;
      matrix_1.M32 = num5 * num3;
      matrix_1.M33 = (float) ((double) num6 * (double) num3 + 1.0);
      matrix_1.M34 = 0.0f;
      matrix_1.M41 = num4 * plane_1.float_0;
      matrix_1.M42 = num5 * plane_1.float_0;
      matrix_1.M43 = num6 * plane_1.float_0;
      matrix_1.M44 = 1f;
    }

    public override string ToString()
    {
      CultureInfo currentCulture = CultureInfo.CurrentCulture;
      return "{ " + string.Format((IFormatProvider) currentCulture, "{{M11:{0} M12:{1} M13:{2} M14:{3}}} ", (object) this.M11.ToString((IFormatProvider) currentCulture), (object) this.M12.ToString((IFormatProvider) currentCulture), (object) this.M13.ToString((IFormatProvider) currentCulture), (object) this.M14.ToString((IFormatProvider) currentCulture)) + string.Format((IFormatProvider) currentCulture, "{{M21:{0} M22:{1} M23:{2} M24:{3}}} ", (object) this.M21.ToString((IFormatProvider) currentCulture), (object) this.M22.ToString((IFormatProvider) currentCulture), (object) this.M23.ToString((IFormatProvider) currentCulture), (object) this.M24.ToString((IFormatProvider) currentCulture)) + string.Format((IFormatProvider) currentCulture, "{{M31:{0} M32:{1} M33:{2} M34:{3}}} ", (object) this.M31.ToString((IFormatProvider) currentCulture), (object) this.M32.ToString((IFormatProvider) currentCulture), (object) this.M33.ToString((IFormatProvider) currentCulture), (object) this.M34.ToString((IFormatProvider) currentCulture)) + string.Format((IFormatProvider) currentCulture, "{{M41:{0} M42:{1} M43:{2} M44:{3}}} ", (object) this.M41.ToString((IFormatProvider) currentCulture), (object) this.M42.ToString((IFormatProvider) currentCulture), (object) this.M43.ToString((IFormatProvider) currentCulture), (object) this.M44.ToString((IFormatProvider) currentCulture)) + "}";
    }

    public bool Equals(Matrix other)
    {
      if ((double) this.M11 == (double) other.M11 && (double) this.M22 == (double) other.M22 && ((double) this.M33 == (double) other.M33 && (double) this.M44 == (double) other.M44) && ((double) this.M12 == (double) other.M12 && (double) this.M13 == (double) other.M13 && ((double) this.M14 == (double) other.M14 && (double) this.M21 == (double) other.M21)) && ((double) this.M23 == (double) other.M23 && (double) this.M24 == (double) other.M24 && ((double) this.M31 == (double) other.M31 && (double) this.M32 == (double) other.M32) && ((double) this.M34 == (double) other.M34 && (double) this.M41 == (double) other.M41 && (double) this.M42 == (double) other.M42)))
        return (double) this.M43 == (double) other.M43;
      return false;
    }

    public override bool Equals(object obj)
    {
      bool flag = false;
      if (obj is Matrix)
        flag = this.Equals((Matrix) obj);
      return flag;
    }

    public override int GetHashCode()
    {
      return this.M11.GetHashCode() + this.M12.GetHashCode() + this.M13.GetHashCode() + this.M14.GetHashCode() + this.M21.GetHashCode() + this.M22.GetHashCode() + this.M23.GetHashCode() + this.M24.GetHashCode() + this.M31.GetHashCode() + this.M32.GetHashCode() + this.M33.GetHashCode() + this.M34.GetHashCode() + this.M41.GetHashCode() + this.M42.GetHashCode() + this.M43.GetHashCode() + this.M44.GetHashCode();
    }

    public static Matrix smethod_39(Matrix matrix_1)
    {
      Matrix matrix;
      matrix.M11 = matrix_1.M11;
      matrix.M12 = matrix_1.M21;
      matrix.M13 = matrix_1.M31;
      matrix.M14 = matrix_1.M41;
      matrix.M21 = matrix_1.M12;
      matrix.M22 = matrix_1.M22;
      matrix.M23 = matrix_1.M32;
      matrix.M24 = matrix_1.M42;
      matrix.M31 = matrix_1.M13;
      matrix.M32 = matrix_1.M23;
      matrix.M33 = matrix_1.M33;
      matrix.M34 = matrix_1.M43;
      matrix.M41 = matrix_1.M14;
      matrix.M42 = matrix_1.M24;
      matrix.M43 = matrix_1.M34;
      matrix.M44 = matrix_1.M44;
      return matrix;
    }

    public static void smethod_40(ref Matrix matrix_1, out Matrix matrix_2)
    {
      float num1 = matrix_1.M11;
      float num2 = matrix_1.M12;
      float num3 = matrix_1.M13;
      float num4 = matrix_1.M14;
      float num5 = matrix_1.M21;
      float num6 = matrix_1.M22;
      float num7 = matrix_1.M23;
      float num8 = matrix_1.M24;
      float num9 = matrix_1.M31;
      float num10 = matrix_1.M32;
      float num11 = matrix_1.M33;
      float num12 = matrix_1.M34;
      float num13 = matrix_1.M41;
      float num14 = matrix_1.M42;
      float num15 = matrix_1.M43;
      float num16 = matrix_1.M44;
      matrix_2.M11 = num1;
      matrix_2.M12 = num5;
      matrix_2.M13 = num9;
      matrix_2.M14 = num13;
      matrix_2.M21 = num2;
      matrix_2.M22 = num6;
      matrix_2.M23 = num10;
      matrix_2.M24 = num14;
      matrix_2.M31 = num3;
      matrix_2.M32 = num7;
      matrix_2.M33 = num11;
      matrix_2.M34 = num15;
      matrix_2.M41 = num4;
      matrix_2.M42 = num8;
      matrix_2.M43 = num12;
      matrix_2.M44 = num16;
    }

    public float method_14()
    {
      float num1 = this.M11;
      float num2 = this.M12;
      float num3 = this.M13;
      float num4 = this.M14;
      float num5 = this.M21;
      float num6 = this.M22;
      float num7 = this.M23;
      float num8 = this.M24;
      float num9 = this.M31;
      float num10 = this.M32;
      float num11 = this.M33;
      float num12 = this.M34;
      float num13 = this.M41;
      float num14 = this.M42;
      float num15 = this.M43;
      float num16 = this.M44;
      float num17 = (float) ((double) num11 * (double) num16 - (double) num12 * (double) num15);
      float num18 = (float) ((double) num10 * (double) num16 - (double) num12 * (double) num14);
      float num19 = (float) ((double) num10 * (double) num15 - (double) num11 * (double) num14);
      float num20 = (float) ((double) num9 * (double) num16 - (double) num12 * (double) num13);
      float num21 = (float) ((double) num9 * (double) num15 - (double) num11 * (double) num13);
      float num22 = (float) ((double) num9 * (double) num14 - (double) num10 * (double) num13);
      return (float) ((double) num1 * ((double) num6 * (double) num17 - (double) num7 * (double) num18 + (double) num8 * (double) num19) - (double) num2 * ((double) num5 * (double) num17 - (double) num7 * (double) num20 + (double) num8 * (double) num21) + (double) num3 * ((double) num5 * (double) num18 - (double) num6 * (double) num20 + (double) num8 * (double) num22) - (double) num4 * ((double) num5 * (double) num19 - (double) num6 * (double) num21 + (double) num7 * (double) num22));
    }

    public static Matrix smethod_41(Matrix matrix_1)
    {
      float num1 = matrix_1.M11;
      float num2 = matrix_1.M12;
      float num3 = matrix_1.M13;
      float num4 = matrix_1.M14;
      float num5 = matrix_1.M21;
      float num6 = matrix_1.M22;
      float num7 = matrix_1.M23;
      float num8 = matrix_1.M24;
      float num9 = matrix_1.M31;
      float num10 = matrix_1.M32;
      float num11 = matrix_1.M33;
      float num12 = matrix_1.M34;
      float num13 = matrix_1.M41;
      float num14 = matrix_1.M42;
      float num15 = matrix_1.M43;
      float num16 = matrix_1.M44;
      float num17 = (float) ((double) num11 * (double) num16 - (double) num12 * (double) num15);
      float num18 = (float) ((double) num10 * (double) num16 - (double) num12 * (double) num14);
      float num19 = (float) ((double) num10 * (double) num15 - (double) num11 * (double) num14);
      float num20 = (float) ((double) num9 * (double) num16 - (double) num12 * (double) num13);
      float num21 = (float) ((double) num9 * (double) num15 - (double) num11 * (double) num13);
      float num22 = (float) ((double) num9 * (double) num14 - (double) num10 * (double) num13);
      float num23 = (float) ((double) num6 * (double) num17 - (double) num7 * (double) num18 + (double) num8 * (double) num19);
      float num24 = (float) -((double) num5 * (double) num17 - (double) num7 * (double) num20 + (double) num8 * (double) num21);
      float num25 = (float) ((double) num5 * (double) num18 - (double) num6 * (double) num20 + (double) num8 * (double) num22);
      float num26 = (float) -((double) num5 * (double) num19 - (double) num6 * (double) num21 + (double) num7 * (double) num22);
      float num27 = (float) (1.0 / ((double) num1 * (double) num23 + (double) num2 * (double) num24 + (double) num3 * (double) num25 + (double) num4 * (double) num26));
      Matrix matrix;
      matrix.M11 = num23 * num27;
      matrix.M21 = num24 * num27;
      matrix.M31 = num25 * num27;
      matrix.M41 = num26 * num27;
      matrix.M12 = (float) -((double) num2 * (double) num17 - (double) num3 * (double) num18 + (double) num4 * (double) num19) * num27;
      matrix.M22 = (float) ((double) num1 * (double) num17 - (double) num3 * (double) num20 + (double) num4 * (double) num21) * num27;
      matrix.M32 = (float) -((double) num1 * (double) num18 - (double) num2 * (double) num20 + (double) num4 * (double) num22) * num27;
      matrix.M42 = (float) ((double) num1 * (double) num19 - (double) num2 * (double) num21 + (double) num3 * (double) num22) * num27;
      float num28 = (float) ((double) num7 * (double) num16 - (double) num8 * (double) num15);
      float num29 = (float) ((double) num6 * (double) num16 - (double) num8 * (double) num14);
      float num30 = (float) ((double) num6 * (double) num15 - (double) num7 * (double) num14);
      float num31 = (float) ((double) num5 * (double) num16 - (double) num8 * (double) num13);
      float num32 = (float) ((double) num5 * (double) num15 - (double) num7 * (double) num13);
      float num33 = (float) ((double) num5 * (double) num14 - (double) num6 * (double) num13);
      matrix.M13 = (float) ((double) num2 * (double) num28 - (double) num3 * (double) num29 + (double) num4 * (double) num30) * num27;
      matrix.M23 = (float) -((double) num1 * (double) num28 - (double) num3 * (double) num31 + (double) num4 * (double) num32) * num27;
      matrix.M33 = (float) ((double) num1 * (double) num29 - (double) num2 * (double) num31 + (double) num4 * (double) num33) * num27;
      matrix.M43 = (float) -((double) num1 * (double) num30 - (double) num2 * (double) num32 + (double) num3 * (double) num33) * num27;
      float num34 = (float) ((double) num7 * (double) num12 - (double) num8 * (double) num11);
      float num35 = (float) ((double) num6 * (double) num12 - (double) num8 * (double) num10);
      float num36 = (float) ((double) num6 * (double) num11 - (double) num7 * (double) num10);
      float num37 = (float) ((double) num5 * (double) num12 - (double) num8 * (double) num9);
      float num38 = (float) ((double) num5 * (double) num11 - (double) num7 * (double) num9);
      float num39 = (float) ((double) num5 * (double) num10 - (double) num6 * (double) num9);
      matrix.M14 = (float) -((double) num2 * (double) num34 - (double) num3 * (double) num35 + (double) num4 * (double) num36) * num27;
      matrix.M24 = (float) ((double) num1 * (double) num34 - (double) num3 * (double) num37 + (double) num4 * (double) num38) * num27;
      matrix.M34 = (float) -((double) num1 * (double) num35 - (double) num2 * (double) num37 + (double) num4 * (double) num39) * num27;
      matrix.M44 = (float) ((double) num1 * (double) num36 - (double) num2 * (double) num38 + (double) num3 * (double) num39) * num27;
      return matrix;
    }

    public static void smethod_42(ref Matrix matrix_1, out Matrix matrix_2)
    {
      float num1 = matrix_1.M11;
      float num2 = matrix_1.M12;
      float num3 = matrix_1.M13;
      float num4 = matrix_1.M14;
      float num5 = matrix_1.M21;
      float num6 = matrix_1.M22;
      float num7 = matrix_1.M23;
      float num8 = matrix_1.M24;
      float num9 = matrix_1.M31;
      float num10 = matrix_1.M32;
      float num11 = matrix_1.M33;
      float num12 = matrix_1.M34;
      float num13 = matrix_1.M41;
      float num14 = matrix_1.M42;
      float num15 = matrix_1.M43;
      float num16 = matrix_1.M44;
      float num17 = (float) ((double) num11 * (double) num16 - (double) num12 * (double) num15);
      float num18 = (float) ((double) num10 * (double) num16 - (double) num12 * (double) num14);
      float num19 = (float) ((double) num10 * (double) num15 - (double) num11 * (double) num14);
      float num20 = (float) ((double) num9 * (double) num16 - (double) num12 * (double) num13);
      float num21 = (float) ((double) num9 * (double) num15 - (double) num11 * (double) num13);
      float num22 = (float) ((double) num9 * (double) num14 - (double) num10 * (double) num13);
      float num23 = (float) ((double) num6 * (double) num17 - (double) num7 * (double) num18 + (double) num8 * (double) num19);
      float num24 = (float) -((double) num5 * (double) num17 - (double) num7 * (double) num20 + (double) num8 * (double) num21);
      float num25 = (float) ((double) num5 * (double) num18 - (double) num6 * (double) num20 + (double) num8 * (double) num22);
      float num26 = (float) -((double) num5 * (double) num19 - (double) num6 * (double) num21 + (double) num7 * (double) num22);
      float num27 = (float) (1.0 / ((double) num1 * (double) num23 + (double) num2 * (double) num24 + (double) num3 * (double) num25 + (double) num4 * (double) num26));
      matrix_2.M11 = num23 * num27;
      matrix_2.M21 = num24 * num27;
      matrix_2.M31 = num25 * num27;
      matrix_2.M41 = num26 * num27;
      matrix_2.M12 = (float) -((double) num2 * (double) num17 - (double) num3 * (double) num18 + (double) num4 * (double) num19) * num27;
      matrix_2.M22 = (float) ((double) num1 * (double) num17 - (double) num3 * (double) num20 + (double) num4 * (double) num21) * num27;
      matrix_2.M32 = (float) -((double) num1 * (double) num18 - (double) num2 * (double) num20 + (double) num4 * (double) num22) * num27;
      matrix_2.M42 = (float) ((double) num1 * (double) num19 - (double) num2 * (double) num21 + (double) num3 * (double) num22) * num27;
      float num28 = (float) ((double) num7 * (double) num16 - (double) num8 * (double) num15);
      float num29 = (float) ((double) num6 * (double) num16 - (double) num8 * (double) num14);
      float num30 = (float) ((double) num6 * (double) num15 - (double) num7 * (double) num14);
      float num31 = (float) ((double) num5 * (double) num16 - (double) num8 * (double) num13);
      float num32 = (float) ((double) num5 * (double) num15 - (double) num7 * (double) num13);
      float num33 = (float) ((double) num5 * (double) num14 - (double) num6 * (double) num13);
      matrix_2.M13 = (float) ((double) num2 * (double) num28 - (double) num3 * (double) num29 + (double) num4 * (double) num30) * num27;
      matrix_2.M23 = (float) -((double) num1 * (double) num28 - (double) num3 * (double) num31 + (double) num4 * (double) num32) * num27;
      matrix_2.M33 = (float) ((double) num1 * (double) num29 - (double) num2 * (double) num31 + (double) num4 * (double) num33) * num27;
      matrix_2.M43 = (float) -((double) num1 * (double) num30 - (double) num2 * (double) num32 + (double) num3 * (double) num33) * num27;
      float num34 = (float) ((double) num7 * (double) num12 - (double) num8 * (double) num11);
      float num35 = (float) ((double) num6 * (double) num12 - (double) num8 * (double) num10);
      float num36 = (float) ((double) num6 * (double) num11 - (double) num7 * (double) num10);
      float num37 = (float) ((double) num5 * (double) num12 - (double) num8 * (double) num9);
      float num38 = (float) ((double) num5 * (double) num11 - (double) num7 * (double) num9);
      float num39 = (float) ((double) num5 * (double) num10 - (double) num6 * (double) num9);
      matrix_2.M14 = (float) -((double) num2 * (double) num34 - (double) num3 * (double) num35 + (double) num4 * (double) num36) * num27;
      matrix_2.M24 = (float) ((double) num1 * (double) num34 - (double) num3 * (double) num37 + (double) num4 * (double) num38) * num27;
      matrix_2.M34 = (float) -((double) num1 * (double) num35 - (double) num2 * (double) num37 + (double) num4 * (double) num39) * num27;
      matrix_2.M44 = (float) ((double) num1 * (double) num36 - (double) num2 * (double) num38 + (double) num3 * (double) num39) * num27;
    }

    public static Matrix smethod_43(Matrix matrix_1, Matrix matrix_2, float float_0)
    {
      Matrix matrix;
      matrix.M11 = matrix_1.M11 + (matrix_2.M11 - matrix_1.M11) * float_0;
      matrix.M12 = matrix_1.M12 + (matrix_2.M12 - matrix_1.M12) * float_0;
      matrix.M13 = matrix_1.M13 + (matrix_2.M13 - matrix_1.M13) * float_0;
      matrix.M14 = matrix_1.M14 + (matrix_2.M14 - matrix_1.M14) * float_0;
      matrix.M21 = matrix_1.M21 + (matrix_2.M21 - matrix_1.M21) * float_0;
      matrix.M22 = matrix_1.M22 + (matrix_2.M22 - matrix_1.M22) * float_0;
      matrix.M23 = matrix_1.M23 + (matrix_2.M23 - matrix_1.M23) * float_0;
      matrix.M24 = matrix_1.M24 + (matrix_2.M24 - matrix_1.M24) * float_0;
      matrix.M31 = matrix_1.M31 + (matrix_2.M31 - matrix_1.M31) * float_0;
      matrix.M32 = matrix_1.M32 + (matrix_2.M32 - matrix_1.M32) * float_0;
      matrix.M33 = matrix_1.M33 + (matrix_2.M33 - matrix_1.M33) * float_0;
      matrix.M34 = matrix_1.M34 + (matrix_2.M34 - matrix_1.M34) * float_0;
      matrix.M41 = matrix_1.M41 + (matrix_2.M41 - matrix_1.M41) * float_0;
      matrix.M42 = matrix_1.M42 + (matrix_2.M42 - matrix_1.M42) * float_0;
      matrix.M43 = matrix_1.M43 + (matrix_2.M43 - matrix_1.M43) * float_0;
      matrix.M44 = matrix_1.M44 + (matrix_2.M44 - matrix_1.M44) * float_0;
      return matrix;
    }

    public static void smethod_44(ref Matrix matrix_1, ref Matrix matrix_2, float float_0, out Matrix matrix_3)
    {
      matrix_3.M11 = matrix_1.M11 + (matrix_2.M11 - matrix_1.M11) * float_0;
      matrix_3.M12 = matrix_1.M12 + (matrix_2.M12 - matrix_1.M12) * float_0;
      matrix_3.M13 = matrix_1.M13 + (matrix_2.M13 - matrix_1.M13) * float_0;
      matrix_3.M14 = matrix_1.M14 + (matrix_2.M14 - matrix_1.M14) * float_0;
      matrix_3.M21 = matrix_1.M21 + (matrix_2.M21 - matrix_1.M21) * float_0;
      matrix_3.M22 = matrix_1.M22 + (matrix_2.M22 - matrix_1.M22) * float_0;
      matrix_3.M23 = matrix_1.M23 + (matrix_2.M23 - matrix_1.M23) * float_0;
      matrix_3.M24 = matrix_1.M24 + (matrix_2.M24 - matrix_1.M24) * float_0;
      matrix_3.M31 = matrix_1.M31 + (matrix_2.M31 - matrix_1.M31) * float_0;
      matrix_3.M32 = matrix_1.M32 + (matrix_2.M32 - matrix_1.M32) * float_0;
      matrix_3.M33 = matrix_1.M33 + (matrix_2.M33 - matrix_1.M33) * float_0;
      matrix_3.M34 = matrix_1.M34 + (matrix_2.M34 - matrix_1.M34) * float_0;
      matrix_3.M41 = matrix_1.M41 + (matrix_2.M41 - matrix_1.M41) * float_0;
      matrix_3.M42 = matrix_1.M42 + (matrix_2.M42 - matrix_1.M42) * float_0;
      matrix_3.M43 = matrix_1.M43 + (matrix_2.M43 - matrix_1.M43) * float_0;
      matrix_3.M44 = matrix_1.M44 + (matrix_2.M44 - matrix_1.M44) * float_0;
    }

    public static Matrix smethod_45(Matrix matrix_1)
    {
      Matrix matrix;
      matrix.M11 = -matrix_1.M11;
      matrix.M12 = -matrix_1.M12;
      matrix.M13 = -matrix_1.M13;
      matrix.M14 = -matrix_1.M14;
      matrix.M21 = -matrix_1.M21;
      matrix.M22 = -matrix_1.M22;
      matrix.M23 = -matrix_1.M23;
      matrix.M24 = -matrix_1.M24;
      matrix.M31 = -matrix_1.M31;
      matrix.M32 = -matrix_1.M32;
      matrix.M33 = -matrix_1.M33;
      matrix.M34 = -matrix_1.M34;
      matrix.M41 = -matrix_1.M41;
      matrix.M42 = -matrix_1.M42;
      matrix.M43 = -matrix_1.M43;
      matrix.M44 = -matrix_1.M44;
      return matrix;
    }

    public static void smethod_46(ref Matrix matrix_1, out Matrix matrix_2)
    {
      matrix_2.M11 = -matrix_1.M11;
      matrix_2.M12 = -matrix_1.M12;
      matrix_2.M13 = -matrix_1.M13;
      matrix_2.M14 = -matrix_1.M14;
      matrix_2.M21 = -matrix_1.M21;
      matrix_2.M22 = -matrix_1.M22;
      matrix_2.M23 = -matrix_1.M23;
      matrix_2.M24 = -matrix_1.M24;
      matrix_2.M31 = -matrix_1.M31;
      matrix_2.M32 = -matrix_1.M32;
      matrix_2.M33 = -matrix_1.M33;
      matrix_2.M34 = -matrix_1.M34;
      matrix_2.M41 = -matrix_1.M41;
      matrix_2.M42 = -matrix_1.M42;
      matrix_2.M43 = -matrix_1.M43;
      matrix_2.M44 = -matrix_1.M44;
    }

    public static Matrix smethod_47(Matrix matrix_1, Matrix matrix_2)
    {
      Matrix matrix;
      matrix.M11 = matrix_1.M11 + matrix_2.M11;
      matrix.M12 = matrix_1.M12 + matrix_2.M12;
      matrix.M13 = matrix_1.M13 + matrix_2.M13;
      matrix.M14 = matrix_1.M14 + matrix_2.M14;
      matrix.M21 = matrix_1.M21 + matrix_2.M21;
      matrix.M22 = matrix_1.M22 + matrix_2.M22;
      matrix.M23 = matrix_1.M23 + matrix_2.M23;
      matrix.M24 = matrix_1.M24 + matrix_2.M24;
      matrix.M31 = matrix_1.M31 + matrix_2.M31;
      matrix.M32 = matrix_1.M32 + matrix_2.M32;
      matrix.M33 = matrix_1.M33 + matrix_2.M33;
      matrix.M34 = matrix_1.M34 + matrix_2.M34;
      matrix.M41 = matrix_1.M41 + matrix_2.M41;
      matrix.M42 = matrix_1.M42 + matrix_2.M42;
      matrix.M43 = matrix_1.M43 + matrix_2.M43;
      matrix.M44 = matrix_1.M44 + matrix_2.M44;
      return matrix;
    }

    public static void smethod_48(ref Matrix matrix_1, ref Matrix matrix_2, out Matrix matrix_3)
    {
      matrix_3.M11 = matrix_1.M11 + matrix_2.M11;
      matrix_3.M12 = matrix_1.M12 + matrix_2.M12;
      matrix_3.M13 = matrix_1.M13 + matrix_2.M13;
      matrix_3.M14 = matrix_1.M14 + matrix_2.M14;
      matrix_3.M21 = matrix_1.M21 + matrix_2.M21;
      matrix_3.M22 = matrix_1.M22 + matrix_2.M22;
      matrix_3.M23 = matrix_1.M23 + matrix_2.M23;
      matrix_3.M24 = matrix_1.M24 + matrix_2.M24;
      matrix_3.M31 = matrix_1.M31 + matrix_2.M31;
      matrix_3.M32 = matrix_1.M32 + matrix_2.M32;
      matrix_3.M33 = matrix_1.M33 + matrix_2.M33;
      matrix_3.M34 = matrix_1.M34 + matrix_2.M34;
      matrix_3.M41 = matrix_1.M41 + matrix_2.M41;
      matrix_3.M42 = matrix_1.M42 + matrix_2.M42;
      matrix_3.M43 = matrix_1.M43 + matrix_2.M43;
      matrix_3.M44 = matrix_1.M44 + matrix_2.M44;
    }

    public static Matrix smethod_49(Matrix matrix_1, Matrix matrix_2)
    {
      Matrix matrix;
      matrix.M11 = matrix_1.M11 - matrix_2.M11;
      matrix.M12 = matrix_1.M12 - matrix_2.M12;
      matrix.M13 = matrix_1.M13 - matrix_2.M13;
      matrix.M14 = matrix_1.M14 - matrix_2.M14;
      matrix.M21 = matrix_1.M21 - matrix_2.M21;
      matrix.M22 = matrix_1.M22 - matrix_2.M22;
      matrix.M23 = matrix_1.M23 - matrix_2.M23;
      matrix.M24 = matrix_1.M24 - matrix_2.M24;
      matrix.M31 = matrix_1.M31 - matrix_2.M31;
      matrix.M32 = matrix_1.M32 - matrix_2.M32;
      matrix.M33 = matrix_1.M33 - matrix_2.M33;
      matrix.M34 = matrix_1.M34 - matrix_2.M34;
      matrix.M41 = matrix_1.M41 - matrix_2.M41;
      matrix.M42 = matrix_1.M42 - matrix_2.M42;
      matrix.M43 = matrix_1.M43 - matrix_2.M43;
      matrix.M44 = matrix_1.M44 - matrix_2.M44;
      return matrix;
    }

    public static void smethod_50(ref Matrix matrix_1, ref Matrix matrix_2, out Matrix matrix_3)
    {
      matrix_3.M11 = matrix_1.M11 - matrix_2.M11;
      matrix_3.M12 = matrix_1.M12 - matrix_2.M12;
      matrix_3.M13 = matrix_1.M13 - matrix_2.M13;
      matrix_3.M14 = matrix_1.M14 - matrix_2.M14;
      matrix_3.M21 = matrix_1.M21 - matrix_2.M21;
      matrix_3.M22 = matrix_1.M22 - matrix_2.M22;
      matrix_3.M23 = matrix_1.M23 - matrix_2.M23;
      matrix_3.M24 = matrix_1.M24 - matrix_2.M24;
      matrix_3.M31 = matrix_1.M31 - matrix_2.M31;
      matrix_3.M32 = matrix_1.M32 - matrix_2.M32;
      matrix_3.M33 = matrix_1.M33 - matrix_2.M33;
      matrix_3.M34 = matrix_1.M34 - matrix_2.M34;
      matrix_3.M41 = matrix_1.M41 - matrix_2.M41;
      matrix_3.M42 = matrix_1.M42 - matrix_2.M42;
      matrix_3.M43 = matrix_1.M43 - matrix_2.M43;
      matrix_3.M44 = matrix_1.M44 - matrix_2.M44;
    }

    public static Matrix smethod_51(Matrix matrix_1, Matrix matrix_2)
    {
      Matrix matrix;
      matrix.M11 = (float) ((double) matrix_1.M11 * (double) matrix_2.M11 + (double) matrix_1.M12 * (double) matrix_2.M21 + (double) matrix_1.M13 * (double) matrix_2.M31 + (double) matrix_1.M14 * (double) matrix_2.M41);
      matrix.M12 = (float) ((double) matrix_1.M11 * (double) matrix_2.M12 + (double) matrix_1.M12 * (double) matrix_2.M22 + (double) matrix_1.M13 * (double) matrix_2.M32 + (double) matrix_1.M14 * (double) matrix_2.M42);
      matrix.M13 = (float) ((double) matrix_1.M11 * (double) matrix_2.M13 + (double) matrix_1.M12 * (double) matrix_2.M23 + (double) matrix_1.M13 * (double) matrix_2.M33 + (double) matrix_1.M14 * (double) matrix_2.M43);
      matrix.M14 = (float) ((double) matrix_1.M11 * (double) matrix_2.M14 + (double) matrix_1.M12 * (double) matrix_2.M24 + (double) matrix_1.M13 * (double) matrix_2.M34 + (double) matrix_1.M14 * (double) matrix_2.M44);
      matrix.M21 = (float) ((double) matrix_1.M21 * (double) matrix_2.M11 + (double) matrix_1.M22 * (double) matrix_2.M21 + (double) matrix_1.M23 * (double) matrix_2.M31 + (double) matrix_1.M24 * (double) matrix_2.M41);
      matrix.M22 = (float) ((double) matrix_1.M21 * (double) matrix_2.M12 + (double) matrix_1.M22 * (double) matrix_2.M22 + (double) matrix_1.M23 * (double) matrix_2.M32 + (double) matrix_1.M24 * (double) matrix_2.M42);
      matrix.M23 = (float) ((double) matrix_1.M21 * (double) matrix_2.M13 + (double) matrix_1.M22 * (double) matrix_2.M23 + (double) matrix_1.M23 * (double) matrix_2.M33 + (double) matrix_1.M24 * (double) matrix_2.M43);
      matrix.M24 = (float) ((double) matrix_1.M21 * (double) matrix_2.M14 + (double) matrix_1.M22 * (double) matrix_2.M24 + (double) matrix_1.M23 * (double) matrix_2.M34 + (double) matrix_1.M24 * (double) matrix_2.M44);
      matrix.M31 = (float) ((double) matrix_1.M31 * (double) matrix_2.M11 + (double) matrix_1.M32 * (double) matrix_2.M21 + (double) matrix_1.M33 * (double) matrix_2.M31 + (double) matrix_1.M34 * (double) matrix_2.M41);
      matrix.M32 = (float) ((double) matrix_1.M31 * (double) matrix_2.M12 + (double) matrix_1.M32 * (double) matrix_2.M22 + (double) matrix_1.M33 * (double) matrix_2.M32 + (double) matrix_1.M34 * (double) matrix_2.M42);
      matrix.M33 = (float) ((double) matrix_1.M31 * (double) matrix_2.M13 + (double) matrix_1.M32 * (double) matrix_2.M23 + (double) matrix_1.M33 * (double) matrix_2.M33 + (double) matrix_1.M34 * (double) matrix_2.M43);
      matrix.M34 = (float) ((double) matrix_1.M31 * (double) matrix_2.M14 + (double) matrix_1.M32 * (double) matrix_2.M24 + (double) matrix_1.M33 * (double) matrix_2.M34 + (double) matrix_1.M34 * (double) matrix_2.M44);
      matrix.M41 = (float) ((double) matrix_1.M41 * (double) matrix_2.M11 + (double) matrix_1.M42 * (double) matrix_2.M21 + (double) matrix_1.M43 * (double) matrix_2.M31 + (double) matrix_1.M44 * (double) matrix_2.M41);
      matrix.M42 = (float) ((double) matrix_1.M41 * (double) matrix_2.M12 + (double) matrix_1.M42 * (double) matrix_2.M22 + (double) matrix_1.M43 * (double) matrix_2.M32 + (double) matrix_1.M44 * (double) matrix_2.M42);
      matrix.M43 = (float) ((double) matrix_1.M41 * (double) matrix_2.M13 + (double) matrix_1.M42 * (double) matrix_2.M23 + (double) matrix_1.M43 * (double) matrix_2.M33 + (double) matrix_1.M44 * (double) matrix_2.M43);
      matrix.M44 = (float) ((double) matrix_1.M41 * (double) matrix_2.M14 + (double) matrix_1.M42 * (double) matrix_2.M24 + (double) matrix_1.M43 * (double) matrix_2.M34 + (double) matrix_1.M44 * (double) matrix_2.M44);
      return matrix;
    }

    public static void smethod_52(ref Matrix matrix_1, ref Matrix matrix_2, out Matrix matrix_3)
    {
      float num1 = (float) ((double) matrix_1.M11 * (double) matrix_2.M11 + (double) matrix_1.M12 * (double) matrix_2.M21 + (double) matrix_1.M13 * (double) matrix_2.M31 + (double) matrix_1.M14 * (double) matrix_2.M41);
      float num2 = (float) ((double) matrix_1.M11 * (double) matrix_2.M12 + (double) matrix_1.M12 * (double) matrix_2.M22 + (double) matrix_1.M13 * (double) matrix_2.M32 + (double) matrix_1.M14 * (double) matrix_2.M42);
      float num3 = (float) ((double) matrix_1.M11 * (double) matrix_2.M13 + (double) matrix_1.M12 * (double) matrix_2.M23 + (double) matrix_1.M13 * (double) matrix_2.M33 + (double) matrix_1.M14 * (double) matrix_2.M43);
      float num4 = (float) ((double) matrix_1.M11 * (double) matrix_2.M14 + (double) matrix_1.M12 * (double) matrix_2.M24 + (double) matrix_1.M13 * (double) matrix_2.M34 + (double) matrix_1.M14 * (double) matrix_2.M44);
      float num5 = (float) ((double) matrix_1.M21 * (double) matrix_2.M11 + (double) matrix_1.M22 * (double) matrix_2.M21 + (double) matrix_1.M23 * (double) matrix_2.M31 + (double) matrix_1.M24 * (double) matrix_2.M41);
      float num6 = (float) ((double) matrix_1.M21 * (double) matrix_2.M12 + (double) matrix_1.M22 * (double) matrix_2.M22 + (double) matrix_1.M23 * (double) matrix_2.M32 + (double) matrix_1.M24 * (double) matrix_2.M42);
      float num7 = (float) ((double) matrix_1.M21 * (double) matrix_2.M13 + (double) matrix_1.M22 * (double) matrix_2.M23 + (double) matrix_1.M23 * (double) matrix_2.M33 + (double) matrix_1.M24 * (double) matrix_2.M43);
      float num8 = (float) ((double) matrix_1.M21 * (double) matrix_2.M14 + (double) matrix_1.M22 * (double) matrix_2.M24 + (double) matrix_1.M23 * (double) matrix_2.M34 + (double) matrix_1.M24 * (double) matrix_2.M44);
      float num9 = (float) ((double) matrix_1.M31 * (double) matrix_2.M11 + (double) matrix_1.M32 * (double) matrix_2.M21 + (double) matrix_1.M33 * (double) matrix_2.M31 + (double) matrix_1.M34 * (double) matrix_2.M41);
      float num10 = (float) ((double) matrix_1.M31 * (double) matrix_2.M12 + (double) matrix_1.M32 * (double) matrix_2.M22 + (double) matrix_1.M33 * (double) matrix_2.M32 + (double) matrix_1.M34 * (double) matrix_2.M42);
      float num11 = (float) ((double) matrix_1.M31 * (double) matrix_2.M13 + (double) matrix_1.M32 * (double) matrix_2.M23 + (double) matrix_1.M33 * (double) matrix_2.M33 + (double) matrix_1.M34 * (double) matrix_2.M43);
      float num12 = (float) ((double) matrix_1.M31 * (double) matrix_2.M14 + (double) matrix_1.M32 * (double) matrix_2.M24 + (double) matrix_1.M33 * (double) matrix_2.M34 + (double) matrix_1.M34 * (double) matrix_2.M44);
      float num13 = (float) ((double) matrix_1.M41 * (double) matrix_2.M11 + (double) matrix_1.M42 * (double) matrix_2.M21 + (double) matrix_1.M43 * (double) matrix_2.M31 + (double) matrix_1.M44 * (double) matrix_2.M41);
      float num14 = (float) ((double) matrix_1.M41 * (double) matrix_2.M12 + (double) matrix_1.M42 * (double) matrix_2.M22 + (double) matrix_1.M43 * (double) matrix_2.M32 + (double) matrix_1.M44 * (double) matrix_2.M42);
      float num15 = (float) ((double) matrix_1.M41 * (double) matrix_2.M13 + (double) matrix_1.M42 * (double) matrix_2.M23 + (double) matrix_1.M43 * (double) matrix_2.M33 + (double) matrix_1.M44 * (double) matrix_2.M43);
      float num16 = (float) ((double) matrix_1.M41 * (double) matrix_2.M14 + (double) matrix_1.M42 * (double) matrix_2.M24 + (double) matrix_1.M43 * (double) matrix_2.M34 + (double) matrix_1.M44 * (double) matrix_2.M44);
      matrix_3.M11 = num1;
      matrix_3.M12 = num2;
      matrix_3.M13 = num3;
      matrix_3.M14 = num4;
      matrix_3.M21 = num5;
      matrix_3.M22 = num6;
      matrix_3.M23 = num7;
      matrix_3.M24 = num8;
      matrix_3.M31 = num9;
      matrix_3.M32 = num10;
      matrix_3.M33 = num11;
      matrix_3.M34 = num12;
      matrix_3.M41 = num13;
      matrix_3.M42 = num14;
      matrix_3.M43 = num15;
      matrix_3.M44 = num16;
    }

    public static Matrix smethod_53(Matrix matrix_1, float float_0)
    {
      Matrix matrix;
      matrix.M11 = matrix_1.M11 * float_0;
      matrix.M12 = matrix_1.M12 * float_0;
      matrix.M13 = matrix_1.M13 * float_0;
      matrix.M14 = matrix_1.M14 * float_0;
      matrix.M21 = matrix_1.M21 * float_0;
      matrix.M22 = matrix_1.M22 * float_0;
      matrix.M23 = matrix_1.M23 * float_0;
      matrix.M24 = matrix_1.M24 * float_0;
      matrix.M31 = matrix_1.M31 * float_0;
      matrix.M32 = matrix_1.M32 * float_0;
      matrix.M33 = matrix_1.M33 * float_0;
      matrix.M34 = matrix_1.M34 * float_0;
      matrix.M41 = matrix_1.M41 * float_0;
      matrix.M42 = matrix_1.M42 * float_0;
      matrix.M43 = matrix_1.M43 * float_0;
      matrix.M44 = matrix_1.M44 * float_0;
      return matrix;
    }

    public static void smethod_54(ref Matrix matrix_1, float float_0, out Matrix matrix_2)
    {
      matrix_2.M11 = matrix_1.M11 * float_0;
      matrix_2.M12 = matrix_1.M12 * float_0;
      matrix_2.M13 = matrix_1.M13 * float_0;
      matrix_2.M14 = matrix_1.M14 * float_0;
      matrix_2.M21 = matrix_1.M21 * float_0;
      matrix_2.M22 = matrix_1.M22 * float_0;
      matrix_2.M23 = matrix_1.M23 * float_0;
      matrix_2.M24 = matrix_1.M24 * float_0;
      matrix_2.M31 = matrix_1.M31 * float_0;
      matrix_2.M32 = matrix_1.M32 * float_0;
      matrix_2.M33 = matrix_1.M33 * float_0;
      matrix_2.M34 = matrix_1.M34 * float_0;
      matrix_2.M41 = matrix_1.M41 * float_0;
      matrix_2.M42 = matrix_1.M42 * float_0;
      matrix_2.M43 = matrix_1.M43 * float_0;
      matrix_2.M44 = matrix_1.M44 * float_0;
    }

    public static Matrix smethod_55(Matrix matrix_1, Matrix matrix_2)
    {
      Matrix matrix;
      matrix.M11 = matrix_1.M11 / matrix_2.M11;
      matrix.M12 = matrix_1.M12 / matrix_2.M12;
      matrix.M13 = matrix_1.M13 / matrix_2.M13;
      matrix.M14 = matrix_1.M14 / matrix_2.M14;
      matrix.M21 = matrix_1.M21 / matrix_2.M21;
      matrix.M22 = matrix_1.M22 / matrix_2.M22;
      matrix.M23 = matrix_1.M23 / matrix_2.M23;
      matrix.M24 = matrix_1.M24 / matrix_2.M24;
      matrix.M31 = matrix_1.M31 / matrix_2.M31;
      matrix.M32 = matrix_1.M32 / matrix_2.M32;
      matrix.M33 = matrix_1.M33 / matrix_2.M33;
      matrix.M34 = matrix_1.M34 / matrix_2.M34;
      matrix.M41 = matrix_1.M41 / matrix_2.M41;
      matrix.M42 = matrix_1.M42 / matrix_2.M42;
      matrix.M43 = matrix_1.M43 / matrix_2.M43;
      matrix.M44 = matrix_1.M44 / matrix_2.M44;
      return matrix;
    }

    public static void smethod_56(ref Matrix matrix_1, ref Matrix matrix_2, out Matrix matrix_3)
    {
      matrix_3.M11 = matrix_1.M11 / matrix_2.M11;
      matrix_3.M12 = matrix_1.M12 / matrix_2.M12;
      matrix_3.M13 = matrix_1.M13 / matrix_2.M13;
      matrix_3.M14 = matrix_1.M14 / matrix_2.M14;
      matrix_3.M21 = matrix_1.M21 / matrix_2.M21;
      matrix_3.M22 = matrix_1.M22 / matrix_2.M22;
      matrix_3.M23 = matrix_1.M23 / matrix_2.M23;
      matrix_3.M24 = matrix_1.M24 / matrix_2.M24;
      matrix_3.M31 = matrix_1.M31 / matrix_2.M31;
      matrix_3.M32 = matrix_1.M32 / matrix_2.M32;
      matrix_3.M33 = matrix_1.M33 / matrix_2.M33;
      matrix_3.M34 = matrix_1.M34 / matrix_2.M34;
      matrix_3.M41 = matrix_1.M41 / matrix_2.M41;
      matrix_3.M42 = matrix_1.M42 / matrix_2.M42;
      matrix_3.M43 = matrix_1.M43 / matrix_2.M43;
      matrix_3.M44 = matrix_1.M44 / matrix_2.M44;
    }

    public static Matrix smethod_57(Matrix matrix_1, float float_0)
    {
      float num = 1f / float_0;
      Matrix matrix;
      matrix.M11 = matrix_1.M11 * num;
      matrix.M12 = matrix_1.M12 * num;
      matrix.M13 = matrix_1.M13 * num;
      matrix.M14 = matrix_1.M14 * num;
      matrix.M21 = matrix_1.M21 * num;
      matrix.M22 = matrix_1.M22 * num;
      matrix.M23 = matrix_1.M23 * num;
      matrix.M24 = matrix_1.M24 * num;
      matrix.M31 = matrix_1.M31 * num;
      matrix.M32 = matrix_1.M32 * num;
      matrix.M33 = matrix_1.M33 * num;
      matrix.M34 = matrix_1.M34 * num;
      matrix.M41 = matrix_1.M41 * num;
      matrix.M42 = matrix_1.M42 * num;
      matrix.M43 = matrix_1.M43 * num;
      matrix.M44 = matrix_1.M44 * num;
      return matrix;
    }

    public static void smethod_58(ref Matrix matrix_1, float float_0, out Matrix matrix_2)
    {
      float num = 1f / float_0;
      matrix_2.M11 = matrix_1.M11 * num;
      matrix_2.M12 = matrix_1.M12 * num;
      matrix_2.M13 = matrix_1.M13 * num;
      matrix_2.M14 = matrix_1.M14 * num;
      matrix_2.M21 = matrix_1.M21 * num;
      matrix_2.M22 = matrix_1.M22 * num;
      matrix_2.M23 = matrix_1.M23 * num;
      matrix_2.M24 = matrix_1.M24 * num;
      matrix_2.M31 = matrix_1.M31 * num;
      matrix_2.M32 = matrix_1.M32 * num;
      matrix_2.M33 = matrix_1.M33 * num;
      matrix_2.M34 = matrix_1.M34 * num;
      matrix_2.M41 = matrix_1.M41 * num;
      matrix_2.M42 = matrix_1.M42 * num;
      matrix_2.M43 = matrix_1.M43 * num;
      matrix_2.M44 = matrix_1.M44 * num;
    }

    private struct Struct87
    {
      public Vector3 vector3_0;
      public Vector3 vector3_1;
      public Vector3 vector3_2;
    }

    private struct Struct88
    {
      public unsafe Vector3* pVector3_0;
      public unsafe Vector3* pVector3_1;
      public unsafe Vector3* pVector3_2;
    }
  }
}
