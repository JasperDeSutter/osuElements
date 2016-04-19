using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using osuElements;
using osuElements.Api;
using osuElements.Api.Repositories;
using osuElements.Db;
using osuElements.Replays;
using TestContent;

namespace ModelsTest
{
    [TestClass]
    public class ReplayTest
    {
        private Replay replay;
        [TestMethod]
        public void ReadTest() {
            replay = new Replay(Paths.Replay, true);
            var score = new ApiScore();
            replay.CloneTo(score);
            
        }
        
        [TestMethod]
        public void ManiaReadTest() {
            replay = new Replay(Paths.ManiaReplay, true);
        }

        [TestMethod]
        public async Task FromApi() {
            //TODO set api key
            var userRep = new ApiUserRepository();
            var replayRep = new ApiReplayRepository();
            var scores = await userRep.GetBest(2614511, limit: 1);
            var score = scores[0];
            var replay = await replayRep.Get(score.BeatmapId, score.UserId, score.GameMode);
            var completeReplay = new Replay(score, replay);
        }
    }
}
