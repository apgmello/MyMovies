using MyMovies.Entities;
using MyMovies.Entities.Dto;
using MyMovies.Repositories.Database.Abstract;
using MyMovies.Repositories.Database.Context;

namespace MyMovies.Repositories.Database
{
    public class ToWatchRepository : Repository<ToWatch, ToWatchSearchDto>

    {
        public ToWatchRepository(SQLiteContext context) : base(context)
        {
        }

        public override List<ToWatch> Search(ToWatchSearchDto model)
        {
            return Read(
                x =>
                    (x.Title.ToLower().Contains(model.Title.ToLower()) || model.Title == "") &&
                    (x.Reason.ToLower().Contains(model.Reason.ToLower()) || model.Reason == ""))
                    .Skip((model.Page - 1) * model.MaxResults).Take(model.MaxResults).ToList();
        }
    }
}
