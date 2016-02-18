using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using osuElements.Api;
using osuElements.Api.Repositories;
using osuElements.Helpers;

namespace UserInfoViewer.Data
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public async Task<User> Get(string name, GameMode mode = 0, int eventDays = 31)
        {
            var list = await GetList<User>($"get_user?u={name}&m={(int)mode}&type=string&event_days={eventDays}");
            var result = list.FirstOrDefault();
            if (result != null)
                result.LastUpdate = DateTime.Now;
            return result;
        }

        public async Task<User> Get(int id, GameMode mode = 0, int eventDays = 31)
        {
            var list = await GetList<User>($"get_user?u={id}&m={(int)mode}&type=id&event_days={eventDays}");
            var result = list.FirstOrDefault();
            if (result != null)
                result.LastUpdate = DateTime.Now;
            return result;
        }

        public async Task<List<Score>> GetBest(int id, GameMode mode = 0, int limit = 100)
        {
            return await GetList<Score>($"get_user_best?u={id}&m={(int)mode}&type=id&limit={limit}");
        }

        public async Task<List<Score>> GetBest(string name, GameMode mode = 0, int limit = 100)
        {
            return await GetList<Score>($"get_user_best?u={name}&m={(int)mode}&type=string&limit={limit}");
        }

        public async Task<List<Score>> GetRecent(int id, GameMode mode = 0, int limit = 100)
        {
            return await GetList<Score>($"get_user_recent?u={id}&m={(int)mode}&type=id&limit={limit}");
        }

        public async Task<List<Score>> GetRecent(string name, GameMode mode = 0, int limit = 100)
        {
            return await GetList<Score>($"get_user_recent?u={name}&m={(int)mode}&type=string&limit={limit}");
        }


    }
}