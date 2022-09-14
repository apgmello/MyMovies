using MyMovies.Entities;

namespace MyMovies.Repositories.Interfaces
{
    public interface IRepository<T>
        where T : Movie
    {
        T Create(T model); 
        T Read(long id);
        List<T> Search(T model);
        List<T> ReadAll();
        T Update(T model);
        T Patch(T model);
        void Delete(long id); 
    }
}
