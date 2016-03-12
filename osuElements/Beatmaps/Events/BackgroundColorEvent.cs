using osuElements.Helpers;
using osuElements.Storyboards;

namespace osuElements.Beatmaps.Events
{
    public class BackgroundColorEvent : EventBase
    {
        public Colour Colour;
        public BackgroundColorEvent(int time, int r, int g, int b)
        {
            Type = EventTypes.Backgroundcolor;
            StartTime = time;
            Colour = new Colour(r, g, b);
        }
        public override string ToString()
        {
            return $"{(int) Type},{StartTime},{Colour}";
        }
    }
}