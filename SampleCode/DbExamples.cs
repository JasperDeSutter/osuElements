using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osuElements.Beatmaps;
using osuElements.Db;

namespace SampleCode
{
    public class DbExamples
    {
        public void Collections() {
            var collectionDb = new CollectionDb();
            collectionDb.ReadFile(); //the pathing is autmatic
            //or set it for a different file
            collectionDb.FullPath = @"X:\Some\Custom\Collection.db";
            var collection = new Collection("cool songs");
            collection.Add(new Beatmap()); //adding a beatmap
            collection.Add("1ds3a456sdq3dsq56"); //or a hash
            collectionDb.AddColection(collection);
            collectionDb.AddColection("other collection", new List<Beatmap>()); //without constructing a collection object
            collectionDb.RemoveEmpty();//looks for collections without items in them and removes those
            collectionDb.WriteFile();
        }
        public void Scores() {
            var scoresDb = new ScoresDb();
            scoresDb.ReadFile(); //pathing works the same way as collectionDb
            var scorelists = scoresDb.ScoreLists; //these are the local replays, grouped by beatmaphash
            var hash = scorelists[0].MapHash;
            var shitmisses = scorelists[0].Replays.Where(s => s.CountMiss == 1);
        }
        //recommended way of reading/ finding beatmaps
        public void Beatmaps() {
            //reading a beatmap by hash in 4 lines:
            var osuDb = new OsuDb();
            osuDb.ReadFile();
            var dbBeatmap = osuDb.FindHash("12qsd5za84612"); //usefull for when working with replays or collections
            dbBeatmap.ReadFile(); //Will execute a full read for hitobject and storyboard data, these are not stored in osu!.db
            //done.
            var highestScore = dbBeatmap.HighestStandardRank; //DbBeatmap has some unique properties a normal beatmap doesn't have

        }
    }
}
