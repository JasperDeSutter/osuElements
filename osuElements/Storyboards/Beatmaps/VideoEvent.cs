using osuElements.Helpers;

namespace osuElements.Storyboards.Beatmaps
{
    public class VideoEvent : EventBase
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
}