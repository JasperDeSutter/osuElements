using osuElements.Storyboards;

namespace osuElements.Beatmaps.Events
{
    public class BackgroundEvent : EventBase
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
            return $"{(int)Type},{StartTime},\"{FilePath}\",{X},{Y}";
        }
    }
}
