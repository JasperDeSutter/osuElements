using System.Linq;
using System.Threading.Tasks;

namespace osuElements.Api.Repositories
{
    public class ApiMultiplayerRepository:ApiRepositoryBase, IApiMultiplayerRepository
    {
        public async Task<ApiMatchResult> Get(int matchId) {
            return (await GetList<ApiMatchResult>($"get_match?id={matchId}")).FirstOrDefault();
        }
    }
}