using System.Linq;
using System.Threading.Tasks;
using osuElements.Api;

namespace osuElements.Repositories.Api
{
    public class ApiMultiplayerRepository:ApiRepositoryBase, IApiMultiplayerRepository
    {
        public async Task<ApiMatchResult> Get(int matchId) {
            return (await GetList<ApiMatchResult>($"get_match?id={matchId}")).FirstOrDefault();
        }
    }
}