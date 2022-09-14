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

        public override List<Watched> Search(Watched model)
        {
            return Read(x => (x.Title.ToLower().Contains(model.Title.ToLower()) || string.IsNullOrEmpty(model.Title)) ||
                             (x.Comment.ToLower().Contains(model.Comment.ToLower()) || string.IsNullOrEmpty(model.Comment)));
        }
    }
}
