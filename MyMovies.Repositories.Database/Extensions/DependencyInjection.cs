using Microsoft.Extensions.DependencyInjection;
using MyMovies.Entities;
using MyMovies.Entities.Dto;
using MyMovies.Repositories.Database.Interfaces;

namespace MyMovies.Repositories.Database.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseRepository(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseRepository<Watched, WatchedSearchDto>, WatchedRepository>();
            services.AddTransient<IDatabaseRepository<ToWatch, ToWatchSearchDto>, ToWatchRepository>();
            return services;
        }
    }
}
