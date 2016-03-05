using System;
using System.Collections.Generic;
using System.Linq;
using osuElements.Helpers;
using osuElements.Repositories;

namespace osuElements.Replays
{
    public class ReplayManager
    {
        Beatmap _beatmap;
        private BeatmapManager _bManager;
        public Replay Replay { get; }

        public ReplayManager(Replay replay) {
            Replay = replay;
        }
        //public Beatmap FindBeatmap(string songsFolder) {
        //    var beatmaps = new List<Beatmap>();
        //    if (!Directory.Exists(songsFolder)) return null;
        //    var songfolders = Directory.GetDirectories(songsFolder);
        //    foreach (string songfolder in songfolders) {
        //        string[] beatmapfiles = Directory.GetFiles(songfolder, "*.osu");
        //        var map = FindBeatmap(beatmapfiles.Select(beatmap => new Beatmap(beatmap, false)));
        //        if (map != null)
        //            return map;
        //    }
        //    return null;
        //}
        public Beatmap FindBeatmap(IEnumerable<Beatmap> maps) {
            return maps.FirstOrDefault(map => map.CompareMd5(Replay.BeatmapHash));
        }

        public void SetBeatmap(Beatmap beatmap) {
            if (!beatmap.CompareMd5(Replay.BeatmapHash)) throw new Exception("The beatmap does not have the hash the replay requires.");
            _beatmap = beatmap;
            _bManager = new BeatmapManager(beatmap);
            _bManager.SetMods(Replay.Enabled_Mods);
            _bManager.DifficultyCalculations();
        }
        public Dictionary<HitObject, KeyPress> KeyPresses;
        private float _timing50;
        private float _timing100;
        private float _timing300;
        private int _approachMs;

        public void Calculate() {
            _timing50 = _bManager.HitWindow50 * _bManager.ModSpeedMultiplier;
            _timing100 = _bManager.HitWindow100 * _bManager.ModSpeedMultiplier;
            _timing300 = _bManager.HitWindow300 * _bManager.ModSpeedMultiplier;
            _approachMs = _bManager.PreEmpt;

            var keyPresses = Calculate(Replay.ReplayFrames, ReplayKey.K1);
            keyPresses.AddRange(Calculate(Replay.ReplayFrames, ReplayKey.K2));
            keyPresses.Sort();
            KeyPresses = new Dictionary<HitObject, KeyPress>();

            foreach (var ho in _beatmap.HitObjects) {
                float time = ho.StartTime;
                KeyPress a;
                try {
                    a = keyPresses.First(t => t.Start > time - _approachMs && t.Start < time + _timing50);
                    keyPresses.Remove(a);
                }
                catch {
                    a = new KeyPress(null, 0, ReplayKey.None) { Timing = 0 };
                }

                if ((ho.Type & HitObjectType.Slider) > 0) {
                    var s = ho as Slider;

                    var isBreak =
                        a.Frames.Select(f => f.Position.Distance(s.PositionAtTime(f.Time)))
                            .Any(f => f > _bManager.HitObjectRadius);
                    
                    a.Timing = isBreak ? 100 : 300;
                }
                else
                    a.Timing = GetTiming(a.Start, ho.StartTime);
                KeyPresses.Add(ho, a);

            }

        }

        private int GetTiming(float actual, float desired) {

            if (actual < desired + _timing300 && actual > desired - _timing300) return 300;
            if (actual < desired + _timing100 && actual > desired - _timing100)
                return 100;
            if (actual < desired + _timing50 && actual > desired - _timing50)
                return 50;
            return 0;
        }

        private static List<KeyPress> Calculate(IEnumerable<ReplayFrame> rframes, ReplayKey k) {
            var result = new List<KeyPress>();
            var frames = new List<ReplayFrame>();
            foreach (var t in rframes) {
                if ((k & t.Key) > 0) {
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


        public class KeyPress : IComparable<KeyPress>
        {
            public List<ReplayFrame> Frames { get; }

            public KeyPress(IEnumerable<ReplayFrame> frames, int nexttime, ReplayKey key) {
                var replayFrames = frames?.ToList() ?? new List<ReplayFrame>();
                Frames = replayFrames;

                Start = replayFrames.Count > 0 ? replayFrames.Min(f => f.Time) : 0;
                if (replayFrames.Count > 0)
                    Position = new Position(replayFrames[0].X, replayFrames[0].Y);
                End = nexttime;
                ReplayKey = key;
            }
            public int Start { get; set; }
            public int End { get; set; }
            public ReplayKey ReplayKey { get; set; }
            public int Timing { get; set; }
            public Position Position { get; set; }
            public int CompareTo(KeyPress other) {
                return Start.CompareTo(other.Start);
            }

            public override string ToString() {
                return $"{Start} - {End} : {Timing}";
            }
        }
    }
}
