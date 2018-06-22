using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static osuElements.GameMode;
using static osuElements.Helpers.Constants;

namespace osuElements.Api.Repositories
{

    public interface IApiRepository
    {
        /// <summary>
        /// Indicates that there was any error during download, parse or processing data.
        /// </summary>
        bool IsError { get; }

        /// <summary>
        /// Error object provided by osu api service. 
        /// May be null if error occured not on osu api side or if no osu api format error message was provided
        /// </summary>
        ApiError ApiError { get; }

    }

    public interface IApiUserRepository : IApiRepository
    {
        /// <summary>
        /// Returns user data from the osu api.
        /// </summary>
        /// <param name="name">username, cannot be ID</param>
        /// <param name="mode">the gamemode for the data</param>
        /// <param name="eventDays">max amount of days for the event data, between 1 and 31</param>
        Task<ApiUser> Get(string name, GameMode mode = Standard, int eventDays = MaxApiEventDays);
        /// <summary>
        /// Returns user data from the osu api.
        /// </summary>
        /// <param name="id">user ID, cannot be name</param>
        /// <param name="mode">the gamemode for the data</param>
        /// <param name="eventDays">max amount of days for the event data, between 1 and 31</param>
        Task<ApiUser> Get(int id, GameMode mode = Standard, int eventDays = MaxApiEventDays);

        /// <summary>
        /// Returns the top scores for the specified user.
        /// </summary>
        /// <param name="name">username, cannot be ID</param>
        /// <param name="mode">the gamemode for the data</param>
        /// <param name="limit">max amount of results, between 1 and 100</param>
        Task<List<ApiScore>> GetBest(string name, GameMode mode = Standard, int limit = MaxApiScoreResults);
        /// <summary>
        /// Returns the top scores for the specified user.
        /// </summary>
        /// <param name="id">user ID, cannot be name</param>
        /// <param name="mode">the gamemode for the data</param>
        /// <param name="limit">max amount of results, between 1 and 100</param>
        Task<List<ApiScore>> GetBest(int id, GameMode mode = Standard, int limit = MaxApiScoreResults);

        /// <summary>
        /// Returns most recent scores for the specified user.
        /// </summary>
        /// <param name="name">username, cannot be ID</param>
        /// <param name="mode">the gamemode for the data</param>
        /// <param name="limit">max amount of results, between 1 and 100</param>
        Task<List<ApiScore>> GetRecent(string name, GameMode mode = Standard, int limit = MaxApiScoreResults);

        /// <summary>
        /// Returns most recent scores for the specified user.
        /// </summary>
        /// <param name="id">user ID, cannot be name</param>
        /// <param name="mode">the gamemode for the data</param>
        /// <param name="limit">max amount of results, between 1 and 100</param>
        Task<List<ApiScore>> GetRecent(int id, GameMode mode = Standard, int limit = MaxApiScoreResults);
    }

    public interface IApiBeatmapRepository : IApiRepository
    {
        /// <summary>
        /// Returns all maps ranked since the supplied date.
        /// </summary>
        /// <param name="time">the date</param>
        /// <param name="mode">optional, only gamemode to return results from</param>
        /// <param name="limit">the maximum amount of results, between 1 and 500</param>
        Task<List<ApiBeatmap>> GetSince(DateTime time, GameMode? mode = null, int limit = MaxApiBeatmapResults);
        /// <summary>
        /// Returns all maps in a beatmapset.
        /// </summary>
        /// <param name="setId">the beatmapset ID</param>
        /// <param name="mode">optional, only gamemode to return results from</param>
        /// <param name="limit">the maximum amount of results, between 1 and 500</param>
        Task<List<ApiBeatmap>> GetSet(int setId, GameMode? mode = null, int limit = MaxApiBeatmapResults);
        /// <summary>
        /// Returns all maps from a mapper.
        /// </summary>
        /// <param name="userName">the username of the mapper</param>
        /// <param name="mode">optional, only gamemode to return results from</param>
        /// <param name="limit">the maximum amount of results, between 1 and 500</param>
        Task<List<ApiBeatmap>> GetCreator(string userName, GameMode? mode = null, int limit = MaxApiBeatmapResults);
        /// <summary>
        /// Returns all maps from a mapper.
        /// </summary>
        /// <param name="userId">the user ID of the mapper</param>
        /// <param name="mode">optional, only gamemode to return results from</param>
        /// <param name="limit">the maximum amount of results, between 1 and 500</param>
        Task<List<ApiBeatmap>> GetCreator(int userId, GameMode? mode = null, int limit = MaxApiBeatmapResults);
        /// <summary>
        /// Returns a map by its ID.
        /// </summary>
        /// <param name="mapId">the beatmap ID</param>
        /// <param name="mode">optional, only gamemode to return results from</param>
        Task<ApiBeatmap> Get(int mapId, GameMode? mode = null);
        /// <summary>
        /// Returns a map by its hash.
        /// </summary>
        /// <param name="mapHash">the beatmap hash</param>
        /// <param name="mode">optional, only gamemode to return results from</param>
        Task<ApiBeatmap> Get(string mapHash, GameMode? mode = null);
        /// <summary>
        /// Returns the top scores for the specified beatmap.
        /// </summary>
        /// <param name="mapId">beatmap ID</param>
        /// <param name="userid">optional, specify a user's ID to get a score for</param>
        /// <param name="username">optional, specify a user's username to get a score for</param>
        /// <param name="mode">optional, specify a gamemode to get scores for</param>
        /// <param name="mods">optional, specify mods to get scores for</param>
        /// <param name="limit">max amount of results, between 1 and 100</param>
        Task<List<ApiScore>> GetScores(int mapId, int? userid = null, string username = null, GameMode mode = Standard, Mods? mods = null, int limit = MaxApiScoreResults);
    }

    public interface IApiReplayRepository : IApiRepository
    {
        /// <summary>
        /// Returns the replay data for a given map, user and gamemode.
        /// </summary>
        /// <param name="mapId">the beatmap ID</param>
        /// <param name="userId">the user ID</param>
        /// <param name="mode">the gamemode</param>
        Task<ApiReplay> Get(int mapId, int userId, GameMode mode = Standard);
        /// <summary>
        /// Returns the replay data for a given map, user and gamemode.
        /// </summary>
        /// <param name="mapId">the beatmap ID</param>
        /// <param name="userName">the username</param>
        /// <param name="mode">the gamemode</param>
        Task<ApiReplay> Get(int mapId, string userName, GameMode mode = Standard);
    }

    public interface IApiMultiplayerRepository : IApiRepository
    {
        /// <summary>
        /// Returns all multiplayer and match history data for a lobby.
        /// </summary>
        /// <param name="matchId">the ID of the multiplayer lobby</param>
        Task<ApiMatchResult> Get(int matchId);
    }

    public interface IApiScoreRepository : IApiRepository
    {
        Task<List<ApiScore>> GetUserBest(int userId, GameMode mode = Standard, int limit = MaxApiScoreResults);

        Task<List<ApiScore>> GetUserBest(string userName, GameMode mode = Standard, int limit = MaxApiScoreResults);

        Task<List<ApiScore>> GetUserRecent(int userId, GameMode mode = Standard, int limit = MaxApiScoreResults);

        Task<List<ApiScore>> GetUserRecent(string userName, GameMode mode = Standard, int limit = MaxApiScoreResults);

        Task<List<ApiScore>> GetMapScores(int mapId, string username = null, GameMode mode = Standard, Mods? mods = null, int limit = MaxApiScoreResults);

        Task<List<ApiScore>> GetMapScores(int mapId, int userid, GameMode mode = Standard, Mods? mods = null, int limit = MaxApiScoreResults);
    }
}