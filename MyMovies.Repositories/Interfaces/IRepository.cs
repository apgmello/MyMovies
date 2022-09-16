using MyMovies.Entities;
using MyMovies.Entities.Dto;

namespace MyMovies.Repositories.Interfaces
{
    public interface IRepository<TMovie, TMovieDto>
        where TMovie : Movie
        where TMovieDto : IDto
    {
        TMovie Create(TMovie model); 
        TMovie Read(long id);
        List<TMovie> Search(TMovieDto model);
        List<TMovie> ReadAll();
        TMovie Update(TMovie model);
        TMovie Patch(TMovie model);
        void Delete(long id); 
    }
}
