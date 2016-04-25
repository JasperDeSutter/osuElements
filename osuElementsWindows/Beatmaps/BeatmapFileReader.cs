using System;
using osuElements.Beatmaps.Events;
using osuElements.Helpers;
using osuElements.IO.File;
using osuElements.Storyboards;

namespace osuElements.Beatmaps
{
    public class BeatmapFileReader
    {
        private static bool TryParseVersion(string line, out int result) {
            result = 0;
            if (line.IndexOf('v') < 1) return false;
            result = int.Parse(line.Remove(0, line.LastIndexOf('v') + 1));
            return true;
        }
        public static FileReader<Beatmap> BeatmapReader() {
            var fileFormat = new FileSection<Beatmap>(null,
                new FileLine<Beatmap, int>(b => b.FormatVersion, osuElements.LatestBeatmapVersion) {
                    WriteIfDefault = true,
                    TryParse = TryParseVersion,
                    WriteFunc = i => "osu file format v" + i
                }
                );
            var general = new FileSection<Beatmap>("General",
                new FileLine<Beatmap, string>(b => b.AudioFilename, "") { WriteIfDefault = true },
                new FileLine<Beatmap, string>(b => b.AudioHash, ""),
                new FileLine<Beatmap, int>(b => b.AudioLeadIn) { WriteIfDefault = true },
                new FileLine<Beatmap, int>(b => b.PreviewTime) { WriteIfDefault = true },
                new FileLine<Beatmap, CountDown>(b => b.Countdown) { WriteIfDefault = true, WriteEnumAsInt = true },
                new FileLine<Beatmap, SampleSet>(b => b.SampleSet) { WriteIfDefault = true },
                new FileLine<Beatmap, float>(b => b.StackLeniency, 1) { WriteIfDefault = true },
                new FileLine<Beatmap, GameMode>(b => b.Mode) { WriteIfDefault = true, WriteEnumAsInt = true },
                new FileLine<Beatmap, bool>(b => b.LetterboxInBreaks) { WriteIfDefault = true },
                new FileLine<Beatmap, bool>(b => b.StoryFireInFront),
                new FileLine<Beatmap, bool>(b => b.UseSkinSprites),
                new FileLine<Beatmap, bool>(b => b.AlwaysShowPlayfield),
                new FileLine<Beatmap, OverlayPosition>(b => b.OverlayPosition),
                new FileLine<Beatmap, string>(b => b.SkinPreference),
                new FileLine<Beatmap, bool>(b => b.EpilepsyWarning),
                new FileLine<Beatmap, int>(b => b.CountdownOffset),
                new FileLine<Beatmap, bool>(b => b.SpecialStyle),
                new FileLine<Beatmap, bool>(b => b.WidescreenStoryboard),
                new FileLine<Beatmap, bool>(b => b.SamplesMatchPlaybackRate)
                );
            var editor = new FileSection<Beatmap>("Editor",
                new ListFileLine<Beatmap, int>(b => b.Bookmarks, 0) { WriteIfDefault = true },
                new FileLine<Beatmap, double>(b => b.DistanceSpacing, 1) { WriteIfDefault = true },
                new FileLine<Beatmap, int>(b => b.BeatDivisor, 4) { WriteIfDefault = true },
                new FileLine<Beatmap, int>(b => b.GridSize, 4) { WriteIfDefault = true },
                new FileLine<Beatmap, float>(b => b.TimelineZoom, 1) { WriteIfDefault = true }
                );
            var metadata = new FileSection<Beatmap>("Metadata",
                new FileLine<Beatmap, string>(b => b.Title, "") { WriteIfDefault = true, Format = "{0}:{1}" },
                new FileLine<Beatmap, string>(b => b.TitleUnicode, "") { Format = "{0}:{1}" },
                new FileLine<Beatmap, string>(b => b.Artist, "") { WriteIfDefault = true, Format = "{0}:{1}" },
                new FileLine<Beatmap, string>(b => b.ArtistUnicode, "") { Format = "{0}:{1}" },
                new FileLine<Beatmap, string>(b => b.Creator, "") { WriteIfDefault = true, Format = "{0}:{1}" },
                new FileLine<Beatmap, string>(b => b.Version, "") { WriteIfDefault = true, Format = "{0}:{1}" },
                new FileLine<Beatmap, string>(b => b.Source, "") { WriteIfDefault = true, Format = "{0}:{1}" },
                new FileLine<Beatmap, string>(b => b.Tags, "") { WriteIfDefault = true, Format = "{0}:{1}" },
                new FileLine<Beatmap, int>(b => b.BeatmapId) { Key = "BeatmapID", Format = "{0}:{1}" },
                new FileLine<Beatmap, int>(b => b.BeatmapSetId) { Key = "BeatmapSetID", Format = "{0}:{1}" }
                );
            var difficulty = new FileSection<Beatmap>("Difficulty",
                new FileLine<Beatmap, float>(b => b.DifficultyHpDrainRate, 5) {
                    WriteIfDefault = true,
                    Key = "HPDrainRate",
                    Format = "{0}:{1}"
                },
                new FileLine<Beatmap, float>(b => b.DifficultyCircleSize, 5) {
                    WriteIfDefault = true,
                    Key = "CircleSize",
                    Format = "{0}:{1}"
                },
                new FileLine<Beatmap, float>(b => b.DifficultyOverall, 5) {
                    WriteIfDefault = true,
                    Key = "OverallDifficulty",
                    Format = "{0}:{1}"
                },
                new FileLine<Beatmap, float>(b => b.DifficultyApproachRate, 5) {
                    WriteIfDefault = true,
                    Key = "ApproachRate",
                    Format = "{0}:{1}"
                },
                new FileLine<Beatmap, double>(b => b.DifficultySliderMultiplier, 1.4) { WriteIfDefault = true, Format = "{0}:{1}" },
                new FileLine<Beatmap, float>(b => b.DifficultySliderTickRate, 1) { WriteIfDefault = true, Format = "{0}:{1}" }
                );
            var events = new StoryboardSection<Beatmap>("Events",
                new FileLine<Beatmap, BackgroundEvent>(b => b.Background) {
                    TryParse = EventBase.TryParse,
                    WriteFunc = b => b.ToString()
                },
                new FileLine<Beatmap, VideoEvent>(b => b.Video) {
                    TryParse = EventBase.TryParse,
                    WriteFunc = b => b.ToString()
                },
                new WriteLine<Beatmap>("//Background Colour Transformations"),
                new MultiFileLine<Beatmap, BackgroundColorEvent>(b => b.BackgroundColorTransformations, null) {
                    TryParse = EventBase.TryParse,
                    WriteFunc = b => b.ToString()
                },
                new WriteLine<Beatmap>("//Break Periods"),
                //new FileLine<Beatmap, object>(b=>b.Artist)) { Key = "ZZZZZZZZZZ", WriteFunc = o => "//Break Periods", WriteIfDefault = true },
                new MultiFileLine<Beatmap, BreakEvent>(b => b.BreakPeriods, null) {
                    TryParse = EventBase.TryParse,
                    WriteFunc = b => b.ToString()
                }
                ) { UseVariables = false };
            var timingpoints = new CollectionFileSection<TimingPoint, Beatmap>(b => b.TimingPoints,
                "TimingPoints",
                TimingPoint.Parse, t => t.ToString());
            var colours = new FileSection<Beatmap>("Colours",
                new MultiFileLine<Beatmap, Colour>(b => b.ComboColours, null) { Key = "Combo", Format = "{0} : {1}" },
                new FileLine<Beatmap, Colour?>(b => b.SliderBorder),
                new FileLine<Beatmap, Colour?>(b => b.SliderTrackOverride)
                );
            var hitobjects = new CollectionFileSection<HitObject, Beatmap>(b => b.HitObjects, "HitObjects",
                HitObject.Parse, t => t.ToString());
            return new FileReader<Beatmap>(fileFormat, general, editor, metadata, difficulty, events, timingpoints,
                colours, hitobjects);
        }
    }
}