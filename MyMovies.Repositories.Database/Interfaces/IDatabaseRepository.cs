using MyMovies.Entities;
using MyMovies.Entities.Dto;
using MyMovies.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MyMovies.Repositories.Database.Interfaces
{
    public interface IDatabaseRepository<T, TDto> : IRepository<T, TDto>
        where T : Movie
        where TDto : Dto
    {
        List<T> Read(Expression<Func<T, bool>> predicate);

    }
}
