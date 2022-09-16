using MyMovies.Entities;
using MyMovies.Entities.Dto;
using MyMovies.Repositories.Interfaces;

namespace MyMovies.Repositories.Api.Interfaces
{
    public interface IWatchedRepository : IRepository<Watched, WatchedSearchDto>
    {
    }
}
