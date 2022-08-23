using MyMovies.Entities;
using MyMovies.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MyMovies.Repositories.Database.Interfaces
{
    public interface IDatabaseRepository<T> : IRepository<T>
        where T : Movie
    {
        List<T> Read(Expression<Func<T, bool>> predicate);

    }
}
