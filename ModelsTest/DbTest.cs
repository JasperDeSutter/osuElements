using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using osuElements;
using osuElements.Db;
using osuElements.Helpers;
using osuElements.IO.File;

namespace ModelsTest
{
    [TestClass]
    public class DbTest
    {
        [TestMethod]
        public void CollectionTest() {
            var collectionDb = new CollectionDb();
            var logger = new BasicLogger();
            collectionDb.ReadFile(logger);
            var scores = collectionDb.Collections.Sum(c => c.Count);
            var deleted = collectionDb.RemoveEmpty();
            collectionDb.WriteFile();
        }

        [TestMethod]
        public void MapsTest() {
            var osuDb = new OsuDb();
            var logger = new BasicLogger();
            osuDb.ReadFile(logger);
            var beatmap = osuDb.Beatmaps.FirstOrDefault(d => d.Mode == GameMode.Mania);
            Assert.IsNotNull(beatmap);
            beatmap.ReadFile(logger);
            beatmap.FileName += "-copy";
            beatmap.WriteFile();
            Assert.IsTrue(logger.Errors.Count == 0);
        }

        private static readonly Dictionary<string, Func<DbBeatmap, object>> DICTIONARY =
            new Dictionary<string, Func<DbBeatmap, object>>{
                {"OD", b => Math.Round(b.DifficultyOverall)},
                {"AR", b => b.DifficultyApproachRate},
                {"CS", b => b.DifficultyCircleSize},
                {"HP", b => b.DifficultyHpDrainRate},
            };

        [TestMethod]
        public void ScoresTest() {
            var scoreDb = new ScoresDb();
            var logger = new BasicLogger();
            scoreDb.ReadFile(logger);
            var scores = scoreDb.ScoreLists.Sum(s => s.Replays.Count);
        }

        [TestMethod]
        public void ReadAllMapsTest() {
            var osuDb = new OsuDb();
            var logger = new BasicLogger();
            osuDb.ReadFile(logger);
            foreach (var dbBeatmap in osuDb.Beatmaps) {
                try {
                    dbBeatmap.ReadFile(logger);
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
