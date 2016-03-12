using System;
using System.Collections.Generic;
using System.Linq;
using osuElements.Storyboards;

namespace osuElements.IO.File
{
    public class StoryboardSection<T> : FileSection<T> where T : IStoryboardEvents
    {
        private SpriteEvent _lastSpriteEvent;
        private ITransformable _lastTransformable;
        public Action<EventBase> DefaultEventAction { get; set; }
        public bool UseVariables { get; set; } = true;

        public StoryboardSection(string section, params IFileLine<T>[] fileLines) : base(section, fileLines) { }

        private Dictionary<string, string> _variables;

        public override void SetModel(T model) {
            base.SetModel(model);
            if (!UseVariables) return;
            _variables = model.VariablesDictionary;

            foreach (var key in _variables.Keys.Where(k => !k.StartsWith("$")).ToList()) {
                var value = _variables[key];
                _variables.Remove(key);
                _variables.Add("$" + key, value);
            }
        }
        private string CheckVariables(string line) {
            return _variables.Aggregate(line, (s, pair) => s.Replace(pair.Key, pair.Value));
        }


        public override bool ReadLine(string line) {
            if (UseVariables && _variables.Count > 0 && line.IndexOf('$') >= 0)
                line = CheckVariables(line);
            if ((line.StartsWith(" ") || line.StartsWith("_")) && _lastSpriteEvent != null) {
                LoopEvent l;
                TriggerEvent te;
                TransformationEvent[] transforms;
                if (LoopEvent.TryParse(line, out l)) {
                    _lastSpriteEvent.Loopevents.Add(l);
                    _lastTransformable = l;
                }
                else if (TriggerEvent.TryParse(line, out te)) {
                    _lastSpriteEvent.Triggerevents.Add(te);
                    _lastTransformable = te;
                }
                else if (TransformationEvent.TryParse(line, out transforms)) {
                    if (!line.StartsWith("  ") && !line.StartsWith("__")) {
                        _lastTransformable = _lastSpriteEvent;
                    }
                    foreach (var transform in transforms) {
                        _lastTransformable?.AddTransformation(transform);

                    }
                    return true;
                }
            }
            if (base.ReadLine(line)) return true;
            EventBase e;
            if (!EventBase.TryParse(line, out e)) return false;
            var sample = e as SampleEvent;
            if (sample != null) {
                _model.SampleEvents.Add(sample);
                return true;
            }
            var spriteEvent = e as SpriteEvent;
            if (spriteEvent == null) return false;
            _lastSpriteEvent = spriteEvent;
            _lastTransformable = spriteEvent;
            _model.AddSpriteEvent(spriteEvent);
            return true;
        }

        public bool UseUnderscores { get; set; }

        private void AddSpritesToList(IEnumerable<SpriteEvent> events, List<string> result) {
            var single = UseUnderscores ? "_" : " ";
            var two = UseUnderscores ? "__" : "  ";
            foreach (var spriteEvent in events) {
                result.Add(spriteEvent.ToString());
                foreach (var loopEvent in spriteEvent.Loopevents) {
                    result.Add(single + loopEvent);
                    result.AddRange(loopEvent.Transformations.Select(transformation => two + transformation));
                }
                result.AddRange(spriteEvent.Transformations.Select(transformationEvent => single + transformationEvent));
                foreach (var triggerEvent in spriteEvent.Triggerevents) {
                    result.Add(single + triggerEvent);
                    result.AddRange(triggerEvent.Transformations.Select(transformation => two + transformation));
                }
            }
        }

        public override List<string> AllLines() {
            var result = base.AllLines();
            result.Remove(string.Empty);
            if (result.Count > 1)
                result.Insert(1, "//Background and Video events");
            else result.Add("//Background and Video events");
            result.Add("//Storyboard Layer 0 (Background)");
            AddSpritesToList(_model.BackgroundEvents, result);
            result.Add("//Storyboard Layer 1 (Fail)");
            AddSpritesToList(_model.FailEvents, result);
            result.Add("//Storyboard Layer 2 (Pass)");
            AddSpritesToList(_model.PassEvents, result);
            result.Add("//Storyboard Layer 3 (Foreground)");
            AddSpritesToList(_model.ForegroundEvents, result);
            result.Add("//Storyboard Sound Samples");
            result.AddRange(_model.SampleEvents.Select(b => b.ToString()));
            result.Add(string.Empty);
            if (!UseVariables) return result;
            for (var index = 0; index < result.Count; index++) {
                result[index] = _variables.Aggregate(result[index], (current, keyValuePair) => current.Replace(keyValuePair.Value, keyValuePair.Key));
            }
            return result;
        }

    }
}