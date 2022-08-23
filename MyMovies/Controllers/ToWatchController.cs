using Microsoft.AspNetCore.Mvc;
using MyMovies.Entities;
using MyMovies.Repositories.Database.Interfaces;

namespace MyMovies.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToWatchController : BaseController<ToWatch>
    {
        public ToWatchController(IDatabaseRepository<ToWatch> repository) : base(repository)
        {
        }
    }
}
