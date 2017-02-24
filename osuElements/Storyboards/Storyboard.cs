using System;
using System.Collections.Generic;
using System.IO;
using osuElements.IO;
using osuElements.IO.File;

namespace osuElements.Storyboards
{
    public class Storyboard : IStoryboardEvents, IFileModel
    {
        public Storyboard() {
            BackgroundEvents = new List<SpriteEvent>();
            ForegroundEvents = new List<SpriteEvent>();
            FailEvents = new List<SpriteEvent>();
            PassEvents = new List<SpriteEvent>();
            SampleEvents = new List<SampleEvent>();
            VariablesDictionary = new Dictionary<string, string>();
        }

        public Storyboard(string filePath) : this() {
            FullPath = filePath;
            ReadFile();
        }

        public List<SpriteEvent> BackgroundEvents { get; set; }
        public List<SpriteEvent> FailEvents { get; set; }
        public List<SpriteEvent> PassEvents { get; set; }
        public List<SpriteEvent> ForegroundEvents { get; set; }
        public List<SampleEvent> SampleEvents { get; set; }
        public Dictionary<string, string> VariablesDictionary { get; set; }
        public void AddSpriteEvent(SpriteEvent sprite) {
            switch (sprite.Layer) {
                case EventLayer.Background:
                    BackgroundEvents.Add(sprite);
                    break;
                case EventLayer.Fail:
                    FailEvents.Add(sprite);
                    break;
                case EventLayer.Pass:
                    PassEvents.Add(sprite);
                    break;
                case EventLayer.Foreground:
                    ForegroundEvents.Add(sprite);
                    break;
                default:
                    throw new ArgumentException("The sprite's (event)layer was not set to a known storyboard layer");
            }
        }

        #region File
        public bool IsRead { get; private set; }
        public string FileName { get; set; }
        public string Directory { get; set; }
        public string FullPath
        {
            get
            {
                var result = Path.Combine(Directory, FileName);
                return Path.IsPathRooted(result) ? result : Path.Combine(osuElements.OsuSongDirectory, result);
            }
            set
            {
                Directory = Path.GetDirectoryName(value);
                FileName = Path.GetFileName(value);
            }
        }
        public void ReadFile(ILogger logger = null) {
            osuElements.StoryboardFileRepository.ReadFile(osuElements.ReadStream(FullPath), this, logger);
            IsRead = true;
        }
        public void WriteFile() {
            osuElements.StoryboardFileRepository.WriteFile(osuElements.WriteStream(FullPath), this);
        }
        public static FileReader<Storyboard> FileReader() {
            return new FileReader<Storyboard>(
                new CollectionFileSection<KeyValuePair<string, string>, Storyboard>(s => s.VariablesDictionary, "Variables",
                    s => {
                        var parts1 = s.Split('=');
                        return new KeyValuePair<string, string>(parts1[0], parts1[1]);
                    },
                    pair => $"{pair.Key}={pair.Value}"), 
                new StoryboardSection<Storyboard>("Events"));
        }
        #endregion
    }
}
