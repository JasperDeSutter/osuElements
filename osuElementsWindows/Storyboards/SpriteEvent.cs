using System;
using System.Collections.Generic;
using System.Linq;
using osuElements.Helpers;

namespace osuElements.Storyboards
{
    public class SpriteEvent : EventBase, ITransformable
    {
        public Origin Origin { get; set; }
        public Position StartPosition { get; set; }
        public List<LoopEvent> Loopevents { get; set; }
        public List<TriggerEvent> Triggerevents { get; set; }
        public string Filepath { get; set; }

        public SpriteEvent(string filepath, EventLayer layer = EventLayer.Background, Origin origin = Origin.Centre, float x = 320, float y = 240) {
            Type = EventTypes.Sprite;
            Layer = layer;
            Origin = origin;
            Filepath = filepath;
            StartPosition = new Position(x, y);
            Transformations = new List<TransformationEvent>();
            Loopevents = new List<LoopEvent>();
            Triggerevents = new List<TriggerEvent>();
            StartTime = int.MaxValue;
            EndTime = int.MinValue;
        }

        public void AddLoop(LoopEvent l) {
            Loopevents.Add(l);
            Loopevents.Sort();
        }

        public void AddTrigger(TriggerEvent t) {
            Triggerevents.Add(t);
            Triggerevents.Sort();
        }

        public void AddTransformation(params TransformationEvent[] transforms) {
            Transformations.AddRange(transforms);
            Transformations.Sort();
            StartTime = Math.Min(transforms.Min(t => t.StartTime), StartTime);
            EndTime = Math.Max(transforms.Max(t => t.EndTime), EndTime);
        }
        public void RemoveTransformation(params TransformationEvent[] transforms) {
            foreach (var transformationEvent in transforms) {
                Transformations.Remove(transformationEvent);
            }
            StartTime = Transformations.Min(t => t.StartTime);
            EndTime = Transformations.Max(t => t.StartTime);
        }


        public List<TransformationEvent> Transformations { get; set; }

        public static string DefaultFileExtension = "jpg";

        public override string ToString() {
            if (!Filepath.Contains(".")) Filepath += "." + DefaultFileExtension;
            return $"{Type},{Layer},{Origin},\"{Filepath}\",{StartPosition.X.ToString(Constants.CULTUREINFO)},{StartPosition.Y.ToString(Constants.CULTUREINFO)}";
        }
    }
}
