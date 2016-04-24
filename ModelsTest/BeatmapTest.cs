using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using osuElements;
using osuElements.Beatmaps;
using osuElements.Db;
using osuElements.Helpers;
using osuElements.IO.File;
using osuElements.Storyboards;
using TestContent;

namespace ModelsTest
{
    [TestClass]
    public class BeatmapTest
    {
        private readonly Beatmap _beatmap;
        private BeatmapManager _manager;

        public BeatmapTest() {
            _beatmap = new Beatmap { FullPath = Paths.Beatmap };
        }

        [TestMethod]
        public void FileReaderTest() {
            var logger = new BasicLogger();
            _beatmap.ReadFile(logger); //Read beatmap
            Assert.AreEqual(0, logger.Errors.Count);

            _beatmap.FileName = "Write.osu";
            _beatmap.WriteFile(); //Write it
            _beatmap.ReadFile(logger); //Read the written one
            Assert.AreEqual(0, logger.Errors.Count);
            _beatmap.FileName = Paths.Beatmap;
        }

        [TestMethod]
        public void ManagerTest() {
            _beatmap.ReadFile();
            _manager = new BeatmapManager(_beatmap);
            _manager.SetMods(Mods.HardRock);
            var hos = _manager.GetHitObjects();
        }

        [TestMethod]
        public void ToStringTest() {
            _beatmap.ReadFile();
            Assert.AreEqual("Our Stolen Theory - United (L.A.O.S Remix) (Asphyxia) [Infinity]", _beatmap.ToString());
        }


        [TestMethod]
        public void TestTest() { //lol rip naming
            var map = new Beatmap { FullPath = "131151 MAN WITH A MISSION - Database (feat Takuma) (TV Size)\\MAN WITH A MISSION - Database (feat. Takuma) (TV Size) (Simon) [MikaruNoel's Hard+].osu" };
            var logger = new BasicLogger();
            map.ReadFile(logger);
            map.DifficultyApproachRate = 10;
            map.FormatVersion = osuElements.osuElements.LatestBeatmapVersion;
            map.Version = "testname";
            map.FileName = map + ".osu";
            map.Countdown = CountDown.Double;
            map.WriteFile();

        }

        [TestMethod]
        public void StoryboardTest() {
            var storyboard = new Storyboard { FullPath = Paths.KungFuStoryboard };
            var logger = new BasicLogger();

            //fileReader.ReadFile(FileReaderFunc(Paths.Storyboard), storyboard, logger);
            storyboard.ReadFile(logger);
            //storyboard.VariablesDictionary.Add("$sp", "Sprite,Foreground,Centre,\"SB\\rain.png\",320,240");
            //storyboard.VariablesDictionary.Add("$f1", "F,0,3687,12000,0,0.5");
            //storyboard.VariablesDictionary.Add("$f2", "F,0,15692,22549,0.5,0.15");
            //storyboard.VariablesDictionary.Add("$s", "S,0,0,,1");
            //storyboard.VariablesDictionary.Add("$r", "R,0,0,,-0.4");
            storyboard.FullPath = Paths.SongFolder + @"\storyboard2.osb";
            storyboard.WriteFile();
        }


        //manager
        [TestMethod]
        public void Difficulty() { 
            _beatmap.ReadFile();
            _manager = new BeatmapManager(_beatmap);
            _manager.SliderCalculations();
            var diff = _manager.CalculateDifficlty();
            Assert.AreEqual(5.64, Math.Round(diff, 2));
        }
    }
}
