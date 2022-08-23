using MyMovies.Entities;
using MyMovies.Repositories.Database.Abstract;
using MyMovies.Repositories.Database.Context;

namespace MyMovies.Repositories.Database
{
    public class WatchedRepository : Repository<Watched>
    {
        public WatchedRepository(SQLiteContext context) : base(context)
        {
        }
    }
}
