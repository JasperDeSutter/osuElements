using System;
using System.Collections.Generic;
using osuElements.Helpers;
using osuElements.Repositories.File;

namespace osuElements.Skins
{
    public class ManiaSkin
    {
        private int _keys;

        public static MultipleFileSection<ManiaSkin, Skin> ManiaSection() {
            return new MultipleFileSection<ManiaSkin, Skin>(nameof(Skin.ManiaSkins), "Mania",
                new FileLine<ManiaSkin, int>(nameof(Keys), 0),
                new FileLine<ManiaSkin, float>(nameof(ColumnStart), 136),
                new FileLine<ManiaSkin, float>(nameof(ColumnRight), 19),
                new FileLine<ManiaSkin, float>(nameof(BarlineHeight), 1.2f),
                new FileLine<ManiaSkin, int>(nameof(HitPosition), 402),
                new FileLine<ManiaSkin, int>(nameof(LightPosition), 413),
                new FileLine<ManiaSkin, int>(nameof(ScorePosition), 325),
                new FileLine<ManiaSkin, int>(nameof(ComboPosition), 111),
                new FileLine<ManiaSkin, bool>(nameof(JudgementLine), true),
                new FileLine<ManiaSkin, int>(nameof(LightFramePerSecond), 60),
                new FileLine<ManiaSkin, ManiaSpecialStyle>(nameof(SpecialStyle), ManiaSpecialStyle.None),
                new FileLine<ManiaSkin, bool>(nameof(SplitStages), false),
                new FileLine<ManiaSkin, float>(nameof(StageSeparation), 40),
                new FileLine<ManiaSkin, bool>(nameof(SeparateScore), true),
                new FileLine<ManiaSkin, bool>(nameof(KeysUnderNotes), false),
                new FileLine<ManiaSkin, bool>(nameof(UpsideDown), false),
                new ListFileLine<ManiaSkin, float>(nameof(ColumnLineWidth), 2),
                new ListFileLine<ManiaSkin, float>(nameof(ColumnSpacing), 0),
                new ListFileLine<ManiaSkin, float>(nameof(LightingNWidth), 0),
                new ListFileLine<ManiaSkin, float>(nameof(LightingLWidth), 0),
                new ListFileLine<ManiaSkin, float>(nameof(ColumnWidth), 30)
                );

        }

        public ManiaSkin() {
            Colours = new List<ComboColour>();
            ColourLights = new List<ComboColour>();
            ColumnWidth = new List<float>();
            ColumnSpacing = new List<float>();
            ColumnLineWidth = new List<float>();
            LightingLWidth = new List<float>();
            LightingNWidth = new List<float>();
            NoteBodyStyle = new List<NoteBodyStyle>();
            KeyFlipWhenUpsideDown = new List<bool>();
            NoteFlipWhenUpsideDown = new Dictionary<NoteType, List<bool>>();
            foreach (NoteType note in Enum.GetValues(typeof(NoteType))) {
                NoteFlipWhenUpsideDown[note] = new List<bool>();
            }
        }

        //positions and sizes
        public float ColumnStart { get; set; } = 136;
        public float ColumnRight { get; set; } = 19;
        public int HitPosition { get; set; } = 402;
        public int ScorePosition { get; set; } = 325;
        public int ComboPosition { get; set; } = 111;
        public int LightPosition { get; set; } = 413;
        public bool JudgementLine { get; set; } = true;
        public List<float> ColumnWidth { get; set; }
        public List<float> ColumnLineWidth { get; set; }
        public List<float> ColumnSpacing { get; set; }
        public List<float> LightingNWidth { get; set; }
        public List<float> LightingLWidth { get; set; }
        public float BarlineHeight { get; set; } = 1.2f;
        public float WidthForNoteHeightScale { get; set; } = 0;

        //colours
        public List<ComboColour> Colours { get; set; }
        public List<ComboColour> ColourLights { get; set; }
        public ComboColour ColourHold { get; set; } = new ComboColour(255, 199, 51);
        public ComboColour ColourBreak { get; set; } = new ComboColour(255, 0, 0);
        public ComboColour ColourColumnLine { get; set; } = new ComboColour(255, 255, 255);
        public ComboColour ColourBarline { get; set; } = new ComboColour(255, 255, 255);
        public ComboColour ColourJudgementLine { get; set; } = new ComboColour(255, 255, 255);
        public ComboColour ColourKeyWarning { get; set; } = new ComboColour(0, 0, 0);
        //general
        public int Keys
        {
            get { return _keys; }
            set
            {
                _keys = value;
                for (int i = 0; i < _keys; i++) {
                    if (i > 0) ColumnSpacing.Add(0);
                    ColumnLineWidth.Add(2);
                    ColumnWidth.Add(30);
                    LightingLWidth.Add(0);
                    LightingNWidth.Add(0);
                    foreach (var flip in NoteFlipWhenUpsideDown.Values) {
                        flip.Add(true);
                    }
                    NoteBodyStyle.Add(Helpers.NoteBodyStyle.RepeatBottom);
                    KeyFlipWhenUpsideDown.Add(true);
                }
                ColumnLineWidth.Add(2);
            }
        }

        public ManiaSpecialStyle SpecialStyle { get; set; } = ManiaSpecialStyle.None;
        public bool UpsideDown { get; set; } = false;
        public bool SplitStages { get; set; } = false;
        public bool SeparateScore { get; set; } = true;
        public float StageSeparation { get; set; } = 40;
        public bool KeysUnderNotes { get; set; } = false;
        public int LightFramePerSecond { get; set; } = 60;
        public List<NoteBodyStyle> NoteBodyStyle { get; set; }
        public List<bool> KeyFlipWhenUpsideDown { get; set; }
        public Dictionary<NoteType, List<bool>> NoteFlipWhenUpsideDown { get; }

        public override string ToString() {
            return $"{Keys} Keys";
        }
    }
}