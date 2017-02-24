using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using osuElements.Api.Repositories;

namespace ModelsTest
{
    [TestClass]
    public class ApiTest
    {
        private readonly ApiBeatmapRepository _beatmapRepository = new ApiBeatmapRepository();

        public ApiTest()
        {
            osuElements.osuElements.ApiKey = ""; //TODO set
        }

        [TestMethod]
        public async Task BeatmapTest()
        {
            var map = await _beatmapRepository.Get(11090);
            var json = JsonConvert.SerializeObject(map);
            Assert.IsNotNull(map);
            Assert.Equals(map.Creator, "peppy");
            Assert.Equals(map.Title, "osu! tutorial");
        }
        [TestMethod]
        public async Task ScoreTest()
        {
            var scores = await osuElements.osuElements.ApiUserRepository.GetRecent("excellrad");
            var score = scores[0];
            var json = JsonConvert.SerializeObject(scores);
            Assert.IsNotNull(scores);
        }
        [TestMethod]
        public async Task UserTest()
        {
            var user = await osuElements.osuElements.ApiUserRepository.Get("excellrad");
            var json = JsonConvert.SerializeObject(user);
            Assert.IsNotNull(user);
        }
    }
}
