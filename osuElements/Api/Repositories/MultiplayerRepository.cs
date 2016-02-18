using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfoViewer.Data;

namespace osuElements.Api.Repositories
{
    public class MultiplayerRepository:RepositoryBase, IMultiplayerRepository
    {
        public async Task<List<MatchResult>> Get(int matchId) {
            return await GetList<MatchResult>($"get_match?id={matchId}");
        }
    }
}