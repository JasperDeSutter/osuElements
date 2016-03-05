using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using osuElements.Helpers;
using osuElements.Repositories;
using osuElements.Repositories.File;
using static osuElements.Helpers.Constants;

namespace osuElements.Replays
{
    public class ReplayFileRepository : IFileRepository<Replay>
    {
        public void ReadFile(Stream stream, Replay result, ILogger logger = null) {
            using (var binaryReader = new BinaryReader(stream)) {
                result.GameMode = (GameMode)binaryReader.ReadByte();
                result.OsuVersion = binaryReader.ReadInt32();
                binaryReader.ReadByte();
                result.BeatmapHash = binaryReader.ReadString();
                binaryReader.ReadByte();
                result.UserName = binaryReader.ReadString();
                binaryReader.ReadByte();
                result.ReplayHash = binaryReader.ReadString();
                result.Count300 = binaryReader.ReadInt16();
                result.Count100 = binaryReader.ReadInt16();
                result.Count50 = binaryReader.ReadInt16();
                result.CountGeki = binaryReader.ReadInt16();
                result.CountKatu = binaryReader.ReadInt16();
                result.CountMiss = binaryReader.ReadInt16();
                result.Score = binaryReader.ReadInt32();
                result.MaxCombo = binaryReader.ReadInt16();
                result.IsPerfect = binaryReader.ReadInt16() == 1;
                result.Enabled_Mods = (Mods)binaryReader.ReadInt32();

                binaryReader.ReadByte();
                string lifebarFrames = binaryReader.ReadString();
                var parts = lifebarFrames.Split(Splitter.Comma, StringSplitOptions.RemoveEmptyEntries);
                foreach (var parts2 in parts.Select(part => part.Split(Splitter.Pipe, StringSplitOptions.RemoveEmptyEntries))) {
                    if (parts2.Length < 2) continue;
                    result.LifebarFames.Add(new LifebarFrame() {
                        Time = int.Parse(parts2[0]),
                        Life = float.Parse(parts2[1], IO.CULTUREINFO)
                    });
                }

                result.TimeStamp = binaryReader.ReadInt64();
                //result.Date = new DateTime(result.TimeStamp, DateTimeKind.Utc);
                result.DataLength = binaryReader.ReadInt32();
                if (result.DataLength <= 0) return;

                var list = new List<byte>();
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length) {
                    list.Add(binaryReader.ReadByte());
                }
                ReadReplayCompressedData(list.ToArray(), result);
            }
        }

        public static void ReadReplayCompressedData(byte[] inStream, Replay result) {
            ReadReplayCompressedData(new MemoryStream(osuElements.DecompressLzmaFunc(inStream)), result);
        }

        public static void ReadReplayCompressedData(Stream compressedData, Replay result) {
            using (var sr = new StreamReader(compressedData)) {
                foreach (var parts in sr.ReadToEnd().Split(',').    //split resulting string in parts
                    Where(frame => !string.IsNullOrEmpty(frame)).   //check for null
                    Select(frame => frame.Split(Splitter.Pipe)).    //split the part into actual variables (into string[])
                    Where(parts => parts.Length >= 4))              //check for correct length of the string[]
                {

                    if (parts[0] == "-12345") {
                        result.Seed = int.Parse(parts[3]);
                        continue;
                    }

                    var lastTime = result.ReplayFrames.Count > 0 ? result.ReplayFrames.Last().Time : 0;
                    int offset = int.Parse(parts[0]);
                    result.ReplayFrames.Add(new ReplayFrame() {
                        TimeOffset = offset,
                        Time = lastTime + offset,
                        Position = Position.FromHitobject(float.Parse(parts[1], IO.CULTUREINFO),
                            float.Parse(parts[2], IO.CULTUREINFO)),
                        Key = (ReplayKey)Enum.Parse(typeof(ReplayKey), parts[3])
                    });
                }
            }
        }

        public void WriteFile(Stream path, Replay t) {
            throw new NotImplementedException();
        }
    }
}
