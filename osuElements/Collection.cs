using System.Collections.Generic;
using System.IO;

namespace osuElements
{
    public class Collection
    {
        const byte SPLITTER = 11;

        public string Name;
        public Collection()
        {
            Name = "New Collection";
            _beatmaps = new List<string>();
        }
        public Collection(string name)
        {
            Name = name;
            _beatmaps = new List<string>();
        }

        List<string> _beatmaps;

        public void Add(Beatmap b)
        {
            Add(b.GetMD5());
        }
        public void Add(string hash)
        {
            _beatmaps.Add(hash);
        }
        public void Remove(Beatmap b)
        {
            Remove(b.GetMD5());
        }
        public void Remove(string hash)
        {
            _beatmaps.Remove(hash);
        }

        public int Count => _beatmaps.Count;

        public override string ToString()
        {
            return Name;
        }
        public void ToOsu(Stream output)
        {
            BinaryWriter binwriter = new BinaryWriter(output);
            binwriter.Write(SPLITTER);
            binwriter.Write(Count);
            binwriter.Write(Name);
            foreach (string b in _beatmaps)
            {
                binwriter.Write(SPLITTER);
                binwriter.Write(b);
            }
        }
        public static List<Collection> ReadFile(Stream input)
        {
            BinaryReader binreader = new BinaryReader(input);
            int colCount = binreader.ReadInt32();
            List<Collection> result = new List<Collection>(colCount);
            for (int i = 0; i < colCount; i++)
            {
                binreader.ReadByte();
                string name = binreader.ReadString();
                int beatmapcount = binreader.ReadInt32();
                result[i] = new Collection(name);
                for (int j = 0; j < beatmapcount; j++)
                {
                    if(binreader.ReadByte() == SPLITTER)
                        result[i].Add(binreader.ReadString());
                }
            }
            return result;
        }
    }
}
