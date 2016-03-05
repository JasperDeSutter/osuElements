using System;
using System.Text;
using osuElements.Helpers;

namespace osuElements.Storyboards
{
    public class AnimationEvent : SpriteEvent
    {
        public int Framecount;
        public int FrameDuration;
        public Looptypes Looptype;

        public AnimationEvent(EventLayer layer, Origin origin, string filepath, float x, float y, int frameCount, int frameDuration, Looptypes looptype = Looptypes.LoopForever) : base(layer, origin, filepath, x, y) {
            Type = EventTypes.Animation;
            Framecount = frameCount;
            FrameDuration = frameDuration;
            Looptype = looptype;
        }
        public AnimationEvent(string filepath, int framecount, int frameDuration, Looptypes looptype = Looptypes.LoopForever)
            : base(filepath) {
            Type = EventTypes.Animation;
            Framecount = framecount;
            FrameDuration = frameDuration;
            Looptype = looptype;
        }

        public string[] Filepaths
        {
            get
            {
                var result = new string[Framecount];
                for (int i = 0; i < Framecount; i++) {
                    result[i] = FrameFilepath(i);
                }
                return result;
            }
        }

        public string FrameFilepath(int frame) {
            return Filepath.Remove(Filepath.LastIndexOf('.')) + frame + Filepath.Substring(Filepath.LastIndexOf('.'));
        }

        public int CurrentFrame(float time) {
            int relative = (int)(time - StartTime);
            if (relative < 0) return 0;
            if (Looptype == Looptypes.LoopOnce && relative > (Framecount * FrameDuration)) return Framecount - 1; //last one
            relative %= (Framecount * FrameDuration);
            int result = (int)Math.Floor(relative / (FrameDuration * 1.0));
            return result;
        }

        public override string ToString() {
            return base.ToString() + $",{Framecount},{FrameDuration}" + (Looptype == Looptypes.LoopForever ? "" : "," + Looptype);
        }
    }
}
