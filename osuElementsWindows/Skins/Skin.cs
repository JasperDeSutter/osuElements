using System.Collections.Generic;
using System.IO;
using osuElements.Helpers;
using osuElements.IO;
using osuElements.IO.File;

namespace osuElements.Skins
{
    public class Skin : IFileModel
    {

        public Skin(string directory) : this() {
            Directory = directory;
            ReadFile();
        }

        public Skin() {
            Version = osuElements.LatestSkinVersion;
            Combo = new List<Colour?>(8);
            for (int i = 0; i < 8; i++) {
                Combo.Add(null);
            }
            ManiaSkins = new List<ManiaSkin>();
            SkinFileRepository = osuElements.SkinFileRepository;
        }
        #region File
        public static IFileRepository<Skin> SkinFileRepository { private get; set; }
        public bool IsRead { get; private set; }
        public string FileName { get; set; } = "skin.ini";
        public string Directory { get; set; }

        public string RootedDirectory
            => Path.IsPathRooted(Directory) ? Directory : Path.Combine(osuElements.OsuSkinsDirectory, Directory);
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
            SkinFileRepository.ReadFile(osuElements.ReadStream(FullPath), this, logger);
            IsRead = true;
        }
        public void WriteFile() {
            SkinFileRepository.WriteFile(osuElements.WriteStream(FullPath), this);
        }
        #endregion


        #region Properties
        //General
        public string Name { get; set; } = "";
        public string Author { get; set; } = "";
        public bool SliderBallFlip { get; set; } = true;
        public bool CursorRotate { get; set; } = true;
        public bool CursorExpand { get; set; } = true;
        public bool CursorCentre { get; set; } = true;
        public int SliderBallFrames { get; set; } = 10;
        public bool HitCircleOverlayAboveNumber { get; set; } = true;
        public bool SpinnerFrequencyModulate { get; set; } = true;
        public bool LayeredHitsounds { get; set; } = true;
        public bool SpinnerFadePlayField { get; set; } = true;
        public bool SpinnerNoBlink { get; set; } = false;
        public bool AllowSliderBallTint { get; set; } = false;
        public int AnimationFramerate { get; set; } = -1;
        public bool CursorTrailRotate { get; set; } = true;
        public List<int> CustomComboBurstSounds { get; set; } = new List<int> { 50, 75, 100, 200, 300 };
        public bool ComboBurstRandom { get; set; } = true;
        public SliderStyle SliderStyle { get; set; } = SliderStyle.Transparent;
        public float Version { get; set; }
        //Colours
        public List<Colour?> Combo { get; set; }
        public List<Colour> Triangle { get; set; }
        public Colour MenuGlow { get; set; } = new Colour(0, 78, 255);
        public Colour SliderBall { get; set; } = new Colour(2, 170, 255);
        public Colour SliderBorder { get; set; } = new Colour(255, 255, 255);
        public Colour? SliderTrackOverride { get; set; }
        public Colour SpinnerApproachCircle { get; set; } = new Colour(77, 139, 217);
        public Colour SpinnerBackground { get; set; } = new Colour(255, 255, 255);
        public Colour SongSelectActiveText { get; set; } = new Colour(0, 0, 0);
        public Colour SongSelectInactiveText { get; set; } = new Colour(255, 255, 255);
        public Colour StarBreakAdditive { get; set; } = new Colour(255, 182, 193);
        public Colour InputOverlayText { get; set; } = new Colour(0, 0, 0);
        //Fonts
        public string HitCirclePrefix { get; set; } = "default";
        public int HitCircleOverlap { get; set; } = -2;
        public string ScorePrefix { get; set; } = "score";
        public int ScoreOverlap { get; set; } = -2;
        public string ComboPrefix { get; set; } = "score";
        public int ComboOverlap { get; set; } = -2;
        //CtB
        public Colour HyperDash { get; set; } = new Colour(255, 0, 0);
        public Colour HyperDashAfterImage { get; set; } = new Colour(255, 0, 0);
        public Colour HyperDashFruit { get; set; } = new Colour(255, 0, 0);
        //Mania
        public List<ManiaSkin> ManiaSkins { get; private set; }
        #endregion

        public override string ToString() {
            return $"{Author} - {Name}";
        }
    }
}