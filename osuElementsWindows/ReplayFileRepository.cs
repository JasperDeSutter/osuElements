using System;
using System.IO;
using System.Linq;
using osuElements;
using osuElements.Helpers;
using osuElements.Replays;
using osuElements.Repositories;
using osuElementsWindows._7zip;

namespace osuElementsWindows
{
    public class ReplayFileRepository:IFileRepository<Replay>
    {
        public void ReadFile(string file, Replay result) {
            if (!File.Exists(file)) return;
            using (var binaryReader = new BinaryReader(new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))) {
                result.GameMode = (GameMode)Enum.Parse(typeof(GameMode), binaryReader.ReadByte().ToString());
                result.FileFormat = binaryReader.ReadInt32();
                binaryReader.ReadByte();
                result.BeatmapHash = binaryReader.ReadString();
                binaryReader.ReadByte();
                result.PlayerName = binaryReader.ReadString();
                binaryReader.ReadByte();
                result.ReplayHash = binaryReader.ReadString();
                result.Count300 = binaryReader.ReadInt16();
                result.Count100 = binaryReader.ReadInt16();
                result.Count50 = binaryReader.ReadInt16();
                result.CountGeki = binaryReader.ReadInt16();
                result.CountKatu = binaryReader.ReadInt16();
                result.CountMiss = binaryReader.ReadInt16();
                result.TotalScore = binaryReader.ReadInt32();
                result.GreatestCombo = binaryReader.ReadInt16();
                result.IsPerfect = binaryReader.ReadBoolean();
                result.Mods = (Mod)binaryReader.ReadInt32();

                binaryReader.ReadByte();
                string lifebarFrames = binaryReader.ReadString();
                var parts = lifebarFrames.Split(Splitter.Comma, StringSplitOptions.RemoveEmptyEntries);
                foreach (var parts2 in parts.Select(part => part.Split(Splitter.Pipe, StringSplitOptions.RemoveEmptyEntries))) {
                    result.LifebarFames.Add(new LifebarFrame()
                    {
                        Time = int.Parse(parts2[0]),
                        Life = float.Parse(parts2[1], Constants.Io.CULTUREINFO)
                    });
                }

                result.TimeStamp = binaryReader.ReadInt64();
                result.DataLength = binaryReader.ReadInt32();
                if (result.DataLength <= 0) return;
                var codedStream = LzmaCoder.Decompress(binaryReader.BaseStream as FileStream);
                using (var sr = new StreamReader(codedStream)) {
                    foreach (var parts3 in sr.ReadToEnd().Split(',').
                        Where(frame => !string.IsNullOrEmpty(frame)).
                        Select(frame => frame.Split(Splitter.Pipe)).
                        Where(parts3 => parts3.Length >= 4)) {

                        if (parts3[0] == "-12345") {
                            result.Seed = int.Parse(parts3[3]);
                            continue;
                        }

                        var lastTime = result.ReplayFrames.Count > 0 ? result.ReplayFrames.Last().Time : 0;
                        int offset = int.Parse(parts3[0]);
                        result.ReplayFrames.Add(new ReplayFrame()
                        {
                            TimeOffset = offset,
                            Time = lastTime + offset,
                            Position = Position.FromHitobject(float.Parse(parts3[1], Constants.Io.CULTUREINFO),
                            float.Parse(parts3[2], Constants.Io.CULTUREINFO)),
                            Key = (ReplayKey)Enum.Parse(typeof(ReplayKey), parts3[3])
                        });
                    }
                }
            }
        }

        public void WriteFile(string file, Replay t) {
            throw new NotImplementedException();
        }

        public string WriteToString(Replay t) {
            throw new NotImplementedException();
        }
    }
}
