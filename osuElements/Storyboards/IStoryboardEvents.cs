using System.Collections.Generic;

namespace osuElements.Storyboards
{
    public interface IStoryboardEvents
    {
        List<SpriteEvent> BackgroundEvents { get; set; }
        List<SpriteEvent> FailEvents { get; set; }
        List<SpriteEvent> PassEvents { get; set; }
        List<SpriteEvent> ForegroundEvents { get; set; }
        List<SampleEvent> SampleEvents { get; set; }
        Dictionary<string, string> VariablesDictionary { get; set; }
    }
}