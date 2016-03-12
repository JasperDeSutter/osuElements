using System.Collections.Generic;
using osuElements.Beatmaps;

namespace osuElements.Db
{
    public class Collection
    {
        public string Name { get; set; }


        public Collection() {
            Beatmaps = new List<string>();
        }

        public Collection(string name) : this() {
            Name = name;
        }

        public List<string> Beatmaps { get; set; }

        public void Add(Beatmap b) {
            Add(b.GetHash());
        }

        public void Add(string hash) {
            Beatmaps.Add(hash);
        }

        public void Remove(Beatmap b) {
            Remove(b.GetHash());
        }

        public void Remove(string hash) {
            Beatmaps.Remove(hash);
        }

        public int Count => Beatmaps.Count;

        public override string ToString() {
            return Name;
        }

        //public void ToFile(Stream output) {
        //    var binwriter = new BinaryWriter(output);
        //    binwriter.Write(SPLITTER);
        //    binwriter.Write(Name);
        //    binwriter.Write(Count);
        //    foreach (var b in Beatmaps) {
        //        binwriter.Write(SPLITTER);
        //        binwriter.Write(b);
        //    }
        //}

        //public static List<Collection> ReadFile(Stream input) {
        //    using (var binreader = new BinaryReader(input)) {
        //        var colCount = binreader.ReadInt32();
        //        var result = new List<Collection>(colCount);
        //        for (var i = 0; i < colCount; i++) {
        //            var name = binreader.ReadNullableString();
        //            var beatmapcount = binreader.ReadInt32();
        //            result[i] = new Collection(name);
        //            for (var j = 0; j < beatmapcount; j++) {
        //                result[i].Add(binreader.ReadNullableString());
        //            }
        //        }
        //        return result;
        //    }
        //}
    }
}