using System.Linq;
using System.Threading.Tasks;

namespace osuElements.Api.Repositories
{
    public class ApiMultiplayerRepository : ApiRepositoryBase, IApiMultiplayerRepository
    {
        public async Task<ApiMatchResult> Get(int matchId) {
            var result = (await GetList<ApiMatchResult>($"get_match?mp={matchId}")).FirstOrDefault();
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
