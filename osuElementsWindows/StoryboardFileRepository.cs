using System;
using System.IO;
using System.Linq;
using System.Text;
using osuElements.Repositories;
using osuElements.Storyboards;

namespace osuElementsWindows
{
    public class StoryboardFileRepository:IFileRepository<Storyboard>
    {

        public void ReadFile(string path, Storyboard result) {
            if (!File.Exists(path)) return;
            using (StreamReader streamreader = new StreamReader(path)) {
                Event currentEvent = null;
                TransformationEvent currentTransform = null;
                string line = streamreader.ReadLine();
                while (line != null) {
                    if (line == "") {
                        line = streamreader.ReadLine();
                        continue;
                    }
                    if (line.StartsWith("//")) {
                        line = streamreader.ReadLine();
                        continue;
                    }
                    if (line.StartsWith(" ")) {
                        if (line.StartsWith("  ")) {
                            TransformationEvent tt;
                            if (TransformationEvent.TryParse(line, out tt) && currentTransform != null) {
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
                        else {
                            if (TransformationEvent.TryParse(line, out currentTransform)) {
                                (currentEvent as SpriteEvent)?.AddTransformation(currentTransform);
                            }
                        }
                    }
                    else {
                        if (Event.TryParse(line, out currentEvent))
                            result.AddEvent(currentEvent);
                    }
                    line = streamreader.ReadLine();
                }
            }
        }

        public void WriteFile(string file, Storyboard t) {
            if (!File.Exists(file)) return;
            var sw = new StreamWriter(file);
            sw.Write(WriteToString(t));
        }

        public string WriteToString(Storyboard t) {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Events]" + Constants.Io.NEW_LINE);
            sb.Append("//Background and Video events" + Constants.Io.NEW_LINE);
            //sb.Append(string.Join(NEW_LINE, t.Events.Where(e => e.Type == EventTypes.Video)));
            foreach (var e in t.Events.Where(e => e.Type == EventTypes.Video)) {
                sb.Append(e);
                sb.Append(Constants.Io.NEW_LINE);
            }

            foreach (EventLayer layer in Enum.GetValues(typeof(EventLayer))) {
                sb.Append($"//Storyboard Layer {(int)layer} ({layer.ToString()})" + Constants.Io.NEW_LINE);
                //sb.Append(string.Join(NEW_LINE, t.Events.Where(e => e.Layer == layer)));
                foreach (var e in t.Events.Where(e => e.Layer == layer)) {
                    sb.Append(e);
                    sb.Append(Constants.Io.NEW_LINE);
                }
            }
            sb.Append(Constants.Io.NEW_LINE + "//Storyboard Sound Samples" + Constants.Io.NEW_LINE);
            //sb.Append(string.Join(NEW_LINE, t.Events.Where(e => e.Type == EventTypes.Sample)));
            foreach (var e in t.Events.Where(e => e.Type == EventTypes.Sample)) {
                sb.Append(e);
                sb.Append(Constants.Io.NEW_LINE);
            }
            string result = sb.ToString();
            return result.Replace(Constants.Io.NEW_LINE + Constants.Io.NEW_LINE, Constants.Io.NEW_LINE);
        }
    }
}
