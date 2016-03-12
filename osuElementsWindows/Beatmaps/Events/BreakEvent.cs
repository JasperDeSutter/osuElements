using osuElements.Helpers;
using osuElements.Storyboards;

namespace osuElements.Beatmaps.Events
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