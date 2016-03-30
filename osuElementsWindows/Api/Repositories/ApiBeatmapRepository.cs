using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace osuElements.Api.Repositories
{
    public class ApiBeatmapRepository : ApiRepositoryBase, IApiBeatmapRepository
    {
        public async Task<List<ApiBeatmap>> GetSince(DateTime time, GameMode? mode = null, int limit = 500) {
            return await GetMaps($"get_beatmaps?since={time.ToString("yyyy MM dd")}&limit={limit}", mode);
        }

        public async Task<List<ApiBeatmap>> GetSet(int setId, GameMode? mode = null, int limit = 500) {
            return await GetMaps($"get_beatmaps?s={setId}&limit={limit}", mode);
        }

        public async Task<List<ApiBeatmap>> GetCreator(string userId, GameMode? mode = null, int limit = 500) {
            return await GetMaps($"get_beatmaps?u={userId}&type=string&limit={limit}", mode);
        }

        public async Task<List<ApiBeatmap>> GetCreator(int userId, GameMode? mode = null, int limit = 500) {
            return await GetMaps($"get_beatmaps?u={userId}&type=id&limit={limit}", mode);
        }

        public async Task<ApiBeatmap> Get(int mapId, GameMode? mode = null) {
            var maps = await GetMaps($"get_beatmaps?b={mapId}", mode);
            return maps.FirstOrDefault(); //if the map is not ranked and no internet
        }

        public async Task<ApiBeatmap> Get(string mapHash, GameMode? mode = null) {
            return (await GetMaps($"get_beatmaps?h={mapHash}", mode)).FirstOrDefault();
        }

        public async Task<List<ApiScore>> GetScores(int mapId, int? userid = null, string username = null,
            GameMode mode = 0, Mods? mods = null, int limit = 100) {
            var userstring = userid.HasValue
                ? $"&u={userid.Value}&type=id"
                : string.IsNullOrEmpty(username) ? "" : $"&u={username}&type=string";
            var modstring = mods.HasValue ? $"&mods={(int)mods.Value}" : "";
            return await GetScoreList($"get_scores?b={mapId}{userstring}{modstring}&limit={limit}", mode,
                s => s.BeatmapId = mapId);
        }

        private async Task<List<ApiBeatmap>> GetMaps(string query, GameMode? mode) {
            var modestring = mode.HasValue && mode.Value != GameMode.Standard ? $"&m={(int)mode.Value}&a=1" : "";
            var list = await GetList<ApiBeatmap>(query + modestring);
            return list;
        }

    }
}