using osuElements.Helpers;

namespace osuElements.Storyboards.Beatmaps
{
    public class BreakEvent : EventBase
    {
        public BreakEvent(int time, int endTime)
        {
            Type = EventTypes.Break;
            StartTime = time;
            EndTime = endTime;
        }
        public override string ToString()
        {
            return $"{(int) Type},{StartTime},{EndTime}";
        }
    }
}