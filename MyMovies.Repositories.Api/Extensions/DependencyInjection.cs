using Microsoft.Extensions.DependencyInjection;
using MyMovies.Entities;
using MyMovies.Repositories.Api.Interfaces;
using MyMovies.Repositories.Interfaces;

namespace MyMovies.Repositories.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiRepository(this IServiceCollection services)
        {
            services.AddTransient<IWatchedRepository, WatchedRepository>();
            services.AddTransient<IToWatchRepository, ToWatchRepository>();
            return services;
        }
    }
}
