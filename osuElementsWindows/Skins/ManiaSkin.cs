using System;
using System.Collections.Generic;

namespace osuElements.Skins
{
    public class ManiaSkin
    {
        private int _keys;

        public ManiaSkin() {
            Colours = new List<Colour>();
            ColourLights = new List<Colour>();
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
        public List<Colour> Colours { get; set; }
        public List<Colour> ColourLights { get; set; }
        public Colour ColourHold { get; set; } = new Colour(255, 199, 51);
        public Colour ColourBreak { get; set; } = new Colour(255, 0, 0);
        public Colour ColourColumnLine { get; set; } = new Colour(255, 255, 255);
        public Colour ColourBarline { get; set; } = new Colour(255, 255, 255);
        public Colour ColourJudgementLine { get; set; } = new Colour(255, 255, 255);
        public Colour ColourKeyWarning { get; set; } = new Colour(0, 0, 0);
        //general
        public int Keys
        {
            get { return _keys; }
            set
            {
                if (_keys == value) return;
                _keys = value;
                ColumnWidth = new List<float>(_keys-1);
                ColumnLineWidth = new List<float>(_keys-1);
                ColumnSpacing = new List<float>(_keys-1);
                LightingNWidth = new List<float>(_keys-1);
                ColumnWidth = new List<float>(_keys-1);
                for (var i = 0; i < _keys; i++) {
                    if (i > 0) ColumnSpacing.Add(0);
                    ColumnLineWidth.Add(2);
                    ColumnWidth.Add(30);
                    LightingLWidth.Add(0);
                    LightingNWidth.Add(0);
                    foreach (var flip in NoteFlipWhenUpsideDown.Values) {
                        flip.Add(true);
                    }
                    NoteBodyStyle.Add(Skins.NoteBodyStyle.RepeatBottom);
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
        public Dictionary<NoteType, List<bool>> NoteFlipWhenUpsideDown { get; } //not sure about this being a good solution

        public override string ToString() {
            return $"{Keys} Keys";
        }
    }
}