using System.Collections.Generic;
using osuElements.Repositories;

namespace osuElements.Skins
{
    public class Skin
    {
        public static IFileRepository<Skin> SkinFileRepository { private get; set; }


        private string _fileName;

        public string Name { get; set; }
        public string Author { get; set; }
        public bool SliderBallFlip { get; set; }
        public bool CursorRotate { get; set; }
        public bool CursorExpand { get; set; }
        public bool CursorCentre { get; set; }
        public int SliderBallFrames { get; set; }
        public bool HitCirlceOverlayAboveNumber { get; set; }
        public bool SpinnerFadePlayField { get; set; }
        public bool SpinnerNoBlink { get; set; }
        public int AnimationFramerate { get; set; }
        public bool AllowSliderBallTint { get; set; }
        public bool CurosrTrailRotate { get; set; }
        public List<int> CustomComboBurstSounds { get; set; }
        public bool ComboBurstRandom { get; set; }
        public int SliderStyle { get; set; }
        public List<ComboColor> ComboColors { get; set; }
        public ComboColor? MenuGlow { get; set; }
        public ComboColor? SliderBall { get; set; }
        public ComboColor? SliderBorder { get; set; }
        public ComboColor? SliderTrackOverride { get; set; }
        public ComboColor? SpinnerApproachCircle { get; set; }
        public ComboColor? SongSelectActiveText { get; set; }
        public ComboColor? SongSelectInactiveText { get; set; }
        public ComboColor? StarBreakAdditive { get; set; }
        public string HitCirclePrefix { get; set; }
        public int HitCircleOverlap { get; set; }
        public string ScorePrefix { get; set; }
        public int ScoreOverlap { get; set; }
        
        public Skin(string fileName) {
            ComboColors = new List<ComboColor>();
            CustomComboBurstSounds = new List<int>();
            _fileName = fileName;
            SkinFileRepository.ReadFile(fileName, this);
        }
    }
}
