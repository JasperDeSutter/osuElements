using System;
using System.IO;
using osuElements.Repositories;
using osuElements.Skins;

namespace osuElementsWindows
{
    public class SkinFileRepository : IFileRepository<Skin>
    {
        public void ReadFile(string fileName, Skin skin) {
            if (!File.Exists(fileName)) return;
            using(var sr = new StreamReader(fileName)) {
                string line = sr.ReadLine();
                while (line != null) {
                    if (line == "" || line.StartsWith("//")) {
                        line = sr.ReadLine();
                        continue;
                    }

                    line = sr.ReadLine();
                }
            }
        }

        public void WriteFile(string file, Skin t) {
            throw new NotImplementedException();
        }

        public string WriteToString(Skin t) {
            throw new NotImplementedException();
        }
    }
}
