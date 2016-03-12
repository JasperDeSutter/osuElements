using System.IO;

namespace osuElements.IO.Binary
{
    public static class BinaryExtensions
    {
        public static string ReadNullableString(this BinaryReader br) {
            return br.ReadByte() == 0 ? null : br.ReadString();
        }

        public static byte[] ReadByteArray(this BinaryReader br) {
            var b = br.ReadInt32();
            return b < 0 ? null : br.ReadBytes(b);
        }

        public static void WriteNullableString(this BinaryWriter bw, string value) {
            if (value == null)
                bw.Write((byte)0);
            else {
                bw.Write((byte)11);
                bw.Write(value);
            }
        }
        public static void WriteByteArray(this BinaryWriter bw, byte[] value) {
            if (value == null)
                bw.Write(-1);
            else {
                bw.Write(value.Length);
                bw.Write(value);
            }
        }
    }
}