using System.Collections.Immutable;
using System.IO;
using osuElements.Net._7zip;
using ManagedLzma.LZMA;
namespace osuElements
{
    public static class osuElementsDotNet
    {
        public static void Init() {
            osuElements.FileReaderFunc = s => new FileStream(s, FileMode.Open, FileAccess.Read, FileShare.Read);
            osuElements.FileWriterFunc = s => { if (File.Exists(s)) File.Delete(s); return new FileStream(s, FileMode.Create); };
            osuElements.DecompressLzmaAction = LzmaCoder.Decompress;
            osuElements.DecompressLzmaFunc = LZMADecode;
            osuURL.OsuAction = s => System.Diagnostics.Process.Start(s);
        }
        static byte[] LZMADecode(byte[] inStream) {
            var a = new Decoder(DecoderSettings.ReadFrom(inStream, 0));
            a.Decode(inStream, 0, inStream.Length, null, true);
            byte[] outStream = new byte[a.AvailableOutputLength];
            a.ReadOutputData(outStream, 0, a.AvailableOutputLength);
            return outStream;
        }
    }
}