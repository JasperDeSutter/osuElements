using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using osuElements.Beatmaps;
using osuElements.Beatmaps.Events;
using osuElements.Helpers;
using osuElements.IO;
using osuElements.IO.File;
using osuElements.Storyboards;
using Enum = System.Enum;

namespace osuElements.Repositories
{

    public class BeatmapFileRepository : IFileRepository<Beatmap>
    {
        //Defines methods directly related to a beatmap instance, such as reading from the .osu file.
        public void ReadFile(Stream stream, Beatmap result, ILogger logger = null) {
            var section = "";
            ITransformable lastEvent = null;
            using (var sr = new StreamReader(stream)) {
                var line = sr.ReadLine();
                if (line == null) return;
                if (line.StartsWith("osu"))
                    result.FormatVersion = Convert.ToInt32(line.Split(new[] { 'v', ' ' }, StringSplitOptions.RemoveEmptyEntries)[3]);
                else return;
                line = sr.ReadLine();
                var hitobjects = new List<HitObject>();
                var timingPoints = new List<TimingPoint>();
                while (line != null) {
                    if (line == "" || line.StartsWith("//")) {
                        line = sr.ReadLine();
                        continue;
                    }
                    if (line.StartsWith("[")) {
                        section = line;
                        line = sr.ReadLine();
                        continue;
                    }
                    string[] parts;
                    switch (section) {
                        #region General
                        case "[General]":
                            parts = line.Split(':'.AsArray(), StringSplitOptions.RemoveEmptyEntries);
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
                                    result.StackLeniency = float.Parse(parts[1], Constants.CULTUREINFO);
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
                            parts = line.Split(':'.AsArray(), StringSplitOptions.RemoveEmptyEntries);
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
                                    result.DistanceSpacing = float.Parse(parts[1], Constants.CULTUREINFO);
                                    break;
                                case ("BeatDivisor"):
                                    result.BeatDivisor = int.Parse(parts[1]);
                                    break;
                                case ("GridSize"):
                                    result.GridSize = int.Parse(parts[1]);
                                    break;
                                case ("TimelineZoom"):
                                    result.TimelineZoom = float.Parse(parts[1], Constants.CULTUREINFO);
                                    break;
                            }
                            break;
                        #endregion

                        #region Metadata
                        case "[Metadata]":
                            parts = line.Split(':');
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
                            parts = line.Split(':');
                            switch (parts[0]) {
                                case "HpDrainRate":
                                    result.Diff_Drain = float.Parse(parts[1], Constants.CULTUREINFO);
                                    break;
                                case "CircleSize":
                                    result.Diff_Size = float.Parse(parts[1], Constants.CULTUREINFO);
                                    break;
                                case "OverallDifficulty":
                                    result.Diff_Overall = float.Parse(parts[1], Constants.CULTUREINFO);
                                    break;
                                case "ApproachRate":
                                    result.DistanceSpacing = float.Parse(parts[1], Constants.CULTUREINFO);
                                    break;
                                case "SliderMultiplier":
                                    result.SliderMultiplier = Convert.ToDouble(parts[1], Constants.CULTUREINFO);
                                    break;
                                case "SliderTickRate":
                                    result.SliderTickRate = float.Parse(parts[1], Constants.CULTUREINFO);
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

                                TransformationEvent[] t;
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
                            parts = line.Split(',');
                            parts[0] = parts[0].TrimEnd();
                            if (parts[0].StartsWith("Combo")) {
                                var combo = Convert.ToInt32(parts[0].Substring(5));
                                result.ComboColours.Insert(combo - 1, Colour.Parse(parts[1]));
                            }
                            else if (parts[0] == "SliderBorder") {
                                result.SliderBorder = (Colour.Parse(parts[1]));
                            }
                            else if (parts[0] == "SliderTrackOverride") {
                                result.SliderTrackOverride = (Colour.Parse(parts[1]));
                            }

                            break;
                        #region HitObjects
                        case "[HitObjects]":
                            result.HitObjects.Add(HitObject.Parse(line));
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

        public void WriteFile(Stream file, Beatmap t) {
            using (var sw = new StreamWriter(file))
                sw.Write(WriteToString(t));
        }
        public string WriteToString(Beatmap t) {
            var output = new StringBuilder("osu file format v" + osuElements.LatestBeatmapVersion + "/r/n"); //always save as newest version

            output.Append(Title("General"));

            output.Append(Title("Editor"));

            output.Append(Title("Metadata"));

            output.Append(Title("Difficulty"));

            output.Append(Title("Events"));
            output.Append("//Background and Video events" + "/r/n");
            output.Append(t.Background == null ? "" : t.Background + "/r/n");
            output.Append(t.Video == null ? "" : t.Background + "/r/n");
            output.Append(t.BackgroundColorTransformations.Aggregate("", (current, e) => current + e.ToString()));
            output.Append("//Break Periods" + "/r/n");
            output.Append(t.BreakPeriods.Aggregate("", (current, e) => current + e.ToString()));
            output.Append("//Storyboard Layer 0 (Background)" + "/r/n");
            output.Append(t.BackgroundEvents.Aggregate("", (current, e) => current + e.ToString()));
            output.Append("//Storyboard Layer 1 (Fail)" + "/r/n");
            output.Append(t.FailEvents.Aggregate("", (current, e) => current + e.ToString()));
            output.Append("//Storyboard Layer 2 (Pass)" + "/r/n");
            output.Append(t.PassEvents.Aggregate("", (current, e) => current + e.ToString()));
            output.Append("//Storyboard Layer 3 (Foreground)" + "/r/n");
            output.Append(t.ForegroundEvents.Aggregate("", (current, e) => current + e.ToString()));
            output.Append("//Storyboard Sound Samples" + "/r/n");
            output.Append(t.SampleEvents.Aggregate("", (current, e) => current + e.ToString()));

            output.Append(Title("TimingPoints"));
            output.Append(t.TimingPoints.Aggregate("", (current, tp) => current + tp + "/r/n"));
            output.Append("/r/n"); // this is default stuff

            output.Append(Title("Colours"));
            if (t.ComboColours.Any()) {
                for (var i = 0; i < t.ComboColours.Count; i++) {
                    output.Append($"Combo{i} : {t.ComboColours[i]}" + "/r/n");
                }
            }
            output.Append(t.SliderBorder == null ? "" : t.SliderBorder + "/r/n");
            output.Append(t.SliderBorder == null ? "" : t.SliderTrackOverride + "/r/n");

            output.Append(Title("HitObjects"));
            output.Append(t.HitObjects.Aggregate("", (current, ho) => current + ho + "/r/n"));

            return output.ToString();
        }

        private static int[] GetAdditions(string part) {
            var a = part.Split(':');
            //string audiofile = a.Last();
            if (a.Length > 4) Array.Resize(ref a, a.Length - 1);
            var additions = a.Select(int.Parse).ToArray();
            return additions;
        }

        private static string Title(string t) => "/r/n" + "[" + t + "]" + "/r/n";
    }
}

