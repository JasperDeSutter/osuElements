using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using osuElements.Api;
using osuElements.Beatmaps.Events;
using osuElements.Helpers;
using osuElements.IO;
using osuElements.IO.File;
using osuElements.Storyboards;

namespace osuElements.Beatmaps
{
    /// <summary>
    /// The file-driven approach to the beatmap object
    /// </summary>
    public class Beatmap : ApiBeatmap, IStoryboardEvents, IFileModel
    {
        public Beatmap() {
            HitObjects = new List<HitObject>();
            TimingPoints = new List<TimingPoint>();
            ComboColours = new List<Colour>(8);
            Bookmarks = new List<int>();

            BreakPeriods = new List<BreakEvent>();
            BackgroundColorTransformations = new List<BackgroundColorEvent>();

            BackgroundEvents = new List<SpriteEvent>();
            ForegroundEvents = new List<SpriteEvent>();
            FailEvents = new List<SpriteEvent>();
            PassEvents = new List<SpriteEvent>();
            SampleEvents = new List<SampleEvent>();
            
            IsRead = false;

            DifficultyApproachRate = 5;
            DifficultyCircleSize = 5;
            DifficultyHpDrainRate = 5;
            DifficultyOverall = 5;
        }

        public Beatmap(string file)
            : this() {
            FullPath = file;
            ReadFile();
        }

        public int FormatVersion { get; set; }
        /// <summary>
        /// A list of TimingPoint() objects. Timingpoints hold the tempo, slidervelocity or hitsounds at certain points in the beatmap.
        /// </summary>
        public List<TimingPoint> TimingPoints { get; set; }
        /// <summary>
        /// A list of the definitions of the hitobjects
        /// </summary>
        public List<HitObject> HitObjects { get; set; }
        /// <summary>
        /// A space-splitted array of the tags
        /// </summary>
        public string[] TagsArray
        {
            get { return Tags.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); }
            set { Tags = value.ToString(" "); }
        }
        /// <summary>
        /// The name of the storyboard associated with this map(set) if it exists.
        /// </summary>
        public string StoryboardFileName => $"{Artist} - {Title} ({Creator}).osb";


        #region File
        public bool IsRead { get; private set; }
        public string FileName { get; set; }
        public string Directory { get; set; }
        public string RootedDirectory => Path.IsPathRooted(Directory) ? Directory : Path.Combine(osuElements.OsuSongDirectory, Directory);

        public string FullPath
        {
            get
            {
                return Path.Combine(RootedDirectory, FileName);
            }
            set
            {
                Directory = Path.GetDirectoryName(value);
                FileName = Path.GetFileName(value);
            }
        }
        public void ReadFile(ILogger logger = null) {
            using (var stream = osuElements.StreamIOStrategy.ReadStream(FullPath)) {
                osuElements.BeatmapFileRepository.ReadFile(stream, this, logger);
            }
            if (FormatVersion < 8) DifficultyApproachRate = DifficultyHpDrainRate;
            IsRead = true;
        }
        public void WriteFile() {
            using (var stream = osuElements.StreamIOStrategy.WriteStream(FullPath)) {
                osuElements.BeatmapFileRepository.WriteFile(stream, this);
            }
        }
        #endregion

        #region Methods

        public void AddSpriteEvent(SpriteEvent sprite) {
            switch (sprite.Layer) {
                case EventLayer.Background:
                    BackgroundEvents.Add(sprite);
                    break;
                case EventLayer.Fail:
                    FailEvents.Add(sprite);
                    break;
                case EventLayer.Pass:
                    PassEvents.Add(sprite);
                    break;
                case EventLayer.Foreground:
                    ForegroundEvents.Add(sprite);
                    break;
                default:
                    throw new ArgumentException("The sprite's (event)layer was not set to a known storyboard layer");
            }
        }

        public async Task AddApiProperties() {
            var apimap = await osuElements.ApiBeatmapRepository.Get(BeatmapId, Mode);
            apimap.CopyTo(this, false);
        }

        public string GetHash(bool forceRenew = false) {
            if (!forceRenew && !string.IsNullOrWhiteSpace(BeatmapHash)) return BeatmapHash;
            var md5 = MD5.Create();
            using (var stream = osuElements.StreamIOStrategy.ReadStream(FullPath)) {
                BeatmapHash = md5.ComputeHash(stream).Aggregate("", (current, b) => current + b.ToString("x2"));
            }
            return BeatmapHash;
        }

        public bool CompareHash(string hash) {
            var hashOfInput = GetHash();
            var comparer = StringComparer.OrdinalIgnoreCase;
            return 0 == comparer.Compare(hashOfInput, hash);
        }

        public override string ToString()
            => IsRead ? $"{Artist} - {Title} ({Creator}) [{Version}]" : FileName.Replace(".osu", "");


        #endregion

        #region General

        /// <summary>
        /// specifies the location of the audio file relative to the current folder.
        /// </summary>
        public string AudioFilename { get; set; }
        /// <summary>
        /// A hash to check if the audio file is the correct one, this is only used in first versions
        /// </summary>
        public string AudioHash { get; set; } = "";
        /// <summary>
        /// the amount of time (in ms) added before the audio file begins playing. Useful for audio files that begin immediately.
        /// </summary>
        public int AudioLeadIn { get; set; }
        /// <summary>
        /// defines when (in ms) the audio file should begin playing when selected in the song selection menu.
        /// </summary>
        public int PreviewTime { get; set; }
        /// <summary>
        /// whether or not a countdown occurs before the first hit object appears.
        /// </summary>
        public CountDown Countdown { get; set; }
        /// <summary>
        /// which set of hit sounds will be used throughout the beatmap.
        /// </summary>
        public SampleSet SampleSet { get; set; }
        /// <summary>
        /// how often closely placed hit objects will be stacked together.
        /// </summary>
        public float StackLeniency { get; set; }
        /// <summary>
        /// specifies whether the letterbox appears during breaks.
        /// </summary>
        public bool LetterboxInBreaks { get; set; }
        //situational
        public bool StoryFireInFront { get; set; } = false;
        public bool UseSkinSprites { get; set; } = false;
        public bool AlwaysShowPlayfield { get; set; } = false;
        public OverlayPosition OverlayPosition { get; set; } = OverlayPosition.NoChange;
        public string SkinPreference { get; set; }
        public bool EpilepsyWarning { get; set; } = false;
        public int CountdownOffset { get; set; } = 0;
        /// <summary>
        /// For Mania beatmaps only, leftmost column will be used for turntable
        /// </summary>
        public bool SpecialStyle { get; set; } = false;
        /// <summary>
        /// whether or not the storyboard should be widescreen.
        /// </summary>
        public bool WidescreenStoryboard { get; set; } = false;
        public bool SamplesMatchPlaybackRate { get; set; } = false;

        #endregion

        #region Colours
        /// <summary>
        /// RGB definitions of hitobject combo colors
        /// </summary>
        public List<Colour> ComboColours { get; set; }
        /// <summary>
        /// Color of the outer border of the slider objects
        /// </summary>
        public Colour? SliderBorder { get; set; } = null;
        /// <summary>
        /// Color of the inside of the slider objects
        /// </summary>
        public Colour? SliderTrackOverride { get; set; } = null;

        #endregion

        #region MetaData
        /// <summary>
        /// the title of the song with unicode support. If not present, Title is used.
        /// </summary>
        public string TitleUnicode { get; set; } = "";
        /// <summary>
        /// the name of the song's artist with unicode support. If not present, Artist is used.
        /// </summary>
        public string ArtistUnicode { get; set; } = "";

        #endregion

        #region Editor

        public List<int> Bookmarks { get; set; }
        /// <summary>
        /// is a multiplier for the "Distance Snap" feature.
        /// </summary>
        public double DistanceSpacing { get; set; }
        /// <summary>
        /// specifies the beat division for placing objects.
        /// </summary>
        public int BeatDivisor { get; set; }
        /// <summary>
        /// specifies the size of the grid for the "Grid Snap" feature.
        /// </summary>
        public int GridSize { get; set; }

        /// <summary>
        /// specifies the zoom in the editor timeline.
        /// </summary>
        public float TimelineZoom { get; set; } = 1;

        #endregion

        #region Events

        //Beatmap events
        /// <summary>
        /// The background image
        /// </summary>
        public BackgroundEvent Background { get; set; }
        /// <summary>
        /// Optional background video
        /// </summary>
        public VideoEvent Video { get; set; }
        /// <summary>
        /// Breaks where no hitobjects appear for a certain duration
        /// </summary>
        public List<BreakEvent> BreakPeriods { get; set; }
        /// <summary>
        /// Coloring of the default background
        /// </summary>
        public List<BackgroundColorEvent> BackgroundColorTransformations { get; }
        //storyboard events
        public List<SpriteEvent> BackgroundEvents { get; set; }
        public List<SpriteEvent> FailEvents { get; set; }
        public List<SpriteEvent> PassEvents { get; set; }
        public List<SpriteEvent> ForegroundEvents { get; set; }
        public List<SampleEvent> SampleEvents { get; set; }

        /// <summary>
        /// Not implemented in .osu event section
        /// </summary>
        public Dictionary<string, string> VariablesDictionary { get; set; }

        #endregion

        #region Difficulty 
        /// <summary>
        /// a multiplier for the slider velocity. Default value is 1.4 
        /// </summary>
        public double DifficultySliderMultiplier { get; set; } = 1.4;
        /// <summary>
        /// specifies how often slider ticks appear. Default value is 1.
        /// </summary>
        public float DifficultySliderTickRate { get; set; } = 1;

        #endregion

    }
}