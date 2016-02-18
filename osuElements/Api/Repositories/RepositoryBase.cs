using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UserInfoViewer.Data
{
    public class RepositoryBase
    {
        #region Properties

        public static string Url { get; } = "osu.ppy.sh/api/";
        public static string Key { private get; set; }

        #endregion

        #region Methods

        protected HttpClient Connect() {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        //return await Task<List<T>> GetList<T>();

        protected async Task<List<T>> GetList<T>(string query) {
            try {
                using (var client = Connect()) {
                    if(string.IsNullOrEmpty(Key))throw new NullReferenceException("Please supply an api key (RepositoryBase.Key)");
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

        #endregion
    }
}