using Microsoft.Extensions.Configuration;
using MyMovies.Entities;
using MyMovies.Repositories.Api.Abstract;
using MyMovies.Repositories.Interfaces;

namespace MyMovies.Repositories.Api
{
    public class ToWatchRepository : Repository<ToWatch>
    {
        public ToWatchRepository(IConfigurationRoot configuration) : base(configuration)
        {
        }
    }
}
