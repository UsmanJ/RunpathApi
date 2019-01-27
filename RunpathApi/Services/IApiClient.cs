using System.Threading.Tasks;

namespace RunpathApi.Services
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string url);
    }
}
