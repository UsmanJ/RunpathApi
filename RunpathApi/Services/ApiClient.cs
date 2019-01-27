using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using RunpathApi.Data;

namespace RunpathApi.Services
{
    public class ApiClient : IApiClient
    {
        public async Task<T> GetAsync<T>(string url)
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var error = JsonConvert.DeserializeObject<ErrorMessage>(content);
                    throw new Exception(error.Message);
                }

                var result = JsonConvert.DeserializeObject<T>(content);
                return result;
            }
        }
    }
}
