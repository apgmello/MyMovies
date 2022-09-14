using Microsoft.Extensions.Configuration;
using MyMovies.Entities;
using MyMovies.Repositories.Api.Abstract;
using System.Net.Http.Json;

namespace MyMovies.Repositories.Api
{
    public class LoginRepository : BaseRepository<Authenticate>
    {
        public LoginRepository(IConfigurationRoot configuration) : base(configuration, "login")
        {
        }

        public AuthenticationToken Login(Authenticate login)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = JsonContent.Create(login)
            };
            var result = Request<AuthenticationToken>(requestMessage).Result;
            return result;
        }
    }
}
