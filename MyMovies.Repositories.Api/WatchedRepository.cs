using Microsoft.Extensions.Configuration;
using MyMovies.Entities;
using MyMovies.Entities.Dto;
using MyMovies.Repositories.Api.Abstract;
using MyMovies.Repositories.Api.Interfaces;

namespace MyMovies.Repositories.Api
{
    public class WatchedRepository : Repository<Watched, WatchedSearchDto>, IWatchedRepository
    {
        public WatchedRepository(IConfigurationRoot configuration, AuthenticationToken authenticationToken) : base(configuration, authenticationToken)
        {
        }
    }
}
