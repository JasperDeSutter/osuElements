using System;
using osuElements.Beatmaps.Events;
using osuElements.Helpers;

namespace osuElements.Storyboards
{
    public abstract class EventBase : IComparable<EventBase>
    {
        public EventLayer Layer = EventLayer.Undefined;
        public EventTypes Type;
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int Duration => EndTime - StartTime;
        
        public static bool TryParse(string s, out EventBase e) {
            e = null;
            string s2;
            if (string.IsNullOrEmpty(s2 = s?.Trim())) return false;
            var s3 = s2.Split(',');
            EventTypes t;
            if (!Enum.TryParse(s3[0], out t)) return false;
            e = Parse(s2);
            return e != null;
        }

        public static EventBase Parse(string s) {
            var parts = s.Split(',');
            EventTypes etype;
            EventBase result;
            if (Enum.TryParse(parts[0], out etype)) {
                switch (etype) {
                    case EventTypes.Sprite:
                        result = new SpriteEvent(parts[3].Trim('\"'),
                            (EventLayer)Enum.Parse(typeof(EventLayer), parts[1]),
                            (Origin)Enum.Parse(typeof(Origin), parts[2]), float.Parse(parts[4], Constants.Cultureinfo),
                            float.Parse(parts[5], Constants.Cultureinfo));
                        break;
                    case EventTypes.Animation:
                        result = new AnimationEvent(parts[3].Trim('\"'),
                            int.Parse(parts[6]), double.Parse(parts[7]),
                            (EventLayer)Enum.Parse(typeof(EventLayer), parts[1]),
                            (Origin)Enum.Parse(typeof(Origin), parts[2]), float.Parse(parts[4], Constants.Cultureinfo),
                            float.Parse(parts[5], Constants.Cultureinfo),
                            parts.Length > 8 ? (Looptypes)Enum.Parse(typeof(Looptypes), parts[8]) : Looptypes.LoopForever);
                        break;
                    case EventTypes.Sample:
                        result = new SampleEvent(parts[3], int.Parse(parts[1]),
                            parts.Length > 4 ? int.Parse(parts[4]) : 100, (EventLayer)int.Parse(parts[2]));
                        break;
                    case EventTypes.Background:
                        result = new BackgroundEvent(int.Parse(parts[1]), parts[2].Trim('"'),
                            parts.Length > 3 ? int.Parse(parts[3]) : 0, parts.Length > 4 ? int.Parse(parts[4]) : 0);
                        break;
                    case EventTypes.Video:
                        result = new VideoEvent(int.Parse(parts[1]), parts[2].Trim('"'));
                        break;
                    case EventTypes.Break:
                        result = new BreakEvent(int.Parse(parts[1]), int.Parse(parts[2]));
                        break;
                    case EventTypes.Backgroundcolor:
                        result = new BackgroundColorEvent(int.Parse(parts[1]), byte.Parse(parts[2]),
                            byte.Parse(parts[3]),
                            byte.Parse(parts[4]));
                        break;
                    default:
                        result = new UndefinedEvent(parts);
                        break;
                }
            }
            else {
                result = new UndefinedEvent(parts);
            }
            return result;
            //0,0,"JamesHa.jpg",0,0 //image
            //Video,4655,"Jmmxp.avi" //video
            //2,110843,118365 //break
            //3 //Backgroundcolor
        }

        public int CompareTo(EventBase other) {
            return Type.CompareTo(other.Type);
        }

        public static bool TryParse<T>(string line, out T result) where T : EventBase {
            EventBase e;
            if (TryParse(line, out e)) {
                result = e as T;
                return result != null;
            }
            result = null;
            return false;
        }

        public class UndefinedEvent : EventBase
        {
            public string[] Lineparts;

            public UndefinedEvent(string[] lineparts) {
                Lineparts = lineparts;
            }

            public override string ToString() {
                return string.Join(",", Lineparts);
            }
        }
    }
}