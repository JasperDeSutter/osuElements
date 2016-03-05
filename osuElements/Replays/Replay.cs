using System;
using System.Collections.Generic;
using System.IO;
using osuElements.Api;
using osuElements.Helpers;
using osuElements.Repositories;

namespace osuElements.Replays
{
    public class Replay : ApiScore //most properties are shared, no need for common base class
    {
        public static IFileRepository<Replay> ReplayFileRepository { get; set; }

        public Replay()
        {
            LifebarFames = new List<LifebarFrame>();
            ReplayFrames = new List<ReplayFrame>();
            ReplayFileRepository = osuElements.ReplayFileRepository;
        }
        public Replay(string fileName):this()
        {
            FileName = fileName;
            ReplayFileRepository.ReadFile(osuElements.FileReaderFunc(fileName), this);
        }
        /// <summary>
        /// Generate the replay data from api calls
        /// </summary>
        /// <param name="score">score object for general properties</param>
        /// <param name="replay">replay object for the compressed replay data</param>
        public Replay(ApiScore score, ApiReplay replay):this()
        {
            score.CloneTo(this);
            var bytes = Convert.FromBase64String(replay.Content);
            DataLength = bytes.Length;
            Replays.ReplayFileRepository.ReadReplayCompressedData(bytes, this);
            OsuVersion = 0; //?
            BeatmapHash = "";// use api-call for this
            ReplayHash = "";//?
            Seed = 0;//?

        }

        public string FileName { get; set; }
        public int OsuVersion { get; set; }
        public string BeatmapHash { get; set; }
        public string ReplayHash { get; set; }
        //public string LifeBarGraphString => LifebarFames.Aggregate("", (current, l) => current + (l + ",")).TrimEnd(',');

        public List<LifebarFrame> LifebarFames { get; }
        public long TimeStamp
        {
            get { return Date.Ticks; }
            set { Date = new DateTime(value, DateTimeKind.Utc); }
        }
        public int DataLength { get; set; }
        public List<ReplayFrame> ReplayFrames { get; private set; }
        public int Seed { get; set; }
    }
}
