using System;
using System.Collections.Generic;
using System.Linq;
using osuElements.Helpers;

namespace osuElements.Storyboards
{
    public class AnimationEvent : SpriteEvent
    {
        public int Framecount { get; set; }
        public int FrameDuration { get; set; }
        public Looptypes Looptype { get; set; }

        public AnimationEvent(string filepath, int frameCount, int frameDuration, EventLayer layer = EventLayer.Background,
            Origin origin = Origin.Centre, float x = 320, float y = 240, Looptypes looptype = Looptypes.LoopForever)
            : base(filepath, layer, origin, x, y) {
            Type = EventTypes.Animation;
            Framecount = frameCount;
            FrameDuration = frameDuration;
            Looptype = looptype;
        }

        public IEnumerable<string> Filepaths
        {
            get
            {
                var parts = Filepath.Split('.');
                return Enumerable.Range(0, Framecount).Select(i => $"{parts[0]}{i}.{parts[1]}");
            }
        }

        public int FrameAt(float time) {
            var relative = time - StartTime;
            if (relative < 0) return 0;
            if (Looptype == Looptypes.LoopOnce && relative > Framecount * FrameDuration) return Framecount - 1; //last one
            relative %= Framecount * FrameDuration;
            var result = (int)Math.Floor(relative / (FrameDuration * 1.0));
            return result;
        }

        public override string ToString() {
            return $"{base.ToString()},{Framecount},{FrameDuration}" + (Looptype == Looptypes.LoopForever ? "" : "," + Looptype);
        }
    }
}
