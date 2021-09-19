using System.Linq;
using System.Threading.Tasks;
using osuElements.Api.Throttling;

namespace osuElements.Api.Repositories
{
    public class ApiMultiplayerRepository : ApiRepositoryBase, IApiMultiplayerRepository
    {

        public ApiMultiplayerRepository() : base() { }

        public ApiMultiplayerRepository(string apiKey, bool throwExceptions, IThrottler throttler) : base(apiKey, throwExceptions, throttler) { }



        public async Task<ApiMatchResult> Get(int matchId) {
            var result = (await GetList<ApiMatchResult>($"get_match?id={matchId}"))?.FirstOrDefault();
            if (result == null) return null;
            if (result.Games == null) return result;
            foreach (var apiMultiGame in result.Games) {
                foreach (var apiScore in apiMultiGame.Scores.Where(s => s != null)) {
                    apiScore.BeatmapId = apiMultiGame.BeatmapId;
                    apiScore.GameMode = apiMultiGame.PlayMode;
                    apiScore.EnabledMods = apiMultiGame.Mods;
                    apiScore.Date = apiMultiGame.EndTime; //or starttime, not sure
                }
            }
            return result;
        }
    }
}