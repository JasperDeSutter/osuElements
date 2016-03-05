using osuElements.Helpers;

namespace osuElements.Storyboards.Beatmaps
{
    public class BackgroundColorEvent : EventBase
    {
        public ComboColour Colour;
        public BackgroundColorEvent(int time, int r, int g, int b)
        {
            Type = EventTypes.Backgroundcolor;
            StartTime = time;
            Colour = new ComboColour(r, g, b);
        }
        public override string ToString()
        {
            return $"{(int) Type},{StartTime},{Colour}";
        }
    }
}