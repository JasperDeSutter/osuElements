using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using osuElements.Api.Throttling;
using osuElements.Helpers;
using static osuElements.Helpers.Constants;

namespace osuElements.Api.Repositories
{
    public class ApiUserRepository : ApiRepositoryBase, IApiUserRepository
    {

        public ApiUserRepository() : base() { }

        public ApiUserRepository(string apiKey, bool throwExceptions, IThrottler throttler) : base(apiKey, throwExceptions, throttler) { }



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

    }
}