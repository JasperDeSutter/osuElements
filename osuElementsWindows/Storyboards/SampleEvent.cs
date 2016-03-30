namespace osuElements.Storyboards
{
    public class SampleEvent:EventBase
    {
        public string FilePath { get; set; }
        public int Volume { get; set; }
        public SampleEvent(string filepath, int startTime, int volume = 100, EventLayer layer = EventLayer.Background)
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
