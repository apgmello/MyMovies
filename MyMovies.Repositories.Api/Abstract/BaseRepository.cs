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
        protected string token;

        public BaseRepository(IConfigurationRoot configuration, string controller)
        {
            httpClient = new HttpClient();
            url = configuration["moviesApiURL"];
            url = $"{url}/{controller}";
        }
        protected async Task<T> Request<T>(HttpRequestMessage requestMessage)
        {
            if(!string.IsNullOrEmpty(token))
                requestMessage.Headers.Add("Authorization", $"bearer {token}");

            var response = await httpClient.SendAsync(requestMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return default;


            var message = await response.Content.ReadAsStringAsync();
            T result = default;
            if (message != null)
                result = JsonConvert.DeserializeObject<T>(message);
            return result;
        }
    }
}
