using MyMovies.Entities;
using MyMovies.Entities.Dto;
using MyMovies.Repositories.Database.Abstract;
using MyMovies.Repositories.Database.Context;
using System.Linq.Expressions;

namespace MyMovies.Repositories.Database
{
    public class WatchedRepository : Repository<Watched, WatchedSearchDto>
    {
        public WatchedRepository(SQLiteContext context) : base(context)
        {
        }

        public override List<Watched> Search(WatchedSearchDto model)
        {
            DateTime.TryParse(model.Date, out DateTime date);
            
            return Read(
                x =>
                    (x.Title.ToLower().Contains(model.Title.ToLower()) || model.Title == "") &&
                    (x.Comment.ToLower().Contains(model.Comment.ToLower()) || model.Comment == "") &&
                    ((x.Date.Day == date.Day && x.Date.Month == date.Month && x.Date.Year == date.Year) || date == DateTime.MinValue))
                    .Skip((model.Page - 1) * model.MaxResults).Take(model.MaxResults).ToList();
        }
    }
}
