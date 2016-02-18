using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using osuElements.Repositories;
using osuElements.Storyboards;

namespace osuElementsWindows
{
    public class AsyncStoryboardFileRepository : IFileRepository<Storyboard>
    {
        private static readonly StoryboardFileRepository _nonasync = new StoryboardFileRepository();
        
        public void ReadFile(string path, Storyboard sb) {
            var result = new List<Event>();
            string file = File.ReadAllText(path);
            string current;
            int count = 0;
            using (StringReader sr = new StringReader(file)) {
                string line = sr.ReadLine();
                while (line != null) {
                    if (line.StartsWith("[") || line.StartsWith("//")) {
                        line = sr.ReadLine();
                        continue;
                    }
                    current = line;
                    line = sr.ReadLine();
                    while (line != null && line.StartsWith(" ")) {
                        current += Environment.NewLine + line;
                        line = sr.ReadLine();
                    }
                    Interlocked.Increment(ref count);
                    string c = current;
                    Task.Factory.StartNew(() =>
                    {
                        Event e = ReadEvent(c);
                        if (e != null)
                            result.Add(e);
                        Interlocked.Decrement(ref count);
                        int a = count;
                        if (a == 0) {

                        }
                    });
                }
            }
            sb.Events = result;
        }
        private static Event ReadEvent(string p) {
            string part = p;
            Event result;
            ITransformable lasttransformable = null;
            using (StringReader sr = new StringReader(part)) {
                string line = sr.ReadLine();
                if (!Event.TryParse(line, out result)) {
                    return null;
                }
                while (line != null) {
                    if (line == "" || line.StartsWith("//")) {
                        line = sr.ReadLine();
                        continue;
                    }
                    if (line.StartsWith(" ")) {
                        if (line.StartsWith("  ")) {
                            TransformationEvent tt;
                            if (TransformationEvent.TryParse(line, out tt)) {
                                lasttransformable?.AddTransformation(tt);
                            }
                        }
                        else {
                            TransformationEvent tt;
                            if (TransformationEvent.TryParse(line, out tt) && result != null) {
                                var spriteEvent = result as SpriteEvent;
                                spriteEvent?.AddTransformation(tt);
                                switch (tt.Transformtype) {
                                    case TransformTypes.L:
                                        lasttransformable = tt as LoopEvent;
                                        break;
                                    case TransformTypes.T:
                                        lasttransformable = tt as TriggerEvent;
                                        break;
                                    default:
                                        lasttransformable = result as SpriteEvent;
                                        break;
                                }
                            }
                        }
                    }
                    line = sr.ReadLine();

                }
            }
            return result;
        }


        public void WriteFile(string file, Storyboard t) {
            _nonasync.WriteFile(file, t);
        }

        public string WriteToString(Storyboard t) {
            return _nonasync.WriteToString(t);
        }
    }
}
