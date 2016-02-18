using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using osuElements.Helpers;

namespace osuElements.Api.Repositories
{
    public interface IUserRepository
    {
        Task<User> Get(string name, GameMode mode = 0, int eventDays = 31);
        Task<User> Get(int id, GameMode mode = 0, int eventDays = 31);
        Task<List<Score>> GetBest(int id, GameMode mode = 0, int limit = 100);
        Task<List<Score>> GetBest(string name, GameMode mode = 0, int limit = 100);
        Task<List<Score>> GetRecent(int id, GameMode mode = 0, int limit = 100);
        Task<List<Score>> GetRecent(string name, GameMode mode = 0, int limit = 100);
    }
    public interface IApiBeatmapRepository
    {
        Task<List<ApiBeatmap>> GetSince(DateTime time, GameMode? mode = null, int limit = 500);
        Task<List<ApiBeatmap>> GetSet(int setId, GameMode? mode = null, int limit = 500);
        Task<List<ApiBeatmap>> GetCreator(string userName, GameMode? mode = null, int limit = 500);
        Task<List<ApiBeatmap>> GetCreator(int userId, GameMode? mode = null, int limit = 500);
        Task<ApiBeatmap> Get(int mapId, GameMode? mode = null);
        Task<ApiBeatmap> Get(string mapHash, GameMode? mode = null);
        Task<List<Score>> GetScores(int mapId, int? userid = null, string userName = null, GameMode mode = 0, Mod? mods = null, int limit = 100);
    }
    public interface IApiReplayRepository
    {
        Task<ApiReplay> Get(int mapId, int userId, GameMode mode);
        Task<ApiReplay> Get(int mapId, string userName, GameMode mode);
    }
    public interface IMultiplayerRepository
    {
        Task<List<MatchResult>> Get(int matchId);
    }
}