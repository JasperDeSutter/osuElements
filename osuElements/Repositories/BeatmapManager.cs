using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using osuElements.Helpers;
using osuElements.Other_Models;

namespace osuElements.Repositories
{
    /// <summary>
    /// Handles timingpoints, creates curves for sliders, handles combo colors and numbers. 
    /// </summary>
    public class BeatmapManager
    {
        private Beatmap _beatmap;
        private List<TimingPoint> _timingpoints;
        private List<HitObject> _hitObjects;
        private List<Slider> _sliders;
        private List<HitCircle> _hitCircles;
        private List<Spinner> _spinners;
        private List<HoldCircle> _holdCircles;
        public List<HitObject> HitObjects => _hitObjects;
        private TpDifficulty _tpDifficulty;

        public BeatmapManager(Beatmap beatmap) {
            _beatmap = beatmap;
            _timingpoints = beatmap.TimingPoints;
            _hitObjects = beatmap.HitObjects;

            _sliders = _hitObjects.OfType<Slider>().ToList();
            foreach (var slider in _sliders) {
                SetupSlider(slider);
            }
            _hitCircles = _hitObjects.OfType<HitCircle>().ToList();
            _spinners = _hitObjects.OfType<Spinner>().ToList();
            _holdCircles = _hitObjects.OfType<HoldCircle>().ToList();

            CalculateComboColors();
            _tpDifficulty = new TpDifficulty(_beatmap);
        }
        int _currentcombocolor;

        private ComboColor NextColor(int newCombo) {
            _currentcombocolor += newCombo;
            _currentcombocolor %= _beatmap.ComboColors.Length;
            return _beatmap.ComboColors[_currentcombocolor];
        }
        private void SetupSlider(Slider slider) {
            slider.Duration = (float)slider.Length * slider.Repeat / CurrentSliderMultiplier(slider.StartTime);
            Task.Factory.StartNew(() => slider._curve = CurveBase.CreateCurve(slider.SliderPoints, slider.SliderType));
        }
        private void CalculateComboColors() {
            int currentcombo = 1;
            foreach (var ho in _hitObjects) {
                if (ho.IsNewCombo) {
                    currentcombo = 1;
                    ho.ComboColor = NextColor(ho.NewCombo);
                }
                else ho.ComboColor = _beatmap.ComboColors[_currentcombocolor];
                ho.ComboNumber = currentcombo;
                currentcombo++;
            }

        }
        public double CalculateDifficulty() {
            return _tpDifficulty.CalculateDifficulty();
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
            var result = _timingpoints.Where(tp => tp.Offset <= timing && tp.IsTiming == isTiming).Max();
            if (isTiming && result == null) result = _timingpoints.First(tp => tp.IsTiming);
            return result;
        }
        public Position AutoCursorPosition(float timing) {
            var result = Constants.CENTER_OF_SCREEN;
            for (int i = 0; i < _hitObjects.Count; i++) {
                var ho = _hitObjects[i];
                if (timing > ho.EndTime) continue;
                if (timing < ho.StartTime) {
                    if (i == 0) {
                        result = ho.StartPosition;
                        break;
                    }
                    var ho2 = _hitObjects[i - 1];
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
