using Microsoft.AspNetCore.Mvc;
using MyMovies.Entities;
using MyMovies.Entities.Dto;
using MyMovies.Repositories.Database.Interfaces;

namespace MyMovies.Api.Controllers
{

    public class ToWatchController : BaseController<ToWatch, ToWatchSearchDto>
    {
        public ToWatchController(IDatabaseRepository<ToWatch, ToWatchSearchDto> repository) : base(repository)
        {
        }
    }
}
