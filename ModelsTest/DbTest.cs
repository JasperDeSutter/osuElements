using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using osuElements;
using osuElements.Db;
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
            var beatmap = osuDb.Beatmaps[1];
            //beatmap.ReadFile();
            var groups = osuDb.Beatmaps.OrderBy(DICTIONARY["AR"]).GroupBy(DICTIONARY["AR"]).ToDictionary(b => b.Key, b => b.ToList());
        }

        private static readonly Dictionary<string, Func<DbBeatmap, object>> DICTIONARY =
            new Dictionary<string, Func<DbBeatmap, object>>{
                {"OD", b => Math.Round(b.Diff_Overall)},
                {"AR", b => b.Diff_Approach},
                {"CS", b => b.Diff_Size},
                {"HP", b => b.Diff_Drain},
            };

        [TestMethod]
        public void ScoresTest() {
            var scoreDb = new ScoresDb();
            var logger = new BasicLogger();
            scoreDb.ReadFile(logger);
            var scores = scoreDb.ScoreLists.Sum(s => s.Replays.Count);
        }
    }
}
