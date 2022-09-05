using Microsoft.AspNetCore.Mvc;
using MyMovies.Entities;
using MyMovies.Repositories.Database.Interfaces;
using MyMovies.Repositories.Interfaces;

namespace MyMovies.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController<T> : Controller
        where T : Movie
    {
        private readonly IDatabaseRepository<T> repository;

        public BaseController(IDatabaseRepository<T> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public T Get(long id)
        {
            return repository.Read(id);
        }

        [HttpGet]
        [Route("search")]
        public IEnumerable<T> List(string title)
        {
            return repository.Search(title);
        }

        [HttpGet]
        [Route("listAll")]
        public IEnumerable<T> ListAll()
        {
            return repository.ReadAll();
        }

        [HttpPut]
        public T Put(long id, T entity)
        {
            //seta a propriedade Id por reflection pois vem vazia e é read-only
            typeof(T).BaseType.GetProperty("Id")?.SetValue(entity, id, null);
            return repository.Update(entity);
        }

        [HttpPost]
        public T Post(T entity)
        {
            return repository.Create(entity);
        }

        [HttpDelete]
        public void Delete(long id)
        {
            repository.Delete(id);
        }
    }
}
