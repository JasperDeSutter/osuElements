using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace osuElements.Api.Repositories
{
    public abstract class ApiRepositoryBase : IApiRepository
    {
        #region Properties
        public static string Url { get; } = "https://osu.ppy.sh/api/";
        public static string Key { protected get; set; }

        public static bool ThrowExceptionsDefault { get; set; } = false;

        public static bool ThrowExceptions { get; set; } = ThrowExceptionsDefault;

        public bool IsError { get; protected set; }

        public ApiError ApiError { get; protected set; }
        #endregion



        #region GetList
        protected async Task<List<T>> GetList<T>(string query) {
            return await GetData<List<T>>(query);
        }

        protected async Task<T> GetData<T>(string query) {

            if (string.IsNullOrEmpty(Key)) {
                SetError(true, null);                
                throw new ArgumentNullException($"{this.GetType().Name}.{nameof(Key)}", $"Please supply an api key.");
            }

            SetError(false, null);

            try {

                var url = Url + query + $"&k={Key}";

                string jsonResult = null;

                using (var client = new HttpClient()) {
                    
                    var response = await client.GetAsync(url);

                    jsonResult = await response.Content.ReadAsStringAsync();
                }

                SetError(jsonResult);

                if (IsError) {
                    return default(T);
                }
                else {
                    return JsonConvert.DeserializeObject<T>(jsonResult);
                }
            }
            catch {
                SetError(true, null);

                if (ThrowExceptions)
                    throw;
                else
                    return default(T);
            }
        }

        #endregion

        #region CallNestedRepository

        protected TResult CallNestedRepository<TRepository, TResult>(TRepository repo, Func<TRepository, TResult> callFunc)
            where TRepository : IApiRepository
        {
            try {
                return callFunc(repo);
            }
            catch {
                throw;
            }
            finally {
                SetError(repo.IsError, repo.ApiError);
            }
        }

        #endregion



        #region SetError

        protected virtual void SetError(string jsonResult) {
            if (jsonResult == null) {
                SetError(false, null);
            }
            else
            {
                // assuming there are no valid results with "error" field in it.
                // maybe additional "other fields absence check" will be required in future.

                JToken errorJtoken = JToken.Parse(jsonResult);

                if (errorJtoken.Type == JTokenType.Object && errorJtoken["error"] != null) {
                    var error = JsonConvert.DeserializeObject<ApiError>(jsonResult);
                    SetError(true, error);
                }
                else {
                    SetError(false, null);
                }
            }
        }

        #endregion

        #region SetError

        protected virtual void SetError(bool isError, ApiError apiError) {
            IsError = isError;
            ApiError = apiError;
        }

        #endregion

    }
}