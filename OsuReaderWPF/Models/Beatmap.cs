using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsuReaderWPF.Repositories;
using System.IO;
using OsuReaderWPF.Helpers;
using System.Threading;
namespace OsuReaderWPF.Models
{
    public class Beatmap
    {
        //the class that that defines the object that gets created from .osu file. Holds all elements of that file.
        public string Directory { get; set; }
        
        public int Version { get; set; }
        public string Artist { get; set; }
        public string Song { get; set; }
        public string Mapper { get; set; }
        public string Difficulty { get; set; }
        public string FileName{ get; set; }
        public List<TimingPoint> TimingPoints { get; set; }
        public List<HitObject> HitObjects { get; set; }
        
        public Beatmap()
        {
            InitProps();
            Thread.CurrentThread.CurrentCulture = Statics.CULTURE2;
        }
        public Beatmap(string file, bool readFile = true):this()
        {
            Directory = Path.GetDirectoryName(file);
            FileName = Path.GetFileName(file);
            if(readFile) OsuRep.ReadFile(file,this);
        }
        public string ToOsu()  //File format
        {
            string output = "";

            output += "\n[TimingPoints]\n";
            foreach (TimingPoint tp in TimingPoints) output += tp + "\n";
            output += "\n[HitObjects]\n";
            foreach (HitObject ho in HitObjects) output += ho+"\n";
            return output;
        }
        private void InitProps(){

        }
        public override string ToString()  //Filename
        {
            if(FileName==null) FileName= Artist + " - " + Song + " (" + Mapper + ") [" + Difficulty + "]" + ".osu";
            return FileName;
        }
    }
}
