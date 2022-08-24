using MyMovies.Entities;

namespace MyMovies.Repositories.Interfaces
{
    public interface IRepository<T>
        where T : Movie
    {
        T Create(T model); 
        T Read(long id);
        List<T> Search(string title);
        List<T> ReadAll();
        T Update(T model);
        void Delete(long id); 
    }
}
