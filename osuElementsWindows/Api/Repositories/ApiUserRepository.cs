using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace osuElements.Api.Repositories
{
    public class ApiUserRepository : ApiRepositoryBase, IApiUserRepository
    {
        public async Task<ApiUser> Get(string name, GameMode mode = 0, int eventDays = 31) {
            var result = (await GetList<ApiUser>($"get_user?u={name}&m={(int)mode}&type=string&event_days={eventDays}")).FirstOrDefault();
            if (result != null) {
                result.GameMode = mode;
            }
            return result;
        }

        public async Task<ApiUser> Get(int id, GameMode mode = 0, int eventDays = 31) {
            var result = (await GetList<ApiUser>($"get_user?u={id}&m={(int)mode}&type=id&event_days={eventDays}")).FirstOrDefault();
            if (result != null) {
                result.GameMode = mode;
            }
            return result;
        }

        public async Task<List<ApiScore>> GetBest(int id, GameMode mode = 0, int limit = 100) {
            return await GetScoreList($"get_user_best?u={id}&type=id&limit={limit}", mode, null);
        }

        public async Task<List<ApiScore>> GetBest(string name, GameMode mode = 0, int limit = 100) {
            return await GetScoreList($"get_user_best?u={name}&type=string&limit={limit}", mode, s => s.Username = name);
        }

        public async Task<List<ApiScore>> GetRecent(int id, GameMode mode = 0, int limit = 100) {
            return await GetScoreList($"get_user_recent?u={id}&type=id&limit={limit}", mode, null);
        }

        public async Task<List<ApiScore>> GetRecent(string name, GameMode mode = 0, int limit = 100) {
            return await GetScoreList($"get_user_recent?u={name}&type=string&limit={limit}", mode, s => s.Username = name);
        }

    }
}