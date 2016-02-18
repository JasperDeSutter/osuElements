using System.Linq;
using System.Threading.Tasks;
using osuElements.Api;
using osuElements.Api.Repositories;
using osuElements.Helpers;

namespace UserInfoViewer.Data
{
    public class ApiReplayRepository: RepositoryBase, IApiReplayRepository
    {
        public async Task<ApiReplay> Get(int mapId, int userId, GameMode mode) {
           return (await GetList<ApiReplay>($"get_replay?b={mapId}&u={userId}&m={mode}")).FirstOrDefault();
        }

        public async Task<ApiReplay> Get(int mapId, string userName, GameMode mode) {
            return (await GetList<ApiReplay>($"get_replay?b={mapId}&u={userName}&m={mode}")).FirstOrDefault();
        }
    }
}