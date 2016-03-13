using System;
using System.Collections.Generic;
using System.Linq;
using osuElements.Beatmaps;
using osuElements.Helpers;

namespace osuElements.Replays
{
    public class ReplayManager
    {
        public Beatmap Beatmap { get; private set; }
        private BeatmapManager _bManager;
        public Replay Replay { get; private set; }

        public ReplayManager(Replay replay) {
            Replay = replay;
        }

        public void SetReplay(Replay replay) {
            Replay = replay;
        }

        public Beatmap FindBeatmap(IEnumerable<Beatmap> maps) {
            return maps.FirstOrDefault(map => map.CompareHash(Replay.BeatmapHash));
        }

        public void SetBeatmap(Beatmap beatmap) {
            if (!beatmap.CompareHash(Replay.BeatmapHash)) throw new Exception("The beatmap does not have the hash the replay requires.");
            Beatmap = beatmap;
            _bManager = new BeatmapManager(beatmap);
            _bManager.SetMods(Replay.Enabled_Mods);
            _bManager.DifficultyCalculations();
        }
        
        private float _timing50;
        private float _timing100;
        private float _timing300;
        private List<KeyPress> _keyPresses;
        private bool ForceRecalculation { get; set; }
        private void CalculateKeyPresses() {
            if (_keyPresses != null && !ForceRecalculation) return;
            _keyPresses = CalculateKeyPresses(Replay.ReplayFrames, ReplayKeys.K1);
            _keyPresses.AddRange(CalculateKeyPresses(Replay.ReplayFrames, ReplayKeys.K2));
            _keyPresses.Sort();
            ForceRecalculation = false;
        }
        private static List<KeyPress> CalculateKeyPresses(IEnumerable<ReplayFrame> rframes, ReplayKeys k) {
            var result = new List<KeyPress>();
            var frames = new List<ReplayFrame>();
            foreach (var t in rframes) {
                if ((k & t.Keys) > 0) {
                    frames.Add(t);
                }
                else {
                    if (frames.Count == 0) {
                        continue;
                    }
                    result.Add(new KeyPress(frames, t.Time, k));
                    frames = new List<ReplayFrame>();
                }
            }
            return result;
        }

        public List<HitobjectTiming> CalculateHitTimings() { //WIP
            var hitobjects = Beatmap.HitObjects?
                .Where(h => h.Type.IsType(HitObjectType.HitCircle | HitObjectType.Slider));
            if (hitobjects == null) return null;
            var result = new List<HitobjectTiming>();

            _timing50 = _bManager.HitWindow50 * _bManager.ModSpeedMultiplier;
            _timing100 = _bManager.HitWindow100 * _bManager.ModSpeedMultiplier;
            _timing300 = _bManager.HitWindow300 * _bManager.ModSpeedMultiplier;
            CalculateKeyPresses();

            var frames = new List<ReplayFrame>(Replay.ReplayFrames);
            var keypresses = _keyPresses;
            
            foreach (var ho in hitobjects) {
                float time = ho.StartTime;
                _keyPresses.RemoveAll(k => k.Start < time - _bManager.PreEmpt);
                KeyPress match;
                try {
                    match = _keyPresses.FirstOrDefault(t =>
                t.Start < time + _bManager.HitWindow50 &&
                t.Position.Distance(ho.StartPosition) <= _bManager.HitObjectRadius);
                }
                catch {
                    match = new KeyPress(null, 0, ReplayKeys.None) { Timing = 0 };
                }

                if ((ho.Type & HitObjectType.Slider) > 0) {
                    var s = ho as Slider;

                    var isBreak =
                        match.Frames.Select(f => f.Position.Distance(s.PositionAtTime(f.Time)))
                            .Any(f => f > _bManager.HitObjectRadius * 3);

                    //TODO foreach sliderscorepoint except last => check if any key is pressed and is in range, else break
                    //TODO last sliderpoint: if not in range/ no key pressed => 100

                    match.Timing = isBreak ? 100 : 300;
                }
                else
                    match.Timing = GetTiming(match.Start, ho.StartTime);

            }
            ForceRecalculation = true;
            return result;
        }

        private int GetTiming(float actual, float desired) {
            if (actual < desired + _timing300 && actual > desired - _timing300) return 300;
            if (actual < desired + _timing100 && actual > desired - _timing100)
                return 100;
            if (actual < desired + _timing50 && actual > desired - _timing50)
                return 50;
            return 0;
        }


        public ReplayFrame GetPositionAt(float time, IEnumerable<ReplayFrame> frames = null) {
            if (frames == null) frames = Replay.ReplayFrames;
            var previous = frames.FirstOrDefault();
            foreach (var replayFrame in frames) {
                if (replayFrame.Time >= time) {
                    var t = time / (replayFrame.Time - previous.Time);
                    var pos = replayFrame.Position + (previous.Position - replayFrame.Position) * t;
                    return new ReplayFrame() { Keys = replayFrame.Keys, Position = pos, Time = (int)time }; //TODO is keys from first or second?
                }
                previous = replayFrame;
            }
            return previous;
        }

        public KeyPress GetFirstHitBetween(float starttime, float endtime, Position pos, float distance, IEnumerable<KeyPress> keyPresses = null) {
            if (keyPresses == null) {
                CalculateKeyPresses();
                keyPresses = _keyPresses;
            }
            return keyPresses.FirstOrDefault(frame => frame.Start <= starttime && frame.Start >= endtime && frame.Position.Distance(pos) <= distance);
        }
    }
}
