using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static osuElements.Helpers.Constants;
using osuElements.Api.Throttling;
using osuElements.Helpers;

namespace osuElements.Api.Repositories
{
    public class ApiScoreRepository : ApiRepositoryBase, IApiScoreRepository
    {

        public ApiScoreRepository() : base() { }

        public ApiScoreRepository(string apiKey, bool throwExceptions, IThrottler throttler) : base(apiKey, throwExceptions, throttler) { }



        public async Task<List<ApiScore>> GetMapScores(int mapId, int userid, GameMode mode = GameMode.Standard, Mods? mods = null, int limit = MaxApiScoreResults)
        {
            var modstring = mods.HasValue ? $"&mods={(int)mods.Value}" : "";
            return await GetScoreList($"get_scores?b={mapId}&u={userid}&type=id{modstring}&limit={limit}", mode,
                s => s.BeatmapId = mapId);
        }

        public async Task<List<ApiScore>> GetMapScores(int mapId, string username = null, GameMode mode = GameMode.Standard, Mods? mods = null, int limit = MaxApiScoreResults)
        {
            var userstring = !string.IsNullOrEmpty(username)
                ? $"&u={username}&type=string"
                : "" ;
            var modstring = mods.HasValue ? $"&mods={(int)mods.Value}" : "";
            return await GetScoreList($"get_scores?b={mapId}{userstring}{modstring}&limit={limit}", mode,
                s => s.BeatmapId = mapId);
        }

        public async Task<List<ApiScore>> GetUserBest(int userId, GameMode mode = GameMode.Standard, int limit = MaxApiScoreResults)
        {
            return await GetScoreList(
                $"get_user_best?u={userId}&type=id&limit={limit.Clamp(1, MaxApiScoreResults)}"
                , mode, null);
        }

        public async Task<List<ApiScore>> GetUserBest(string userName, GameMode mode = GameMode.Standard, int limit = MaxApiScoreResults)
        {
            return await GetScoreList(
                $"get_user_best?u={userName}&type=string&limit={limit.Clamp(1, MaxApiScoreResults)}"
                , mode, s => s.Username = userName);
        }

        public async Task<List<ApiScore>> GetUserRecent(int userId, GameMode mode = GameMode.Standard, int limit = MaxApiScoreResults)
        {
            return await GetScoreList(
                $"get_user_recent?u={userId}&type=id&limit={limit.Clamp(1, MaxApiScoreResults)}"
                , mode, null);
        }

        public async Task<List<ApiScore>> GetUserRecent(string userName, GameMode mode = GameMode.Standard, int limit = MaxApiScoreResults)
        {
            return await GetScoreList(
                $"get_user_recent?u={userName}&type=string&limit={limit.Clamp(1, MaxApiScoreResults)}"
                , mode, s => s.Username = userName);
        }


        protected async Task<List<ApiScore>> GetScoreList(string query, GameMode mode, Action<ApiScore> action)
        {
            var scores = await GetList<ApiScore>(query + $"&m={(int)mode}");
            if (scores == null) return null;
            foreach (var score in scores.Where(score => score != null))
            {
                score.GameMode = mode;
                action?.Invoke(score);
            }
            return scores;
        }


    }
}
