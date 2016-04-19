using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using osuElements.Api;
using osuElements.Beatmaps;
using osuElements.Helpers;
using osuElements.IO.Binary;
using osuElements.IO.File;

namespace osuElements.Db
{
    public class OsuDb
    {
        public OsuDb() {
            Beatmaps = new List<DbBeatmap>();
        }
        public int FileVersion { get; set; }
        public int CollectionCount { get; set; }
        public string UserName { get; set; }
        public List<DbBeatmap> Beatmaps { get; set; }
        //unsure
        public int SomeInt { get; set; }
        public bool SomeBool { get; set; }
        public DateTime DateTime { get; set; }

        #region File
        public bool IsRead { get; private set; }
        public string Directory { get; set; } = osuElements.OsuDirectory;
        public string FileName { get; set; } = "osu!.db";
        public string FullPath
        {
            get { return Path.Combine(Directory, FileName); }
            set
            {
                Directory = Path.GetDirectoryName(value);
                FileName = Path.GetFileName(value);
            }
        }
        public void ReadFile(ILogger logger = null) {
            osuElements.OsuDbRepository.ReadFile(osuElements.ReadStream(FullPath), this, logger);
            IsRead = true;
        }

        public void WriteFile() {
            osuElements.OsuDbRepository.WriteFile(osuElements.WriteStream(FullPath), this);
        }
        public static BinaryFile<OsuDb> FileReader() {
            var result = new BinaryFile<OsuDb>(
                new BinaryFileLine<OsuDb, int>(s => s.FileVersion),
                new BinaryFileLine<OsuDb, int>(s => s.CollectionCount),
                new BinaryFileLine<OsuDb, bool>(s => s.SomeBool),
                new BinaryFileLine<OsuDb, DateTime>(s => s.DateTime),
                new BinaryFileLine<OsuDb, string>(s => s.UserName),
                new BinaryCollection<OsuDb, DbBeatmap>(s => s.Beatmaps,
                    new BinaryFileLine<DbBeatmap, int>(b => b.New),
                    new BinaryFileLine<DbBeatmap, string>(b => b.Artist),
                    new BinaryFileLine<DbBeatmap, string>(b => b.ArtistUnicode),
                    new BinaryFileLine<DbBeatmap, string>(b => b.Title),
                    new BinaryFileLine<DbBeatmap, string>(b => b.TitleUnicode),
                    new BinaryFileLine<DbBeatmap, string>(b => b.Creator),
                    new BinaryFileLine<DbBeatmap, string>(b => b.Version),
                    new BinaryFileLine<DbBeatmap, string>(b => b.AudioFilename),
                    new BinaryFileLine<DbBeatmap, string>(b => b.BeatmapHash),
                    new BinaryFileLine<DbBeatmap, string>(b => b.FileName),
                    new BinaryFileLine<DbBeatmap, DbBeatmapState>(b => b.DbBeatmapState) { Type = typeof(byte) },
                    new BinaryFileLine<DbBeatmap, ushort>(b => b.HitCircleAmount),
                    new BinaryFileLine<DbBeatmap, ushort>(b => b.SliderAmount),
                    new BinaryFileLine<DbBeatmap, ushort>(b => b.SpinnerAmount),
                    new BinaryFileLine<DbBeatmap, DateTime>(b => b.DownloadDate),
                    new BinaryFileLine<DbBeatmap, float>(b => b.DifficultyApproachRate),
                    new BinaryFileLine<DbBeatmap, float>(b => b.DifficultyCircleSize),
                    new BinaryFileLine<DbBeatmap, float>(b => b.DifficultyHpDrainRate),
                    new BinaryFileLine<DbBeatmap, float>(b => b.DifficultyOverall),
                    new BinaryFileLine<DbBeatmap, double>(b => b.DifficultySliderMultiplier),
                    new BinaryFileDictionary<DbBeatmap, Mods, double>(b => b.StandardDifficulties) {
                        KeyType = typeof(int)
                    },
                    new BinaryFileDictionary<DbBeatmap, Mods, double>(b => b.TaikoDifficulties) { KeyType = typeof(int) },
                    new BinaryFileDictionary<DbBeatmap, Mods, double>(b => b.CtbDifficulties) { KeyType = typeof(int) },
                    new BinaryFileDictionary<DbBeatmap, Mods, double>(b => b.ManiaDifficulties) { KeyType = typeof(int) },
                    new BinaryFileLine<DbBeatmap, int>(b => b.HitLength),
                    new BinaryFileLine<DbBeatmap, int>(b => b.TotalLength),
                    new BinaryFileLine<DbBeatmap, int>(b => b.PreviewTime),
                    new BinaryCollection<DbBeatmap, TimingPoint>(b => b.TimingPoints,
                        new BinaryFileLine<TimingPoint, double>(t => t.Value),
                        new BinaryFileLine<TimingPoint, double>(t => t.Offset),
                        new BinaryFileLine<TimingPoint, bool>(t => t.IsTiming)),
                    new BinaryFileLine<DbBeatmap, int>(b => b.BeatmapId),
                    new BinaryFileLine<DbBeatmap, int>(b => b.BeatmapSetId),
                    new BinaryFileLine<DbBeatmap, Genre>(b => b.Genre) { Type = typeof(int) },
                    new BinaryFileLine<DbBeatmap, ScoreRank>(b => b.HighestStandardRank) { Type = typeof(byte) },
                    new BinaryFileLine<DbBeatmap, ScoreRank>(b => b.HighestCtbRank) { Type = typeof(byte) },
                    new BinaryFileLine<DbBeatmap, ScoreRank>(b => b.HighestTaikoRank) { Type = typeof(byte) },
                    new BinaryFileLine<DbBeatmap, ScoreRank>(b => b.HighestManiaRank) { Type = typeof(byte) },
                    new BinaryFileLine<DbBeatmap, short>(b => b.UserOffset),
                    new BinaryFileLine<DbBeatmap, float>(b => b.StackLeniency),
                    new BinaryFileLine<DbBeatmap, GameMode>(b => b.Mode) { Type = typeof(byte) },
                    new BinaryFileLine<DbBeatmap, string>(b => b.Source),
                    new BinaryFileLine<DbBeatmap, string>(b => b.Tags),
                    new BinaryFileLine<DbBeatmap, short>(b => b.OnlineOffset),
                    new BinaryFileLine<DbBeatmap, string>(b => b.TitleMarkdown),
                    new BinaryFileLine<DbBeatmap, bool>(b => b.Unplayed),
                    new BinaryFileLine<DbBeatmap, DateTime>(b => b.LastPlayTime),
                    new BinaryFileLine<DbBeatmap, bool>(b => b.Osz2),
                    new BinaryFileLine<DbBeatmap, string>(b => b.Directory),
                    new BinaryFileLine<DbBeatmap, DateTime>(b => b.LastRead),
                    new BinaryFileLine<DbBeatmap, bool>(b => b.IgnoreHitsounds),
                    new BinaryFileLine<DbBeatmap, bool>(b => b.IgnoreSkin),
                    new BinaryFileLine<DbBeatmap, bool>(b => b.IgnoreStoryboard),
                    new BinaryFileLine<DbBeatmap, bool>(b => b.IgnoreVideo),
                    new BinaryFileLine<DbBeatmap, bool>(b => b.Bool2),
                    new BinaryFileLine<DbBeatmap, int>(b => b.Int),
                    new BinaryFileLine<DbBeatmap, byte>(b => b.ManiaScrollSpeed)
                    ),

                new BinaryFileLine<OsuDb, int>(s => s.SomeInt)
                );
            return result;
        }
        

        #endregion

        public DbBeatmap FindHash(string hash) {
            return Beatmaps.FirstOrDefault(b => b.BeatmapHash == hash);
        }
    }
}