using System.Collections.Generic;
using osuElements.Helpers;
using osuElements.Repositories;
using osuElements.Repositories.File;

namespace osuElements.Skins
{
    public class Skin
    {
        public static FileReader<Skin> FileReader() {
            var general = new FileSection<Skin>("General",
                new FileLine<Skin, string>(nameof(Name), "") { WriteIfDefault = true },
                new FileLine<Skin, string>(nameof(Author), "") { WriteIfDefault = true },
                new FileLine<Skin, float>(nameof(Version), osuElements.LatestSkinVersion) { ReadFunc = s => s == "latest" ? osuElements.LatestSkinVersion : float.Parse(s, Constants.IO.CULTUREINFO), WriteIfDefault = true },
                new FileLine<Skin, bool>(nameof(SliderBallFlip), true),
                new FileLine<Skin, bool>(nameof(CursorRotate), true),
                new FileLine<Skin, bool>(nameof(CursorExpand), true),
                new FileLine<Skin, bool>(nameof(CursorCentre), true),
                new FileLine<Skin, bool>(nameof(CursorTrailRotate), true),
                new FileLine<Skin, int>(nameof(SliderBallFrames), 10),
                new FileLine<Skin, bool>(nameof(HitCircleOverlayAboveNumber), true),
                new FileLine<Skin, bool>(nameof(SpinnerFrequencyModulate), true),
                new FileLine<Skin, bool>(nameof(LayeredHitsounds), true),
                new FileLine<Skin, bool>(nameof(SpinnerFadePlayField), true),
                new FileLine<Skin, bool>(nameof(SpinnerNoBlink), false),
                new FileLine<Skin, bool>(nameof(AllowSliderBallTint), false),
                new FileLine<Skin, int>(nameof(AnimationFramerate), 60),
                new ListFileLine<Skin, int>(nameof(CustomComboBurstSounds), new List<int>(new[] { 75, 100, 200, 300 })),
                new FileLine<Skin, bool>(nameof(ComboBurstRandom), false),
                new FileLine<Skin, SliderStyle>(nameof(SliderStyle), SliderStyle.Transparent)
                );
            var colours = new FileSection<Skin>("Colours",
                new FileLine<Skin, ComboColour>(nameof(SongSelectActiveText), new ComboColour(0, 0, 0)),
                new FileLine<Skin, ComboColour>(nameof(SongSelectInactiveText), new ComboColour(255, 255, 255)),
                new FileLine<Skin, ComboColour>(nameof(StarBreakAdditive), new ComboColour(255, 182, 193)),
                new FileLine<Skin, ComboColour>(nameof(MenuGlow), new ComboColour(0, 78, 255)),
                new FileLine<Skin, ComboColour>(nameof(SliderBall), new ComboColour(2, 170, 255)),
                new FileLine<Skin, ComboColour?>(nameof(SliderTrackOverride), null),
                new FileLine<Skin, ComboColour>(nameof(SpinnerBackground), new ComboColour(255, 255, 255)),
                new FileLine<Skin, ComboColour>(nameof(SpinnerApproachCircle), new ComboColour(77, 139, 217)),
                new FileLine<Skin, ComboColour>(nameof(SliderBorder), new ComboColour(255, 255, 255)),
                new FileLine<Skin, ComboColour>(nameof(InputOverlayText), new ComboColour(0, 0, 0))
                );
            var fonts = new FileSection<Skin>("Fonts",
                new FileLine<Skin, string>(nameof(HitCirclePrefix), "default"),
                new FileLine<Skin, int>(nameof(HitCircleOverlap), -2),
                new FileLine<Skin, string>(nameof(ScorePrefix), "score"),
                new FileLine<Skin, int>(nameof(ScoreOverlap), -2),
                new FileLine<Skin, string>(nameof(ComboPrefix), "score"),
                new FileLine<Skin, int>(nameof(ComboOverlap), -2)
                );
            var ctb = new FileSection<Skin>("CatchTheBeat",
                new FileLine<Skin, ComboColour>(nameof(HyperDash), new ComboColour(255, 0, 0)),
                new FileLine<Skin, ComboColour>(nameof(HyperDashFruit), new ComboColour(255, 0, 0)),
                new FileLine<Skin, ComboColour>(nameof(HyperDashAfterImage), new ComboColour(255, 0, 0))
                );
            return new FileReader<Skin>(general, colours, fonts, ctb, ManiaSkin.ManiaSection());
        }
        public string FileName { get; set; }
        public List<ManiaSkin> ManiaSkins { get; private set; }

        public Skin(string fileName) : this() {
            FileName = fileName;
            SkinFileRepository.ReadFile(osuElements.FileReaderFunc(fileName), this);
        }

        public Skin() {
            Version = osuElements.LatestSkinVersion;
            Combo = new List<ComboColour?>(8);
            for (int i = 0; i < 8; i++) {
                Combo[i] = null;
            }
            ManiaSkins = new List<ManiaSkin>();
            SkinFileRepository = osuElements.SkinFileRepository;
        }

        public static IFileRepository<Skin> SkinFileRepository { private get; set; }

        #region File Properties
        //General
        public string Name { get; set; } = "";
        public string Author { get; set; } = "";
        public bool SliderBallFlip { get; set; } = true;
        public bool CursorRotate { get; set; } = true;
        public bool CursorExpand { get; set; } = true;
        public bool CursorCentre { get; set; } = true;
        public int SliderBallFrames { get; set; } = 10;
        public bool HitCircleOverlayAboveNumber { get; set; } = true;
        public bool SpinnerFrequencyModulate { get; set; } = true; //
        public bool LayeredHitsounds { get; set; } = true; //
        public bool SpinnerFadePlayField { get; set; } = true;
        public bool SpinnerNoBlink { get; set; } = false;
        public bool AllowSliderBallTint { get; set; } = false;
        public int AnimationFramerate { get; set; } = -1;
        public bool CursorTrailRotate { get; set; } = true;
        public List<int> CustomComboBurstSounds { get; set; } = new List<int>(new[] { 50, 75, 100, 200, 300 });
        public bool ComboBurstRandom { get; set; } = true;
        public SliderStyle SliderStyle { get; set; } = SliderStyle.Transparent;
        public float Version { get; set; }
        //Colours
        public List<ComboColour?> Combo { get; set; }
        public List<ComboColour> Triangle { get; set; }
        public ComboColour MenuGlow { get; set; } = new ComboColour(0, 78, 255);
        public ComboColour SliderBall { get; set; } = new ComboColour(2, 170, 255);
        public ComboColour SliderBorder { get; set; } = new ComboColour(255, 255, 255);
        public ComboColour? SliderTrackOverride { get; set; }
        public ComboColour SpinnerApproachCircle { get; set; } = new ComboColour(77, 139, 217);
        public ComboColour SpinnerBackground { get; set; } = new ComboColour(255, 255, 255);
        public ComboColour SongSelectActiveText { get; set; } = new ComboColour(0, 0, 0);
        public ComboColour SongSelectInactiveText { get; set; } = new ComboColour(255, 255, 255);
        public ComboColour StarBreakAdditive { get; set; } = new ComboColour(255, 182, 193);
        public ComboColour InputOverlayText { get; set; } = new ComboColour(0, 0, 0);
        //Fonts
        public string HitCirclePrefix { get; set; } = "default";
        public int HitCircleOverlap { get; set; } = -2;
        public string ScorePrefix { get; set; } = "score";
        public int ScoreOverlap { get; set; } = -2;
        public string ComboPrefix { get; set; } = "score";
        public int ComboOverlap { get; set; } = -2;
        //CtB
        public ComboColour HyperDash { get; set; } = new ComboColour(255, 0, 0);
        public ComboColour HyperDashAfterImage { get; set; } = new ComboColour(255, 0, 0);
        public ComboColour HyperDashFruit { get; set; } = new ComboColour(255, 0, 0);
        #endregion

        public override string ToString() {
            return $"{Author} - {Name}";
        }
    }
}