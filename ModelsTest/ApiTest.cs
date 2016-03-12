using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using osuElements.Api.Repositories;

namespace ModelsTest
{
    [TestClass]
    public class ApiTest
    {
        private readonly ApiBeatmapRepository _beatmapRepository = new ApiBeatmapRepository();

        public ApiTest() {
            osuElements.osuElements.ApiKey = ""; //TODO set
        }

        [TestMethod]
        public async Task BeatmapTest() {
            var map = await _beatmapRepository.Get(3756);//tutorial
            Assert.IsNotNull(map);
            Assert.Equals(map.Creator, "peppy");
            Assert.Equals(map.Title, "osu! tutorial");
        }
    }
}
