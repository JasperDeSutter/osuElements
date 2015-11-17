using osuElements.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuElements.Repositories
{
    internal class StoryboardReader
    {

        //TODO Make async reader, otherwise too slow
        void ReadAsync(string path)
        {
            Storyboard result = new Storyboard();
            string file = File.ReadAllText(path);
            string current = "";
            List<Task<Event>> tasks = new List<Task<Event>>();
            using (StringReader sr = new StringReader(file))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    current = line;
                    while (line != null && line.StartsWith(" "))
                    {
                        current += Environment.NewLine + sr.ReadLine();
                        line = sr.ReadLine();
                    }
                    tasks.Add(new Task<Event>(() => ReadEvent(current)));
                    tasks.Last().Start();
                    line = sr.ReadLine();
                }
            }
            foreach (Task<Event> task in tasks)
            {
                Event e = task.Result;
                if (e != null) result.AddEvent(e);
            }
        }

        private Event ReadEvent(string part)
        {
            Event result;
            ITransformable lasttransformable = null;
            using (StringReader sr = new StringReader(part))
            {
                string line = sr.ReadLine();
                if (!Event.TryParse(line, out result)) return null;
                while (line != null)
                {
                    if (line == "" || line.StartsWith("//"))
                    {
                        line = sr.ReadLine();
                        continue;
                    }
                    if (line.StartsWith(" "))
                    {
                        if (line.StartsWith("  "))
                        {
                            TransformationEvent tt;
                            if (TransformationEvent.TryParse(line, out tt))
                            {
                                lasttransformable?.AddTransformation(tt);
                            }
                        }
                        else
                        {
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


        public static void ReadFile(string path, Storyboard result)
        {
            if (!File.Exists(path)) return;
            using (StreamReader streamreader = new StreamReader(path))
            {
                Event currentEvent = null;
                TransformationEvent currentTransform = null;
                string line = streamreader.ReadLine();
                while (line != null)
                {
                    if (line == "")
                    {
                        line = streamreader.ReadLine();
                        continue;
                    }
                    if (line.StartsWith("//"))
                    {
                        line = streamreader.ReadLine();
                        continue;
                    }
                    if (line.StartsWith(" "))
                    {
                        if (line.StartsWith("  "))
                        {
                            TransformationEvent tt;
                            if (TransformationEvent.TryParse(line, out tt) && currentTransform != null)
                            {
                                if (currentTransform.Transformtype == TransformTypes.L) {
                                    var loopEvent = currentTransform as LoopEvent;
                                    loopEvent?.AddTransformation(tt);
                                }
                                else if (currentTransform.Transformtype == TransformTypes.T) {
                                    var triggerEvent = currentTransform as TriggerEvent;
                                    triggerEvent?.AddTransformation(tt);
                                }
                            }
                        }
                        else
                        {
                            if (TransformationEvent.TryParse(line, out currentTransform))
                            {
                                (currentEvent as SpriteEvent)?.AddTransformation(currentTransform);
                            }
                        }
                    }
                    else
                    {
                        if (Event.TryParse(line, out currentEvent))
                            result.AddEvent(currentEvent);
                    }
                    line = streamreader.ReadLine();
                }
            }
        }
    }
}
