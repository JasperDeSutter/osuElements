using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using osuElements.Helpers;

namespace osuElements.Api.Repositories
{
    public abstract class ApiRepositoryBase
    {
        #region Properties
        public static string Url { get; } = "https://osu.ppy.sh/api/";
        public static string Key { private get; set; }
        #endregion

        #region Methods
        protected async Task<List<T>> GetList<T>(string query) {
            if (string.IsNullOrEmpty(Key)) throw new NullReferenceException("Please supply an api key (RepositoryBase.Key)");
            try {
                using (var client = new HttpClient()) {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var url = Url + query + $"&k={Key}";

                    var json = await client.GetStringAsync(url);


                    var list = JsonConvert.DeserializeObject<List<T>>(json);

                    return list;
                }
            }
            catch {
                return null;
            }
        }
        protected static async Task<ApiReplay> GetReplay(string query) {
            if (string.IsNullOrEmpty(ApiReplayRepository.Key)) throw new NullReferenceException("Please supply an api key (ApiReplayRepository.Key)");
            var result = new ApiReplay();
            using (var client = new HttpClient()) {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var url = Url + query + $"&k={ApiReplayRepository.Key}";
                var json = await client.GetStringAsync(url);
                if ("{\"error\":\"Replay not available.\"}" == json) return null;
                json = json.Remove(0, 12).TrimEnd('"', '}');
                var last = json.LastIndexOf('"') + 1;
                result.Encoding = json.Substring(last, json.Length - last);
                result.Content = json.Remove(json.Length - result.Encoding.Length - 14);
            }
            return result;
        }

        protected async Task<List<ApiScore>> GetScoreList(string query, GameMode mode) {
            var scores = await GetList<ApiScore>(query + $"&m={(int)mode}");
            foreach (var score in scores) {
                score.GameMode = mode;
            }
            return scores;
        }
        #endregion

    }
}