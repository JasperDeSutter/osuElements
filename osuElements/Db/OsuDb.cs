﻿using System;
using System.Collections.Generic;
using osuElements.Beatmaps;
using osuElements.Helpers;
using osuElements.IO.Binary;
using osuElements.Replays;

namespace osuElements.Db
{
    public class OsuDb
    {
        public OsuDb() {
            Beatmaps = new List<DbBeatmap>();
        }

        public static BinaryFile<OsuDb> FileReader() {
            var result = new BinaryFile<OsuDb>(
                new BinaryFileLine<OsuDb, int>(s => s.FileVersion),
                new BinaryFileLine<OsuDb, int>(s => s.CollectionCount),
                new BinaryFileLine<OsuDb, bool>(s => s.SomeBool),
                new BinaryFileLine<OsuDb, DateTime>(s => s.DateTime),
                new BinaryFileLine<OsuDb, string>(s => s.UserName),
                new BinaryCollection<OsuDb, DbBeatmap>(s => s.Beatmaps,
                    new BinaryFileLine<DbBeatmap, string>(b => b.Artist),
                    new BinaryFileLine<DbBeatmap, string>(b => b.ArtistUnicode),
                    new BinaryFileLine<DbBeatmap, string>(b => b.Title),
                    new BinaryFileLine<DbBeatmap, string>(b => b.TitleUnicode),
                    new BinaryFileLine<DbBeatmap, string>(b => b.Creator),
                    new BinaryFileLine<DbBeatmap, string>(b => b.Version),
                    new BinaryFileLine<DbBeatmap, string>(b => b.AudioFilename),
                    new BinaryFileLine<DbBeatmap, string>(b => b.Hash),
                    new BinaryFileLine<DbBeatmap, string>(b => b.FileName),
                    new BinaryFileLine<DbBeatmap, DbBeatmapState>(b => b.DbBeatmapState) { Type = typeof(byte) },
                    new BinaryFileLine<DbBeatmap, ushort>(b => b.HitCircleAmount),
                    new BinaryFileLine<DbBeatmap, ushort>(b => b.SliderAmount),
                    new BinaryFileLine<DbBeatmap, ushort>(b => b.SpinnerAmount),
                    new BinaryFileLine<DbBeatmap, DateTime>(b => b.DownloadDate),
                    new BinaryFileLine<DbBeatmap, float>(b => b.Diff_Approach),
                    new BinaryFileLine<DbBeatmap, float>(b => b.Diff_Size),
                    new BinaryFileLine<DbBeatmap, float>(b => b.Diff_Drain),
                    new BinaryFileLine<DbBeatmap, float>(b => b.Diff_Overall),
                    new BinaryFileLine<DbBeatmap, double>(b => b.SliderMultiplier),
                    new BinaryFileDictionary<DbBeatmap, Mods, double>(b => b.StandardDifficulties) {
                        KeyType = typeof(int)
                    },
                    new BinaryFileDictionary<DbBeatmap, Mods, double>(b => b.TaikoDifficulties) { KeyType = typeof(int) },
                    new BinaryFileDictionary<DbBeatmap, Mods, double>(b => b.CtbDifficulties) { KeyType = typeof(int) },
                    new BinaryFileDictionary<DbBeatmap, Mods, double>(b => b.ManiaDifficulties) { KeyType = typeof(int) },
                    new BinaryFileLine<DbBeatmap, int>(b => b.Hit_Length),
                    new BinaryFileLine<DbBeatmap, int>(b => b.Total_Length),
                    new BinaryFileLine<DbBeatmap, int>(b => b.PreviewTime),
                    new BinaryCollection<DbBeatmap, TimingPoint>(b => b.TimingPoints,
                        new BinaryFileLine<TimingPoint, double>(t => t.Value),
                        new BinaryFileLine<TimingPoint, double>(t => t.Offset),
                        new BinaryFileLine<TimingPoint, bool>(t => t.IsTiming)),
                    new BinaryFileLine<DbBeatmap, int>(b => b.Beatmap_Id),
                    new BinaryFileLine<DbBeatmap, int>(b => b.BeatmapSet_Id),
                    new BinaryFileLine<DbBeatmap, int>(b => b.GenreId),
                    new BinaryFileLine<DbBeatmap, DbScoreRank>(b => b.HighestStandardRank) { Type = typeof(byte) },
                    new BinaryFileLine<DbBeatmap, DbScoreRank>(b => b.HighestCtbRank) { Type = typeof(byte) },
                    new BinaryFileLine<DbBeatmap, DbScoreRank>(b => b.HighestTaikoRank) { Type = typeof(byte) },
                    new BinaryFileLine<DbBeatmap, DbScoreRank>(b => b.HighestManiaRank) { Type = typeof(byte) },
                    new BinaryFileLine<DbBeatmap, short>(b => b.UserOffset),
                    new BinaryFileLine<DbBeatmap, float>(b => b.StackLeniency),
                    new BinaryFileLine<DbBeatmap, GameMode>(b => b.Mode) { Type = typeof(byte) },
                    new BinaryFileLine<DbBeatmap, string>(b => b.Source),
                    new BinaryFileLine<DbBeatmap, string>(b => b.Tags),
                    new BinaryFileLine<DbBeatmap, short>(b => b.OnlineOffset),
                    new BinaryFileLine<DbBeatmap, string>(b => b.TitleMarkdown),
                    new BinaryFileLine<DbBeatmap, bool>(b => b.Unplayed),
                    new BinaryFileLine<DbBeatmap, DateTime>(b => b.LastPlayTime),
                    new BinaryFileLine<DbBeatmap, bool>(b => b.Bool1),
                    new BinaryFileLine<DbBeatmap, string>(b => b.Directory),
                    new BinaryFileLine<DbBeatmap, DateTime>(b => b.LastRead),
                    new BinaryFileLine<DbBeatmap, bool>(b => b.IgnoreHitsounds),
                    new BinaryFileLine<DbBeatmap, bool>(b => b.IgnoreSkin),
                    new BinaryFileLine<DbBeatmap, bool>(b => b.IgnoreStoryboard),
                    new BinaryFileLine<DbBeatmap, bool>(b => b.IgnoreVideo),
                    new BinaryFileLine<DbBeatmap, bool>(b => b.Bool2),
                    new BinaryFileLine<DbBeatmap, int>(b => b.Int),
                    new BinaryFileLine<DbBeatmap, byte>(b => b.Byte)
                    ),

                new BinaryFileLine<OsuDb, int>(s => s.SomeInt)
                );
            return result;
        }

        public int FileVersion { get; set; }
        public int CollectionCount { get; set; }
        public bool SomeBool { get; set; }
        public DateTime DateTime { get; set; }
        public string UserName { get; set; }
        public List<DbBeatmap> Beatmaps { get; set; }
        public int SomeInt { get; set; }
    }
}