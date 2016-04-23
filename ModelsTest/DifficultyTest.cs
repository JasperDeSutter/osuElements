using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using osuElements;
using osuElements.Beatmaps;
using osuElements.Db;

namespace ModelsTest
{
    [TestClass]
    public class DifficultyTest
    {
        private OsuDb _osuDb;

        public DifficultyTest() {
            _osuDb = new OsuDb();
            _osuDb.ReadFile();
        }

        [TestMethod]
        public void CalculateAll() {
            var results = new List<SomeStruct>();
            const Mods mod = Mods.DoubleTime;
            foreach (var map in _osuDb.Beatmaps.Where(t =>
                            t.DbBeatmapState == DbBeatmapState.Ranked && File.Exists(t.FullPath) &&
                            t.Mode == GameMode.Standard).Skip(100).Take(20)) {
                map.ReadFile();
                var manager = new BeatmapManager(map);
                manager.SetMods(mod);
                manager.SliderCalculations();
                //manager.ApiCalculations();
                //var diff = manager.CalculateDifficlty();
                results.Add(new SomeStruct {
                    Expected = map.StandardDifficulties[mod],
                    Calculated = manager.CalculateDifficlty(),
                    Pp = manager.CalculatePerformancePoints()
                });
            }
        }

        private struct SomeStruct
        {
            public double Expected { get; set; }
            public double Calculated { get; set; }
            public double Pp { get; set; }
            public double DifferenceAbsolute => Expected - Calculated;
            public double DifferenceRelative => 100 * DifferenceAbsolute / Calculated;
        }
    }
}