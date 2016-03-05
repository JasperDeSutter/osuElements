using osuElements.Helpers;

namespace osuElements.Storyboards
{
    public class SampleEvent:EventBase
    {
        public string FilePath;
        public int Volume;
        public SampleEvent(int startTime,  string filepath, int volume=100, EventLayer layer=EventLayer.Background)
        {
            Type = EventTypes.Sample;
            Layer = layer;
            StartTime = startTime;
            FilePath = filepath;
            Volume = volume;
        }
        public override string ToString() => $"{Type},{StartTime},{(int) Layer},\"{FilePath}\",{Volume}";
    }
}
