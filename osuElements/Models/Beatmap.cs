using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Security.Cryptography;
using osuElements.Repositories;
using osuElements.Helpers;
using osuElements.Events;

namespace osuElements
{
    public class Beatmap : BeatmapBase
    {
        //Properties
        public string FileName { get; set; }
        public string Directory { get; set; }
        public string StoryboardPath => $"{Artist} - {Title} ({Creator}).osb";

        public string[] TagsArray => Tags.Split(Splitter.Space);

        #region Difficulty 
        public override float ApproachRate {
            get { return Math.Min(Ar * ModDiff, 10); }
            set { Ar = value; }
        }
        public override float OverallDifficulty {
            get { return Math.Min(Od * ModDiff, 10); }
            set { Od = value; }
        }
        public override float HPDrainRate {
            get { return Math.Min(Hp * ModDiff, 10); }
            set { Hp = value; }
        }
        public override float CircleSize {
            get { return Math.Min(Cs * ModDiff2, 10); }
            set { Cs = value; }
        }

        public int ApproachRateMS {
            get {
                if (ApproachRate >= 5) return (int)((1950 - ApproachRate * 150));
                return (int)((1800 - ApproachRate * 120));
            }
        }
        public float CircleDiameter => 9.6f + (10 - CircleSize) / 44.8f;

        /// <summary>
        /// A hit within this value before AND after timing results in a 300.
        /// </summary>
        public float Timing300 => 79.5f - OverallDifficulty * 6;

        /// <summary>
        /// A hit within this value before AND after timing results in a 100.
        /// </summary>
        public float Timing100 => 139.5f - OverallDifficulty * 8;

        /// <summary>
        /// A hit within this value before AND after timing results in a 50.
        /// </summary>
        public float Timing50 => 199.5f - OverallDifficulty * 10;

        #endregion

        #region Mods

        private float ModDiff => (Mods.Compare(Mods.HardRock) ? Constants.HardRockMultiplier : 1) * (Mods.Compare(Mods.Easy) ? Constants.EasyMultiplier : 1);
        //Circle size uses this one
        private float ModDiff2 => (Mods.Compare(Mods.HardRock) ? Constants.CircleSizeModMultiplier : 1) * (Mods.Compare(Mods.Easy) ? Constants.EasyMultiplier : 1);

        public float ModSpeed => (Mods.Compare(Mods.DoubleTime) || Mods.Compare(Mods.Nightcore) ? Constants.DtMultiplier : 1) * (Mods.Compare(Mods.HalfTime) ? Constants.HtMultiplier : 1);

        public Mods Mods { get; private set; }

        //groups, only one member of a group can be active;
        private const Mods SPEED_CHANGERS = Mods.DoubleTime | Mods.HalfTime | Mods.Nightcore;
        private const Mods DIFFICULTY_CHANGERS = Mods.Easy | Mods.HardRock;
        private const Mods FAIL_CHANGERS = Mods.NoFail | Mods.Perfect | Mods.SuddenDeath | Mods.Relax | Mods.Relax2 | Mods.Autoplay | Mods.Cinema;

        //Need to add more for other gamemodes

        public readonly Mods[] Modgroups = { SPEED_CHANGERS, DIFFICULTY_CHANGERS, FAIL_CHANGERS, };

        public void UpdateSetMod(Mods value) {
            Mods ^= value;
            foreach (Mods member in Modgroups.Where(member => member.Compare(value))) {
                Mods &= ~(member ^ value);
            }
        }

        #endregion

        public bool IsRead;

        public Beatmap() {
            //Thread.CurrentThread.CurrentCulture = Constants.CULTUREINFO;
            IsRead = false;
        }
        public Beatmap(string file, bool readFile = true)
            : this() {
            Directory = Path.GetDirectoryName(file);
            FileName = Path.GetFileName(file);
            if (readFile) ReadFile();
        }
        public void ReadFile() {
            OsuReader.ReadFile(Directory + "\\" + FileName, this);
            IsRead = true;
        }
        public string ToOsu()  //File format
        {
            Mods temp = Mods;
            Mods = Mods.None;
            string nl = System.Environment.NewLine;
            string output = "osu file format v14" + nl; //always save as newest version

            output += title("General");
            output += title("Editor");
            output += title("Metadata");
            output += title("Difficulty");
            output += title("Events");
            output += "//Background and Video events" + nl;
            output += "//Break Periods" + nl;
            output += "//Storyboard Layer 0 (Background)" + nl;
            output = BackgroundEvents.Cast<Event>().Aggregate(output, (current, e) => current + e.ToString());
            output += "//Storyboard Layer 1 (Fail)" + nl;
            output = FailEvents.Cast<Event>().Aggregate(output, (current, e) => current + e.ToString());
            output += "//Storyboard Layer 2 (Pass)" + nl;
            output = PassEvents.Cast<Event>().Aggregate(output, (current, e) => current + e.ToString());
            output += "//Storyboard Layer 3 (Foreground)" + nl;
            output = ForegroundEvents.Cast<Event>().Aggregate(output, (current, e) => current + e.ToString());
            output += "//Storyboard Sound Samples" + nl;
            output += title("TimingPoints");
            output = TimingPoints.Aggregate(output, (current, tp) => current + tp + nl);

            output += nl; // this is default stuff

            if (ComboColors.Any()) {
                output += title("Colours");
                output = ComboColors.Aggregate(output, (current, cc) => current + cc + nl);
            }

            output += title("HitObjects");
            output = HitObjects.Aggregate(output, (current, ho) => current + ho + nl);

            Mods = temp;
            return output;
        }
        public string GetMd5() {
            string path = Directory + "\\" + FileName;
            var md5 = MD5.Create();
            using (var stream = File.OpenRead(path))
                return BitConverter.ToString(md5.ComputeHash((Stream)stream)).Replace("-", string.Empty).ToLower();
        }

        public bool CompareMd5(string hash) {
            string hashOfInput = GetMd5();
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return (0 == comparer.Compare(hashOfInput, hash));
        }

        private static string title(string t) {
            string nl = Environment.NewLine;
            return nl + "[" + t + "]" + nl;
        }

        public override string ToString() => IsRead ? $"{Artist} - {Title} ({Creator}) [{Version}]" : FileName.Replace(".osu", "");

    }
}
