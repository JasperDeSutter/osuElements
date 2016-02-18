using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using osuElements.Api;
using osuElements.Api.Repositories;
using osuElements.Helpers;

namespace UserInfoViewer.Data
{
    public class ApiBeatmapRepository : RepositoryBase, IApiBeatmapRepository
    {
        #region Methods

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

            return (await GetMaps($"get_beatmaps?h={mapHash}", mode)).FirstOrDefault() ;
        }

        public async Task<List<Score>> GetScores(int mapId, int? userid = null, string userName = null,
            GameMode mode = 0, Mod? mods = null, int limit = 100) {
            var userstring = userid.HasValue
                ? $"&u={userid.Value}&type=id"
                : string.IsNullOrEmpty(userName) ? "" : $"&u={userName}&type=string";
            var modstring = mods.HasValue ? $"&mods={mods.Value}" : "";
            return await GetList<Score>($"get_scores?b={mapId}{userstring}&m={mode}{modstring}&limit={limit}");
        }

        private async Task<List<ApiBeatmap>> GetMaps(string query, GameMode? mode) {
            var modestring = mode.HasValue ? $"&m={(int)mode.Value}&a=1" : "";
            var list = await GetList<ApiBeatmap>(query + modestring);
            return list;
        }

        #endregion
    }
}