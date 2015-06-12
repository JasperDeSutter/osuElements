// Decompiled with JetBrains decompiler
// Type: Microsoft.Xna.Framework.BoundingBox
// Assembly: osu!, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01B8D71D-E69E-4E8A-76A7-28C15896CF26
// Assembly location: D:\Downloads\Decompiled osu\osu!-cleaned.exe

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Xna.Framework
{
  [ComVisible(false)]
  [Serializable]
  public struct BoundingBox : IEquatable<BoundingBox>
  {
    public Vector3 Min;
    public Vector3 Max;

    public BoundingBox(Vector3 vector3_0, Vector3 vector3_1)
    {
      this.Min = vector3_0;
      this.Max = vector3_1;
    }

    public Vector3[] method_0()
    {
      return new Vector3[8]
      {
        new Vector3(this.Min.float_0, this.Max.float_1, this.Max.float_2),
        new Vector3(this.Max.float_0, this.Max.float_1, this.Max.float_2),
        new Vector3(this.Max.float_0, this.Min.float_1, this.Max.float_2),
        new Vector3(this.Min.float_0, this.Min.float_1, this.Max.float_2),
        new Vector3(this.Min.float_0, this.Max.float_1, this.Min.float_2),
        new Vector3(this.Max.float_0, this.Max.float_1, this.Min.float_2),
        new Vector3(this.Max.float_0, this.Min.float_1, this.Min.float_2),
        new Vector3(this.Min.float_0, this.Min.float_1, this.Min.float_2)
      };
    }

    public void method_1(Vector3[] vector3_0)
    {
      if (vector3_0 == null)
        throw new ArgumentNullException("#=qVPwfgA9wvuKj3aLZdoRfjA==");
      if (vector3_0.Length < 8)
        throw new ArgumentOutOfRangeException(Class1070.smethod_8());
      vector3_0[0].float_0 = this.Min.float_0;
      vector3_0[0].float_1 = this.Max.float_1;
      vector3_0[0].float_2 = this.Max.float_2;
      vector3_0[1].float_0 = this.Max.float_0;
      vector3_0[1].float_1 = this.Max.float_1;
      vector3_0[1].float_2 = this.Max.float_2;
      vector3_0[2].float_0 = this.Max.float_0;
      vector3_0[2].float_1 = this.Min.float_1;
      vector3_0[2].float_2 = this.Max.float_2;
      vector3_0[3].float_0 = this.Min.float_0;
      vector3_0[3].float_1 = this.Min.float_1;
      vector3_0[3].float_2 = this.Max.float_2;
      vector3_0[4].float_0 = this.Min.float_0;
      vector3_0[4].float_1 = this.Max.float_1;
      vector3_0[4].float_2 = this.Min.float_2;
      vector3_0[5].float_0 = this.Max.float_0;
      vector3_0[5].float_1 = this.Max.float_1;
      vector3_0[5].float_2 = this.Min.float_2;
      vector3_0[6].float_0 = this.Max.float_0;
      vector3_0[6].float_1 = this.Min.float_1;
      vector3_0[6].float_2 = this.Min.float_2;
      vector3_0[7].float_0 = this.Min.float_0;
      vector3_0[7].float_1 = this.Min.float_1;
      vector3_0[7].float_2 = this.Min.float_2;
    }

    public bool Equals(BoundingBox other)
    {
      if (this.Min == other.Min)
        return this.Max == other.Max;
      return false;
    }

    public override bool Equals(object obj)
    {
      bool flag = false;
      if (obj is BoundingBox)
        flag = this.Equals((BoundingBox) obj);
      return flag;
    }

    public override int GetHashCode()
    {
      return this.Min.GetHashCode() + this.Max.GetHashCode();
    }

    public override string ToString()
    {
      return string.Format((IFormatProvider) CultureInfo.CurrentCulture, "{{Min:{0} Max:{1}}}", new object[2]
      {
        (object) this.Min.ToString(),
        (object) this.Max.ToString()
      });
    }

    public static BoundingBox smethod_0(BoundingBox boundingBox_0, BoundingBox boundingBox_1)
    {
      BoundingBox boundingBox;
      Vector3.smethod_24(ref boundingBox_0.Min, ref boundingBox_1.Min, out boundingBox.Min);
      Vector3.smethod_26(ref boundingBox_0.Max, ref boundingBox_1.Max, out boundingBox.Max);
      return boundingBox;
    }

    public static void smethod_1(ref BoundingBox boundingBox_0, ref BoundingBox boundingBox_1, out BoundingBox boundingBox_2)
    {
      Vector3 vector3_13_1;
      Vector3.smethod_24(ref boundingBox_0.Min, ref boundingBox_1.Min, out vector3_13_1);
      Vector3 vector3_13_2;
      Vector3.smethod_26(ref boundingBox_0.Max, ref boundingBox_1.Max, out vector3_13_2);
      boundingBox_2.Min = vector3_13_1;
      boundingBox_2.Max = vector3_13_2;
    }

    public static BoundingBox smethod_2(IEnumerable<Vector3> ienumerable_0)
    {
      if (ienumerable_0 == null)
        throw new ArgumentNullException();
      bool flag = false;
      Vector3 vector3_13_1 = new Vector3(float.MaxValue);
      Vector3 vector3_13_2 = new Vector3(float.MinValue);
      foreach (Vector3 vector3_12 in ienumerable_0)
      {
        Vector3.smethod_24(ref vector3_13_1, ref vector3_12, out vector3_13_1);
        Vector3.smethod_26(ref vector3_13_2, ref vector3_12, out vector3_13_2);
        flag = true;
      }
      if (!flag)
        throw new ArgumentException(Class1070.smethod_3());
      return new BoundingBox(vector3_13_1, vector3_13_2);
    }

    public bool method_2(BoundingBox boundingBox_0)
    {
      if ((double) this.Max.float_0 >= (double) boundingBox_0.Min.float_0 && (double) this.Min.float_0 <= (double) boundingBox_0.Max.float_0 && ((double) this.Max.float_1 >= (double) boundingBox_0.Min.float_1 && (double) this.Min.float_1 <= (double) boundingBox_0.Max.float_1) && (double) this.Max.float_2 >= (double) boundingBox_0.Min.float_2)
        return (double) this.Min.float_2 <= (double) boundingBox_0.Max.float_2;
      return false;
    }

    public void method_3(ref BoundingBox boundingBox_0, out bool bool_0)
    {
      bool_0 = false;
      if ((double) this.Max.float_0 < (double) boundingBox_0.Min.float_0 || (double) this.Min.float_0 > (double) boundingBox_0.Max.float_0 || ((double) this.Max.float_1 < (double) boundingBox_0.Min.float_1 || (double) this.Min.float_1 > (double) boundingBox_0.Max.float_1) || ((double) this.Max.float_2 < (double) boundingBox_0.Min.float_2 || (double) this.Min.float_2 > (double) boundingBox_0.Max.float_2))
        return;
      bool_0 = true;
    }

    public GEnum97 method_4(Plane plane_0)
    {
      Vector3 vector3_1;
      vector3_1.float_0 = (double) plane_0.Normal.float_0 >= 0.0 ? this.Min.float_0 : this.Max.float_0;
      vector3_1.float_1 = (double) plane_0.Normal.float_1 >= 0.0 ? this.Min.float_1 : this.Max.float_1;
      vector3_1.float_2 = (double) plane_0.Normal.float_2 >= 0.0 ? this.Min.float_2 : this.Max.float_2;
      Vector3 vector3_2;
      vector3_2.float_0 = (double) plane_0.Normal.float_0 >= 0.0 ? this.Max.float_0 : this.Min.float_0;
      vector3_2.float_1 = (double) plane_0.Normal.float_1 >= 0.0 ? this.Max.float_1 : this.Min.float_1;
      vector3_2.float_2 = (double) plane_0.Normal.float_2 >= 0.0 ? this.Max.float_2 : this.Min.float_2;
      if ((double) plane_0.Normal.float_0 * (double) vector3_1.float_0 + (double) plane_0.Normal.float_1 * (double) vector3_1.float_1 + (double) plane_0.Normal.float_2 * (double) vector3_1.float_2 + (double) plane_0.float_0 > 0.0)
        return (GEnum97) 0;
      return (double) plane_0.Normal.float_0 * (double) vector3_2.float_0 + (double) plane_0.Normal.float_1 * (double) vector3_2.float_1 + (double) plane_0.Normal.float_2 * (double) vector3_2.float_2 + (double) plane_0.float_0 < 0.0 ? (GEnum97) 1 : (GEnum97) 2;
    }

    public void method_5(ref Plane plane_0, out GEnum97 genum97_0)
    {
      Vector3 vector3_1;
      vector3_1.float_0 = (double) plane_0.Normal.float_0 >= 0.0 ? this.Min.float_0 : this.Max.float_0;
      vector3_1.float_1 = (double) plane_0.Normal.float_1 >= 0.0 ? this.Min.float_1 : this.Max.float_1;
      vector3_1.float_2 = (double) plane_0.Normal.float_2 >= 0.0 ? this.Min.float_2 : this.Max.float_2;
      Vector3 vector3_2;
      vector3_2.float_0 = (double) plane_0.Normal.float_0 >= 0.0 ? this.Max.float_0 : this.Min.float_0;
      vector3_2.float_1 = (double) plane_0.Normal.float_1 >= 0.0 ? this.Max.float_1 : this.Min.float_1;
      vector3_2.float_2 = (double) plane_0.Normal.float_2 >= 0.0 ? this.Max.float_2 : this.Min.float_2;
      if ((double) plane_0.Normal.float_0 * (double) vector3_1.float_0 + (double) plane_0.Normal.float_1 * (double) vector3_1.float_1 + (double) plane_0.Normal.float_2 * (double) vector3_1.float_2 + (double) plane_0.float_0 > 0.0)
        genum97_0 = (GEnum97) 0;
      else if ((double) plane_0.Normal.float_0 * (double) vector3_2.float_0 + (double) plane_0.Normal.float_1 * (double) vector3_2.float_1 + (double) plane_0.Normal.float_2 * (double) vector3_2.float_2 + (double) plane_0.float_0 < 0.0)
        genum97_0 = (GEnum97) 1;
      else
        genum97_0 = (GEnum97) 2;
    }
  }
}
