using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using osuElements;
using osuElements.Beatmaps.Difficulty;

namespace ModelsTest
{
    [TestClass]
    public class PpTest
    {
        [TestMethod]
        public void SuppliedValues() {
            var pp = StandardDifficultyCalculator.PerformancePoints(Mods.DoubleTime | Mods.HardRock, 2.31, 1.95, 20, 450, 1068, 659, 0, 0,
                0, 50, false);
        }
    }
}
