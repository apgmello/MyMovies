using Microsoft.AspNetCore.Mvc;
using MyMovies.Entities;
using MyMovies.Repositories.Database.Interfaces;

namespace MyMovies.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WatchedController : BaseController<Watched>
    {
        public WatchedController(IDatabaseRepository<Watched> repository) : base(repository)
        {
        }
    }
}
