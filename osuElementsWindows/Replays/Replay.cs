using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using osuElements.Api;
using osuElements.Helpers;
using osuElements.IO;
using osuElements.IO.Binary;
using osuElements.IO.File;
using osuElements._7zip;

namespace osuElements.Replays
{
    /// <summary>
    /// The file-driven approach of a user's score on a beatmap
    /// </summary>
    public class Replay : ApiScore, IFileModel //most properties are shared, no need for common base class
    {
        public Replay() {
            LifebarFrames = new List<LifebarFrame>();
            ReplayFrames = new List<ReplayFrame>();
            ReplayFileRepository = osuElements.ReplayFileRepository;
        }

        public Replay(string filePath, bool readData) : this() {
            FullPath = filePath;
            ReadFile();
            if (readData) ReadData();
            LifebarFrames =
                LifebarFrameString.Split(','.AsArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(part => part.Split('|'.AsArray(), StringSplitOptions.RemoveEmptyEntries))
                    .Where(parts2 => parts2.Length >= 2)
                    .Select(t => new LifebarFrame(int.Parse(t[0]), float.Parse(t[1], Constants.CULTUREINFO)))
                    .ToList();
        }

        /// <summary>
        /// Generate the replay data from api calls
        /// </summary>
        /// <param name="score">score object for general properties</param>
        /// <param name="replay">replay object for the compressed replay data</param>
        /// <param name="readData">uncomress and read the compressed replay data</param>
        public Replay(ApiScore score, ApiReplay replay, bool readData = true) : this() {
            score.CloneTo(this);
            ReplayData = Convert.FromBase64String(replay.Content.Replace("\\/", "/")); // doesn't work yet
            if (readData) ReadData();
            FileFormat = 0; //?
            BeatmapHash = ""; // use api-call for this
            //LifebarFrames aren't available
            ReplayHash = ""; //?
        }

        #region File
        public static IFileRepository<Replay> ReplayFileRepository { get; set; }

        public bool IsRead { get; private set; }
        public string Directory { get; set; }
        public string FileName { get; set; }
        public string FullPath
        {
            get
            {
                var result = Path.Combine(Directory, FileName);
                return Path.IsPathRooted(result) ? result : Path.Combine(osuElements.OsuReplaysDirectory, result);
            }
            set
            {
                Directory = Path.GetDirectoryName(value);
                FileName = Path.GetFileName(value);
            }
        }
        public void ReadFile(ILogger logger = null) {
            ReplayFileRepository.ReadFile(osuElements.ReadStream(FullPath), this, logger);
            IsRead = true;
        }
        public void WriteFile() {
            ReplayFileRepository.WriteFile(osuElements.WriteStream(FullPath), this);
        }
        #endregion


        public int FileFormat { get; set; }
        public string BeatmapHash { get; set; }
        public string ReplayHash { get; set; }
        public string LifebarFrameString { get; set; }
        public List<LifebarFrame> LifebarFrames { get; }
        public byte[] ReplayData { get; set; }
        public List<ReplayFrame> ReplayFrames { get; private set; }
        public int Seed { get; set; }//?
        public long SomeLong { get; set; }//?

        internal static object ReadSomeLong(BinaryReader reader, Replay replay) {
            if (replay.FileFormat > 20140720)
                return reader.ReadInt64();
            return reader.ReadInt32();
        }

        internal static void WriteSomeLong(BinaryWriter writer, Replay replay) {
            if (replay.FileFormat > 20140720)
                writer.Write(replay.SomeLong);
            if (replay.FileFormat > 20121007)
                writer.Write((int)replay.SomeLong);
        }

        public static BinaryFile<Replay> FileReader() {
            return new BinaryFile<Replay>(HeaderFileLines());
        }


        internal static IBinaryFileLine<Replay>[] HeaderFileLines() {
            return new IBinaryFileLine<Replay>[]{
                new BinaryFileLine<Replay, GameMode>(r => r.GameMode){Type = typeof (byte)},
                new BinaryFileLine<Replay, int>(r => r.FileFormat),
                new BinaryFileLine<Replay, string>(r => r.BeatmapHash),
                new BinaryFileLine<Replay, string>(r => r.UserName),
                new BinaryFileLine<Replay, string>(r => r.ReplayHash),
                new BinaryFileLine<Replay, ushort>(r => r.Count300),
                new BinaryFileLine<Replay, ushort>(r => r.Count100),
                new BinaryFileLine<Replay, ushort>(r => r.Count50),
                new BinaryFileLine<Replay, ushort>(r => r.CountGeki),
                new BinaryFileLine<Replay, ushort>(r => r.CountKatu),
                new BinaryFileLine<Replay, ushort>(r => r.CountMiss),
                new BinaryFileLine<Replay, int>(r => r.Score),
                new BinaryFileLine<Replay, ushort>(r => r.MaxCombo),
                new BinaryFileLine<Replay, bool>(r => r.IsPerfect),
                new BinaryFileLine<Replay, Mods>(r => r.Enabled_Mods){Type = typeof (int)},
                new BinaryFileLine<Replay, string>(r => r.LifebarFrameString),
                new BinaryFileLine<Replay, DateTime>(r => r.Date),
                new BinaryFileLine<Replay, byte[]>(r => r.ReplayData),
                new BinaryFileLine<Replay, long>(r => r.SomeLong) { ReaderFunc = ReadSomeLong, WriterAction = WriteSomeLong }
            };
        }

        public void ReadData() {
            var uncompressed = LzmaCoder.Decompress(ReplayData);
            var a = new System.Text.UTF8Encoding().GetString(uncompressed, 0, uncompressed.Length);
            ReadReplayCompressedData(a);
        }

        private void ReadReplayCompressedData(string data) {
            int lasttime = 0;
            foreach (var parts in data.Split(','). //split resulting string in parts
                Where(frame => !string.IsNullOrEmpty(frame)). //check for null
                Select(frame => frame.Split('|'))
                . //split the part into actual variables (into string[])
                Where(parts => parts.Length >= 4)) {
                //check for correct length of the string[]

                if (parts[0] == "-12345") {
                    Seed = int.Parse(parts[3]);
                    continue;
                }

                int offset = int.Parse(parts[0]);
                lasttime += offset;
                ReplayFrames.Add(new ReplayFrame() {
                    TimeOffset = offset,
                    Time = lasttime,
                    Position = Position.FromHitobject(float.Parse(parts[1], Constants.CULTUREINFO),
                        float.Parse(parts[2], Constants.CULTUREINFO)),
                    Keys = (ReplayKeys)Enum.Parse(typeof(ReplayKeys), parts[3])
                });
            }
        }
    }
}