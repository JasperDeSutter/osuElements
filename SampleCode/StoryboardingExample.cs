using osuElements;
using osuElements.Beatmaps;
using osuElements.Helpers;
using osuElements.Storyboards;
using osuElements.Storyboards.Triggers;

namespace SampleCode
{
    public class StoryboardingExample
    {
        private Storyboard storyboard;
        private Beatmap beatmap;
        public void ReadWrite() {
            storyboard = new Storyboard("something.osb"); //reads an existing one
            storyboard = new Storyboard(); //makes a new one
            var foregroundevents = storyboard.ForegroundEvents; //sprites and animations
            var transforms = foregroundevents[0].Transformations; //all transformations except loops and triggers
            var loops = foregroundevents[0].Loopevents;
            storyboard.VariablesDictionary.Add("$key", "255,255,255"); //https://osu.ppy.sh/wiki/Storyboard_Variables
            storyboard.FileName = "copy.osb";
            storyboard.WriteFile();
        }

        public void StoryboardGeneration() {
            //sprite creation
            var sprite = new SpriteEvent("sb\\image.png", EventLayer.Foreground);
            var animation = new AnimationEvent("sb\\images.jpg", 10, 20); //don't specify an index number of the file 
            //adding transformations
            sprite.AddTransformation(new TransformationEvent(TransformTypes.F, Easing.None, 0, 200, new[] { 0f }, new[] { 1f }));
            //shortcut methods
            sprite.Move(100, 200, Easing.In, new Position(0, 0), new Position(300, 400));
            sprite.FlipH(500, 700);
            //loops
            var loop = new LoopEvent(200, 5);
            loop.Color(0, values: new Colour(255, 255, 255)); //also have these shortcut methods
            sprite.AddLoop(loop); //you still need to add it to one or more sprites
            //triggers
            var trigger = new TriggerEvent(TriggerTypes.Failing, 0, 1000);//short way, only for failing and passing
            //somewhat longer way for hitsounds
            var hitsound = new HitSoundTrigger(HitObjectSoundType.Clap);
            hitsound.SampleSet = SampleSet.Drum;
            var hitsoundTrigger = new TriggerEvent(hitsound, 0, 500);
            sprite.AddTrigger(trigger); //also add it to one or more sprites

            storyboard.AddSpriteEvent(sprite); //dont forget to add it!
            beatmap.AddSpriteEvent(sprite); //or add it to the beatmap instead
        }
    }
}