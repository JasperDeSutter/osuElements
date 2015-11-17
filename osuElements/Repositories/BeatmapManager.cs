using osuElements.Curves;
using osuElements.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuElements
{
    /// <summary>
    /// Handles timingpoints, creates curves for sliders, handles combo colors and numbers. 
    /// </summary>
    public class BeatmapManager
    {
        Beatmap _beatmap;
        List<TimingPoint> _timingpoints;
        List<HitObject> _hitobjects;

        public BeatmapManager(Beatmap beatmap) {
            _beatmap = beatmap;
            _timingpoints = beatmap.TimingPoints;
            _hitobjects = beatmap.HitObjects;

            SetupHitObjects();
        }
        int _currentcombocolor;

        private ComboColor NextColor(int newCombo) {
            _currentcombocolor += newCombo;
            _currentcombocolor %= _beatmap.ComboColors.Count();
            return _beatmap.ComboColors[_currentcombocolor];
        }

        private void SetupHitObjects() {
            int currentcombo = 1;
            foreach (var ho in _hitobjects) {
                if (ho.IsNewCombo) {
                    currentcombo = 1;
                    ho.ComboColor = NextColor(ho.NewCombo);
                }
                else ho.ComboColor = _beatmap.ComboColors[_currentcombocolor];
                ho.ComboNumber = currentcombo;
                currentcombo++;
                if (!(ho is Slider)) continue;
                var s = ho as Slider;
                s.Duration = s.Length * s.Repeat / CurrentSliderMultiplier(s.StartTime);
                Task.Factory.StartNew(() => s._curve = CurveBase.CreateCurve(s.SliderPoints, s.SliderType));
            }
            
        }

        public float CurrentBpm(int time) {
            return (Last(time, true).Bpm);
        }
        public float CurrentSliderMultiplier(float time) {
            var mult = Last(time); //if result is timing, return bpm. if its not, return speedmult * lastbpm
            var bpm = Last(time, true);
            float result = bpm.Bpm * (float)_beatmap.SliderMultiplier / 600;
            if (mult == null || mult.Offset < bpm.Offset) return result;
            return mult.SliderVMultiplier * result;
        }
        public TimingPoint Last(float timing, bool isTiming = false) {
            return _timingpoints.Where(tp => tp.Offset <= timing && tp.IsTiming == isTiming).Max();
        }
        public Position AutoCursorPosition(float timing) {
            var result = Constants.CENTER_OF_SCREEN;
            for (int i = 0; i < _hitobjects.Count(); i++) {
                var ho = _hitobjects[i];
                if (timing > ho.EndTime) continue;
                if (timing < ho.StartTime) {
                    if (i == 0) {
                        result = ho.StartPosition;
                        break;
                    }
                    var ho2 = _hitobjects[i - 1];
                    var start = ho2.StartPosition;
                    if (ho2 is Slider && (ho2 as Slider).Repeat % 2 == 1)
                        start = (ho2 as Slider).PositionAt(1);
                    var difference = ho.StartPosition - start;
                    float t = (timing - ho2.EndTime) / (ho.StartTime - ho2.EndTime);
                    result = start + difference * t;
                    break;
                }
                if (!(ho is Slider)) continue;
                Slider s = ho as Slider;
                float tfull = s.Repeat * (timing - s.StartTime) / s.Duration;
                int currepeat = (int)(tfull % 2);
                if (currepeat == 1)
                    tfull = (2 - tfull);
                result = s.PositionAt(tfull % 1);
                break;
            }
            return result;
        }

    }
}
