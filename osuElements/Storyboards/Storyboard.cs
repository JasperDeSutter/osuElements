using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using osuElements.Repositories;
using osuElements.Repositories.File;

namespace osuElements.Storyboards
{
    public class Storyboard : IStoryboardEvents
    {
        public static IFileRepository<Storyboard> StoryboardFileRepository { private get; set; }
        public string FileName;
        public string Directory;
        public List<EventBase> Events;
        public Storyboard() {
            BackgroundEvents = new List<SpriteEvent>();
            ForegroundEvents = new List<SpriteEvent>();
            FailEvents = new List<SpriteEvent>();
            PassEvents = new List<SpriteEvent>();
            SampleEvents = new List<SampleEvent>();
            Events = new List<EventBase>();
            VariablesDictionary = new Dictionary<string, string>();
        }

        public Storyboard(string filePath) : this() {
            FilePath = filePath;
            StoryboardFileRepository.ReadFile(osuElements.FileReaderFunc(filePath), this);
        }

        public void AddEvent(EventBase e) {
            Events.Add(e);
        }

        public string FilePath
        {
            set
            {
                FileName = Path.GetFileName(value);
                Directory = Path.GetDirectoryName(value);
            }
            get
            {
                return Path.Combine(Directory, FileName);
            }
        }

        public List<EventBase> GetActiveEvents(float time) {
            return Events.Where(e => e.StartTime < time && e.EndTime > time).ToList();
        }

        public void WriteFile(string file) {
            StoryboardFileRepository.WriteFile(osuElements.FileWriterFunc(file), this);
        }


        public List<SpriteEvent> BackgroundEvents { get; set; }
        public List<SpriteEvent> FailEvents { get; set; }
        public List<SpriteEvent> PassEvents { get; set; }
        public List<SpriteEvent> ForegroundEvents { get; set; }
        public List<SampleEvent> SampleEvents { get; set; }
        public Dictionary<string, string> VariablesDictionary { get; set; }

        public static FileReader<Storyboard> FileReader() {
            var variables = new ObjectListFileSection<KeyValuePair<string, string>, Storyboard>(nameof(VariablesDictionary), "Variables",
                s => {
                    var parts = s.Split('=');
                    return new KeyValuePair<string, string>(parts[0], parts[1]);
                },
                pair => $"{pair.Key}={pair.Value}");

            return new FileReader<Storyboard>(variables, new StoryboardSection<Storyboard>("Events"));
        }
    }
}
