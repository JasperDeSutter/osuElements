using System;
using System.Collections.Generic;
using System.Linq;
using osuElements.Api;
using osuElements.Helpers;
using osuElements.Repositories;

namespace osuElements.Replays
{
    public class Replay : Score
    {
        public static IFileRepository<Replay> ReplayFileRepository { private get; set; }
        public Replay(string fileName) {
            LifebarFames = new List<LifebarFrame>();
            ReplayFrames = new List<ReplayFrame>();
            FileName = fileName;
            ReplayFileRepository.ReadFile(fileName, this);
        }

        public string FileName { get; private set; }

        public GameMode GameMode { get; set; }
        public int FileFormat { get; set; }
        public string BeatmapHash { get; set; }
        //public string UserName { get; set; }
        public string ReplayHash { get; set; }
        //public short Count300 { get; set; }
        //public short Count100 { get; set; }
        //public short Count50 { get; set; }
        //public short CountGeki { get; set; }
        //public short CountKatu { get; set; }
        //public short CountMiss { get; set; }
        public long TotalScore { get; set; }
        //public short MaxCombo { get; set; }
        //public bool IsPerfect { get; set; } //no misses
        //public Mod Enabled_Mods { get; set; }
        public string LifeBarGraphString => LifebarFames.Aggregate("", (current, l) => current + (l + ",")).TrimEnd(',');

        public List<LifebarFrame> LifebarFames { get; }
        public long TimeStamp { get; set; }
        //public DateTime Date => new DateTime(TimeStamp, DateTimeKind.Utc);
        public int DataLength { get; set; }
        public List<ReplayFrame> ReplayFrames { get; private set; }
        public int Seed { get; set; }
    }
}
