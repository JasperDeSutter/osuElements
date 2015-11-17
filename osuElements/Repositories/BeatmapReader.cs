using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using osuElements.Helpers;
using osuElements.Events;
namespace osuElements.Repositories
{

    internal static class OsuReader
    {
        //Defines methods directly related to a beatmap instance, such as reading from the .osu file.

        public static void ReadFile(string path, BeatmapBase result) {
            if (!File.Exists(path)) return;
            string section = "";
            string eventSection = "";
            using (StreamReader sr = new StreamReader(path)) {
                string line = sr.ReadLine();
                if (line == null) return;
                if (line.StartsWith("osu"))
                    result.FormatVersion = Convert.ToInt32(line.Split(new char[] { 'v', Splitter.Space }, StringSplitOptions.RemoveEmptyEntries)[3]);
                else return;
                line = sr.ReadLine();
                List<HitObject> hitobjects = new List<HitObject>();
                List<TimingPoint> timingPoints = new List<TimingPoint>();
                while (line != null) {
                    if (line == "") {
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
                                    result.SampleSet = (SampleSets)Enum.Parse(typeof(SampleSets), parts[1]);
                                    break;
                                case "StackLeniency":
                                    result.StackLeniency = float.Parse(parts[1], Constants.FORMATPROVIDER);
                                    break;
                                case "Mode":
                                    result.Mode = (GameModes)Convert.ToInt32(parts[1]);
                                    break;
                                case "LetterboxInBreaks":
                                    result.LetterboxInBreaks = Convert.ToBoolean(int.Parse(parts[1]));
                                    break;
                                case "WidescreenStoryboard":
                                    result.WidescreenStoryboard = parts[1] == "1";
                                    break;
                                case ("EditorBookmarks"): //only in first versions
                                    foreach (string bookmark in parts[1].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)) {
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
                                    if (parts.Count() > 1) {
                                        string[] bms = parts[1].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                        if (bms != null) {
                                            foreach (string bookmark in bms) {
                                                result.Bookmarks.Add(int.Parse(bookmark));
                                            }
                                        }
                                    }
                                    break;
                                case ("DistanceSpacing"):
                                    result.DistanceSpacing = float.Parse(parts[1], Constants.FORMATPROVIDER);
                                    break;
                                case ("BeatDivisor"):
                                    result.BeatDivisor = int.Parse(parts[1]);
                                    break;
                                case ("GridSize"):
                                    result.GridSize = int.Parse(parts[1]);
                                    break;
                                case ("TimelineZoom"):
                                    result.TimelineZoom = float.Parse(parts[1], Constants.FORMATPROVIDER);
                                    break;
                            }
                            /*foreach (beatmapEditor val in Enum.GetValues(typeof(beatmapEditor)))
                            {
                                if ("" + val == parts[0]) result.Editor.Add(val, parts[1].TrimStart(Splitter.Space));
                            }*/
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
                                    result.BeatmapId = int.Parse(parts[1]);
                                    break;
                                case ("BeatmapSetID"):
                                    result.BeatmapSetId = int.Parse(parts[1]);
                                    break;
                            }
                            break;
                        #endregion
                        case "[Difficulty]":
                            parts = line.Split(Splitter.Colon);
                            switch (parts[0]) {
                                case "HPDrainRate":
                                    result.HPDrainRate = float.Parse(parts[1], Constants.FORMATPROVIDER);
                                    break;
                                case "CircleSize":
                                    result.CircleSize = float.Parse(parts[1], Constants.FORMATPROVIDER);
                                    break;
                                case "OverallDifficulty":
                                    result.OverallDifficulty = float.Parse(parts[1], Constants.FORMATPROVIDER);
                                    break;
                                case "ApproachRate":
                                    result.ApproachRate = float.Parse(parts[1], Constants.FORMATPROVIDER);
                                    break;
                                case "SliderMultiplier":
                                    result.SliderMultiplier = Convert.ToDouble(parts[1], Constants.FORMATPROVIDER);
                                    break;
                                case "SliderTickRate":
                                    result.SliderTickRate = float.Parse(parts[1], Constants.FORMATPROVIDER);
                                    break;
                            }
                            break;
                        case "[Events]":
                            if (line.StartsWith("//")) {
                                eventSection = line;
                                line = sr.ReadLine();
                                continue;
                            }
                            Event a;
                            TransformationEvent t;
                            switch (eventSection) {
                                case "//Background and Video events":
                                    a = Event.Parse(line);
                                    if (a.Type == EventTypes.Video) result.Video = (VideoEvent)a;
                                    if (a.Type == EventTypes.Background) result.Background = (BackgroundEvent)a;
                                    break;
                                case "//Break Periods":
                                    a = Event.Parse(line);
                                    if (a.Type == EventTypes.Break) result.BreakPeriods.Add((BreakEvent)a);
                                    break;
                                case "//Storyboard Layer 0 (Background)":
                                    if (line.StartsWith(" ") || line.StartsWith("_")) {
                                        if (TransformationEvent.TryParse(line, out t)) {
                                            if (result.BackgroundEvents.Any()) result.BackgroundEvents.Last().AddTransformation(t);
                                        }
                                    }
                                    else
                                        if (Event.TryParse(line, out a)) result.BackgroundEvents.Add((SpriteEvent)a);
                                    break;
                                case "//Storyboard Layer 1 (Fail)":
                                    if (line.StartsWith(" ") || line.StartsWith("_")) {
                                        if (TransformationEvent.TryParse(line, out t)) {
                                            if (result.FailEvents.Any()) result.FailEvents.Last().AddTransformation(t);
                                        }
                                    }
                                    else
                                        if (Event.TryParse(line, out a)) result.FailEvents.Add((SpriteEvent)a);
                                    break;
                                case "//Storyboard Layer 2 (Pass)":
                                    if (line.StartsWith(" ") || line.StartsWith("_")) {
                                        if (TransformationEvent.TryParse(line, out t)) {
                                            if (result.PassEvents.Any()) result.PassEvents.Last().AddTransformation(t);
                                        }
                                    }
                                    else
                                        if (Event.TryParse(line, out a)) result.PassEvents.Add((SpriteEvent)a);
                                    break;
                                case "//Storyboard Layer 3 (Foreground)":
                                    if (line.StartsWith(" ") || line.StartsWith("_")) {
                                        if (TransformationEvent.TryParse(line, out t)) {
                                            if (result.ForegroundEvents.Any()) result.ForegroundEvents.Last().AddTransformation(t);
                                        }
                                    }
                                    else
                                        if (Event.TryParse(line, out a)) result.ForegroundEvents.Add((SpriteEvent)a);
                                    break;
                                case "//Storyboard Sound Samples":
                                    a = Event.Parse(line);
                                    if (a.Type == EventTypes.Sample) result.SampleEvents.Add((SampleEvent)a);
                                    break;
                                case "//Background Colour Transformations":
                                    a = Event.Parse(line);
                                    if (a.Type == EventTypes.Backgroundcolor) result.BackgroundColorTransformations.Add((BackgroundColorEvent)a);
                                    break;
                            }
                            break;
                        case "[TimingPoints]":
                            TimingPoint tp;
                            parts = line.Split(Splitter.Comma, StringSplitOptions.RemoveEmptyEntries);
                            Timing offset = new Timing(Convert.ToInt32(float.Parse(parts[0], Constants.FORMATPROVIDER)));
                            float bpm = (float)Convert.ToDouble(parts[1], Constants.FORMATPROVIDER);
                            if (parts.Length > 2) {
                                int signature = Convert.ToInt32(parts[2]);
                                SampleSets sampleSet = (SampleSets)Convert.ToInt32(parts[3]);
                                int customSet = Convert.ToInt32(parts[4]);
                                int volume = parts.Length > 6 ? Convert.ToInt32(parts[5]) : 100;
                                bool isTiming = parts.Length <= 6 || Convert.ToBoolean(Convert.ToInt32(parts[6]));
                                TimingPointOptions options = parts.Length > 7 ? (TimingPointOptions)Convert.ToInt32(parts[7]) : TimingPointOptions.None;

                                tp = new TimingPoint(offset, bpm, signature, sampleSet, customSet, volume, isTiming, options);
                                timingPoints.Add(tp);
                            }
                            else {
                                tp = new TimingPoint(offset, bpm);
                                timingPoints.Add(tp);
                            }
                            break;
                        case "[Colours]":
                            parts = line.Split(Splitter.Colon);
                            parts[0] = parts[0].TrimEnd();
                            if (parts[0].StartsWith("Combo")) {
                                int combo = Convert.ToInt32(parts[0].Substring(5));
                                result.ComboColors[combo - 1] = (ComboColor.Parse(parts[1]));
                            }
                            else if (parts[0] == "SliderBorder") {
                                result.SliderBorder = (ComboColor.Parse(parts[1]));
                            }
                            else if (parts[0] == "SliderTrackOverride") {
                                result.SliderTrackOverride = (ComboColor.Parse(parts[1]));
                            }

                            break;
                        case "[HitObjects]":
                            parts = line.Split(Splitter.Comma, StringSplitOptions.RemoveEmptyEntries);  //Start making HitObject
                            int x = Convert.ToInt32(parts[0]);
                            int y = Convert.ToInt32(parts[1]);
                            Timing time = new Timing(Convert.ToInt32(parts[2]));
                            HoTypes type = (HoTypes)Convert.ToInt32(parts[3]);
                            bool isNewCombo = type.Compare(HoTypes.NewCombo);
                            HitsoundTypes hitsound = (HitsoundTypes)Convert.ToInt32(parts[4]);

                            HitObject hObject = new HitObject(time, x, y, isNewCombo, type, hitsound);

                            if (type.Compare(HoTypes.HitCircle))                            //Make HitCircle
                            {
                                HitCircle h = new HitCircle(hObject);
                                if (parts.Length > 5) h.Additions = GetAdditions(parts[5]);
                                hitobjects.Add(h);
                            }
                            if (type.Compare(HoTypes.Spinner)) {                            //Make Spinner
                                Spinner sp = new Spinner(hObject){
                                    EndTime = int.Parse(parts[5]),
                                    Additions = GetAdditions(parts[6])
                                };
                            }
                            if (type.Compare(HoTypes.HoldCircle)) {                            //Make HoldCircle
                                HoldCircle sp = new HoldCircle(hObject){
                                    EndTime = int.Parse(parts[5]),
                                    Additions = GetAdditions(parts[6])
                                };
                            }
                            if (type.Compare(HoTypes.Slider))                               //Make Slider
                            {
                                Slider s = new Slider(hObject);
                                int repeat = Convert.ToInt32(parts[6]);
                                float length = (float)Convert.ToDouble(parts[7], Constants.FORMATPROVIDER);
                                s.Repeat = repeat;
                                s.Length = length;
                                string[] points = parts[5].Split(Splitter.Pipe);
                                SliderTypes sliderType;
                                switch (points[0]) {
                                    case "C":
                                        sliderType = SliderTypes.Catmull;
                                        break;
                                    case "B":
                                        sliderType = SliderTypes.Bezier;
                                        break;
                                    case "L":
                                        sliderType = SliderTypes.Linear;
                                        break;
                                    case "P":
                                        sliderType = SliderTypes.PerfectCurve;
                                        break;
                                    default:
                                        sliderType = SliderTypes.Linear;
                                        break;
                                }
                                s.SliderType = sliderType;
                                Position[] pointPositions = new Position[points.Length];
                                pointPositions[0] = s.StartPosition;
                                for (int i = 1; i < points.Length; i++) {
                                    int[] p = points[i].Split(Splitter.Colon).Select(int.Parse).ToArray();
                                    pointPositions[i] = Position.FromHitobject(p[0], p[1], true);
                                }
                                s.SliderPoints = pointPositions;
                                int[] sadditions;
                                int[][] pointadditions;
                                HitsoundTypes[] pointHitsounds;
                                if (parts.Length > 8) {
                                    pointHitsounds = parts[8].Split(Splitter.Pipe).Select(sel => (HitsoundTypes)int.Parse(sel)).ToArray();

                                    pointadditions = null;
                                    if (parts.Length > 9) {
                                        sadditions = GetAdditions(parts[10]);
                                        var pas = parts[9].Split(Splitter.Pipe);
                                        pointadditions = new int[pas.Length][];
                                        for (int i = 0; i < pas.Length; i++) {
                                            pointadditions[i] = GetAdditions(pas[i]);
                                        }
                                    }
                                    else {
                                        sadditions = new int[4] { 0, 0, 0, 0 };
                                    }

                                }
                                else {
                                    sadditions = new int[] { 0, 0, 0, 0 };
                                    pointHitsounds = new HitsoundTypes[points.Length];
                                    pointadditions = new int[points.Length][];
                                    for (int i = 0; i < points.Length; i++) {
                                        pointadditions[i] = new int[2] { 0, 0 };
                                    }
                                }
                                s.Additions = sadditions;
                                s.PointHisounds = pointHitsounds;
                                s.PointAdditions = pointadditions;
                                hitobjects.Add(s);
                            }
                            if (type.Compare(HoTypes.Spinner))                               //Make Spinner
                            {
                                Spinner p = new Spinner(hObject);
                                if (parts.Length > 6) p.Additions = GetAdditions(parts[6]);
                                p.EndTime = new Timing(Convert.ToInt32(parts[5]));
                                hitobjects.Add(p);
                            }
                            break;
                    }
                    line = sr.ReadLine();
                }
                hitobjects.Sort();
                result.TimingPoints = timingPoints;
                result.HitObjects = hitobjects;
            }

        }

        private static int[] GetAdditions(string part) {
            string[] a = part.Split(Splitter.Colon);
            string audiofile = a.Last();
            if (a.Count() > 4) Array.Resize(ref a, a.Count() - 1);
            int[] additions = a.Select(int.Parse).ToArray();
            return additions;
        }
    }
}

