using Microsoft.Extensions.Configuration;
using MyMovies.Entities;
using MyMovies.Repositories.Api.Abstract;

namespace MyMovies.Repositories.Api
{
    public class WatchedRepository : Repository<Watched>
    {
        public WatchedRepository(IConfigurationRoot configuration) : base(configuration)
        {
        }
    }
}
