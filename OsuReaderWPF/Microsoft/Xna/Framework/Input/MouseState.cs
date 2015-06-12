// Decompiled with JetBrains decompiler
// Type: Microsoft.Xna.Framework.Input.MouseState
// Assembly: osu!, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01B8D71D-E69E-4E8A-76A7-28C15896CF26
// Assembly location: D:\Downloads\Decompiled osu\osu!-cleaned.exe

using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Xna.Framework.Input
{
  [ComVisible(false)]
  [Serializable]
  public struct MouseState
  {
    internal int int_0;
    internal int int_1;
    internal ButtonState left;
    internal ButtonState right;
    internal ButtonState middle;
    internal ButtonState xb1;
    internal ButtonState xb2;
    internal int wheel;

    public int ScrollWheelValue
    {
      get
      {
        return this.wheel;
      }
    }

    public ButtonState XButton2
    {
      get
      {
        return this.xb2;
      }
    }

    public ButtonState XButton1
    {
      get
      {
        return this.xb1;
      }
    }

    public ButtonState MiddleButton
    {
      get
      {
        return this.middle;
      }
    }

    public ButtonState RightButton
    {
      get
      {
        return this.right;
      }
    }

    public ButtonState LeftButton
    {
      get
      {
        return this.left;
      }
    }

    public int Int32_0
    {
      get
      {
        return this.int_1;
      }
    }

    public int Int32_1
    {
      get
      {
        return this.int_0;
      }
    }

    public static unsafe bool operator ==(MouseState left, MouseState right)
    {
      uint num1 = (uint) sizeof (MouseState);
      MouseState* mouseStatePtr1 = &right;
      MouseState* mouseStatePtr2 = &left;
      int num2;
      if ((int) num1 != 0)
      {
        sbyte num3 = *(sbyte*) mouseStatePtr2;
        sbyte num4 = *(sbyte*) mouseStatePtr1;
        if ((int) num3 >= (int) num4)
        {
          while ((int) num3 <= (int) num4)
          {
            if ((int) num1 != 1)
            {
              --num1;
              mouseStatePtr2 += 1 / sizeof (MouseState);
              mouseStatePtr1 += 1 / sizeof (MouseState);
              num3 = *(sbyte*) mouseStatePtr2;
              num4 = *(sbyte*) mouseStatePtr1;
              if ((int) num3 < (int) num4)
                break;
            }
            else
              goto label_6;
          }
        }
        num2 = 0;
        goto label_7;
      }
label_6:
      num2 = 1;
label_7:
      return (int) (byte) num2 != 0;
    }

    public static bool operator !=(MouseState left, MouseState right)
    {
      return (!(left == right) ? 1 : 0) != 0;
    }

    public override string ToString()
    {
      string str1 = string.Empty;
      if (this.left == ButtonState.Pressed)
      {
        string str2 = str1.Length == 0 ? string.Empty : " ";
        str1 = str1 + str2 + "Left";
      }
      if (this.right == ButtonState.Pressed)
      {
        string str2 = str1.Length == 0 ? string.Empty : " ";
        str1 = str1 + str2 + "Right";
      }
      if (this.middle == ButtonState.Pressed)
      {
        string str2 = str1.Length == 0 ? string.Empty : " ";
        str1 = str1 + str2 + "Middle";
      }
      if (this.xb1 == ButtonState.Pressed)
      {
        string str2 = str1.Length == 0 ? string.Empty : " ";
        str1 = str1 + str2 + "XButton1";
      }
      if (this.xb2 == ButtonState.Pressed)
      {
        string str2 = str1.Length == 0 ? string.Empty : " ";
        str1 = str1 + str2 + "XButton2";
      }
      if (str1.Length == 0)
        str1 = "None";
      return string.Format((IFormatProvider) CultureInfo.CurrentCulture, "{{X:{0} Y:{1} Buttons:{2} Wheel:{3}}}", (object) this.int_0, (object) this.int_1, (object) str1, (object) this.wheel);
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public override bool Equals(object obj)
    {
      if (obj == null || obj.GetType() != typeof (MouseState))
        return false;
      return this == (MouseState) obj;
    }
  }
}
