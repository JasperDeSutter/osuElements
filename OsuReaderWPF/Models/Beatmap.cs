using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
//using System.Reflection;
using System.Security.Cryptography;
namespace osuElements
{
    public class Beatmap
    {
        //the class that that defines the object that gets created from .osu file. Holds all elements of that file.

        //general
        public string Directory { get; set; }

        internal Dictionary<beatmapGeneral,string> General { get; set; }

        public string AudioFilename { get; set; }
        public int AudioLeadIn { get; set; }
        public int PreviewTime { get; set; }
        public bool Countdown { get; set; }
        public SampleSets SampleSet { get; set; }
        public float StackLeniency { get; set; }
        public GameModes Mode { get; set; }
        public bool LetterboxInBreaks { get; set; }
        public bool WidescreenStoryboard { get; set; }

        //colours
        public List<ComboColor> ComboColors { get; set; }

        //meta
        internal Dictionary<beatmapMetadata, string> Metadata { get; set; }

        public int FormatVersion { get; set; }
        public string Title { get; set; }
        public string TitleUnicode { get; set; }
        public string Artist { get; set; }
        public string ArtistUnicode { get; set; }
        public string Creator { get; set; }
        public string Version { get; set; }
        public string Source { get; set; }
        public string Tags { get; set; }
        public string[] TagArr { get { return 
            Tags.Split(Splitter.Space); 
        } }
        public int BeatmapID { get; set; }
        public int BeatmapSetID { get; set; }

        public string FileName;
        
        //Editor
        internal Dictionary<beatmapEditor, string> Editor { get; set; }

        public string Bookmarks { get; set; }
        public int[] BookmarkArr
        {
            get
            {
                if(Bookmarks!=null)
                return Array.ConvertAll(Bookmarks.Split(Splitter.Comma), s => int.Parse(s));
                return new int[0];
            }
        }
        public float DistanceSpacing { get; set; }
        public int BeatDivisor { get; set; }
        public int GridSize { get; set; }
        public float TimelineZoom { get; set; }
        //Events

        //videoevent
        public SpriteEvent Background;
        //Breakevents list
        public List<SpriteEvent> BackgroundEvents;
        public List<SpriteEvent> FailEvents;
        public List<SpriteEvent> PassEvents;
        public List<SpriteEvent> ForegroundEvents;
        //sampleevents list

        //Difficulty
        internal Dictionary<beatmapDifficulty, string> Difficulty { get; set; }

        float modDiff { get { return (mods.Compare(Mods.HardRock) ? Statics.HardRockMultiplier : 1) * (mods.Compare(Mods.Easy) ? Statics.EasyMultiplier : 1); } }
        float modDiff2 { get { return (mods.Compare(Mods.HardRock) ? Statics.CircleSizeModMultiplier : 1) * (mods.Compare(Mods.Easy) ? Statics.EasyMultiplier : 1); } } //special for CS, dunno why
        public float ModSpeed { get { return (mods.Compare(Mods.DoubleTime)||mods.Compare(Mods.Nightcore) ? Statics.DTMultiplier : 1) * (mods.Compare(Mods.HalfTime) ? Statics.HTMultiplier : 1); } }
        #region
        private float ar;
        public float AR
        {
            get { return (float)Math.Min(ar * modDiff,10); }
            set { ar = value; }
        }
        private float od;
        public float OD
        {
            get { return (float)Math.Min(od * modDiff, 10); }
            set { od = value; }
        }
        private float hp;
        public float HP
        {
            get { return (float)Math.Min(hp * modDiff, 10); }
            set { hp = value; }
        }
        private float cs;
        public float CS
        {
            get { return (float)Math.Min(cs * modDiff2, 10); }
            set { cs = value; }
        }

        public int ApproachRate
        {
            get
            {
                if (AR >= 5) return (int)((1950 - AR * 150));
                return (int)((1800 - AR * 120));
            }
        }
        public float CircleSize
        {
            get { return 0.025f + (10-(CS)) / 43; } // multiply by screenHeight for actual value
            //get { return (float)((OsuScreenProportion / 16) * (1 - 0.7 * (CS - 5) / 5.0)); }
        }
        public float Timing300
        {
            get
            {
                return 79.5f - OD * 6;
            }
        }

        public float Timing100
        {
            get
            {
                return 139.5f - OD * 8;
            }
        }

        public float Timing50
        {
            get
            {
                return 199.5f - OD * 10;
            }
        }
        #endregion
        public double SliderMultiplier { get; set; }
        public int SliderTickRate { get; set; }

        public Mods mods { get; private set; }

        //groups, only one member of a group can be active;
        static Mods SpeedChangers = Mods.DoubleTime | Mods.HalfTime | Mods.Nightcore;
        static Mods DifficultyChangers = Mods.Easy | Mods.HardRock;
        static Mods FailChangers = Mods.NoFail | Mods.Perfect | Mods.SuddenDeath | Mods.Relax | Mods.Relax2 | Mods.Autoplay | Mods.Cinema;
        
        //Need to add more for other gamemodes

        readonly Mods[] groups = { SpeedChangers, DifficultyChangers, FailChangers,  };

        public void UpdateSetMod(Mods value)
        {
            mods ^= value;
            foreach (Mods member in groups)
            {
                if (member.Compare(value)) //is it part of a group? -> unset all other group members
                {
                    mods &= ~(member ^ value);
                }
            }
        }

        public List<TimingPoint> TimingPoints { get; set; }
        public List<HitObject> HitObjects { get; set; }

        public bool IsRead;

        public Beatmap()
        {
            InitProps();
            Thread.CurrentThread.CurrentCulture = Statics.CULTURE2;
            IsRead = false;
        }
        public Beatmap(string file, bool readFile = true)
            : this()
        {
            Directory = Path.GetDirectoryName(file);
            FileName = Path.GetFileName(file);
            if (readFile) ReadFile();
        }
        public void ReadFile()
        {
            OsuReader.ReadFile(Directory + "\\" + FileName, this);
            VariablesFromDictionaries();
            IsRead = true;
        }
        private void VariablesFromDictionaries()
        {
            SetValue(beatmapGeneral.AudioFilename, "");
            SetValue(beatmapGeneral.AudioLeadIn, 0);
            SetValue(beatmapGeneral.Countdown, false);
            SetValue(beatmapGeneral.LetterboxInBreaks, false);
            SetValue(beatmapGeneral.Mode, (int)GameModes.Standard);
            SetValue(beatmapGeneral.PreviewTime, 0);
            string sample;
            SampleSet = General.TryGetValue(beatmapGeneral.SampleSet, out sample) ? (SampleSets)Enum.Parse(typeof(SampleSets), sample) : SampleSets.None;
            SetValue(beatmapGeneral.StackLeniency, 0f);
            SetValue(beatmapGeneral.WidescreenStoryboard, false);

            SetValue(beatmapMetadata.Artist, "");
            SetValue(beatmapMetadata.ArtistUnicode, "");
            SetValue(beatmapMetadata.BeatmapID, 0);
            SetValue(beatmapMetadata.BeatmapSetID, 0);
            SetValue(beatmapMetadata.Creator, "");
            SetValue(beatmapMetadata.Source, "");
            SetValue(beatmapMetadata.Tags, "");
            SetValue(beatmapMetadata.Title, "");
            SetValue(beatmapMetadata.TitleUnicode, "");
            SetValue(beatmapMetadata.Version, "");

            SetValue<string>(beatmapEditor.Bookmarks, null);
            SetValue(beatmapEditor.BeatDivisor, 4);
            SetValue(beatmapEditor.DistanceSpacing, 1f);
            SetValue(beatmapEditor.GridSize, 1);
            SetValue(beatmapEditor.TimelineZoom, 1f);
        }
        private void VariablesToDictionaries()
        {
            foreach (beatmapGeneral gen in Enum.GetValues(typeof(beatmapGeneral))) General[gen] = GetPropertyString(""+gen);
            foreach (beatmapEditor edit in Enum.GetValues(typeof(beatmapEditor)))
            {
                if(GetPropertyString(""+edit)!="")
                Editor[edit] = GetPropertyString("" + edit);
            }
            foreach (beatmapMetadata meta in Enum.GetValues(typeof(beatmapMetadata))) Metadata[meta] = GetPropertyString("" + meta);
            Difficulty[beatmapDifficulty.HPDrainRate] = HP.ToString();
            Difficulty[beatmapDifficulty.CircleSize] = CS.ToString();
            Difficulty[beatmapDifficulty.OverallDifficulty] = OD.ToString();
            Difficulty[beatmapDifficulty.ApproachRate] = AR.ToString();
            Difficulty[beatmapDifficulty.SliderMultiplier] =  SliderMultiplier.ToString();
            Difficulty[beatmapDifficulty.SliderTickRate] = SliderTickRate.ToString();
        }
        
        #region
        void SetValue<T>(beatmapGeneral param, T @default)
        {
            string value;
            
            string prop = "" + param;
            this.GetType().GetProperty("" + prop).SetValue(this,
                (General.TryGetValue(param, out value) ? 
                (typeof(T) == typeof(string))? value :
                    (typeof(T) == typeof(bool)) ? Convert.ToBoolean(Convert.ToInt16(value)) :
                        (typeof(T) == typeof(float)) ? (float)Convert.ToDecimal(value) :
                            Convert.ChangeType(value,typeof(T))
                : @default),  null);
        }
        void SetValue<T>(beatmapMetadata param, T @default)
        {
            string value;

            string prop = "" + param;
            this.GetType().GetProperty("" + prop).SetValue(this,
                (Metadata.TryGetValue(param, out value) ?
                (typeof(T) == typeof(string)) ? value :
                    (typeof(T) == typeof(bool)) ? Convert.ToBoolean(Convert.ToInt16(value)) :
                        (typeof(T) == typeof(float)) ? (float)Convert.ToDecimal(value) :
                            Convert.ChangeType(value, typeof(T))
                : @default), null);
        }
        void SetValue<T>(beatmapEditor param, T @default)
        {
            string value;

            string prop = "" + param;
            this.GetType().GetProperty("" + prop).SetValue(this,
                (Editor.TryGetValue(param, out value) ?
                (typeof(T) == typeof(string)) ? value :
                    (typeof(T) == typeof(bool)) ? Convert.ToBoolean(Convert.ToInt16(value)) :
                        (typeof(T) == typeof(float)) ? (float)Convert.ToDecimal(value) :
                            Convert.ChangeType(value, typeof(T))
                : @default), null);
        }
        #endregion
        string GetPropertyString(string prop)
        {
            var value = this.GetType().GetProperty(prop).GetValue(this, null);
            if (value == null) return "";
            if (value.GetType() == typeof(bool)) return (bool)value ? "1" :"0";
            if (value.GetType() == typeof(GameModes)) return ((int)value).ToString();
            return value.ToString();
        }
        public string ToOsu()  //File format
        {
            Mods temp = mods;
            mods = Mods.None;
            VariablesToDictionaries();
            string nl = System.Environment.NewLine;
            string output = "osu file format v14" + nl; //always save as newest version

            output += AddTitle("General");
            foreach (var gen in General.OrderBy(a=>a.Key)) output += gen.Key + ": " + gen.Value + nl; //has space
            output += AddTitle("Editor");
            foreach (var edit in Editor.OrderBy(a => a.Key)) output += edit.Key + ": " + edit.Value + nl; //has space
            output += AddTitle("Metadata");
            foreach (var meta in Metadata.OrderBy(a => a.Key)) output += meta.Key + ":" + meta.Value + nl; //no space
            output += AddTitle("Difficulty");
            foreach (var diff in Difficulty.OrderBy(a => a.Key)) output += diff.Key + ":" + diff.Value + nl; //no space
            output += AddTitle("Events");
            output += "//Background and Video events" + nl;
            output += "//Break Periods" + nl;
            output += "//Storyboard Layer 0 (Background)" + nl;
            foreach (Event e in BackgroundEvents)
            {
                output += e.ToString();
            }
            output += "//Storyboard Layer 1 (Fail)" + nl;
            output += "//Storyboard Layer 2 (Pass)" + nl;
            output += "//Storyboard Layer 3 (Foreground)" + nl;
            output += "//Storyboard Sound Samples" + nl;
            output += AddTitle("TimingPoints");
            foreach (TimingPoint tp in TimingPoints) output += tp + nl;

            output += nl; //?????????????

            if (ComboColors.Count() > 0)
            {
                output += AddTitle("Colours");
                foreach (ComboColor cc in ComboColors) output += cc + nl;
            }

            output += AddTitle("HitObjects");
            foreach (HitObject ho in HitObjects) output += ho + nl;

            mods = temp;
            return output;
        }
        public string GetMD5()
        {
            string path = Directory + "\\" + FileName;
            MD5 md5 = MD5.Create();
            using (FileStream stream = File.OpenRead(path))
            return BitConverter.ToString(md5.ComputeHash((Stream)stream)).Replace("-", string.Empty).ToLower();
        }
        public bool CompareMD5(string hash)
        {
            string hashOfInput = GetMD5();
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return (0 == comparer.Compare(hashOfInput, hash));
        }
        string AddTitle(string title)
        {
            string nl = System.Environment.NewLine;
            return nl + "["+title+"]" + nl;
        }

        private void InitProps()
        {
            ComboColors = new List<ComboColor>();
            General = new Dictionary<beatmapGeneral, string>();
            Metadata = new Dictionary<beatmapMetadata, string>();
            Editor = new Dictionary<beatmapEditor, string>();
            Difficulty = new Dictionary<beatmapDifficulty, string>();
            BackgroundEvents = new List<SpriteEvent>();
            ForegroundEvents = new List<SpriteEvent>();
            FailEvents = new List<SpriteEvent>();
            PassEvents = new List<SpriteEvent>();
        }
        public override string ToString()  //Filename
        {
            if(IsRead)
            return Artist + " - " + Title + " (" + Creator + ") [" + Version + "]";
            return FileName.Replace(".osu", "");
        }
    }
}
