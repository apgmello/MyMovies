using MyMovies.Entities;
using MyMovies.Repositories.Database.Abstract;
using MyMovies.Repositories.Database.Context;

namespace MyMovies.Repositories.Database
{
    public class ToWatchRepository : Repository<ToWatch>

    {
        public ToWatchRepository(SQLiteContext context) : base(context)
        {
        }
    }
}
