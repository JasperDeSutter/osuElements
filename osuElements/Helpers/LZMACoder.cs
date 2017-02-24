using System;
using System.IO;
using osuElements.Helpers.LZMA;

namespace osuElements.Helpers
{
    internal static class LzmaCoder
    {
        public static byte[] Decompress(byte[] inputBytes) {
            var memoryStream1 = new MemoryStream(inputBytes);
            var decoder = new Decoder();
            memoryStream1.Seek(0L, SeekOrigin.Begin);
            var memoryStream2 = new MemoryStream();
            var numArray = new byte[5];
            if (memoryStream1.Read(numArray, 0, 5) != 5)
                throw new Exception("input .lzma is too short");
            var outSize = 0L;
            for (var index = 0; index < 8; ++index) {
                var num = memoryStream1.ReadByte();
                if (num < 0)
                    throw new Exception("Can't Read 1");
                outSize |= (long)(byte)num << 8 * index;
            }
            decoder.SetDecoderProperties(numArray);
            var inSize = memoryStream1.Length - memoryStream1.Position;
            decoder.Code(memoryStream1, memoryStream2, inSize, outSize, null);
            return memoryStream2.ToArray();
        }
    }
}