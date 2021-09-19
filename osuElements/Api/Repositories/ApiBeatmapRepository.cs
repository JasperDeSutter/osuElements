using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using osuElements.Api.Throttling;
using osuElements.Helpers;
using static osuElements.Helpers.Constants;

namespace osuElements.Api.Repositories
{
    public class ApiBeatmapRepository : ApiRepositoryBase, IApiBeatmapRepository
    {

        public ApiBeatmapRepository() : base() { }

        public ApiBeatmapRepository(string apiKey, bool throwExceptions, IThrottler throttler) : base(apiKey, throwExceptions, throttler) { }



        public async Task<List<ApiBeatmap>> GetSince(DateTime time, GameMode? mode = null, int limit = MaxApiBeatmapResults) {
            return await GetMaps(
                $"get_beatmaps?since={time:yyyy MM dd}&limit={limit.Clamp(1, MaxApiBeatmapResults)}"
                , mode);
        }

        public async Task<List<ApiBeatmap>> GetSet(int setId, GameMode? mode = null, int limit = MaxApiBeatmapResults) {
            return await GetMaps(
                $"get_beatmaps?s={setId}&limit={limit.Clamp(1, MaxApiBeatmapResults)}"
                , mode);
        }

        public async Task<List<ApiBeatmap>> GetCreator(string userName, GameMode? mode = null, int limit = MaxApiBeatmapResults) {
            return await GetMaps(
                $"get_beatmaps?u={userName}&type=string&limit={limit.Clamp(1, MaxApiBeatmapResults)}"
                , mode);
        }

        public async Task<List<ApiBeatmap>> GetCreator(int userId, GameMode? mode = null, int limit = MaxApiBeatmapResults) {
            return await GetMaps(
                $"get_beatmaps?u={userId}&type=id&limit={limit.Clamp(1, MaxApiBeatmapResults)}"
                , mode);
        }

        public async Task<ApiBeatmap> Get(int mapId, GameMode? mode = null) {
            return (await GetMaps($"get_beatmaps?b={mapId}", mode))?.FirstOrDefault();
        }

        public async Task<ApiBeatmap> Get(string mapHash, GameMode? mode = null) {
            return (await GetMaps($"get_beatmaps?h={mapHash}", mode))?.FirstOrDefault();
        }


        private async Task<List<ApiBeatmap>> GetMaps(string query, GameMode? mode) {
            var modestring = mode.HasValue && mode.Value != GameMode.Standard ? $"&m={(int)mode.Value}&a=1" : "";
            var list = await GetList<ApiBeatmap>(query + modestring);
            return list;
        }
    }
}