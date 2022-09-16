using Microsoft.EntityFrameworkCore;
using MyMovies.Entities;
using MyMovies.Entities.Dto;
using MyMovies.Repositories.Database.Context;
using MyMovies.Repositories.Database.Interfaces;
using System.Linq.Expressions;

namespace MyMovies.Repositories.Database.Abstract
{
    public abstract class Repository<T, TDto> : IDatabaseRepository<T, TDto>
        where T : Movie
        where TDto : IDto
    {
        private readonly SQLiteContext context;
        private readonly DbSet<T> dbSet;

        public Repository(SQLiteContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public T Create(T model)
        {
            var ret = context.Add(model).Entity;
            context.SaveChanges();
            return ret;
        }

        public void Delete(long id)
        {
            var entity = Read(id);
            context.Remove(entity);
            context.SaveChanges();
        }

        public T Patch(T model)
        {
            return Update(model);
        }

        public T Read(long id)
        {
            return Read(entity => entity.Id == id).FirstOrDefault();
        }

        public List<T> Read(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).AsNoTracking().ToList();
        }

        public List<T> ReadAll()
        {
            return dbSet.Select(x => x).AsNoTracking().ToList();
        }

        public abstract List<T> Search(TDto model);

        public T Update(T entity)
        {
            var ret = context.Update(entity).Entity;
            context.SaveChanges();
            return ret;
        }
    }
}
