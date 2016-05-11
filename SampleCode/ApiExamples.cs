using System;
using osuElements;
using osuElements.Api.Repositories;

namespace SampleCode
{
    public class ApiExamples
    {
        //https://github.com/ppy/osu-api/wiki
        public async void Api() {
            osuElements.osuElements.ApiKey = "ENTERAPIKEYHERE";//put this somewhere at the start of your program
            var bRep = new ApiBeatmapRepository(); //getting beatmaps or scores on beatmaps
            var firstMap = await bRep.Get(1);
            var someManiaMap = await bRep.Get("ds12dza68123sdq564", GameMode.Mania);
            var mapsByMe = await bRep.GetCreator("ExCellRaD", limit: 5);
            var scoresOnMap = bRep.GetScores(firstMap.BeatmapId);
            var maps2016 = bRep.GetSince(new DateTime(2016, 1, 1));

            var uRep = new ApiUserRepository(); //getting users, topscores and recent scores of users
            var peppy = await uRep.Get("peppy");
            var peppyscores = await uRep.GetBest(peppy.UserId, GameMode.CatchTheBeat);
            var recentscores = await uRep.GetRecent("Rafis");

            var mRep = new ApiMultiplayerRepository(); //getting active multiplayer matches
            var match = await mRep.Get(123456);
            var games = match.Games;

            var rRep = new ApiReplayRepository(); //getting replay data (if available)
            var score = recentscores[0]; //should be rafis' top play
            var replay = rRep.Get(score.BeatmapId, score.UserId, score.GameMode);
        }

        public void Url() {
            osuURL.InClientDownload(123); //if user has supporter, an inclient download of the map can be started. if he doesn't it will simply open a webbrowser page to that beatmap.
            osuURL.JoinChatChannel("ModRequests"); //joins a chat channel
            osuURL.JoinMultiplayerRoom(123456, "123456"); //join an active multiplayer match
            osuURL.SelectEditorNotes(new TimeSpan(0, 0, 1, 20, 250), 2, 3, 4);//select notes with combonumber 2,3 and 4 starting at tme 1:20:250
            osuURL.SpectateUser("Cookiezi"); //only when user is online
        }
    }
}