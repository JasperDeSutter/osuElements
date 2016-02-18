using System.Collections.Generic;
using osuElements.Helpers;
using osuElements.Storyboards;

namespace osuElements.Other_Models
{
    /// <summary>
    /// All the properties in a .osu file, for better readability of the Beatmap class.
    /// </summary>
    public abstract class BeatmapBase
    {
        public int FormatVersion { get; set; }

        #region General
        //always
        public string AudioFilename { get; set; }
        public string AudioHash = ""; //only in first versions 
        public int AudioLeadIn { get; set; }
        //EditorBookmarks -> to Editor
        public int PreviewTime { get; set; }
        public SampleSet SampleSet { get; set; }
        public bool Countdown { get; set; }
        public float StackLeniency { get; set; }
        public GameMode Mode { get; set; }
        public bool LetterboxInBreaks { get; set; }
        //situational
        public bool StoryFireInFront = false;
        public bool UseSkinSprites = false;
        public bool AlwaysShowPlayfield = false;
        public OverlayPosition OverlayPosition = OverlayPosition.NoChange;
        public string SkinPreference;
        public bool EpilepsyWarning = false;
        public int CountdownOffset = 0;
        /// <summary>
        /// For Mania beatmaps only, leftmost column will be used for turntable
        /// </summary>
        public bool SpecialStyle = false;
        public bool WidescreenStoryboard = false;
        public bool SamplesMatchPlaybackRate = false;
        #endregion

        #region Colours
        public ComboColor[] ComboColors { get; set; }
        public ComboColor? SliderBorder = null;
        public ComboColor? SliderTrackOverride = null;
        #endregion

        #region MetaData
        public string Title { get; set; }
        public string TitleUnicode { get; set; }
        public string Artist { get; set; }
        public string ArtistUnicode { get; set; }
        public string Creator { get; set; }
        public string Version { get; set; }
        public string Source { get; set; }
        public string Tags { get; set; }
        public int BeatmapId { get; set; }
        public int BeatmapSetId { get; set; }
        #endregion

        #region Editor
        public List<int> Bookmarks;
        public float DistanceSpacing { get; set; }
        public int BeatDivisor { get; set; }
        public int GridSize { get; set; }
        public float TimelineZoom { get; set; }
        #endregion

        #region Events
        //Beatmap events
        public BackgroundEvent Background;
        public VideoEvent Video;
        public List<BreakEvent> BreakPeriods;
        public List<BackgroundColorEvent> BackgroundColorTransformations;
        //storyboard events
        public List<SpriteEvent> BackgroundEvents;
        public List<SpriteEvent> FailEvents;
        public List<SpriteEvent> PassEvents;
        public List<SpriteEvent> ForegroundEvents;
        public List<SampleEvent> SampleEvents;
        #endregion

        #region Difficulty 
        protected float Ar;
        public virtual float ApproachRate {
            get { return Ar; }
            set { Ar = value; }
        }
        protected float Od;
        public virtual float OverallDifficulty {
            get { return Od; }
            set { Od = value; }
        }
        protected float Hp;
        public virtual float HPDrainRate {
            get { return Hp; }
            set { Hp = value; }
        }
        protected float Cs;
        public virtual float CircleSize {
            get { return Cs; }
            set { Cs = value; }
        }

        public double SliderMultiplier { get; set; }
        public float SliderTickRate { get; set; }
        #endregion
        public List<TimingPoint> TimingPoints { get; set; }
        public List<HitObject> HitObjects { get; set; }
        protected BeatmapBase() {
            HitObjects = new List<HitObject>();
            TimingPoints = new List<TimingPoint>();
            ComboColors = new ComboColor[8];

            BackgroundEvents = new List<SpriteEvent>();
            ForegroundEvents = new List<SpriteEvent>();
            BreakPeriods = new List<BreakEvent>();
            BackgroundColorTransformations = new List<BackgroundColorEvent>();
            FailEvents = new List<SpriteEvent>();
            PassEvents = new List<SpriteEvent>();
            SampleEvents = new List<SampleEvent>();

            BackgroundColorTransformations = new List<BackgroundColorEvent>();
            Bookmarks = new List<int>();
        }
    }
}
