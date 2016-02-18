using System;
using osuElements.Helpers;

namespace osuElements.Storyboards
{
    public abstract class Event : IComparable<Event>
    {
        public EventTypes Type;
        public EventLayer Layer;
        protected int Starttime;
        public virtual int StartTime { get { return Starttime; } protected set { Starttime = value; } }

        public virtual int EndTime { get; protected set; }
        public int Duration => EndTime - StartTime;

        public static bool TryParse(string s, out Event e) {
            e = null;
            string s2 = s.Trim();
            if (s2 == "") return false;
            var s3 = s2.Split(Splitter.Comma);
            int a; EventTypes t;
            if (!int.TryParse(s3[0], out a) && !Enum.TryParse(s3[0], out t)) return false;
            e = Parse(s2);
            if (e == null) return false;
            return true;
        }
        public static Event Parse(string s) {
            var parts = s.Split(Splitter.Comma);
            EventTypes etype;
            Event result;
            if (Enum.TryParse(parts[0], out etype)) {
                string path = "";
                if (parts.Length > 3) path = parts[3].Trim('\"');
                switch (etype) {
                    case (EventTypes.Sprite):
                        result = new SpriteEvent((EventLayer)Enum.Parse(typeof(EventLayer), parts[1]), (Origin)Enum.Parse(typeof(Origin), parts[2]), path, float.Parse(parts[4], Constants.Io.CULTUREINFO), float.Parse(parts[5], Constants.Io.CULTUREINFO));
                        break;
                    case (EventTypes.Animation):
                        Looptypes lt;
                        result = new AnimationEvent((EventLayer)Enum.Parse(typeof(EventLayer), parts[1]), (Origin)Enum.Parse(typeof(Origin), parts[2]), path, float.Parse(parts[4], Constants.Io.CULTUREINFO), float.Parse(parts[5], Constants.Io.CULTUREINFO), int.Parse(parts[6]), int.Parse(parts[7]), (Enum.TryParse(parts[8], out lt)) ? lt : Looptypes.LoopForever);
                        break;
                    case (EventTypes.Sample):
                        result = new SampleEvent(int.Parse(parts[1]), parts[3], int.Parse(parts[4]), (EventLayer)int.Parse(parts[2]));
                        break;
                    case (EventTypes.Background): //Background
                        result = new BackgroundEvent(int.Parse(parts[1]), parts[2], parts.Length > 3 ? int.Parse(parts[3]) : 0, parts.Length > 3 ? int.Parse(parts[4]) : 0);
                        break;
                    case (EventTypes.Video):
                        result = new VideoEvent(int.Parse(parts[1]), parts[2]);
                        break;
                    case (EventTypes.Break): //Break
                        result = new BreakEvent(int.Parse(parts[1]), int.Parse(parts[2]));
                        break;
                    case (EventTypes.Backgroundcolor): //COlor
                        result = new BackgroundColorEvent(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]));
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
            //Video,4655,"Jmmxp.avi" //video
            //0,0,"JamesHa.jpg",0,0 //image
            //1 //animation?
            //2,110843,118365 //break
            //3 //Backgroundcolor
        }
        public int CompareTo(Event other) {
            return Type.CompareTo(other.Type);
        }
    }

}
