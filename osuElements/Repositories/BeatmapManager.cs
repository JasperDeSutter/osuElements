using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using osu.GameplayElements;
using osuElements.Curves;
using osuElements.Helpers;
using static osuElements.Helpers.Constants.Beatmap;

namespace osuElements.Repositories
{
    /// <summary>
    /// Handles timingpoints, creates curves for sliders, handles combo colors and numbers. 
    /// </summary>
    public class BeatmapManager : HitObjectManagerBase
    {
        #region Fields
        private Beatmap _beatmap;
        private int _currentcombocolor;
        private List<Task> _sliderCreateTasks;
        private TpDifficulty _tpDifficulty;
        #endregion

        public BeatmapManager(Beatmap beatmap) {
            SetBeatmap(beatmap);

            if (_beatmap.ComboColours != null && _beatmap.ComboColours.Count > 0) {
                ComboColours = _beatmap.ComboColours;
            }
            
            CalculateComboColors();
        }

        #region Properties
        public List<TimingPoint> TimingPoints => _beatmap.TimingPoints;
        public List<ComboColour> ComboColours { get; set; }
        public Mods Mods { get; private set; }

        private float DifficultyModMultiplier =>
            (Mods.IsType(Mods.HardRock) ? HARD_ROCK_MULTIPLIER : 1) * (Mods.IsType(Mods.Easy) ? EASY_MULTIPLIER : 1);

        //Circle size uses this one
        private float CircleSizeModMultiplier =>
            (Mods.IsType(Mods.HardRock) ? CIRCLE_SIZE_MOD_MULTIPLIER : 1) *
            (Mods.IsType(Mods.Easy) ? EASY_MULTIPLIER : 1);

        public float ModSpeedMultiplier =>
            (Mods.IsType(Mods.DoubleTime) || Mods.IsType(Mods.Nightcore) ? DT_MULTIPLIER : 1) *
            (Mods.IsType(Mods.HalfTime) ? HT_MULTIPLIER : 1);
        #endregion

        #region Methods
        public override BeatmapBase GetBeatmap() => _beatmap;

        public override List<HitObject> GetHitObjects() => _beatmap.HitObjects;

        public override double AdjustDifficulty(double difficulty) {
            return Math.Min(10, difficulty * CircleSizeModMultiplier);
        }

        public override double MapDifficultyRange(double difficulty, double min, double mid, double max) {
            difficulty = Math.Min(10, DifficultyModMultiplier * difficulty);
            if (difficulty == 5) return mid;
            if (difficulty > 5) return MathHelper.Lerp((difficulty - 5) / 5, mid, max);
            return MathHelper.Lerp(difficulty / 5, min, mid);
        }

        public void SetBeatmap(Beatmap beatmap) {
            _beatmap = beatmap;
            _sliderCreateTasks = GetHitObjects().OfType<Slider>().Select(SetupSlider).ToList();
            ComboColours = _beatmap.ComboColours;
            CalculateComboColors();
            DifficultyCalculations();
            //AwaitSliderCalculations().Wait();
        }

        public async Task AwaitSliderCalculations() {
            if (_sliderCreateTasks.Count < 1) return;
            await Task.WhenAll(_sliderCreateTasks);
            _sliderCreateTasks.Clear();
        }

        public void DifficultyCalculations() {
            var difficulty = Math.Min(10, DifficultyModMultiplier * _beatmap.Diff_Overall);
            HitObjectRadius = (float)(54.4 - AdjustDifficulty(_beatmap.Diff_Size) * 4.48);
            HitWindow300 = (int)(80 - difficulty * 6);
            HitWindow100 = (int)(140 - difficulty * 8);
            HitWindow50 = (int)(200 - difficulty * 10);
            PreEmpt = (int)MapDifficultyRange(_beatmap.Diff_Approach, 1800, 1200, 450);
            SpinnerRotationRatio = MapDifficultyRange(_beatmap.Diff_Overall, 3, 5, 7.5);
            StackOffset = HitObjectRadius / 10;
            SliderScoringPointDistance = 100 * _beatmap.SliderMultiplier / _beatmap.SliderTickRate;
        }


        public void SetMods(Mods mods) {
            //TODO check for impossible combinations
            Mods = mods;
        }

        public Task SetupSlider(Slider slider) {
            slider.Duration = (float)(slider.Length * slider.SegmentCount / SliderVelocityAt(slider.StartTime));
            return Task.Run(() => slider._curve = CurveBase.CreateCurve(slider.ControlPoints, slider.SliderType));
        }

        public void CalculateStacking() {
            const int stackLenience = 3;
            var hitObjects = GetHitObjects();
            for (var i = hitObjects.Count - 1; i > 0; i--) {
                var n = i;
                var objectI = hitObjects[i];

                if (objectI.Stack != 0 || objectI is Spinner) continue;

                if (objectI is Slider) {
                    while (--n >= 0) {
                        var objectN = hitObjects[n];
                        if (objectN is Spinner) continue;

                        if (objectI.StartTime - (PreEmpt * _beatmap.StackLeniency) > objectN.EndTime)
                            break;
                        if (!(objectN.EndPosition.Distance(objectI.StartPosition) < stackLenience)) continue;
                        objectN.Stack = objectI.Stack + 1;
                        objectI = objectN;
                    }
                }
                else if (objectI is HitCircle) {
                    while (--n >= 0) {
                        var objectN = hitObjects[n];
                        if (objectN is Spinner) continue;

                        if (objectI.StartTime - (PreEmpt * _beatmap.StackLeniency) > objectN.EndTime)
                            break;
                        if (objectN != null && objectN.EndPosition.Distance(objectI.StartPosition) < stackLenience) {
                            var offset = objectI.Stack - objectN.Stack + 1;
                            for (var j = n + 1; j <= i; j++) {
                                if (objectN.EndPosition.Distance(hitObjects[j].StartPosition) < stackLenience)
                                    hitObjects[j].Stack -= offset;
                            }
                            break;
                        }

                        if (!(objectN.StartPosition.Distance(objectI.StartPosition) < stackLenience)) continue;
                        objectN.Stack = objectI.Stack + 1;
                        objectI = objectN;
                    }
                }
            }
        }


        public async Task<double> CalculateDifficlty() {
            if (_tpDifficulty == null) _tpDifficulty = new TpDifficulty(this);
            return await Task.Factory.StartNew(() => _tpDifficulty.CalculateDifficulty());
        }

        public double BpmAt(int time) {
            return (Last(time, true).Bpm);
        }

        public override double SliderVelocityAt(int time) {
            var mult = Last(time); //if result is timing, return bpm. if its not, return speedmult * lastbpm
            var bpm = Last(time, true);
            var result = bpm.Bpm * _beatmap.SliderMultiplier / 600;
            if (mult == null || mult.Offset < bpm.Offset) return result;
            return mult.SliderVelocityMultiplier * result;
        }

        public TimingPoint Last(float timing, bool isBpm = false) {
            var timingpoints = TimingPoints;
            var result = timingpoints.LastOrDefault(tp => tp.Offset <= timing && tp.IsTiming == isBpm);
            if (isBpm && result == null) result = timingpoints.First(tp => tp.IsTiming);
            return result;
        }

        public Position AutoCursorPosition(float timing) {
            var hitObjects = GetHitObjects();
            var result = Constants.CENTER_OF_SCREEN;
            for (var i = 0; i < hitObjects.Count; i++) {
                var ho = hitObjects[i];
                if (timing > ho.EndTime) continue;
                if (timing < ho.StartTime) {
                    if (i == 0) {
                        result = ho.StartPosition;
                        break;
                    }
                    var ho2 = hitObjects[i - 1];
                    var slider = ho2 as Slider;
                    var start = ho2.EndPosition;
                    if (slider?.SegmentCount % 2 == 0) start = slider.StartPosition;
                    var difference = ho.StartPosition - start;
                    var t = (timing - ho2.EndTime) / (ho.StartTime - ho2.EndTime);
                    result = start + difference * t;
                    break;
                }
                if (!(ho is Slider)) break;
                var s = ho as Slider;
                var tfull = s.SegmentCount * (timing - s.StartTime) / s.Duration;
                var currepeat = (int)(tfull % 2);
                if (currepeat == 1)
                    tfull = (2 - tfull);
                result = s.PositionAt(tfull % 1);
                break;
            }
            return result;
        }

        private ComboColour NextColor(int newCombo) {
            _currentcombocolor += newCombo;
            _currentcombocolor %= ComboColours.Count;
            return ComboColours[_currentcombocolor];
        }

        private void CalculateComboColors() {
            var currentcombo = 1;
            foreach (var ho in GetHitObjects()) {
                if (ho.IsNewCombo) {
                    currentcombo = 1;
                    ho.ComboColour = NextColor(ho.NewCombo);
                }
                else ho.ComboColour = ComboColours[_currentcombocolor];
                ho.ComboNumber = currentcombo;
                currentcombo++;
            }
        }
        #endregion
    }
}