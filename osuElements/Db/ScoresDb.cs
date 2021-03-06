﻿using System.Collections.Generic;
using osuElements.IO.Binary;
using osuElements.Replays;

namespace osuElements.Db
{
    public class ScoresDb
    {
        public ScoresDb() {
            Scores = new List<ScoreList>();
        }

        public List<ScoreList> Scores { get; set; }
        public int FileVersion { get; set; }

        public static BinaryFile<ScoresDb> FileReader() {
            var result = new BinaryFile<ScoresDb>(
                new BinaryFileLine<ScoresDb, int>(s => s.FileVersion),
                new BinaryCollection<ScoresDb, ScoreList>(s => s.Scores,
                    new BinaryFileLine<ScoreList, string>(s => s.MapHash),
                    new BinaryCollection<ScoreList, Replay>(l => l.Replays,
                Replay.HeaderFileLines())));
            return result;
        }

        public class ScoreList
        {
            public string MapHash { get; set; }
            public List<Replay> Replays { get; set; } = new List<Replay>();
            public override string ToString() {
                return MapHash;
            }
        }
    }
}