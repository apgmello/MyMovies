using Microsoft.AspNetCore.Mvc;
using MyMovies.Entities;
using MyMovies.Entities.Dto;
using MyMovies.Repositories.Database.Interfaces;

namespace MyMovies.Api.Controllers
{

    public class WatchedController : BaseController<Watched, WatchedSearchDto>
    {
        public WatchedController(IDatabaseRepository<Watched, WatchedSearchDto> repository) : base(repository)
        {
        }
    }
}
