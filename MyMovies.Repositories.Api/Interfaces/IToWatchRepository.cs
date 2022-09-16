using MyMovies.Entities;
using MyMovies.Entities.Dto;
using MyMovies.Repositories.Interfaces;

namespace MyMovies.Repositories.Api.Interfaces
{
    public interface IToWatchRepository : IRepository<ToWatch, ToWatchSearchDto>
    {
    }
}
