using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using osuElements.Repositories;
using osuElements.Events;

namespace osuElements
{
    public class Storyboard
    {
        public string FileName;
        public string Directory;
        public List<Event> Events;
        public Storyboard()
        {
            Events = new List<Event>();
        }

        public Storyboard(string path) : this()
        {
            Path = path;
            StoryboardReader.ReadFile(path, this);
            //ReadAsync(path);
        }

        public void AddEvent(Event e)
        {
            Events.Add(e);
        }

        public string Path
        {
            set
            {
                FileName = System.IO.Path.GetFileName(value);
                Directory = System.IO.Path.GetDirectoryName(value);
            }
            get
            {
                return Directory + "\\" + FileName;
            }
        }

        public List<Event> GetActiveEvents(float time)
        {
            return Events.Where(e => e.StartTime < time && e.EndTime > time).ToList();
        }

        public string ToOsb()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Events]\r\n");
            sb.Append("//Background and Video events\r\n");
            sb.Append(string.Join("\r\n", Events.Where(e => e.Type == EventTypes.Video)));

            foreach (EventLayer layer in Enum.GetValues(typeof(EventLayer)))
            {
                sb.Append("//Storyboard Layer " + (int)layer + " (" + layer.ToString() + ")\r\n");
                sb.Append(string.Join("\r\n", Events.Where(e => e.Layer == layer)));
            }
            sb.Append("\r\n//Storyboard Sound Samples\r\n");
            sb.Append(string.Join("\r\n", Events.Where(e => e.Type == EventTypes.Sample)));
            string result = sb.ToString();
            return result.Replace("\r\n\r\n", "\r\n");
        }
    }
}
