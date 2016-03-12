using System;
using System.Collections.Generic;
using osuElements.Helpers;
using osuElements.IO.File;

namespace osuElements.Skins
{
    public class SkinFileReader
    {
        public static FileReader<Skin> SkinReader() {
            var general = new FileSection<Skin>("General",
                new FileLine<Skin, string>(s => s.Name, "") { WriteIfDefault = true },
                new FileLine<Skin, string>(s => s.Author, "") { WriteIfDefault = true },
                new FileLine<Skin, float>(s => s.Version, osuElements.LatestSkinVersion) { ReadFunc = s => s == "latest" ? osuElements.LatestSkinVersion : Single.Parse(s, Constants.IO.CULTUREINFO), WriteIfDefault = true },
                new FileLine<Skin, bool>(s => s.SliderBallFlip, true),
                new FileLine<Skin, bool>(s => s.CursorRotate, true),
                new FileLine<Skin, bool>(s => s.CursorExpand, true),
                new FileLine<Skin, bool>(s => s.CursorCentre, true),
                new FileLine<Skin, bool>(s => s.CursorTrailRotate, true),
                new FileLine<Skin, int>(s => s.SliderBallFrames, 10),
                new FileLine<Skin, bool>(s => s.HitCircleOverlayAboveNumber, true),
                new FileLine<Skin, bool>(s => s.SpinnerFrequencyModulate, true),
                new FileLine<Skin, bool>(s => s.LayeredHitsounds, true),
                new FileLine<Skin, bool>(s => s.SpinnerFadePlayField, true),
                new FileLine<Skin, bool>(s => s.SpinnerNoBlink, false),
                new FileLine<Skin, bool>(s => s.AllowSliderBallTint, false),
                new FileLine<Skin, int>(s => s.AnimationFramerate, 60),
                new ListFileLine<Skin, int>(s => s.CustomComboBurstSounds, new List<int>(new[] { 75, 100, 200, 300 })),
                new FileLine<Skin, bool>(s => s.ComboBurstRandom, false),
                new FileLine<Skin, SliderStyle>(s => s.SliderStyle, SliderStyle.Transparent)
                );
            var colours = new FileSection<Skin>("Colours",
                new FileLine<Skin, Colour>(s => s.SongSelectActiveText, new Colour(0, 0, 0)),
                new FileLine<Skin, Colour>(s => s.SongSelectInactiveText, new Colour(255, 255, 255)),
                new FileLine<Skin, Colour>(s => s.StarBreakAdditive, new Colour(255, 182, 193)),
                new FileLine<Skin, Colour>(s => s.MenuGlow, new Colour(0, 78, 255)),
                new FileLine<Skin, Colour>(s => s.SliderBall, new Colour(2, 170, 255)),
                new FileLine<Skin, Colour?>(s => s.SliderTrackOverride, null),
                new FileLine<Skin, Colour>(s => s.SpinnerBackground, new Colour(255, 255, 255)),
                new FileLine<Skin, Colour>(s => s.SpinnerApproachCircle, new Colour(77, 139, 217)),
                new FileLine<Skin, Colour>(s => s.SliderBorder, new Colour(255, 255, 255)),
                new FileLine<Skin, Colour>(s => s.InputOverlayText, new Colour(0, 0, 0))
                );
            var fonts = new FileSection<Skin>("Fonts",
                new FileLine<Skin, string>(s => s.HitCirclePrefix, "default"),
                new FileLine<Skin, int>(s => s.HitCircleOverlap, -2),
                new FileLine<Skin, string>(s => s.ScorePrefix, "score"),
                new FileLine<Skin, int>(s => s.ScoreOverlap, -2),
                new FileLine<Skin, string>(s => s.ComboPrefix, "score"),
                new FileLine<Skin, int>(s => s.ComboOverlap, -2)
                );
            var ctb = new FileSection<Skin>("CatchTheBeat",
                new FileLine<Skin, Colour>(s => s.HyperDash, new Colour(255, 0, 0)),
                new FileLine<Skin, Colour>(s => s.HyperDashFruit, new Colour(255, 0, 0)),
                new FileLine<Skin, Colour>(s => s.HyperDashAfterImage, new Colour(255, 0, 0))
                );
            return new FileReader<Skin>(general, colours, fonts, ctb, ManiaSection());
        }

        internal static MultipleFileSection<ManiaSkin, Skin> ManiaSection() {
            return new MultipleFileSection<ManiaSkin, Skin>(s => s.ManiaSkins, "Mania",
                new FileLine<ManiaSkin, int>(s => s.Keys, 0),
                new FileLine<ManiaSkin, float>(s => s.ColumnStart, 136),
                new FileLine<ManiaSkin, float>(s => s.ColumnRight, 19),
                new FileLine<ManiaSkin, float>(s => s.BarlineHeight, 1.2f),
                new FileLine<ManiaSkin, int>(s => s.HitPosition, 402),
                new FileLine<ManiaSkin, int>(s => s.LightPosition, 413),
                new FileLine<ManiaSkin, int>(s => s.ScorePosition, 325),
                new FileLine<ManiaSkin, int>(s => s.ComboPosition, 111),
                new FileLine<ManiaSkin, bool>(s => s.JudgementLine, true),
                new FileLine<ManiaSkin, int>(s => s.LightFramePerSecond, 60),
                new FileLine<ManiaSkin, ManiaSpecialStyle>(s => s.SpecialStyle, ManiaSpecialStyle.None),
                new FileLine<ManiaSkin, bool>(s => s.SplitStages, false),
                new FileLine<ManiaSkin, float>(s => s.StageSeparation, 40),
                new FileLine<ManiaSkin, bool>(s => s.SeparateScore, true),
                new FileLine<ManiaSkin, bool>(s => s.KeysUnderNotes, false),
                new FileLine<ManiaSkin, bool>(s => s.UpsideDown, false),
                new ListFileLine<ManiaSkin, float>(s => s.ColumnLineWidth, 2),
                new ListFileLine<ManiaSkin, float>(s => s.ColumnSpacing, 0),
                new ListFileLine<ManiaSkin, float>(s => s.LightingNWidth, 0),
                new ListFileLine<ManiaSkin, float>(s => s.LightingLWidth, 0),
                new ListFileLine<ManiaSkin, float>(s => s.ColumnWidth, 30)
                );

        }
    }
}