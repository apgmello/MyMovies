using Microsoft.Extensions.Configuration;
using MyMovies.Entities;
using MyMovies.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MyMovies.Repositories.Api.Abstract
{
    public class Repository<TMovie> : IRepository<TMovie> 
        where TMovie : Movie
    {
        private readonly string url;
        private readonly HttpClient httpClient;

        public Repository(IConfigurationRoot configuration)//vem de dentro do container IConfigurationRoot
        {
            url = configuration["moviesApiURL"];
            url = $"{url}/{typeof(TMovie).Name}";
            httpClient = new HttpClient();
        }
        private async Task<T> Request<T>(HttpRequestMessage requestMessage)
        {
            var response = await httpClient.SendAsync(requestMessage);
            var message = await response.Content.ReadAsStringAsync();
            T result = default;
            if(message != null)
                result = JsonConvert.DeserializeObject<T>(message);
            return result;
        }

        public TMovie Create(TMovie entity)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = JsonContent.Create(entity)
            };

            return Request<TMovie>(requestMessage).Result;
        }

        public void Delete(long id)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, $"{url}?id={id}");
            _ = Request<TMovie>(requestMessage).Result;
        }

        public TMovie Read(long id)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{url}?id={id}");
            return Request<TMovie>(requestMessage).Result;
        }

        public List<TMovie> ReadAll()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{url}/listAll");
            return Request<List<TMovie>>(requestMessage).Result;
        }

        public List<TMovie> Search(string title)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{url}/search?title={title}");
            return Request<List<TMovie>>(requestMessage).Result;
        }

        public TMovie Update(TMovie entity)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, $"{url}?id={entity.Id}")
            {
                Content = JsonContent.Create(entity)
            };

            return Request<TMovie>(requestMessage).Result;
        }
    }
}
