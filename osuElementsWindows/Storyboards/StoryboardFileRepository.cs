    using System;
using System.IO;
using System.Linq;
using System.Text;
using osuElements.Helpers;
using osuElements.Repositories;

namespace osuElements.Storyboards
{
    public class StoryboardFileRepository : IFileRepository<Storyboard>
    {

        public void ReadFile(string path, Storyboard result) {
            using (var streamreader = new StreamReader(osuElements.FileReaderFunc(path))) {
                EventBase currentEvent = null;
                TransformationEvent currentTransform = null;
                var line = streamreader.ReadLine();
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
                                //if (currentTransform.Transformtype == TransformTypes.L) {
                                //    var loopEvent = currentTransform as LoopEvent;
                                //    loopEvent?.AddTransformation(tt);
                                //}
                                //else if (currentTransform.Transformtype == TransformTypes.T) {
                                //    var triggerEvent = currentTransform as TriggerEvent;
                                //    triggerEvent?.AddTransformation(tt);
                                //}
                            }
                        }
                        else {
                            if (TransformationEvent.TryParse(line, out currentTransform)) {
                                (currentEvent as SpriteEvent)?.AddTransformation(currentTransform);
                            }
                        }
                    }
                    else {
                        if (EventBase.TryParse(line, out currentEvent))
                            result.AddEvent(currentEvent);
                    }
                    line = streamreader.ReadLine();
                }
            }
        }

        public void WriteFile(string file, Storyboard t) {
            using (var sw = new StreamWriter(osuElements.FileWriterFunc(file)))
                sw.Write(WriteToString(t));
        }

        public string WriteToString(Storyboard t) {
            var sb = new StringBuilder();
            sb.Append("[Events]" + Constants.IO.NEW_LINE);
            sb.Append("//Background and Video events" + Constants.IO.NEW_LINE);
            //sb.Append(string.Join(NEW_LINE, t.Events.Where(e => e.Type == EventTypes.Video)));
            foreach (var e in t.Events.Where(e => e.Type == EventTypes.Video)) {
                sb.Append(e);
                sb.Append(Constants.IO.NEW_LINE);
            }

            foreach (EventLayer layer in Enum.GetValues(typeof(EventLayer))) {
                sb.Append($"//Storyboard Layer {(int)layer} ({layer.ToString()})" + Constants.IO.NEW_LINE);
                //sb.Append(string.Join(NEW_LINE, t.Events.Where(e => e.Layer == layer)));
                foreach (var e in t.Events.Where(e => e.Layer == layer)) {
                    sb.Append(e);
                    sb.Append(Constants.IO.NEW_LINE);
                }
            }
            sb.Append(Constants.IO.NEW_LINE + "//Storyboard Sound Samples" + Constants.IO.NEW_LINE);
            //sb.Append(string.Join(NEW_LINE, t.Events.Where(e => e.Type == EventTypes.Sample)));
            foreach (var e in t.Events.Where(e => e.Type == EventTypes.Sample)) {
                sb.Append(e);
                sb.Append(Constants.IO.NEW_LINE);
            }
            var result = sb.ToString();
            return result.Replace(Constants.IO.NEW_LINE + Constants.IO.NEW_LINE, Constants.IO.NEW_LINE);
        }
    }
}
