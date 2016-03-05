using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using osuElements.Helpers;

namespace osuElements.Storyboards
{
    public class SpriteEvent : EventBase, ITransformable
    {
        public Origin Origin;

        //public float StartX;
        //public float StartY;
        public Position StartPosition { get; set; }
        public List<LoopEvent> Loopevents;
        public List<TriggerEvent> Triggerevents;
        protected string filepath;
        public string Filepath
        {
            get { return filepath; }
            set { filepath = value; }
        }

        public SpriteEvent(string filepath) : this(EventLayer.Foreground, Origin.Centre, filepath, 320, 240) { } //default constructor
        public SpriteEvent(EventLayer layer, Origin origin, string filepath, float x, float y) {
            Type = EventTypes.Sprite;
            Layer = layer;
            Origin = origin;
            Filepath = filepath;
            StartPosition = new Position(x, y);
            Transformations = new List<TransformationEvent>();
            Loopevents = new List<LoopEvent>();
            Triggerevents = new List<TriggerEvent>();
        }

        public void AddTransformation(TransformationEvent t) {
            Transformations.Add(t);
            Transformations.Sort();
            Starttime = Math.Min(StartTime, t.StartTime);
            EndTime = Math.Min(EndTime, t.EndTime);
        }

        public List<TransformationEvent> Transformations { get; set; }

        public override string ToString() {
            return $"{Type},{Layer},{Origin},\"{Filepath}\",{StartPosition.X.ToString(Constants.IO.CULTUREINFO)},{StartPosition.Y.ToString(Constants.IO.CULTUREINFO)}";
        }
    }
}
