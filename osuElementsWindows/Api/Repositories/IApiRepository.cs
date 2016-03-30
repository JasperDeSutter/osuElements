using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace osuElements.Api.Repositories
{
    public interface IApiUserRepository
    {
        Task<ApiUser> Get(string name, GameMode mode = 0, int eventDays = 31);
        Task<ApiUser> Get(int id, GameMode mode = 0, int eventDays = 31);
        Task<List<ApiScore>> GetBest(int id, GameMode mode = 0, int limit = 100);
        Task<List<ApiScore>> GetBest(string name, GameMode mode = 0, int limit = 100);
        Task<List<ApiScore>> GetRecent(int id, GameMode mode = 0, int limit = 100);
        Task<List<ApiScore>> GetRecent(string name, GameMode mode = 0, int limit = 100);
    }
    public interface IApiBeatmapRepository
    {
        Task<List<ApiBeatmap>> GetSince(DateTime time, GameMode? mode = null, int limit = 500);
        Task<List<ApiBeatmap>> GetSet(int setId, GameMode? mode = null, int limit = 500);
        Task<List<ApiBeatmap>> GetCreator(string userName, GameMode? mode = null, int limit = 500);
        Task<List<ApiBeatmap>> GetCreator(int userId, GameMode? mode = null, int limit = 500);
        Task<ApiBeatmap> Get(int mapId, GameMode? mode = null);
        Task<ApiBeatmap> Get(string mapHash, GameMode? mode = null);
        Task<List<ApiScore>> GetScores(int mapId, int? userid = null, string username = null, GameMode mode = 0, Mods? mods = null, int limit = 100);
    }
    public interface IApiReplayRepository
    {
        Task<ApiReplay> Get(int mapId, int userId, GameMode mode);
        Task<ApiReplay> Get(int mapId, string userName, GameMode mode);
    }
    public interface IApiMultiplayerRepository
    {
        Task<ApiMatchResult> Get(int matchId);
    }
}