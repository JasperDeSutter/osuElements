using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace osuElements.Api.Repositories
{
    public class ApiReplayRepository: ApiRepositoryBase, IApiReplayRepository
    {
        public async Task<ApiReplay> Get(int mapId, int userId, GameMode mode) {
            return await GetData<ApiReplay>($"get_replay?b={mapId}&u={userId}&m={(int) mode}");
        }

        public async Task<ApiReplay> Get(int mapId, string userName, GameMode mode) {
            return await GetData<ApiReplay>($"get_replay?b={mapId}&u={userName}&m={(int)mode}");
        }
    }
}