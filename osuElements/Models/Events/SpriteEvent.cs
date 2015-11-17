using osuElements.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace osuElements.Events
{
    public class SpriteEvent : Event, ITransformable
    {
        public Origin Origin;
        private TransformationModel _currentTransform;

        public float StartX;
        public float StartY;
        public List<TransformationEvent> Transformations;
        public List<LoopEvent> Loopevents;
        public List<TriggerEvent> Triggerevents;
        protected string filepath;
        public string Filepath
        {
            get { return filepath; }
            set { filepath = value; }
        }

        public SpriteEvent(string filepath) : this(EventLayer.Foreground, Origin.Centre, filepath, 320, 240) { } //default constructor
        public SpriteEvent(EventLayer layer, Origin origin, string filepath, float x, float y)
        {
            Type = EventTypes.Sprite;
            this.Layer = layer;
            this.Origin = origin;
            this.Filepath = filepath;
            StartX = x;
            StartY = y;
            Transformations = new List<TransformationEvent>();
            Loopevents = new List<LoopEvent>();
            Triggerevents = new List<TriggerEvent>();
            _currentTransform = new TransformationModel(x, y);
        }
        public void Trigger(TriggerTypes tt, float time)
        {
            var triggers = Transformations.Where(t => t.Transformtype == TransformTypes.T).Select(s => s as TriggerEvent)
                .Where(w => w.TriggerType == tt && w.StartTime < time && w.EndTime > time);
        }

        public bool IsActive(float time)
        {
            //If between transformations (start and end) then always draw
            if (time >= StartTime && time <= EndTime) return true;
            //If in loop, look if active
            return Loopevents.Any(loop => loop.IsActive(time));
        }

        public TransformationModel CurrentValues(float time)
        {
            //currentTransform.SetParametersFalse();

            foreach (TransformTypes tt in Enum.GetValues(typeof(TransformTypes)))
            {
                if (tt == TransformTypes.L || tt == TransformTypes.T) break;
                var active = Transformations.Where(t => t.Transformtype == tt).ToArray(); //select only one type at a time

                bool hasactive = false;
                foreach (TransformationEvent te in active)
                {
                    if (hasactive && te.StartTime > time) break;
                    if (te.CurrentValues(time, ref _currentTransform)) break; //if we have an active one, go to next type. First transform of a type gets executed
                    if (te.StartTime > time) break;
                    hasactive = true;
                }
            }
            if (Loopevents.Any(le => le.CurrentValues(time, ref _currentTransform))) {
                return _currentTransform;
            }
            return _currentTransform;
        }
        public void AddTransformation(TransformationEvent t)
        {
            var l = t as LoopEvent;
            var te = t as TriggerEvent;

            if (l != null)
            {
                Loopevents.Add(l);
                Loopevents.Sort();
                return;
            }
            if (te != null)
            {
                Triggerevents.Add(te);
                Triggerevents.Sort();
                return;
            }
            Transformations.Add(t);
            Transformations.Sort();
            Starttime = Transformations.Min(m => m.StartTime);
            EndTime = Transformations.Max(m => m.EndTime);
        }
        #region FileStuff
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(ActualToString());
            result.Append("\r\n");
            result.Append(ChildrenToString());
            return result.ToString();
        }
        protected string ChildrenToString()
        {
            var result = new StringBuilder();
            var tostring = new List<TransformationEvent>(Transformations);
            tostring.AddRange(Loopevents);
            tostring.AddRange(Triggerevents);
            tostring.Sort();
            foreach (var t in tostring)
            {
                result.Append(" " + t.ToString());
            }
            return result.ToString();
        }
        protected string ActualToString() => 
            $"{Type},{Layer},{Origin},\"{Filepath}\",{StartX.ToString(Constants.FORMATPROVIDER)},{StartY.ToString(Constants.FORMATPROVIDER)}";

        #endregion
    }
}
