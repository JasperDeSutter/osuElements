using System;
using System.Collections.Generic;
using System.IO;
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
            for (int i = 0; i < 20; i++) {
                var map = _osuDb.Beatmaps[i];
                if (!File.Exists(map.FullPath) || map.Mode != GameMode.Standard) continue;

                map.ReadFile();
                var manager = new BeatmapManager(map);
                manager.SetMods(Mods.HardRock);
                manager.SliderCalculations();
                //manager.ApiCalculations();
                //var diff = manager.CalculateDifficlty();
                results.Add(new SomeStruct { Expected = map.StandardDifficulties[Mods.HardRock], Calculated = manager.CalculateDifficlty() });
            }
        }

        private struct SomeStruct
        {
            public double Expected { get; set; }
            public double Calculated { get; set; }
            public double DifferenceAbsolute => Expected - Calculated;
            public double DifferenceRelative => 100 * DifferenceAbsolute / Calculated;
        }
    }
}
