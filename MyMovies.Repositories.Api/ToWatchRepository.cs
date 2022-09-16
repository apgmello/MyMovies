using Microsoft.Extensions.Configuration;
using MyMovies.Entities;
using MyMovies.Entities.Dto;
using MyMovies.Repositories.Api.Abstract;
using MyMovies.Repositories.Api.Interfaces;
using MyMovies.Repositories.Interfaces;

namespace MyMovies.Repositories.Api
{
    public class ToWatchRepository : Repository<ToWatch, ToWatchSearchDto>, IToWatchRepository
    {
        public ToWatchRepository(IConfigurationRoot configuration, AuthenticationToken authenticationToken) : base(configuration, authenticationToken)
        {
        }
    }
}
