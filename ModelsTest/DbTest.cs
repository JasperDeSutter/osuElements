using System;
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
        }

        [TestMethod]
        public void ScoresTest() {
            var scoreDb = new ScoresDb();
            var logger = new BasicLogger();
            scoreDb.ReadFile(logger);
            var scores = scoreDb.Scores.Sum(s => s.Replays.Count);
        }
    }
}
