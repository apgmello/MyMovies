using Microsoft.Extensions.DependencyInjection;
using MyMovies.Entities;
using MyMovies.Repositories.Interfaces;

namespace MyMovies.Repositories.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiRepository(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Watched>, WatchedRepository>();
            services.AddTransient<IRepository<ToWatch>, ToWatchRepository>();
            return services;
        }
    }
}
