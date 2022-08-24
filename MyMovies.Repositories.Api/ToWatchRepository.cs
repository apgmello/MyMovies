using Microsoft.Extensions.Configuration;
using MyMovies.Entities;
using MyMovies.Repositories.Api.Abstract;
using MyMovies.Repositories.Api.Interfaces;
using MyMovies.Repositories.Interfaces;

namespace MyMovies.Repositories.Api
{
    public class ToWatchRepository : Repository<ToWatch>, IToWatchRepository
    {
        public ToWatchRepository(IConfigurationRoot configuration) : base(configuration)
        {
        }
    }
}
