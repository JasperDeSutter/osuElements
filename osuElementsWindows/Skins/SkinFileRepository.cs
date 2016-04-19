using System;
using System.IO;
using System.Linq;
using osuElements.Helpers;
using osuElements.Repositories;

namespace osuElements.Skins
{
    public class SkinFileRepository : IFileRepository<Skin>
    {
        public void ReadFile(string fileName, Skin skin) {
            using (var sr = new StreamReader(osuElements.FileReaderFunc(fileName))) {
                var line = sr.ReadLine();
                string section = "";
                int maniakeys = -1;
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
                    try {
                        if (section == "[General]") {
                            var parts = line.Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            switch (parts[0]) {
                                case "Name":
                                    skin.Name = parts[1];
                                    break;
                                case "Author":
                                    skin.Author = parts[1];
                                    break;
                                case "SliderBallFlip":
                                    skin.SliderBallFlip = parts[1] == "1";
                                    break;
                                case "CursorRotate":
                                    skin.CursorRotate = parts[1] == "1";
                                    break;
                                case "CursorExpand":
                                    skin.CursorExpand = parts[1] == "1";
                                    break;
                                case "CursorCentre":
                                    skin.CursorCentre = parts[1] == "1";
                                    break;
                                case "SliderBallFrames":
                                    skin.SliderBallFrames = int.Parse(parts[1]);
                                    break;
                                case "HitCircleOverlayAboveNumber":
                                    skin.HitCircleOverlayAboveNumber = parts[1] == "1";
                                    break;
                                case "SpinnerFadePlayField":
                                    skin.SpinnerFadePlayField = parts[1] == "1";
                                    break;
                                case "SpinnerNoBlink":
                                    skin.SpinnerNoBlink = parts[1] == "1";
                                    break;
                                case "AnimationFramerate":
                                    skin.AnimationFramerate = int.Parse(parts[1]);
                                    break;
                                case "AllowSliderBallTint":
                                    skin.AllowSliderBallTint = parts[1] == "1";
                                    break;
                                case "CursorTrailRotate":
                                    skin.CursorTrailRotate = parts[1] == "1";
                                    break;
                                case "CustomComboBurstSounds":
                                    skin.CustomComboBurstSounds = parts[1].Trim().Split(',').Select(int.Parse).ToList();
                                    break;
                                case "ComboBurstRandom":
                                    skin.ComboBurstRandom = parts[1] == "1";
                                    break;
                                case "SliderStyle":
                                    skin.SliderStyle = (SliderStyle)Enum.Parse(typeof(SliderStyle), parts[1]);
                                    break;
                                case "Version":
                                    if (parts[1] == "latest" || parts[1] == "User")
                                        skin.Version = -1;
                                    else
                                        skin.Version = float.Parse(parts[1], Constants.IO.CULTUREINFO);
                                    break;
                            }
                        }
                        if (section == "[Colours]") {
                            var parts = line.Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (parts[0].StartsWith("Combo")) {
                                var combo = Convert.ToInt32(parts[0].Substring(5));
                                skin.Combo[combo - 1] = ComboColour.Parse(parts[1]);
                            }
                            switch (parts[0]) {
                                case "MenuGlow":
                                    skin.MenuGlow = ComboColour.Parse(parts[1]);
                                    break;
                                case "SliderBall":
                                    skin.SliderBall = ComboColour.Parse(parts[1]);
                                    break;
                                case "SliderBorder":
                                    skin.SliderBorder = ComboColour.Parse(parts[1]);
                                    break;
                                case "SliderTrackOverride":
                                    skin.SliderTrackOverride = ComboColour.Parse(parts[1]);
                                    break;
                                case "SpinnerApproachCircle":
                                    skin.SpinnerApproachCircle = ComboColour.Parse(parts[1]);
                                    break;
                                case "SongSelectActiveText":
                                    skin.SongSelectActiveText = ComboColour.Parse(parts[1]);
                                    break;
                                case "SongSelectInactiveText":
                                    skin.SongSelectInactiveText = ComboColour.Parse(parts[1]);
                                    break;
                                case "StarBreakAdditive":
                                    skin.StarBreakAdditive = ComboColour.Parse(parts[1]);
                                    break;
                            }
                        }
                        if (section == "[Fonts]") {
                            var parts = line.Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            switch (parts[0]) {
                                case "HitCirclePrefix":
                                    skin.HitCirclePrefix = parts[1];
                                    break;
                                case "HitCircleOverlap":
                                    skin.HitCircleOverlap = int.Parse(parts[1]);
                                    break;
                                case "ScorePrefix":
                                    skin.ScorePrefix = parts[1];
                                    break;
                                case "ScoreOverlap":
                                    skin.ScoreOverlap = int.Parse(parts[1]);
                                    break;
                                case "ComboPrefix":
                                    skin.ComboPrefix = parts[1];
                                    break;
                                case "ComboOverlap":
                                    skin.ComboOverlap = int.Parse(parts[1]);
                                    break;
                            }
                        }
                        if (section == "[Mania]") {
                            var parts = line.Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            switch (parts[0]) {
                                case "Keys":
                                    maniakeys = int.Parse(parts[1]);
                                    skin.ManiaSkins[maniakeys] = new ManiaSkin { Keys = maniakeys };
                                    break;
                            }
                        }

                        line = sr.ReadLine();
                    }
                    catch {

                    }
                }
            }
        }

        public void WriteFile(string file, Skin t) {
            throw new NotImplementedException();
        }

        public string WriteToString(Skin t) {
            throw new NotImplementedException();
        }
    }
}
