using System;
using System.IO;
using System.Security.Cryptography;
using osuElements.Helpers;
using osuElements.Other_Models;
using osuElements.Repositories;
using static osuElements.Helpers.Constants.Beatmap;

namespace osuElements
{
    public class Beatmap : BeatmapBase
    {

        public static IRepository<Beatmap> BeatmapRepository { private get; set; }
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
        public double CircleDiameter =>
            54.4 - CircleSize * 4.48;

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

        private float ModDiff => 
            (Mods.Compare(Mod.HardRock) ? HARD_ROCK_MULTIPLIER : 1) * (Mods.Compare(Mod.Easy) ? EASY_MULTIPLIER : 1);
        //Circle size uses this one
        private float ModDiff2 => 
            (Mods.Compare(Mod.HardRock) ? CIRCLE_SIZE_MOD_MULTIPLIER : 1) * (Mods.Compare(Mod.Easy) ? EASY_MULTIPLIER : 1);

        public float ModSpeed => 
            (Mods.Compare(Mod.DoubleTime) || Mods.Compare(Mod.Nightcore) ? DT_MULTIPLIER : 1) * (Mods.Compare(Mod.HalfTime) ? HT_MULTIPLIER : 1);

        public Mod Mods { get; private set; }


        //only one per item can be active
        //Need to add more for other gamemodes
        public readonly Mod[] Modgroups = {
            Mod.DoubleTime | Mod.HalfTime | Mod.Nightcore,
            Mod.Easy | Mod.HardRock,
            Mod.NoFail | Mod.Perfect | Mod.SuddenDeath | Mod.Relax | Mod.Relax2 | Mod.Autoplay | Mod.Cinema
        };

        public void UpdateSetMod(Mod value) {
            Mods ^= value;
            /*foreach (Mod member in Modgroups.Where(member => member.Compare(value))) {
                Mod &= ~(member ^ value);
            }*/
        }

        #endregion

        public bool IsRead { get; private set; }
        public string FullPath => Path.Combine(Directory, FileName);

        static Beatmap() {
            BeatmapRepository = new OsuRepository();
        }
        public Beatmap() {
            IsRead = false;
        }
        public Beatmap(string file, bool readFile = true)
            : this() {
            Directory = Path.GetDirectoryName(file);
            FileName = Path.GetFileName(file);
            if (readFile) ReadFile();
        }
        public void ReadFile() {
            BeatmapRepository.ReadFile(FullPath, this);
            IsRead = true;
        }
        public string WriteToString()  //File format
        {
            Mod temp = Mods;
            Mods = Mod.None;
            var result = BeatmapRepository.WriteToString(this);
            Mods = temp;
            return result;
        }
        public void WriteFile() {
            BeatmapRepository.WriteFile(FullPath, this);
        }
        public string GetMD5() {
            var md5 = MD5.Create();
            using (var stream = File.OpenRead(FullPath))
                return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
        }
        public bool CompareMd5(string hash) {
            string hashOfInput = GetMD5();
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return (0 == comparer.Compare(hashOfInput, hash));
        }

        public override string ToString() => IsRead ? $"{Artist} - {Title} ({Creator}) [{Version}]" : FileName.Replace(".osu", "");

    }
}
