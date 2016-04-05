using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using osuElements.Beatmaps.Base;
using osuElements.Helpers;

namespace osuElements.Beatmaps
{
    /// <summary>
    /// Handles timingpoints, creates curves for sliders, handles combo colors and numbers. 
    /// For standard osu! game mode.
    /// </summary>
    public class BeatmapManager : HitObjectManagerBase
    {
        #region Fields
        private Beatmap _beatmap;
        private int _currentcombocolor;
        private TpDifficulty _tpDifficulty;
        private bool _hitObjectsFlipped;
        private bool _flipHitObjects;
        private List<HitObject> _hitObjects;
        #endregion
        /// <summary>
        /// Sets the beatmap and calculates the Combo numbers and colors.
        /// </summary>
        public BeatmapManager(Beatmap beatmap) {
            SetBeatmap(beatmap);
        }

        #region Properties
        public List<TimingPoint> TimingPoints => _beatmap.TimingPoints;
        public List<Colour> ComboColours { get; set; }
        public Mods Mods { get; private set; }

        private float DifficultyModMultiplier =>
            (Mods.IsType(Mods.HardRock) ? Constants.HARD_ROCK_MULTIPLIER : 1) * (Mods.IsType(Mods.Easy) ? Constants.EASY_MULTIPLIER : 1);

        //Circle size uses this one
        private float CircleSizeModMultiplier =>
            (Mods.IsType(Mods.HardRock) ? Constants.CIRCLE_SIZE_MOD_MULTIPLIER : 1) *
            (Mods.IsType(Mods.Easy) ? Constants.EASY_MULTIPLIER : 1);

        public float ModSpeedMultiplier =>
            (Mods.IsType(Mods.DoubleTime) || Mods.IsType(Mods.Nightcore) ? Constants.DT_MULTIPLIER : 1) *
            (Mods.IsType(Mods.HalfTime) ? Constants.HT_MULTIPLIER : 1);
        #endregion

        #region Methods
        public override Beatmap GetBeatmap() => _beatmap;

        public override List<HitObject> GetHitObjects() {
            if (_hitObjectsFlipped != _flipHitObjects) {
                FlipHitobjects();
                _hitObjectsFlipped = _flipHitObjects;
            }
            return _hitObjects;
        }

        public override double AdjustDifficulty(double difficulty) {
            return Math.Min(10, difficulty * CircleSizeModMultiplier);
        }

        public override double MapDifficultyRange(double difficulty, double min, double mid, double max) {
            difficulty = Math.Min(10, DifficultyModMultiplier * difficulty);
            if (difficulty == 5) return mid;
            if (difficulty > 5) return MathHelper.Lerp((difficulty - 5) / 5, mid, max);
            return MathHelper.Lerp(difficulty / 5, min, mid);
        }

        /// <summary>
        /// Sets the beatmap and calculates difficulties, ComboColors and Stacking
        /// </summary>
        public void SetBeatmap(Beatmap beatmap) {
            _beatmap = beatmap;
            //ComboColours = _beatmap.ComboColours;
            _hitObjects = beatmap.HitObjects.Select(h => h.Clone()).ToList();
            //CalculateComboColors();
            //CalculateStacking();
            DifficultyCalculations();
        }

        /// <summary>
        /// Adds HitLength, DifficultyRating, Bpm, TotalLength and MaxCombo
        /// </summary>
        public void ApiCalculations() {
            var modsbuffer = Mods;
            SetMods(Mods.None);
            _beatmap.DifficultyRating = CalculateDifficlty();
            SetMods(modsbuffer);
            _beatmap.Bpm = (int)_beatmap.TimingPoints.First(tp => tp.IsTiming).Bpm;
            _beatmap.TotalLength = _hitObjects.Max(h => h.EndTime) - _hitObjects.Min(h => h.StartTime);
            _beatmap.HitLength = _beatmap.TotalLength - _beatmap.BreakPeriods.Sum(b => b.Duration);
            _beatmap.MaxCombo = _hitObjects.Sum(h => h.MaxCombo);
        }

        public void SliderCalculations() {
            foreach (var slider in GetHitObjects().OfType<Slider>()) {
                var mult = SliderVelocityAt(slider.StartTime);
                slider.Duration = (int)(slider.Length * slider.SegmentCount / mult);
                slider.CreateCurve();
                slider.ScorePointCount = (int)(_beatmap.DifficultySliderTickRate * slider.SegmentDuration / BeatlengthAt(slider.StartTime));
            }
        }

        public void DifficultyCalculations() {
            var difficulty = Math.Min(10, DifficultyModMultiplier * _beatmap.DifficultyOverall);
            HitObjectRadius = (float)(54.422 - AdjustDifficulty(_beatmap.DifficultyCircleSize) * 4.4818);
            HitWindow300 = (int)(80 - difficulty * 6);
            HitWindow100 = (int)(140 - difficulty * 8);
            HitWindow50 = (int)(200 - difficulty * 10);
            PreEmpt = (int)MapDifficultyRange(_beatmap.DifficultyApproachRate, 1800, 1200, 450);
            SpinnerRotationRatio = MapDifficultyRange(_beatmap.DifficultyOverall, 3, 5, 7.5);
            StackOffset = HitObjectRadius / 10;
            SliderScoringPointDistance = 100 * _beatmap.DifficultySliderMultiplier / _beatmap.DifficultySliderTickRate;
        }

        private void FlipHitobjects() {
            foreach (var hitObject in _hitObjects) {
                hitObject.StartPosition = Position.Flip(hitObject.StartPosition);
                if (!hitObject.IsHitObjectType(HitObjectType.Slider)) continue;
                var slider = hitObject as Slider;
                for (var i = 0; i < slider.ControlPoints.Length; i++) {
                    slider.ControlPoints[i] = Position.Flip(slider.ControlPoints[i]);
                }
            }
        }

        public void SetMods(Mods mods) {
            if (mods.HasFlag(Mods.Easy)) {
                if (mods.HasFlag(Mods.HardRock)) throw new ArgumentException("Easy and HardRock are enabled at the same time");
                _flipHitObjects = false;
            }
            if (mods.HasFlag(Mods.HardRock)) {
                _flipHitObjects = true;
            }
            if (mods.HasFlag(Mods.HalfTime) && mods.HasFlag(Mods.DoubleTime)) {
                throw new ArgumentException("HalfTime and DoubleTime (or Nightcore) are enabled at the same time");
            }
            if (mods.HasFlag(Mods.Nightcore) && !mods.HasFlag(Mods.DoubleTime)) throw new ArgumentException("Nightcore is enabled without DoubleTime");

            //TODO check for more impossible combinations
            Mods = mods;
            DifficultyCalculations();
        }


        public void CalculateStacking() {
            const int stackLenience = 3;
            var hitobjects = GetHitObjects();
            for (var i = hitobjects.Count - 1; i > 0; i--) {
                var n = i;
                var objectI = hitobjects[i];

                if (objectI.StackCount != 0 || objectI is Spinner) continue;

                if (objectI is Slider) {
                    while (--n >= 0) {
                        var objectN = hitobjects[n];
                        if (objectN is Spinner) continue;

                        if (objectI.StartTime - (PreEmpt * _beatmap.StackLeniency) > objectN.EndTime)
                            break;
                        if (!(objectN.EndPosition.Distance(objectI.StartPosition) < stackLenience)) continue;
                        objectN.StackCount = objectI.StackCount + 1;
                        objectI = objectN;
                    }
                }
                else if (objectI is HitCircle) {
                    while (--n >= 0) {
                        var objectN = hitobjects[n];
                        if (objectN is Spinner) continue;

                        if (objectI.StartTime - (PreEmpt * _beatmap.StackLeniency) > objectN.EndTime)
                            break;
                        if (objectN != null && objectN.EndPosition.Distance(objectI.StartPosition) < stackLenience) {
                            var offset = objectI.StackCount - objectN.StackCount + 1;
                            for (var j = n + 1; j <= i; j++) {
                                if (objectN.EndPosition.Distance(hitobjects[j].StartPosition) < stackLenience)
                                    hitobjects[j].StackCount -= offset;
                            }
                            break;
                        }

                        if (!(objectN.StartPosition.Distance(objectI.StartPosition) < stackLenience)) continue;
                        objectN.StackCount = objectI.StackCount + 1;
                        objectI = objectN;
                    }
                }
            }
        }

        public double CalculateDifficlty() {
            if (_tpDifficulty == null) _tpDifficulty = new TpDifficulty(this);
            return _tpDifficulty.CalculateDifficulty();
        }

        public double BpmAt(int time) {
            return (Last(time, true).Bpm);
        }

        public double BeatlengthAt(int time) {
            return Last(time, true).BeatLength;
        }

        public override double SliderVelocityAt(int time) {
            var mult = Last(time); //if result is timing, return bpm. if its not, return speedmult * lastbpm
            var bpm = Last(time, true);
            var result = bpm.Bpm * _beatmap.DifficultySliderMultiplier / 600; // divide by 60,000 minutes->ms and multiply 100 for default slider length
            if (mult == null || mult.Offset < bpm.Offset) return result;
            return mult.SliderVelocityMultiplier * result;
        }

        public TimingPoint Last(float time, bool isBpm = false) {
            var timingpoints = TimingPoints;
            var result = timingpoints.LastOrDefault(tp => tp.Offset <= time && tp.IsTiming == isBpm);
            if (isBpm && result == null) result = timingpoints.First(tp => tp.IsTiming);
            return result;
        }

        public Position AutoCursorPosition(float timing) {
            var result = Constants.CENTER_OF_SCREEN;
            var hitobjects = GetHitObjects();
            for (var i = 0; i < hitobjects.Count; i++) {
                var ho = hitobjects[i];
                if (timing > ho.EndTime) continue;
                if (timing < ho.StartTime) {
                    if (i == 0) {
                        result = ho.StartPosition;
                        break;
                    }
                    var ho2 = hitobjects[i - 1];
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
                result = s.PositionAtTime(timing);
                break;
            }
            return result;
        }

        private Colour NextColor(int newCombo) {
            _currentcombocolor += newCombo;
            _currentcombocolor %= ComboColours.Count;
            return ComboColours[_currentcombocolor];
        }

        private void CalculateComboColors() {
            var currentcombo = 1;
            HitObject previous = null;
            foreach (var ho in _hitObjects) {
                if (ho.IsNewCombo || (previous != null && previous.IsHitObjectType(HitObjectType.Spinner))) {
                    if (previous != null) previous.LastInCombo = true;
                    currentcombo = 1;
                    ho.Colour = NextColor(ho.NewCombo);
                }
                else ho.Colour = ComboColours[_currentcombocolor];
                previous = ho;
                ho.ComboNumber = currentcombo;
                currentcombo++;
            }
        }

        public HitSound[] GetHitsoundsForHitobject(HitObject ho) {
            var timingPoint = Last(ho.StartTime);
            if (timingPoint == null) return new[] { new HitSound(SampleSet.Normal, HitObjectSoundType.Normal, 0) };
            var result = ho.InheritSoundsFrom(timingPoint);
            if (!ho.IsHitObjectType(HitObjectType.Slider)) return ho.GetHitSounds();

            var slider = ho as Slider;
            if (slider.PointHitsounds != null && slider.PointHitsounds.Count > 0)
                return slider.PointHitsounds[0].InheritSoundsFrom(result).GetHitSounds();
            return ho.GetHitSounds();
        }
        #endregion
    }
}