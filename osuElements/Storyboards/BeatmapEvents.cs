namespace osuElements.Storyboards
{
    public class BackgroundEvent : Event
    {
        public int X;
        public int Y;
        public string FilePath;
        public BackgroundEvent(int time, string filepath, int x, int y)
        {
            Type = EventTypes.Background;
            StartTime = time;
            X = x;
            Y = y;
            FilePath = filepath;
        }
        public override string ToString()
        {
            return $"{Type},{StartTime},\"{FilePath}\",{X},{Y}";
        }
    }
    public class VideoEvent : Event
    {
        public string FilePath;
        public VideoEvent(int time, string filepath)
        {
            Type = EventTypes.Video;
            StartTime = time;
            FilePath = filepath;
        }
        public override string ToString()
        {
            return $"{Type},{StartTime},\"{FilePath}\"";
        }
    }
    public class BreakEvent : Event
    {
        public BreakEvent(int time, int endTime)
        {
            Type = EventTypes.Break;
            StartTime = time;
            EndTime = endTime;
        }
        public override string ToString()
        {
            return $"{(int) Type},{StartTime},\"{EndTime}\"";
        }
    }
    //TODO
    public class BackgroundColorEvent : Event
    {
        public ComboColor Color;
        public BackgroundColorEvent(int time, int r, int g, int b)
        {
            Type = EventTypes.Backgroundcolor;
            StartTime = time;
            Color = new ComboColor(r, g, b);
        }
        public override string ToString()
        {
            return $"{(int) Type},{StartTime},{Color}";
        }
    }
}
