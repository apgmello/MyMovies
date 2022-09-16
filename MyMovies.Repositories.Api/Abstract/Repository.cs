using Microsoft.Extensions.Configuration;
using MyMovies.Entities;
using MyMovies.Entities.Dto;
using MyMovies.Repositories.Interfaces;
using System.Net.Http.Json;

namespace MyMovies.Repositories.Api.Abstract
{
    public class Repository<TMovie, TMovieDto> : BaseRepository<TMovie>, IRepository<TMovie, TMovieDto>
        where TMovie : Movie
        where TMovieDto : IDto
    {
        private readonly AuthenticationToken _authenticationToken;

        public Repository(IConfigurationRoot configuration, AuthenticationToken authenticationToken) : base(configuration, typeof(TMovie).Name)
        {
            _authenticationToken = authenticationToken;
        }
        
        private void AddAuthorizationHeader(HttpRequestMessage httpRequestMessage)
        {
            httpRequestMessage.Headers.Add("Authorization", $"bearer {_authenticationToken.Token}");
        }
        
        public TMovie Create(TMovie entity)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = JsonContent.Create(entity)
            };
            AddAuthorizationHeader(requestMessage);

            return Request<TMovie>(requestMessage).Result;
        }

        public void Delete(long id)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, $"{url}?id={id}");
            AddAuthorizationHeader(requestMessage);
            _ = Request<TMovie>(requestMessage).Result;
        }

        public TMovie Read(long id)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{url}?id={id}");
            AddAuthorizationHeader(requestMessage);
            return Request<TMovie>(requestMessage).Result;
        }

        public List<TMovie> ReadAll()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{url}/listAll");
            AddAuthorizationHeader(requestMessage);
            return Request<List<TMovie>>(requestMessage).Result;
        }

        public TMovie Update(TMovie entity)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, $"{url}?id={entity.Id}")
            {
                Content = JsonContent.Create(entity)
            };
            AddAuthorizationHeader(requestMessage);

            return Request<TMovie>(requestMessage).Result;
        }

        public List<TMovie> Search(TMovieDto model)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{url}/query")
            {
                Content = JsonContent.Create(model)
            };
            AddAuthorizationHeader(requestMessage);
            return Request<List<TMovie>>(requestMessage).Result;
        }

        public TMovie Patch(TMovie model)
        {
            throw new NotImplementedException();
        }
    }
}
