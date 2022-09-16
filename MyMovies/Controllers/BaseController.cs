using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Api.Filters;
using MyMovies.Entities;
using MyMovies.Entities.Dto;
using MyMovies.Repositories.Database.Interfaces;
using MyMovies.Repositories.Interfaces;

namespace MyMovies.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public abstract class BaseController<T, TDto> : Controller
        where T : Movie
        where TDto : IDto
    {
        private readonly IDatabaseRepository<T, TDto> repository;

        public BaseController(IDatabaseRepository<T, TDto> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public T Get(long id)
        {
            return repository.Read(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("query")]
        public async Task<IActionResult> List([FromBody] TDto entity)
        {
            var ret = repository.Search(entity);

            if(ret == null || ret.Count == 0)
            {
                return NotFound();
            }
            return Ok(ret);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("listAll")]
        public async Task<IActionResult> ListAll()
        {
            var ret = repository.ReadAll();

            if (ret == null || ret.Count == 0)
            {
                return NotFound();
            }
            return Ok(ret);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [CustomActionFilterEndpoint]
        public async Task<IActionResult> Put(long id, T entity)
        {
            //seta a propriedade Id por reflection pois vem vazia e é read-only
            typeof(T).BaseType.GetProperty("Id")?.SetValue(entity, id, null);
            var obj = repository.Update(entity);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [CustomActionFilterEndpoint]
        public async Task<IActionResult> Post(T entity)
        {
            return Ok(repository.Create(entity));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [CustomActionFilterEndpoint]
        public async Task<IActionResult> Delete(long id)
        {
            var obj = repository.Read(id);

            if (obj == null)
            {
                return NotFound();
            }
            repository.Delete(id);
            return Ok();
        }
    }
}
