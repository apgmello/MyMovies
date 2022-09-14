using Microsoft.Extensions.Configuration;
using MyMovies.Entities;
using MyMovies.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;

namespace MyMovies.Repositories.Api.Abstract
{
    public class BaseRepository<T> 
    where T : class
    {
        protected readonly string url;
        protected readonly HttpClient httpClient;

        public BaseRepository(IConfigurationRoot configuration, string controller)
        {
            httpClient = new HttpClient();
            url = configuration["moviesApiURL"];
            url = $"{url}/{controller}";
        }
        protected async Task<T> Request<T>(HttpRequestMessage requestMessage)
        {
            var response = await httpClient.SendAsync(requestMessage);
            var message = await response.Content.ReadAsStringAsync();
            T result = default;
            if (message != null)
                result = JsonConvert.DeserializeObject<T>(message);
            return result;
        }
    }
}
