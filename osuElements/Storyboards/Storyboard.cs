using System.Collections.Generic;
using System.IO;
using System.Linq;
using osuElements.Repositories;

namespace osuElements.Storyboards
{
    public class Storyboard
    {
        public static IFileRepository<Storyboard> StoryboardFileRepository { private get; set; }
        public string FileName;
        public string Directory;
        public List<Event> Events;

        public Storyboard(string filePath) : this() {
            FilePath = filePath;
            StoryboardFileRepository.ReadFile(filePath, this);
        }

        public void AddEvent(Event e) {
            Events.Add(e);
        }

        public string FilePath {
            set {
                FileName = Path.GetFileName(value);
                Directory = Path.GetDirectoryName(value);
            }
            get {
                return Path.Combine(Directory, FileName);
            }
        }

        public List<Event> GetActiveEvents(float time) {
            return Events.Where(e => e.StartTime < time && e.EndTime > time).ToList();
        }
        public void WriteFile(string file) {
            StoryboardFileRepository.WriteFile(file, this);
        }
        public string WriteToString() {
            return StoryboardFileRepository.WriteToString(this);
        }
        
        public Storyboard() {
            Events = new List<Event>();
        }
    }
}
