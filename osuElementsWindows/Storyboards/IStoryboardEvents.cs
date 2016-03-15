using System.Collections.Generic;

namespace osuElements.Storyboards
{
    public interface IStoryboardEvents
    {
        /// <summary>
        /// A list of all Sprite- and AnimationEvents in the background layer
        /// </summary>
        List<SpriteEvent> BackgroundEvents { get; set; }
        /// <summary>
        /// A list of all Sprite- and AnimationEvents in the fail layer
        /// </summary>
        List<SpriteEvent> FailEvents { get; set; }
        /// <summary>
        /// A list of all Sprite- and AnimationEvents in the pass layer
        /// </summary>
        List<SpriteEvent> PassEvents { get; set; }
        /// <summary>
        /// A list of all Sprite- and AnimationEvents in the foreground layer
        /// </summary>
        List<SpriteEvent> ForegroundEvents { get; set; }
        /// <summary>
        /// A list of all sound samples to be played with the storyboard
        /// </summary>
        List<SampleEvent> SampleEvents { get; set; }
        /// <summary>
        /// A dictionary of keys to hold variable values in the storyboard
        /// </summary>
        Dictionary<string, string> VariablesDictionary { get; set; }

        void AddSpriteEvent(SpriteEvent sprite);
    }
}