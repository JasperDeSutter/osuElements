using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using osuElements.Helpers;
using osuElements.Storyboards;
using osuElements.Storyboards.Beatmaps;
using static osuElements.Helpers.Constants;
using Enum = System.Enum;

namespace osuElements.Repositories
{

    public class BeatmapFileRepository : IFileRepository<BeatmapBase>
    {
        //Defines methods directly related to a beatmap instance, such as reading from the .osu file.

        public void ReadFile(string path, BeatmapBase result) {
            var section = "";
            ITransformable lastEvent = null;
            using (var sr = new StreamReader(osuElements.FileReaderFunc(path))) {
                var line = sr.ReadLine();
                if (line == null) return;
                if (line.StartsWith("osu"))
                    result.FormatVersion = Convert.ToInt32(line.Split(new[] { 'v', Splitter.Space }, StringSplitOptions.RemoveEmptyEntries)[3]);
                else return;
                line = sr.ReadLine();
                var hitobjects = new List<HitObject>();
                var timingPoints = new List<TimingPoint>();
                while (line != null) {
                    if (line == "" || line.StartsWith("//")) {
                        line = sr.ReadLine();
                        continue;
                    }
                    if (line.StartsWith(new string(Splitter.Bracket))) {
                        section = line;
                        line = sr.ReadLine();
                        continue;
                    }
                    string[] parts;
                    switch (section) {
                        #region General
                        case "[General]":
                            parts = line.Split(Splitter.Colon, StringSplitOptions.RemoveEmptyEntries);
                            parts[1] = parts[1].Trim();
                            switch (parts[0]) {

                                case "AudioFilename":
                                    result.AudioFilename = line.Substring(line.IndexOf(':') + 2);
                                    break;
                                case "AudioLeadIn":
                                    result.AudioLeadIn = Convert.ToInt32(parts[1]);
                                    break;
                                case "PreviewTime":
                                    result.PreviewTime = Convert.ToInt32(parts[1]);
                                    break;
                                case "Countdown":
                                    result.Countdown = parts[1] == "1";
                                    break;
                                case "SampleSet":
                                    result.SampleSet = (SampleSet)Enum.Parse(typeof(SampleSet), parts[1]);
                                    break;
                                case "StackLeniency":
                                    result.StackLeniency = float.Parse(parts[1], IO.CULTUREINFO);
                                    break;
                                case "Mode":
                                    result.Mode = (GameMode)Convert.ToInt32(parts[1]);
                                    break;
                                case "LetterboxInBreaks":
                                    result.LetterboxInBreaks = Convert.ToBoolean(int.Parse(parts[1]));
                                    break;
                                case "WidescreenStoryboard":
                                    result.WidescreenStoryboard = parts[1] == "1";
                                    break;
                                case ("EditorBookmarks"): //only in first versions
                                    foreach (var bookmark in parts[1].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)) {
                                        result.Bookmarks.Add(int.Parse(bookmark));
                                    }
                                    break;
                                case ("AudioHash"):
                                    result.AudioHash = parts[1];
                                    break;
                                //non defaults below
                                case "StoryFireInFront":
                                    result.StoryFireInFront = parts[1] == "1";
                                    break;
                                case "UseSkinSprites":
                                    result.UseSkinSprites = parts[1] == "1";
                                    break;
                                case "AlwaysShowPlayfield":
                                    result.AlwaysShowPlayfield = parts[1] == "1";
                                    break;
                                case "OverlayPosition":
                                    result.OverlayPosition = (OverlayPosition)Enum.Parse(typeof(OverlayPosition), parts[1]);
                                    break;
                                case "SkinPreference":
                                    result.SkinPreference = parts[1];
                                    break;
                                case "EpilepsyWarning":
                                    result.EpilepsyWarning = parts[1] == "1";
                                    break;
                                case "CountdownOffset":
                                    result.CountdownOffset = Convert.ToInt32(parts[1]);
                                    break;
                                case "SamplesMatchPlaybackRate":
                                    result.SamplesMatchPlaybackRate = parts[1] == "1";
                                    break;
                                //mania only
                                case "SpecialStyle":
                                    result.SpecialStyle = parts[1] == "1";
                                    break;
                            }
                            break;
                        #endregion

                        #region Editor
                        case "[Editor]":
                            parts = line.Split(Splitter.Colon, StringSplitOptions.RemoveEmptyEntries);
                            parts[1] = parts[1].Trim();
                            switch (parts[0]) {
                                case ("Bookmarks"):
                                    if (parts.Length > 1) {
                                        var bms = parts[1].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                        if (bms != null) {
                                            foreach (var bookmark in bms) {
                                                result.Bookmarks.Add(int.Parse(bookmark));
                                            }
                                        }
                                    }
                                    break;
                                case ("DistanceSpacing"):
                                    result.DistanceSpacing = float.Parse(parts[1], IO.CULTUREINFO);
                                    break;
                                case ("BeatDivisor"):
                                    result.BeatDivisor = int.Parse(parts[1]);
                                    break;
                                case ("GridSize"):
                                    result.GridSize = int.Parse(parts[1]);
                                    break;
                                case ("TimelineZoom"):
                                    result.TimelineZoom = float.Parse(parts[1], IO.CULTUREINFO);
                                    break;
                            }
                            break;
                        #endregion

                        #region Metadata
                        case "[Metadata]":
                            parts = line.Split(Splitter.Colon);
                            switch (parts[0]) {
                                case ("Title"):
                                    result.Title = parts[1];
                                    break;
                                case ("TitleUnicode"):
                                    result.TitleUnicode = parts[1];
                                    break;
                                case ("Artist"):
                                    result.Artist = parts[1];
                                    break;
                                case ("ArtistUnicode"):
                                    result.ArtistUnicode = parts[1];
                                    break;
                                case ("Creator"):
                                    result.Creator = parts[1];
                                    break;
                                case ("Version"):
                                    result.Version = parts[1];
                                    break;
                                case ("Source"):
                                    result.Source = parts[1];
                                    break;
                                case ("Tags"):
                                    result.Tags = parts[1];
                                    break;
                                case ("BeatmapID"):
                                    result.Beatmap_Id = int.Parse(parts[1]);
                                    break;
                                case ("BeatmapSetID"):
                                    result.BeatmapSet_Id = int.Parse(parts[1]);
                                    break;
                            }
                            break;
                        #endregion

                        #region Difficulty

                        case "[Difficulty]":
                            parts = line.Split(Splitter.Colon);
                            switch (parts[0]) {
                                case "HpDrainRate":
                                    result.HPDrainRate = float.Parse(parts[1], IO.CULTUREINFO);
                                    break;
                                case "CircleSize":
                                    result.CircleSize = float.Parse(parts[1], IO.CULTUREINFO);
                                    break;
                                case "OverallDifficulty":
                                    result.OverallDifficulty = float.Parse(parts[1], IO.CULTUREINFO);
                                    break;
                                case "ApproachRate":
                                    result.ApproachRate = float.Parse(parts[1], IO.CULTUREINFO);
                                    break;
                                case "SliderMultiplier":
                                    result.SliderMultiplier = Convert.ToDouble(parts[1], IO.CULTUREINFO);
                                    break;
                                case "SliderTickRate":
                                    result.SliderTickRate = float.Parse(parts[1], IO.CULTUREINFO);
                                    break;
                            }
                            break;

                        #endregion

                        #region Events

                        case "[Events]":
                            EventBase ev;

                            if (EventBase.TryParse(line, out ev)) {
                                var videoEvent = ev as VideoEvent;
                                if (videoEvent != null) result.Video = videoEvent;
                                var backgroundEvent = ev as BackgroundEvent;
                                if (backgroundEvent != null) result.Background = backgroundEvent;
                                var breakEvent = ev as BreakEvent;
                                if (breakEvent != null) result.BreakPeriods.Add(breakEvent);
                                var sampleEvent = ev as SampleEvent;
                                if (sampleEvent != null) result.SampleEvents.Add(sampleEvent);
                                var colorEvent = ev as BackgroundColorEvent;
                                if (colorEvent != null) result.BackgroundColorTransformations.Add(colorEvent);
                                if (ev is SpriteEvent) {
                                    var se = ev as SpriteEvent;
                                    lastEvent = se;
                                    switch (se.Layer) {
                                        case EventLayer.Background:
                                            result.BackgroundEvents.Add(se);
                                            break;
                                        case EventLayer.Fail:
                                            result.FailEvents.Add(se);
                                            break;
                                        case EventLayer.Pass:
                                            result.PassEvents.Add(se);
                                            break;
                                        case EventLayer.Foreground:
                                            result.ForegroundEvents.Add(se);
                                            break;
                                    }
                                }
                            }
                            if (line.StartsWith(" ") || line.StartsWith("_")) {
                                LoopEvent l;
                                if (LoopEvent.TryParse(line, out l)) {
                                    lastEvent = l;
                                }

                                TransformationEvent t;
                                if (TransformationEvent.TryParse(line, out t)) {
                                    lastEvent?.AddTransformation(t);
                                    //var loopEvent = t as LoopEvent;
                                    //if (loopEvent != null) lastEvent = loopEvent;
                                    //var triggerEvent = t as TriggerEvent;
                                    //if (triggerEvent != null) lastEvent = triggerEvent;
                                }
                            }

                            break;
                        #endregion

                        case "[TimingPoints]":
                            timingPoints.Add(TimingPoint.Parse(line));
                            break;
                        case "[Colours]":
                            parts = line.Split(Splitter.Colon);
                            parts[0] = parts[0].TrimEnd();
                            if (parts[0].StartsWith("Combo")) {
                                var combo = Convert.ToInt32(parts[0].Substring(5));
                                result.ComboColours.Insert(combo - 1, ComboColour.Parse(parts[1]));
                            }
                            else if (parts[0] == "SliderBorder") {
                                result.SliderBorder = (ComboColour.Parse(parts[1]));
                            }
                            else if (parts[0] == "SliderTrackOverride") {
                                result.SliderTrackOverride = (ComboColour.Parse(parts[1]));
                            }

                            break;
                        #region HitObjects
                        case "[HitObjects]":
                            parts = line.Split(Splitter.Comma, StringSplitOptions.RemoveEmptyEntries);
                            var x = Convert.ToInt32(parts[0]);
                            var y = Convert.ToInt32(parts[1]);
                            var time = Convert.ToInt32(parts[2]);
                            var type = (HitObjectType)Convert.ToInt32(parts[3]);
                            var isNewCombo = type.Compare(HitObjectType.NewCombo);
                            var hitsound = (HitObjectSoundType)Convert.ToInt32(parts[4]);


                            if (type.Compare(HitObjectType.HitCircle))                            //Make HitCircle
                            {
                                var h = new HitCircle(x, y, time, isNewCombo, type, hitsound);
                                if (parts.Length > 5) h.Additions = GetAdditions(parts[5]);
                                hitobjects.Add(h);
                            }
                            if (type.Compare(HitObjectType.Spinner)) {                            //Make Spinner
                                var sp = new Spinner(x, y, time, int.Parse(parts[5]), isNewCombo, hitsound);
                                if (parts.Length > 6) sp.Additions = GetAdditions(parts[6]);
                                hitobjects.Add(sp);
                            }
                            if (type.Compare(HitObjectType.HoldCircle)) {                            //Make HoldCircle
                                //float endtime = parts[5]
                                var hc = new HoldCircle(x, y, time, int.Parse(parts[5]), isNewCombo, type, hitsound) {
                                    EndTime = int.Parse(parts[5])
                                };
                                if (parts.Length > 6) hc.Additions = GetAdditions(parts[6]);
                                hitobjects.Add(hc);
                            }
                            if (type.Compare(HitObjectType.Slider))                               //Make Slider
                            {
                                var s = new Slider(x, y, time, isNewCombo, type, hitsound);
                                var repeat = Convert.ToInt32(parts[6]);
                                var length = Convert.ToDouble(parts[7], IO.CULTUREINFO);
                                s.SegmentCount = repeat;
                                s.Length = length;
                                var points = parts[5].Split(Splitter.Pipe);
                                SliderType sliderType;
                                switch (points[0]) {
                                    case "C":
                                        sliderType = SliderType.Catmull;
                                        break;
                                    case "B":
                                        sliderType = SliderType.Bezier;
                                        break;
                                    case "L":
                                        sliderType = SliderType.Linear;
                                        break;
                                    case "P":
                                        sliderType = SliderType.PerfectCurve;
                                        break;
                                    default:
                                        sliderType = SliderType.Linear;
                                        break;
                                }
                                s.SliderType = sliderType;
                                var pointPositions = new Position[points.Length];
                                pointPositions[0] = s.StartPosition;
                                for (var i = 1; i < points.Length; i++) {
                                    var p = points[i].Split(Splitter.Colon).Select(int.Parse).ToArray();
                                    pointPositions[i] = Position.FromHitobject(p[0], p[1]);
                                }
                                s.ControlPoints = pointPositions;
                                int[] sadditions;
                                int[][] pointadditions;
                                HitObjectSoundType[] pointHitsounds;
                                if (parts.Length > 8) {
                                    pointHitsounds = parts[8].Split(Splitter.Pipe).Select(sel => (HitObjectSoundType)int.Parse(sel)).ToArray();

                                    pointadditions = null;
                                    if (parts.Length > 9) {
                                        sadditions = GetAdditions(parts[10]);
                                        var pas = parts[9].Split(Splitter.Pipe);
                                        pointadditions = new int[pas.Length][];
                                        for (var i = 0; i < pas.Length; i++) {
                                            pointadditions[i] = GetAdditions(pas[i]);
                                        }
                                    }
                                    else {
                                        sadditions = new[] { 0, 0, 0, 0 };
                                    }

                                }
                                else {
                                    sadditions = new[] { 0, 0, 0, 0 };
                                    pointHitsounds = new HitObjectSoundType[points.Length];
                                    pointadditions = new int[points.Length][];
                                    for (var i = 0; i < points.Length; i++) {
                                        pointadditions[i] = new[] { 0, 0 };
                                    }
                                }
                                s.Additions = sadditions;
                                s.PointHisounds = pointHitsounds;
                                s.PointAdditions = pointadditions;
                                hitobjects.Add(s);
                            }
                            break;
                            #endregion
                    }
                    line = sr.ReadLine();
                }
                hitobjects.Sort();
                result.TimingPoints = timingPoints;
                result.HitObjects = hitobjects;
            }

        }

        public void WriteFile(string file, BeatmapBase t) {
            using (var sw = new StreamWriter(osuElements.FileWriterFunc(file)))
                sw.Write(WriteToString(t));
        }
        public string WriteToString(BeatmapBase t) {
            var output = new StringBuilder("osu file format v" + osuElements.LatestBeatmapVersion + IO.NEW_LINE); //always save as newest version

            output.Append(Title("General"));

            output.Append(Title("Editor"));

            output.Append(Title("Metadata"));

            output.Append(Title("Difficulty"));

            output.Append(Title("Events"));
            output.Append("//Background and Video events" + IO.NEW_LINE);
            output.Append(t.Background == null ? "" : t.Background + IO.NEW_LINE);
            output.Append(t.Video == null ? "" : t.Background + IO.NEW_LINE);
            output.Append(t.BackgroundColorTransformations.Aggregate("", (current, e) => current + e.ToString()));
            output.Append("//Break Periods" + IO.NEW_LINE);
            output.Append(t.BreakPeriods.Aggregate("", (current, e) => current + e.ToString()));
            output.Append("//Storyboard Layer 0 (Background)" + IO.NEW_LINE);
            output.Append(t.BackgroundEvents.Aggregate("", (current, e) => current + e.ToString()));
            output.Append("//Storyboard Layer 1 (Fail)" + IO.NEW_LINE);
            output.Append(t.FailEvents.Aggregate("", (current, e) => current + e.ToString()));
            output.Append("//Storyboard Layer 2 (Pass)" + IO.NEW_LINE);
            output.Append(t.PassEvents.Aggregate("", (current, e) => current + e.ToString()));
            output.Append("//Storyboard Layer 3 (Foreground)" + IO.NEW_LINE);
            output.Append(t.ForegroundEvents.Aggregate("", (current, e) => current + e.ToString()));
            output.Append("//Storyboard Sound Samples" + IO.NEW_LINE);
            output.Append(t.SampleEvents.Aggregate("", (current, e) => current + e.ToString()));

            output.Append(Title("TimingPoints"));
            output.Append(t.TimingPoints.Aggregate("", (current, tp) => current + tp + IO.NEW_LINE));
            output.Append(IO.NEW_LINE); // this is default stuff

            output.Append(Title("Colours"));
            if (t.ComboColours.Any()) {
                for (var i = 0; i < t.ComboColours.Count; i++) {
                    output.Append($"Combo{i} : {t.ComboColours[i]}" + IO.NEW_LINE);
                }
            }
            output.Append(t.SliderBorder == null ? "" : t.SliderBorder + IO.NEW_LINE);
            output.Append(t.SliderBorder == null ? "" : t.SliderTrackOverride + IO.NEW_LINE);

            output.Append(Title("HitObjects"));
            output.Append(t.HitObjects.Aggregate("", (current, ho) => current + ho + IO.NEW_LINE));

            return output.ToString();
        }

        private static int[] GetAdditions(string part) {
            var a = part.Split(Splitter.Colon);
            //string audiofile = a.Last();
            if (a.Length > 4) Array.Resize(ref a, a.Length - 1);
            var additions = a.Select(int.Parse).ToArray();
            return additions;
        }

        private static string Title(string t) => IO.NEW_LINE + "[" + t + "]" + IO.NEW_LINE;
    }
}

