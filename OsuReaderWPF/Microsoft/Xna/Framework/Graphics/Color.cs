// Decompiled with JetBrains decompiler
// Type: Microsoft.Xna.Framework.Graphics.Color
// Assembly: osu!, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01B8D71D-E69E-4E8A-76A7-28C15896CF26
// Assembly location: D:\Downloads\Decompiled osu\osu!-cleaned.exe

using Microsoft.Xna.Framework;
using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Xna.Framework.Graphics
{
  [ComVisible(false)]
  public struct Color : IEquatable<Color>
  {
    public byte byte_0;
    public byte byte_1;
    public byte byte_2;
    public byte byte_3;

    public static Color TransparentBlack
    {
      get
      {
        return new Color(0U);
      }
    }

    public static Color TransparentWhite
    {
      get
      {
        return new Color(16777215U);
      }
    }

    public static Color AliceBlue
    {
      get
      {
        return new Color(4293982463U);
      }
    }

    public static Color AntiqueWhite
    {
      get
      {
        return new Color(4294634455U);
      }
    }

    public static Color Aqua
    {
      get
      {
        return new Color(4278255615U);
      }
    }

    public static Color Aquamarine
    {
      get
      {
        return new Color(4286578644U);
      }
    }

    public static Color Azure
    {
      get
      {
        return new Color(4293984255U);
      }
    }

    public static Color Beige
    {
      get
      {
        return new Color(4294309340U);
      }
    }

    public static Color Bisque
    {
      get
      {
        return new Color(4294960324U);
      }
    }

    public static Color Black
    {
      get
      {
        return new Color(4278190080U);
      }
    }

    public static Color BlanchedAlmond
    {
      get
      {
        return new Color(4294962125U);
      }
    }

    public static Color Blue
    {
      get
      {
        return new Color(4278190335U);
      }
    }

    public static Color BlueViolet
    {
      get
      {
        return new Color(4287245282U);
      }
    }

    public static Color Brown
    {
      get
      {
        return new Color(4289014314U);
      }
    }

    public static Color BurlyWood
    {
      get
      {
        return new Color(4292786311U);
      }
    }

    public static Color CadetBlue
    {
      get
      {
        return new Color(4284456608U);
      }
    }

    public static Color Chartreuse
    {
      get
      {
        return new Color(4286578432U);
      }
    }

    public static Color Chocolate
    {
      get
      {
        return new Color(4291979550U);
      }
    }

    public static Color Coral
    {
      get
      {
        return new Color(4294934352U);
      }
    }

    public static Color CornflowerBlue
    {
      get
      {
        return new Color(4284782061U);
      }
    }

    public static Color Cornsilk
    {
      get
      {
        return new Color(4294965468U);
      }
    }

    public static Color Crimson
    {
      get
      {
        return new Color(4292613180U);
      }
    }

    public static Color Cyan
    {
      get
      {
        return new Color(4278255615U);
      }
    }

    public static Color DarkBlue
    {
      get
      {
        return new Color(4278190219U);
      }
    }

    public static Color DarkCyan
    {
      get
      {
        return new Color(4278225803U);
      }
    }

    public static Color DarkGoldenrod
    {
      get
      {
        return new Color(4290283019U);
      }
    }

    public static Color DarkGray
    {
      get
      {
        return new Color(4289309097U);
      }
    }

    public static Color DarkGreen
    {
      get
      {
        return new Color(4278215680U);
      }
    }

    public static Color DarkKhaki
    {
      get
      {
        return new Color(4290623339U);
      }
    }

    public static Color DarkMagenta
    {
      get
      {
        return new Color(4287299723U);
      }
    }

    public static Color DarkOliveGreen
    {
      get
      {
        return new Color(4283788079U);
      }
    }

    public static Color DarkOrange
    {
      get
      {
        return new Color(4294937600U);
      }
    }

    public static Color DarkOrchid
    {
      get
      {
        return new Color(4288230092U);
      }
    }

    public static Color DarkRed
    {
      get
      {
        return new Color(4287299584U);
      }
    }

    public static Color DarkSalmon
    {
      get
      {
        return new Color(4293498490U);
      }
    }

    public static Color DarkSeaGreen
    {
      get
      {
        return new Color(4287609995U);
      }
    }

    public static Color DarkSlateBlue
    {
      get
      {
        return new Color(4282924427U);
      }
    }

    public static Color DarkSlateGray
    {
      get
      {
        return new Color(4281290575U);
      }
    }

    public static Color DarkTurquoise
    {
      get
      {
        return new Color(4278243025U);
      }
    }

    public static Color DarkViolet
    {
      get
      {
        return new Color(4287889619U);
      }
    }

    public static Color DeepPink
    {
      get
      {
        return new Color(4294907027U);
      }
    }

    public static Color DeepSkyBlue
    {
      get
      {
        return new Color(4278239231U);
      }
    }

    public static Color DimGray
    {
      get
      {
        return new Color(4285098345U);
      }
    }

    public static Color DodgerBlue
    {
      get
      {
        return new Color(4280193279U);
      }
    }

    public static Color Firebrick
    {
      get
      {
        return new Color(4289864226U);
      }
    }

    public static Color FloralWhite
    {
      get
      {
        return new Color(4294966000U);
      }
    }

    public static Color ForestGreen
    {
      get
      {
        return new Color(4280453922U);
      }
    }

    public static Color Fuchsia
    {
      get
      {
        return new Color(4294902015U);
      }
    }

    public static Color Gainsboro
    {
      get
      {
        return new Color(4292664540U);
      }
    }

    public static Color GhostWhite
    {
      get
      {
        return new Color(4294506751U);
      }
    }

    public static Color Gold
    {
      get
      {
        return new Color(4294956800U);
      }
    }

    public static Color Goldenrod
    {
      get
      {
        return new Color(4292519200U);
      }
    }

    public static Color Gray
    {
      get
      {
        return new Color(4286611584U);
      }
    }

    public static Color Green
    {
      get
      {
        return new Color(4278222848U);
      }
    }

    public static Color GreenYellow
    {
      get
      {
        return new Color(4289593135U);
      }
    }

    public static Color Honeydew
    {
      get
      {
        return new Color(4293984240U);
      }
    }

    public static Color HotPink
    {
      get
      {
        return new Color(4294928820U);
      }
    }

    public static Color IndianRed
    {
      get
      {
        return new Color(4291648604U);
      }
    }

    public static Color Indigo
    {
      get
      {
        return new Color(4283105410U);
      }
    }

    public static Color Ivory
    {
      get
      {
        return new Color(4294967280U);
      }
    }

    public static Color Khaki
    {
      get
      {
        return new Color(4293977740U);
      }
    }

    public static Color Lavender
    {
      get
      {
        return new Color(4293322490U);
      }
    }

    public static Color LavenderBlush
    {
      get
      {
        return new Color(4294963445U);
      }
    }

    public static Color LawnGreen
    {
      get
      {
        return new Color(4286381056U);
      }
    }

    public static Color LemonChiffon
    {
      get
      {
        return new Color(4294965965U);
      }
    }

    public static Color LightBlue
    {
      get
      {
        return new Color(4289583334U);
      }
    }

    public static Color LightCoral
    {
      get
      {
        return new Color(4293951616U);
      }
    }

    public static Color LightCyan
    {
      get
      {
        return new Color(4292935679U);
      }
    }

    public static Color LightGoldenrodYellow
    {
      get
      {
        return new Color(4294638290U);
      }
    }

    public static Color LightGreen
    {
      get
      {
        return new Color(4287688336U);
      }
    }

    public static Color LightGray
    {
      get
      {
        return new Color(4292072403U);
      }
    }

    public static Color LightPink
    {
      get
      {
        return new Color(4294948545U);
      }
    }

    public static Color LightSalmon
    {
      get
      {
        return new Color(4294942842U);
      }
    }

    public static Color LightSeaGreen
    {
      get
      {
        return new Color(4280332970U);
      }
    }

    public static Color LightSkyBlue
    {
      get
      {
        return new Color(4287090426U);
      }
    }

    public static Color LightSlateGray
    {
      get
      {
        return new Color(4286023833U);
      }
    }

    public static Color LightSteelBlue
    {
      get
      {
        return new Color(4289774814U);
      }
    }

    public static Color LightYellow
    {
      get
      {
        return new Color(4294967264U);
      }
    }

    public static Color Lime
    {
      get
      {
        return new Color(4278255360U);
      }
    }

    public static Color LimeGreen
    {
      get
      {
        return new Color(4281519410U);
      }
    }

    public static Color Linen
    {
      get
      {
        return new Color(4294635750U);
      }
    }

    public static Color Magenta
    {
      get
      {
        return new Color(4294902015U);
      }
    }

    public static Color Maroon
    {
      get
      {
        return new Color(4286578688U);
      }
    }

    public static Color MediumAquamarine
    {
      get
      {
        return new Color(4284927402U);
      }
    }

    public static Color MediumBlue
    {
      get
      {
        return new Color(4278190285U);
      }
    }

    public static Color MediumOrchid
    {
      get
      {
        return new Color(4290401747U);
      }
    }

    public static Color MediumPurple
    {
      get
      {
        return new Color(4287852763U);
      }
    }

    public static Color MediumSeaGreen
    {
      get
      {
        return new Color(4282168177U);
      }
    }

    public static Color MediumSlateBlue
    {
      get
      {
        return new Color(4286277870U);
      }
    }

    public static Color MediumSpringGreen
    {
      get
      {
        return new Color(4278254234U);
      }
    }

    public static Color MediumTurquoise
    {
      get
      {
        return new Color(4282962380U);
      }
    }

    public static Color MediumVioletRed
    {
      get
      {
        return new Color(4291237253U);
      }
    }

    public static Color MidnightBlue
    {
      get
      {
        return new Color(4279834992U);
      }
    }

    public static Color MintCream
    {
      get
      {
        return new Color(4294311930U);
      }
    }

    public static Color MistyRose
    {
      get
      {
        return new Color(4294960353U);
      }
    }

    public static Color Moccasin
    {
      get
      {
        return new Color(4294960309U);
      }
    }

    public static Color NavajoWhite
    {
      get
      {
        return new Color(4294958765U);
      }
    }

    public static Color Navy
    {
      get
      {
        return new Color(4278190208U);
      }
    }

    public static Color OldLace
    {
      get
      {
        return new Color(4294833638U);
      }
    }

    public static Color Olive
    {
      get
      {
        return new Color(4286611456U);
      }
    }

    public static Color OliveDrab
    {
      get
      {
        return new Color(4285238819U);
      }
    }

    public static Color Orange
    {
      get
      {
        return new Color(4294944000U);
      }
    }

    public static Color OrangeRed
    {
      get
      {
        return new Color(4294919424U);
      }
    }

    public static Color Orchid
    {
      get
      {
        return new Color(4292505814U);
      }
    }

    public static Color PaleGoldenrod
    {
      get
      {
        return new Color(4293847210U);
      }
    }

    public static Color PaleGreen
    {
      get
      {
        return new Color(4288215960U);
      }
    }

    public static Color PaleTurquoise
    {
      get
      {
        return new Color(4289720046U);
      }
    }

    public static Color PaleVioletRed
    {
      get
      {
        return new Color(4292571283U);
      }
    }

    public static Color PapayaWhip
    {
      get
      {
        return new Color(4294963157U);
      }
    }

    public static Color PeachPuff
    {
      get
      {
        return new Color(4294957753U);
      }
    }

    public static Color Peru
    {
      get
      {
        return new Color(4291659071U);
      }
    }

    public static Color Pink
    {
      get
      {
        return new Color(4294951115U);
      }
    }

    public static Color Plum
    {
      get
      {
        return new Color(4292714717U);
      }
    }

    public static Color PowderBlue
    {
      get
      {
        return new Color(4289781990U);
      }
    }

    public static Color Purple
    {
      get
      {
        return new Color(4286578816U);
      }
    }

    public static Color Red
    {
      get
      {
        return new Color(4294901760U);
      }
    }

    public static Color RosyBrown
    {
      get
      {
        return new Color(4290547599U);
      }
    }

    public static Color RoyalBlue
    {
      get
      {
        return new Color(4282477025U);
      }
    }

    public static Color SaddleBrown
    {
      get
      {
        return new Color(4287317267U);
      }
    }

    public static Color Salmon
    {
      get
      {
        return new Color(4294606962U);
      }
    }

    public static Color SandyBrown
    {
      get
      {
        return new Color(4294222944U);
      }
    }

    public static Color SeaGreen
    {
      get
      {
        return new Color(4281240407U);
      }
    }

    public static Color SeaShell
    {
      get
      {
        return new Color(4294964718U);
      }
    }

    public static Color Sienna
    {
      get
      {
        return new Color(4288696877U);
      }
    }

    public static Color Silver
    {
      get
      {
        return new Color(4290822336U);
      }
    }

    public static Color SkyBlue
    {
      get
      {
        return new Color(4287090411U);
      }
    }

    public static Color SlateBlue
    {
      get
      {
        return new Color(4285160141U);
      }
    }

    public static Color SlateGray
    {
      get
      {
        return new Color(4285563024U);
      }
    }

    public static Color Snow
    {
      get
      {
        return new Color(4294966010U);
      }
    }

    public static Color SpringGreen
    {
      get
      {
        return new Color(4278255487U);
      }
    }

    public static Color SteelBlue
    {
      get
      {
        return new Color(4282811060U);
      }
    }

    public static Color Tan
    {
      get
      {
        return new Color(4291998860U);
      }
    }

    public static Color Teal
    {
      get
      {
        return new Color(4278222976U);
      }
    }

    public static Color Thistle
    {
      get
      {
        return new Color(4292394968U);
      }
    }

    public static Color Tomato
    {
      get
      {
        return new Color(4294927175U);
      }
    }

    public static Color Turquoise
    {
      get
      {
        return new Color(4282441936U);
      }
    }

    public static Color Violet
    {
      get
      {
        return new Color(4293821166U);
      }
    }

    public static Color Wheat
    {
      get
      {
        return new Color(4294303411U);
      }
    }

    public static Color White
    {
      get
      {
        return new Color(uint.MaxValue);
      }
    }

    public static Color WhiteSmoke
    {
      get
      {
        return new Color(4294309365U);
      }
    }

    public static Color Yellow
    {
      get
      {
        return new Color(4294967040U);
      }
    }

    public static Color YellowGreen
    {
      get
      {
        return new Color(4288335154U);
      }
    }

    private Color(uint uint_0)
    {
      this.byte_0 = (byte) (uint_0 >> 16);
      this.byte_1 = (byte) (uint_0 >> 8);
      this.byte_2 = (byte) uint_0;
      this.byte_3 = (byte) (uint_0 >> 24);
    }

    public Color(byte byte_4, byte byte_5, byte byte_6)
    {
      this.byte_0 = byte_4;
      this.byte_1 = byte_5;
      this.byte_2 = byte_6;
      this.byte_3 = byte.MaxValue;
    }

    public Color(byte byte_4, byte byte_5, byte byte_6, byte byte_7)
    {
      this.byte_0 = byte_4;
      this.byte_1 = byte_5;
      this.byte_2 = byte_6;
      this.byte_3 = byte_7;
    }

    public Color(Vector3 vector)
    {
      this.byte_0 = (byte) ((double) vector.float_0 * (double) byte.MaxValue);
      this.byte_1 = (byte) ((double) vector.float_1 * (double) byte.MaxValue);
      this.byte_2 = (byte) ((double) vector.float_2 * (double) byte.MaxValue);
      this.byte_3 = byte.MaxValue;
    }

    public Color(Vector4 vector)
    {
      this.byte_0 = (byte) ((double) vector.float_0 * (double) byte.MaxValue);
      this.byte_1 = (byte) ((double) vector.float_1 * (double) byte.MaxValue);
      this.byte_2 = (byte) ((double) vector.float_2 * (double) byte.MaxValue);
      this.byte_3 = (byte) ((double) vector.float_3 * (double) byte.MaxValue);
    }

    public static bool operator ==(Color color_0, Color color_1)
    {
      return color_0.Equals(color_1);
    }

    public static bool operator !=(Color color_0, Color color_1)
    {
      return !color_0.Equals(color_1);
    }

    public override string ToString()
    {
      return string.Format((IFormatProvider) CultureInfo.CurrentCulture, "{{R:{0} G:{1} B:{2} A:{3}}}", (object) this.byte_0, (object) this.byte_1, (object) this.byte_2, (object) this.byte_3);
    }

    public override bool Equals(object obj)
    {
      if (obj is Color)
        return this.Equals((Color) obj);
      return false;
    }

    public bool Equals(Color other)
    {
      if ((int) this.byte_0 == (int) other.byte_0 && (int) this.byte_1 == (int) other.byte_1 && (int) this.byte_2 == (int) other.byte_2)
        return (int) this.byte_3 == (int) other.byte_3;
      return false;
    }
  }
}
