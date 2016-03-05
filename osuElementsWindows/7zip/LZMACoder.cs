using System;
using System.IO;
using osuElements.Net._7zip.Compress.LZMA;

namespace osuElements.Net._7zip
{
    //Class is from smoogipooo
    public class LzmaCoder
    {
        public static MemoryStream Compress(Stream inStream) {
            inStream.Position = 0;

            CoderPropID[] propIDs =
            {
                CoderPropID.DictionarySize,
                CoderPropID.PosStateBits,
                CoderPropID.LitContextBits,
                CoderPropID.LitPosBits,
                CoderPropID.Algorithm,
            };

            object[] properties =
            {
                (1 << 16),
                2,
                3,
                0,
                2,
            };

            var outStream = new MemoryStream();
            var encoder = new Encoder();
            encoder.SetCoderProperties(propIDs, properties);
            encoder.WriteCoderProperties(outStream);
            for (var i = 0; i < 8; i++)
                outStream.WriteByte((byte)(inStream.Length >> (8 * i)));
            encoder.Code(inStream, outStream, -1, -1, null);
            outStream.Flush();
            outStream.Position = 0;

            return outStream;
        }

        public static void Decompress(Stream inStream, Stream outStream) {
            var decoder = new Decoder();
            inStream.Seek(0L, SeekOrigin.Begin);

            var properties = new byte[5];
            if (inStream.Read(properties, 0, 5) != 5)
                throw (new Exception("input .lzma is too short"));

            long outSize = 0;
            for (var i = 0; i < 8; i++) {
                var v = inStream.ReadByte();
                if (v < 0)
                    break;
                outSize |= (long)v << 8 * i;
            }
            var compressedSize = inStream.Length - inStream.Position;
            decoder.SetDecoderProperties(properties);

            decoder.Code(inStream, outStream, compressedSize, outSize, null);
            outStream.Flush();
            outStream.Position = 0;
        }

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