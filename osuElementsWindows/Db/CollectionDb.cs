using System.Collections.Generic;
using System.IO;
using System.Linq;
using osuElements.Beatmaps;
using osuElements.IO;
using osuElements.IO.Binary;
using osuElements.IO.File;

namespace osuElements.Db
{
    public class CollectionDb : IFileModel
    {
        public static BinaryFile<CollectionDb> FileReader() {
            return new BinaryFile<CollectionDb>(
                    new BinaryFileLine<CollectionDb, int>(c => c.FileVersion),
                new BinaryCollection<CollectionDb, Collection>(c => c.Collections,
                    new BinaryFileLine<Collection, string>(c => c.Name),
                    new BinaryFileList<Collection, string>(c => c.Beatmaps)
                    ));
        }

        public int FileVersion { get; set; }

        public List<Collection> Collections { get; }

        public CollectionDb() {
            Collections = new List<Collection>();
            CollectionDbRepository = osuElements.CollectionDbRepository;

        }
        public void AddColection(string name, IEnumerable<Beatmap> beatmaps) {
            AddColection(name, beatmaps.Select(b => b.GetHash()));
        }
        public void AddColection(string name, IEnumerable<string> beatmapHashes) {
            Collections.Add(new Collection(name) { Beatmaps = beatmapHashes.ToList() });
        }
        public void AddToCollection(string name, IEnumerable<Beatmap> beatmaps) {
            Collections.FirstOrDefault(c => c.Name == name)?.Beatmaps.AddRange(beatmaps.Select(b => b.GetHash()));
        }
        public Collection GetCollection(string name) {
            return Collections.FirstOrDefault(c => c.Name == name);
        }
        public int RemoveCollection(string name) {
            return Collections.RemoveAll(c => c.Name == name);
        }
        public int RemoveEmpty() {
            return Collections.RemoveAll(c => c.Beatmaps.Count < 1);
        }


        #region File
        public static IFileRepository<CollectionDb> CollectionDbRepository { get; set; }

        public bool IsRead { get; private set; }
        public string Directory { get; set; } = osuElements.OsuDirectory;
        public string FileName { get; set; } = "collection.db";
        public string FullPath
        {
            get { return Path.Combine(Directory, FileName); }
            set
            {
                Directory = Path.GetDirectoryName(value);
                FileName = Path.GetFileName(value);
            }
        }
        public void ReadFile(ILogger logger = null) {
            CollectionDbRepository.ReadFile(osuElements.ReadStream(FullPath), this, logger);
            IsRead = true;
        }

        public void WriteFile() {
            CollectionDbRepository.WriteFile(osuElements.WriteStream(FullPath), this);
        }
        #endregion

    }
}