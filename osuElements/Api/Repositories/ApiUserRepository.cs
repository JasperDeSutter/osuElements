using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using osuElements.Helpers;
using static osuElements.GameMode;
using static osuElements.Helpers.Constants;

namespace osuElements.Api.Repositories
{
    public class ApiUserRepository : ApiRepositoryBase, IApiUserRepository
    {
        Lazy<IApiScoreRepository> _apiScoreRepository;

        public ApiUserRepository()
        {
            _apiScoreRepository = new Lazy<IApiScoreRepository>(() => new ApiScoreRepository(), true);
        }

        public ApiUserRepository(IApiScoreRepository apiScoreRepository)
        {
            _apiScoreRepository = new Lazy<IApiScoreRepository>(() => apiScoreRepository, true);
        }

        public async Task<ApiUser> Get(string name, GameMode mode = 0, int eventDays = MaxApiEventDays)
        {
            var result = (await GetList<ApiUser>(
                $"get_user?u={name}&m={(int)mode}&type=string&event_days={eventDays.Clamp(1, MaxApiEventDays)}"
                ))?.FirstOrDefault();
            if (result != null)
            {
                result.GameMode = mode;
            }
            return result;
        }

        public async Task<ApiUser> Get(int id, GameMode mode = 0, int eventDays = MaxApiEventDays)
        {
            var result = (await GetList<ApiUser>(
                $"get_user?u={id}&m={(int)mode}&type=id&event_days={eventDays.Clamp(1, MaxApiEventDays)}"
                ))?.FirstOrDefault();
            if (result != null)
            {
                result.GameMode = mode;
            }
            return result;
        }

        // Methods below left for backward compatibility

        public async Task<List<ApiScore>> GetBest(int id, GameMode mode = Standard, int limit = MaxApiScoreResults)
        {
            return await CallNestedRepository(_apiScoreRepository.Value, async (repo) => await
                repo.GetUserBest(id, mode, limit));
        }

        public async Task<List<ApiScore>> GetBest(string name, GameMode mode = Standard, int limit = MaxApiScoreResults)
        {
            return await CallNestedRepository(_apiScoreRepository.Value, async (repo) => await
                repo.GetUserBest(name, mode, limit));
        }

        public async Task<List<ApiScore>> GetRecent(int id, GameMode mode = Standard, int limit = MaxApiScoreResults)
        {
            return await CallNestedRepository(_apiScoreRepository.Value, async (repo) => await
                repo.GetUserBest(id, mode, limit));
        }

        public async Task<List<ApiScore>> GetRecent(string name, GameMode mode = Standard, int limit = MaxApiScoreResults)
        {
            return await CallNestedRepository(_apiScoreRepository.Value, async (repo) => await
                repo.GetUserBest(name, mode, limit));
        }
    }
}