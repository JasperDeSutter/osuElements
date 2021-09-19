using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using osuElements.Api.Throttling;

namespace osuElements.Api.Repositories
{
    public class ApiReplayRepository: ApiRepositoryBase, IApiReplayRepository
    {

        public ApiReplayRepository() : base() { }

        public ApiReplayRepository(string apiKey, bool throwExceptions, IThrottler throttler) : base(apiKey, throwExceptions, throttler) { }



        public async Task<ApiReplay> Get(int mapId, int userId, GameMode mode) {
            return await GetData<ApiReplay>($"get_replay?b={mapId}&u={userId}&m={(int) mode}");
        }

        public async Task<ApiReplay> Get(int mapId, string userName, GameMode mode) {
            return await GetData<ApiReplay>($"get_replay?b={mapId}&u={userName}&m={(int)mode}");
        }
    }
}