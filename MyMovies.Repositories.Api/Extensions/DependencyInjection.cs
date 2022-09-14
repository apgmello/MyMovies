using Microsoft.Extensions.DependencyInjection;
using MyMovies.Entities;
using MyMovies.Repositories.Api.Interfaces;
using MyMovies.Repositories.Interfaces;

namespace MyMovies.Repositories.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMoviesApiRepositories(this IServiceCollection services)
        {
            services.AddTransient<IWatchedRepository, WatchedRepository>();
            services.AddTransient<IToWatchRepository, ToWatchRepository>();
            return services;
        }

        public static IServiceCollection AddLoginApiRepository(this IServiceCollection services)
        {
            services.AddTransient<LoginRepository>();
            return services;
        }

    }
}
