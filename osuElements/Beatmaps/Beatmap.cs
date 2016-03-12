using System;
using System.Collections.Generic;
using System.IO;
using osuElements.Api;
using osuElements.Beatmaps.Events;
using osuElements.Helpers;
using osuElements.IO;
using osuElements.IO.File;
using osuElements.Storyboards;

namespace osuElements.Beatmaps
{
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

            BeatmapFileRepository = osuElements.BeatmapFileRepository;
            IsRead = false;
        }

        public Beatmap(string file)
            : this() {
            FullPath = file;
            ReadFile();
        }

        public int FormatVersion { get; set; }
        public List<TimingPoint> TimingPoints { get; set; }
        public List<HitObject> HitObjects { get; set; }

        public string[] TagsArray
        {
            get { return Tags.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries); }
            set { Tags = value.ToString(","); }
        }
        public string StoryboardFileName => $"{Artist} - {Title} ({Creator}).osb";
        

        #region File
        public IFileRepository<Beatmap> BeatmapFileRepository { get; set; }
        public bool IsRead { get; private set; }
        public string FileName { get; set; }
        public string Directory { get; set; }
        public string FullPath
        {
            get { return Path.Combine(Directory, FileName); }
            set
            {
                Directory = Path.GetDirectoryName(value);
                FileName = Path.GetFileName(value);
            }
        }
        public void ReadFile(ILogger logger = null) {
            BeatmapFileRepository.ReadFile(osuElements.FileReaderFunc(FullPath), this, logger);
            IsRead = true;
        }
        public void WriteFile() {
            BeatmapFileRepository.WriteFile(osuElements.FileWriterFunc(FullPath), this);
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


        public string GetHash(bool forceRenew = false) {
            if (forceRenew || string.IsNullOrWhiteSpace(Hash))
                Hash = osuElements.Md5Func(FullPath);
            return Hash;
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

        public List<Colour> ComboColours { get; set; }
        public Colour? SliderBorder { get; set; } = null;
        public Colour? SliderTrackOverride { get; set; } = null;

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

        public double SliderMultiplier { get; set; }
        public float SliderTickRate { get; set; }
        public string Hash { get; set; }

        #endregion

    }
}