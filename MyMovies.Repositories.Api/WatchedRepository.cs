using Microsoft.Extensions.Configuration;
using MyMovies.Entities;
using MyMovies.Repositories.Api.Abstract;
using MyMovies.Repositories.Api.Interfaces;

namespace MyMovies.Repositories.Api
{
    public class WatchedRepository : Repository<Watched>, IWatchedRepository
    {
        public WatchedRepository(IConfigurationRoot configuration) : base(configuration)
        {
        }
    }
}
