using osuElements.Helpers;
using osuElements.Storyboards;

namespace osuElements.Beatmaps.Events
{
    public class BackgroundColorEvent : EventBase
    {
        public Colour Colour;
        public BackgroundColorEvent(int time, byte r, byte g, byte b) {
            Type = EventTypes.Backgroundcolor;
            StartTime = time;
            Colour = new Colour(r, g, b);
        }

        public BackgroundColorEvent(int time, Colour colour) {
            Type = EventTypes.Backgroundcolor;
            Colour = colour;
            StartTime = time;
        }
        public override string ToString() {
            return $"{(int)Type},{StartTime},{Colour}";
        }
    }
}