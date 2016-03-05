using System.Collections.Generic;
using osuElements.Api;
using osuElements.Helpers;
using osuElements.Storyboards;
using osuElements.Storyboards.Beatmaps;

namespace osuElements
{
    /// <summary>
    /// All the properties in a .osu file, for better readability of the Beatmap class.
    /// </summary>
    public abstract class BeatmapBase : ApiBeatmap, IStoryboardEvents
    {
        public int FormatVersion { get; set; }

        #region General
        //always
        public string AudioFilename { get; set; }
        public string AudioHash { get; set; } = ""; //only in first versions 
        public int AudioLeadIn { get; set; }
        public int PreviewTime { get; set; }
        public bool Countdown { get; set; }
        public SampleSet SampleSet { get; set; }
        public float StackLeniency { get; set; }
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
        public bool WidescreenStoryboard { get; set; } = false;
        public bool SamplesMatchPlaybackRate { get; set; } = false;
        #endregion

        #region Colours
        public List<ComboColour> ComboColours { get; set; }
        public ComboColour? SliderBorder { get; set; } = null;
        public ComboColour? SliderTrackOverride { get; set; } = null;
        #endregion

        #region MetaData

        public string TitleUnicode { get; set; } = "";
        public string ArtistUnicode { get; set; } = "";
        #endregion

        #region Editor
        public List<int> Bookmarks { get; set; }
        public float DistanceSpacing { get; set; }
        public int BeatDivisor { get; set; }
        public int GridSize { get; set; }
        public float TimelineZoom { get; set; }
        #endregion

        #region Events
        //Beatmap events
        public BackgroundEvent Background { get; set; }
        public VideoEvent Video { get; set; }
        public List<BreakEvent> BreakPeriods { get; set; }
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
        public virtual float ApproachRate
        {
            get { return Diff_Approach; }
            set { Diff_Approach = value; }
        }
        public virtual float OverallDifficulty
        {
            get { return Diff_Overall; }
            set { Diff_Overall = value; }
        }
        public virtual float HPDrainRate
        {
            get { return Diff_Drain; }
            set { Diff_Drain = value; }
        }
        public virtual float CircleSize
        {
            get { return Diff_Size; }
            set { Diff_Size = value; }
        }

        public double SliderMultiplier { get; set; }
        public float SliderTickRate { get; set; }
        #endregion
        public List<TimingPoint> TimingPoints { get; set; }
        public List<HitObject> HitObjects { get; set; }


        protected BeatmapBase() {
            HitObjects = new List<HitObject>();
            TimingPoints = new List<TimingPoint>();
            ComboColours = new List<ComboColour>(8);
            Bookmarks = new List<int>();

            BreakPeriods = new List<BreakEvent>();
            BackgroundColorTransformations = new List<BackgroundColorEvent>();

            BackgroundEvents = new List<SpriteEvent>();
            ForegroundEvents = new List<SpriteEvent>();
            FailEvents = new List<SpriteEvent>();
            PassEvents = new List<SpriteEvent>();
            SampleEvents = new List<SampleEvent>();
        }

    }
}
